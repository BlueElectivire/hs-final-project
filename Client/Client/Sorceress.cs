using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Client.Gamestates;

namespace Client
{
    public class Sorceress : Hero
    {
        private readonly Projectile[] projectiles;
        public Sorceress(ContentManager content, Tile tile, int maxHealth, int attackDamage, int armor, int attackRange)
            : base(content, tile, maxHealth, attackDamage, armor, attackRange)
        {
            Texture = Content.Load<Texture2D>("Assets/sorceressWalkDown0");
            projectiles = new Projectile[5];
            for (int i = 0; i < projectiles.Length; i++)
                projectiles[i] = new Projectile(content, 2f, true);
        }

        public override void Attack(List<Creature> creatures)
        {
            Tick++;
            if (Tick == 5) //number is animation length
            {
                bool fired = false;
                Random r = new Random();
                foreach (Projectile p in projectiles)
                    if (!fired && !p.IsBeingUsed)
                    {
                        if (Inventory.Locket != null && Inventory.Locket.Statboost == Locket.Stat.Pen)
                            p.Use(Tile, "Assets/projectile0", AttackDamage + Inventory.Items[0].Rank + 2 *Inventory.Items[1].Rank, Facing, Level);
                        else if (Inventory.Locket != null && Inventory.Locket.Statboost == Locket.Stat.Crit && r.Next(4) == 1)
                            p.Use(Tile, "Assets/projectile0", 2 * (AttackDamage + Inventory.Items[0].Rank + 2 * Inventory.Items[1].Rank), Facing, 0);
                        else
                            p.Use(Tile, "Assets/projectile0", AttackDamage + Inventory.Items[0].Rank + 2 * Inventory.Items[1].Rank, Facing, 0);
                        fired = true;
                    }
                Tick = -1;
            }
        }

        public override bool TakeDamage(int damage)
        {
            CurrentHealth -= damage - (Armor + Inventory.Items[2].Rank + Inventory.Items[3].Rank);
            if (CurrentHealth <= 0)
            {
                Die();
                return true;
            }
            return false;
        }

        public override void LevelUp()
        {
            //stat upgrades
            MaxHealth += 2;
            CurrentHealth += 2;
            AttackDamage += 5;

            //level change
            Exp -= Level * 10;
            Level++;
        }
        public override void TextureChange(int max, Direction old, int action)
        {
            string texture = "Assets/sorceressWalk";
            texture += Facing switch
            {
                Direction.Up => "Up",
                Direction.Down => "Down",
                _ => "Left"
            };
            if (old != Facing || cycle >= max)
                cycle = -1;
            cycle++;
            texture += cycle;
            Texture = Content.Load<Texture2D>(texture);
        }

        public override void Update(GameTime gameTime, List<GameEntity> gameEntities)
        {
            base.Update(gameTime, gameEntities);
            foreach (Projectile p in projectiles)
                if (p.IsBeingUsed)
                    p.Update(gameTime, gameEntities);
        }
        public override void Draw(SpriteBatch spriteBatch, Vector2 drawPosition)
        {
            base.Draw(spriteBatch, drawPosition);
            foreach (Projectile p in projectiles)
                if (p.IsBeingUsed)
                    p.Draw(spriteBatch, new Vector2((float)((p.Tile.Position.X - Position.X) * Tile.Texture.Width + (GameStateManager.Instance.Graphics.PreferredBackBufferWidth / 2)), (float)((p.Tile.Position.Y - Position.Y) * Tile.Texture.Height + (GameStateManager.Instance.Graphics.PreferredBackBufferHeight / 2))));
        }
    }
}
