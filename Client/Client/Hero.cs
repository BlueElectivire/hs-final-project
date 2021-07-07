using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Client
{
    public abstract class Hero : Creature
    {
        private int exp;
        private int gold;
        private int score;
        private Inventory inventory;
        public bool action;
        public Hero(ContentManager content, Tile tile, int maxHealth, int attackDamage, int armor, int attackRange) 
            : base(content, tile, maxHealth, attackDamage, armor, attackRange, false, 1, true)
        {
            Texture = Content.Load<Texture2D>("Assets/warriorWalkDown0");
            exp = 0;
            gold = 100;
            score = 0;
            inventory = new Inventory();
            action = false;
        }

        public int Exp
        {
            get
            {
                return exp;
            }
            set
            {
                exp = value;
            }
        }
        public int Gold
        {
            get
            {
                return gold;
            }
            set
            {
                gold = value;
            }
        }
        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
            }
        }
        public Inventory Inventory
        {
            get
            {
                return inventory;
            }
            set
            {
                inventory = value;
            }
        }

        public override void Update(GameTime gameTime, List<GameEntity> gameEntities) 
        {
            if (Tick < 0)
                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                    Tick = 0;
                else if (Keyboard.GetState().IsKeyDown(Keys.T))
                    action = true;
            if (Tick >= 0) 
            {
                Attack(gameEntities.FindAll(item => item is Creature).Cast<Creature>().ToList());
                if (!(this is Sorceress) && !(this is Vampire))
                    TextureChange(4, Facing, 1);
            }


            else
            {
                //Position updating
                if (CanMove)
                {
                    List<Tile> tiles = gameEntities.FindAll(item => item is Tile).Cast<Tile>().ToList();
                    Direction old = Facing;

                    if (Keyboard.GetState().IsKeyDown(Keys.W))
                    {
                        Tile dest = tiles.Find(item => item.Position.X == Tile.Position.X && item.Position.Y == Tile.Position.Y - 1);
                        if (dest != null && dest.Type == Tile.TileType.Floor)
                        {
                            Tile = dest;
                            Facing = Direction.Up;
                            TextureChange(5, old, 0);
                            CanMove = false;
                        }
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.S))
                    {
                        Tile dest = tiles.Find(item => item.Position.X == Tile.Position.X && item.Position.Y == Tile.Position.Y + 1);
                        if (dest != null && dest.Type == Tile.TileType.Floor)
                        {
                            Tile = dest;
                            Facing = Direction.Down;
                            TextureChange(5, old, 0);
                            CanMove = false;
                        }
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.A))
                    {
                        Tile dest = tiles.Find(item => item.Position.X == Tile.Position.X - 1 && item.Position.Y == Tile.Position.Y);
                        if (dest != null && dest.Type == Tile.TileType.Floor)
                        {
                            Tile = dest;
                            Facing = Direction.Left;
                            TextureChange(5, old, 0);
                            CanMove = false;
                        }
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.D))
                    {
                        Tile dest = tiles.Find(item => item.Position.X == Tile.Position.X + 1 && item.Position.Y == Tile.Position.Y);
                        if (dest != null && dest.Type == Tile.TileType.Floor)
                        {
                            Tile = dest;
                            Facing = Direction.Right;
                            TextureChange(5, old, 0);
                            CanMove = false;
                        }
                    }
                }
            }


            //Level updating
            if (exp >= Level * 50)
            {
                LevelUp();
            }

            if (inventory.Locket != null && inventory.Locket.Statboost == Locket.Stat.Healboost)
            {
                Heal(5);
            }
        }
        public abstract void LevelUp();
        public bool IsInRange(Creature creature, int i)
        {
            return Facing switch
            {
                Direction.Up => (Tile.Position.X - creature.Tile.Position.X == i && Tile.Position.Y == creature.Tile.Position.Y),
                Direction.Down => (creature.Tile.Position.X - Tile.Position.X == i && Tile.Position.Y == creature.Tile.Position.Y),
                Direction.Left => (creature.Tile.Position.X == Tile.Position.X && Tile.Position.Y - creature.Tile.Position.Y == i),
                Direction.Right => (creature.Tile.Position.X == Tile.Position.X && creature.Tile.Position.Y - Tile.Position.Y == i),
                _ => false,
            };
        }

        public void DrawUI(SpriteBatch spriteBatch, GraphicsDeviceManager graphics)
        {
            int hp = 100 * CurrentHealth / MaxHealth;
            string hpTexture;

            if (hp <= 25)
                hpTexture = "Assets/health3";
            else if (hp <= 50)
                hpTexture = "Assets/health2";
            else if (hp <= 75)
                hpTexture = "Assets/health1";
            else
                hpTexture = "Assets/health0";

            spriteBatch.Draw
            (
                Content.Load<Texture2D>(hpTexture),
                Vector2.Zero,
                null,
                Color.White,
                0f,
                Vector2.Zero,
                2f,
                SpriteEffects.None,
                0f
            );

            inventory.DrawInventory(spriteBatch, graphics, Content);

            SpriteFont font = Content.Load<SpriteFont>("font");

            string l = "Level: " + Level;

            spriteBatch.DrawString
            (
                font,
                l,
                new Vector2(0, graphics.PreferredBackBufferHeight),
                Color.White,
                0f,
                new Vector2(0, font.MeasureString(l).Y),
                Vector2.One,
                SpriteEffects.None,
                0f
            );

            string e = "Exp: " + exp + "/" + Level * 50;

            spriteBatch.DrawString
            (
                font,
                e,
                new Vector2(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight),
                Color.White,
                0f,
                new Vector2(font.MeasureString(e).X / 2, font.MeasureString(e).Y),
                Vector2.One,
                SpriteEffects.None,
                0f
            );

            string g = "Gold: " + gold;

            spriteBatch.DrawString
            (
                font,
                g,
                new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight),
                Color.White,
                0f,
                new Vector2(font.MeasureString(g).X, font.MeasureString(g).Y),
                Vector2.One,
                SpriteEffects.None,
                0f
            );
        }
        public abstract void TextureChange(int max, Direction old, int action);
    }
}
