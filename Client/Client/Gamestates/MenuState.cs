using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Myra;
using Myra.Graphics2D.UI;

namespace Client.Gamestates
{
    public class MenuState : GameState
    {
        public MenuState(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
        }
        
        public override void Initialize()
        {
        }

        public override void LoadContent(ContentManager content)
        {
            Grid grid = new Grid
            {
                RowSpacing = 8,
                ColumnSpacing = 8
            };

            grid.ColumnsProportions.Add(new Proportion(ProportionType.Auto));
            grid.RowsProportions.Add(new Proportion(ProportionType.Auto));
            grid.RowsProportions.Add(new Proportion(ProportionType.Auto));

            TextButton login = new TextButton
            {
                GridColumn = 0,
                GridRow = 0,
                Text = "Login"
            };
            TextButton register = new TextButton
            {
                GridColumn = 0,
                GridRow = 1,
                Text = "Register"
            };

            login.Click += (s, a) =>
            {
                GameStateManager.Instance.AddScreen(new LoginState(graphicsDevice));
            };
            register.Click += (s, a) =>
            {
                GameStateManager.Instance.AddScreen(new RegisterState(graphicsDevice));
            };

            grid.Widgets.Add(login);
            grid.Widgets.Add(register);


            desktop = new Desktop
            {
                Root = grid
            };
        }

        public override void UnloadContent()
        {
        }

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            graphicsDevice.Clear(Color.Black);
            desktop.Render();
        }
    }
}
