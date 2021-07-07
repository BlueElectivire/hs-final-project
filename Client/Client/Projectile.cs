using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Timers;

namespace Client
{
    public class Projectile : GameEntity
    {
        private float velocity;
        private Direction facing;
        private bool isGood;
        private int damage;
        private int pen;
        private bool isBeingUsed;
        private Tile tile;
        readonly private Timer timer;
        private bool canMove;

        public Projectile(ContentManager content, float velocity, bool isGood)
            : base(content, Vector2.Zero)
        {
            
            this.velocity = velocity;
            facing = Direction.Up;
            this.isGood = isGood;
            damage = 0;
            pen = 0;
            isBeingUsed = false;
            canMove = true;
            timer = new Timer(100)
            {
                AutoReset = true,
                Enabled = true
            };
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            canMove = true;
        }

        public float Velocity
        {
            get
            {
                return velocity;
            }
            set
            {
                velocity = value;
            }
        }
        public Direction Facing 
        {
            get
            {
                return facing;
            }
            set
            {
                facing = value;
            }
        }
        public bool IsGood 
        {
            get
            {
                return isGood;
            }
            set
            {
                isGood = value;
            }
        }
        public int Damage
        {
            get
            {
                return damage;
            }
            set
            {
                damage = value;
            }
        }
        public bool IsBeingUsed
        {
            get
            {
                return isBeingUsed;
            }
        }
        public Tile Tile
        {
            get
            {
                return tile;
            }
        }

        public void Use(Tile tile, string textureName, int damage, Direction facing, int pen)
        {
            Texture = Content.Load<Texture2D>(textureName);
            this.tile = tile;
            this.damage = damage;
            this.pen = pen;
            this.facing = facing;
            isBeingUsed = true;
        }

        public override void Update(GameTime gameTime, List<GameEntity> gameEntities)
        {
            if (isBeingUsed)
            {
                foreach (Enemy e in gameEntities.FindAll(item => item is Enemy))
                    if (tile.Equals(e.Tile))
                    {
                        if (e.TakeDamage(Damage, pen))
                        {
                            int bonus = e.Level * 5;

                            Hero h = (Hero)gameEntities.Find(item => item is Hero);
                            
                            h.Exp += bonus;
                            h.Gold += bonus;
                            h.Score += bonus;
                        }
                        isBeingUsed = false;
                    }

                if (canMove)
                {
                    List<Tile> tiles = gameEntities.FindAll(item => item is Tile).Cast<Tile>().ToList();

                    tile = Facing switch
                    {
                        Direction.Up => tiles.Find(item => item.Position.X == tile.Position.X && item.Position.Y == tile.Position.Y - 1),
                        Direction.Down => tiles.Find(item => item.Position.X == tile.Position.X && item.Position.Y == tile.Position.Y + 1),
                        Direction.Left => tiles.Find(item => item.Position.X == tile.Position.X - 1 && item.Position.Y == tile.Position.Y),
                        _ => tiles.Find(item => item.Position.X == tile.Position.X + 1 && item.Position.Y == tile.Position.Y)
                    };

                    canMove = false;
                }


                if (tile.Type == Tile.TileType.Wall || tile.Type == Tile.TileType.Obstacle)
                    isBeingUsed = false;
            }
        }
    }
}
