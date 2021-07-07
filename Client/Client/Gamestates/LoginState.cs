using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Myra.Graphics2D.UI;
using Service;

namespace Client.Gamestates
{
    public class LoginState : GameState
    {
        GameServiceClient srvc;
        
        public LoginState(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
        }

        public override void Initialize()
        {
            srvc = new GameServiceClient();
        }

        public override void LoadContent(ContentManager content)
        {
            Grid grid = new Grid
            {
                RowSpacing = 10,
                ColumnSpacing = 10
            };

            grid.ColumnsProportions.Add(new Proportion(ProportionType.Auto));
            grid.ColumnsProportions.Add(new Proportion(ProportionType.Pixels, 150));
            grid.RowsProportions.Add(new Proportion(ProportionType.Auto));
            grid.RowsProportions.Add(new Proportion(ProportionType.Auto));
            grid.RowsProportions.Add(new Proportion(ProportionType.Auto));
            grid.RowsProportions.Add(new Proportion(ProportionType.Auto));

            grid.Widgets.Add(new Label
            {
                GridColumn = 0,
                GridRow = 0,
                Text = "Login"
            });
            grid.Widgets.Add(new Label
            {
                GridColumn = 0,
                GridRow = 1,
                Text = "Username:"
            });
            TextBox username = new TextBox
            {
                GridColumn = 1,
                GridRow = 1
            };
            grid.Widgets.Add(new Label
            {
                GridColumn = 0,
                GridRow = 2,
                Text = "Password:"
            });
            TextBox password = new TextBox
            {
                GridColumn = 1,
                GridRow = 2,
                PasswordField = true
            };
            TextButton submit = new TextButton
            {
                GridColumn = 0,
                GridRow = 3,
                Text = "Submit"
            };

            submit.Click += (s, a) =>
            {
                User u = srvc.GetUserByUsernameAsync(username.Text).Result;
                if (u != null && password.Text == u.Password)
                    GameStateManager.Instance.AddScreen(new MainState(graphicsDevice, u));
                else
                {
                    Dialog messgaeBox = Dialog.CreateMessageBox("Error", "Username or password incorrect");
                    messgaeBox.ShowModal(desktop);
                }
            };

            grid.Widgets.Add(username);
            grid.Widgets.Add(password);
            grid.Widgets.Add(submit);

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
