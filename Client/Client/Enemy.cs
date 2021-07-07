using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Client
{
    public class Enemy : Creature
    {

        public Enemy(ContentManager content, Tile tile, int maxHealth, int attackDamage, int armor, int attackRange, bool isStunned, bool isAlive, int level)
            : base(content, tile, maxHealth, attackDamage, armor, attackRange, isStunned, level, isAlive)
        {
            Texture = Content.Load<Texture2D>("Assets/enemyDown0");
        }

        public Enemy(ContentManager content, Tile tile, int level)
            : this(content, tile, (level - 1) * 5 + 20, (level - 1) * 5 + 5, (level - 1) * 3 + 3, 1, false, true, level)
        {
        }
        public override void Update(GameTime gameTime, List<GameEntity> gameEntities)
        {
            base.Update(gameTime, gameEntities);
            if (!IsStunned)
            {
                Hero hero = (Hero)gameEntities.Find(item => item is Hero);
                Random r = new Random();
                if (IsInRange(hero) && Tick < 0)
                {
                    Tick = 0;
                }
                if (Tick >= 0)
                    Attack(new List<Creature>() { hero });
                else
                {
                    if (CanMove)
                    {
                        List<Tile> tiles = gameEntities.FindAll(item => item is Tile).Cast<Tile>().ToList();
                        Tile dest;
                        Direction old = Facing;
                        switch (r.Next(4))
                        {
                            case 0:
                                dest = tiles.Find(item => item.Position.X == Tile.Position.X && item.Position.Y == Tile.Position.Y - 1);
                                if (dest != null && dest.Type == Tile.TileType.Floor)
                                {
                                    Tile = dest;
                                    Facing = Direction.Up;
                                    TextureChange(old);
                                    CanMove = false;
                                }
                                break;
                            case 1:
                                dest = tiles.Find(item => item.Position.X == Tile.Position.X && item.Position.Y == Tile.Position.Y + 1);
                                if (dest != null && dest.Type == Tile.TileType.Floor)
                                {
                                    Tile = dest;
                                    Facing = Direction.Down;
                                    TextureChange(old);
                                    CanMove = false;
                                }
                                break;
                            case 2:
                                dest = tiles.Find(item => item.Position.X == Tile.Position.X - 1 && item.Position.Y == Tile.Position.Y);
                                if (dest != null && dest.Type == Tile.TileType.Floor)
                                {
                                    Tile = dest;
                                    Facing = Direction.Left;
                                    TextureChange(old);
                                    CanMove = false;
                                }
                                break;
                            case 3:
                                dest = tiles.Find(item => item.Position.X == Tile.Position.X + 1 && item.Position.Y == Tile.Position.Y);
                                if (dest != null && dest.Type == Tile.TileType.Floor)
                                {
                                    Tile = dest;
                                    Facing = Direction.Right;
                                    TextureChange(old);
                                    CanMove = false;
                                }
                                break;
                        }
                    }
                }
            }
        }
        public bool IsInRange(Creature c)
        {
            return Facing switch
            {
                Direction.Up => c.Tile.Position.Y == Tile.Position.Y - 1 && c.Tile.Position.X == Tile.Position.X,
                Direction.Down => c.Tile.Position.Y == Tile.Position.Y + 1 && c.Tile.Position.X == Tile.Position.X,
                Direction.Left => c.Tile.Position.Y == Tile.Position.Y && c.Tile.Position.X == Tile.Position.X - 1,
                _ => c.Tile.Position.Y == Tile.Position.Y && c.Tile.Position.X == Tile.Position.X + 1,
            } || c.Tile.Equals(Tile);
        }
        public override void Attack(List<Creature> creatures)
        {
            Tick++;
            if (Tick == 5)
            {
                if (IsInRange(creatures[0]))
                    creatures[0].TakeDamage(AttackDamage);
                Tick = -1;
            }
        }
        public void Reuse(Tile tile, int level)
        {
            Tile = tile;
            Level = level;
            MaxHealth = (level - 1) * 5 + 20;
            AttackDamage = (level - 1) * 5 + 5;
            Armor = (level - 1) * 3 + 3;
            IsAlive = true;
        }
        public void TextureChange(Direction old)
        {
            string texture = "Assets/enemy";
            texture += Facing switch
            {
                Direction.Up => "Up",
                Direction.Down => "Down",
                _ => "Left"
            };
            if (old != Facing || cycle == 3)
                cycle = -1;
            cycle++;
            texture += cycle;
            Texture = Content.Load<Texture2D>(texture);
        }
    }
}
