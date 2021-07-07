using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Client
{
    public abstract class GameEntity
    {
        private ContentManager content;
        private Texture2D texture;
        private Vector2 position;

        public GameEntity(ContentManager content, Vector2 position)
        {
            this.content = content;
            this.position = new Vector2(position.X, position.Y);
        }

        public ContentManager Content
        {
            get
            {
                return content;
            }
            set
            {
                content = value;
            }
        }
        public Texture2D Texture
        {
            get
            {
                return texture;
            }
            set
            {
                texture = value;
            }
        }

        public Vector2 Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        public abstract void Update(GameTime gameTime, List<GameEntity> gameEntities);
        public virtual void Draw(SpriteBatch spriteBatch, Vector2 drawPosition)
        {
            spriteBatch.Draw(
                texture,
                drawPosition,
                null,
                Color.White,
                0f,
                new Vector2(texture.Width / 2, texture.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f
            );
        }
        public virtual void Draw(SpriteBatch spriteBatch, Vector2 drawPosition, SpriteEffects spriteEffects)
        {
            spriteBatch.Draw(
                texture,
                drawPosition,
                null,
                Color.White,
                0f,
                new Vector2(texture.Width / 2, texture.Height / 2),
                Vector2.One,
                spriteEffects,
                0f
            );
        }

        public enum Direction
        {
            Up, Down, Left, Right
        }
    }
}
