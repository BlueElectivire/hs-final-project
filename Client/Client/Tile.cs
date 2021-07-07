using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Client
{
    public class Tile : GameEntity
    {
        private TileType type;
        public Tile(ContentManager content, Vector2 position, TileType type) : base(content,  position)
        {
            this.type = type;
            Texture = Content.Load<Texture2D>(type switch { TileType.Floor => "Assets/floor", TileType.Wall => "Assets/wall", _ => "Assets/chest0" });
        }

        public TileType Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        public override void Update(GameTime gameTime, List<GameEntity> gameEntities)
        {
        }


        public enum TileType
        {
            Floor, Obstacle, Wall
        }
    }
}
