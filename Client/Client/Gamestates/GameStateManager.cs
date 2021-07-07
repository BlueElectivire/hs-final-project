using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Client.Gamestates
{
    public class GameStateManager
    {   
        private static GameStateManager instance;
    
        private readonly Stack<GameState> screens = new Stack<GameState>();
        private ContentManager content;
        private GraphicsDeviceManager graphics;

        public static GameStateManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new GameStateManager();

                return instance;
            }
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
        public GraphicsDeviceManager Graphics
        {
            get
            {
                return graphics;
            }
            set
            {
                graphics = value;
            }
        }

        public void AddScreen(GameState screen)
        {
            screens.Push(screen);
            screens.Peek().Initialize();
            if (content != null)
                screens.Peek().LoadContent(content);
        }

        public void RemoveScreen()
        {
            if (screens.Count > 0)
                screens.Pop();
        }

        public bool Removable()
        {
            return screens.Count > 1;
        }

        public void ClearScreens()
        {
            while (screens.Count > 0)
                screens.Pop();
        }

        public void ChangeScreens(GameState screen)
        {
            ClearScreens();
            AddScreen(screen);
        }

        public void Update(GameTime gameTime)
        {
            if (screens.Count > 0)
                screens.Peek().Update(gameTime);
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (screens.Count > 0)
                screens.Peek().Draw(gameTime, spriteBatch);
        }
        public void UnloadContent()
        {
            foreach (GameState gs in screens)
                gs.UnloadContent();
        }
    }
}
