using Client.Gamestates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Myra;
using Myra.Graphics2D.UI;

namespace Client
{
    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private bool escKeyLift;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            escKeyLift = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        protected override void LoadContent()
        {
            MyraEnvironment.Game = this;
            spriteBatch = new SpriteBatch(GraphicsDevice);
            GameStateManager.Instance.Content = Content;
            GameStateManager.Instance.Graphics = graphics;

            GameStateManager.Instance.AddScreen(new MenuState(GraphicsDevice));
            // TODO: use this.Content to load your game content here
        }
        protected override void UnloadContent()
        {
            GameStateManager.Instance.UnloadContent();
            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape) && escKeyLift )
            {
                if (GameStateManager.Instance.Removable())
                    GameStateManager.Instance.RemoveScreen();
                else
                    Exit();
                escKeyLift = false;
            }
            escKeyLift = Keyboard.GetState().IsKeyUp(Keys.Escape);

            GameStateManager.Instance.Update(gameTime);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // TODO: Add your drawing code here

            GameStateManager.Instance.Draw(gameTime, spriteBatch);
            base.Draw(gameTime);
        }
    }
}
