using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Service;

namespace Client.Gamestates
{
    public class PlayState : GameState
    {
        int level;
        List<GameEntity> entities;
        Map map;
        Enemy[] enemies;
        Hero hero;
        readonly GameServiceClient srvc;
        readonly User user;
        readonly HeroType type;
        Shop shop;

        public Hero Hero
        {
            get
            {
                return hero;
            }
            set
            {
                hero = value;
            }
        }

        public void NewLevel()
        {
            level++;
            entities = new List<GameEntity>();

            map = new Map(GameStateManager.Instance.Content, level);
            foreach (Tile t in map.Tiles)
                entities.Add(t);

            if (hero == null)
                hero = type switch
                {
                    HeroType.Rogue => new Rogue(GameStateManager.Instance.Content, map.SpawnPoint, 35, 20, 2, 1),
                    HeroType.Warrior => new Warrior(GameStateManager.Instance.Content, map.SpawnPoint, 50, 15, 2, 1),
                    HeroType.Sorceress => new Sorceress(GameStateManager.Instance.Content, map.SpawnPoint, 35, 10, 2, 5),
                    _ => new Vampire(GameStateManager.Instance.Content, map.SpawnPoint, 35, 10, 2, 3)
                };
            else
            {
                hero.Tile = map.SpawnPoint;
                hero.Score += 50;
            }
            entities.Add(hero);

            if (enemies == null)
                enemies = new Enemy[map.EnemySpawnPoints.Length];

            for (int i = 0; i < map.EnemySpawnPoints.Length; i++)
            {
                if (enemies[i] == null)
                    enemies[i] = new Enemy(GameStateManager.Instance.Content, map.EnemySpawnPoints[i], level);
                else
                    enemies[i].Reuse(map.EnemySpawnPoints[i], level);
                entities.Add(enemies[i]);
            }
        }

        public PlayState(GraphicsDevice graphicsDevice, User user, HeroType heroType) : base(graphicsDevice)
        {
            this.user = user;
            type = heroType;
            srvc = new GameServiceClient();
        }
        public override void Initialize()
        {
            NewLevel();
            shop = null;
        }

        public override void LoadContent(ContentManager content)
        {
        }

        public override void UnloadContent()
        {
        }

        public override void Update(GameTime gameTime)
        {
            if (shop == null)
            {
                bool allDead = true;
                foreach (Enemy e in enemies)
                    allDead = allDead && !e.IsAlive;
                if (hero.Tile.Equals(map.Exit) && allDead)
                    NewLevel();
                else if (!hero.IsAlive)
                {
                    Score s = new Score()
                    {
                        User = user,
                        Role = srvc.GetRoleByTypeAsync(type switch
                        {
                            HeroType.Rogue => "Rogue",
                            HeroType.Warrior => "Warrior",
                            HeroType.Sorceress => "Sorceress",
                            _ => "Vampire"
                        }).Result,
                        Level = level,
                        Points = Hero.Score
                    };
                    if (srvc.InsertScoreAsync(s).Result)
                        srvc.SaveChangesAsync();
                    GameStateManager.Instance.ChangeScreens(new MainState(graphicsDevice, user));
                }
                else if (hero.action)
                {
                    int x = 0;
                    int y = 0;
                    switch (hero.Facing)
                    {
                        case GameEntity.Direction.Up:
                            y = -1;
                            break;
                        case GameEntity.Direction.Down:
                            y = 1;
                            break;
                        case GameEntity.Direction.Left:
                            x = -1;
                            break;
                        case GameEntity.Direction.Right:
                            x = 1;
                            break;
                    }
                    Vector2 v = new Vector2(hero.Position.X + x, hero.Position.Y + y);
                    foreach (Tile t in entities.FindAll(item => item is Tile).FindAll(item => Math.Abs(item.Position.X - v.X) <= 1 && Math.Abs(item.Position.Y - v.Y) <= 1))
                        if (t is Shop s)
                            shop = s;
                        else if (t is Chest c)
                            hero.Inventory.UpdateItem(c.GenerateLoot(level));
                    hero.action = false;
                }
                else
                {
                    foreach (Enemy e in enemies)
                        if (e.IsAlive)
                            e.Update(gameTime, entities);
                    hero.Update(gameTime, entities);
                }
            }
            else
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Z))
                    shop = null;
                else if (Keyboard.GetState().IsKeyDown(Keys.Y))
                    shop.BuyHeal(Hero);
                else if (Keyboard.GetState().IsKeyDown(Keys.U))
                    shop.BuyItem(Hero);
                else if (Keyboard.GetState().IsKeyDown(Keys.I))
                    shop.BuyLocket(Hero);
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            graphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            double tileWidth = GameStateManager.Instance.Content.Load<Texture2D>("Assets/floor").Width;
            double tileHeight = GameStateManager.Instance.Content.Load<Texture2D>("Assets/floor").Height;

            double tileAmountWide = GameStateManager.Instance.Graphics.PreferredBackBufferWidth / tileWidth;
            double tileAmountTall = GameStateManager.Instance.Graphics.PreferredBackBufferHeight / tileHeight;

            foreach (Tile t in entities.FindAll(item => item is Tile))
                if (Math.Abs(t.Position.X - hero.Position.X) <= tileAmountWide / 2 && Math.Abs(t.Position.Y - hero.Position.Y) <= tileAmountTall / 2)
                    t.Draw(spriteBatch, new Vector2((float)((t.Position.X - hero.Position.X) * tileWidth + (GameStateManager.Instance.Graphics.PreferredBackBufferWidth / 2)), (float)((t.Position.Y - hero.Position.Y) * tileHeight + (GameStateManager.Instance.Graphics.PreferredBackBufferHeight / 2))));
            foreach (Creature c in entities.FindAll(item => item is Creature))
                if (Math.Abs(c.Position.X - hero.Position.X) <= tileAmountWide / 2 && Math.Abs(c.Position.Y - hero.Position.Y) <= tileAmountTall / 2 && c.IsAlive)
                    c.Draw(spriteBatch, new Vector2((float)((c.Position.X - hero.Position.X) * tileWidth + (GameStateManager.Instance.Graphics.PreferredBackBufferWidth / 2)), (float)((c.Position.Y - hero.Position.Y) * tileHeight + (GameStateManager.Instance.Graphics.PreferredBackBufferHeight / 2))));
            foreach (Projectile p in entities.FindAll(item => item is Projectile))
                if (Math.Abs(p.Position.X - hero.Position.X) <= tileAmountWide / 2 && Math.Abs(p.Position.Y - hero.Position.Y) <= tileAmountTall / 2 && p.IsBeingUsed)
                    p.Draw(spriteBatch, new Vector2((float)((p.Position.X - hero.Position.X) * tileWidth + (GameStateManager.Instance.Graphics.PreferredBackBufferWidth / 2)), (float)((p.Position.Y - hero.Position.Y) * tileHeight + (GameStateManager.Instance.Graphics.PreferredBackBufferHeight / 2))));

            if (shop != null)
            {
                shop.DrawShop(spriteBatch, GameStateManager.Instance.Graphics, GameStateManager.Instance.Content, hero);
            }
            else
                hero.DrawUI(spriteBatch, GameStateManager.Instance.Graphics);

            spriteBatch.End();
        }

        public enum HeroType
        {
            Warrior, Rogue, Sorceress, Vampire
        }
    }
}
