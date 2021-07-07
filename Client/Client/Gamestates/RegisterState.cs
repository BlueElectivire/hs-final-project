using System;
using System.Collections.Generic;
using System.Text;
using Myra.Graphics2D.UI;
using Service;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Client.Gamestates
{
    public class RegisterState : GameState
    {
        GameServiceClient srvc;

        public RegisterState(GraphicsDevice graphicsDevice) : base(graphicsDevice)
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
                Text = "Register"
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
            grid.Widgets.Add(new Label
            {
                GridColumn = 0,
                GridRow = 3,
                Text = "Mail:"
            });
            TextBox mail = new TextBox
            {
                GridColumn = 1,
                GridRow = 3
            };
            TextButton submit = new TextButton
            {
                GridColumn = 0,
                GridRow = 4,
                Text = "Submit"
            };

            submit.Click += (s, a) =>
            {
                User u = new User
                {
                    Username = username.Text,
                    Password = password.Text,
                    Mail = mail.Text,
                    IsAdmin = false
                };
                srvc.InsertUserAsync(u);
                if (srvc.SaveChangesAsync().Result == 1)
                    GameStateManager.Instance.AddScreen(new MainState(graphicsDevice, u));
                else
                {
                    Dialog messgaeBox = Dialog.CreateMessageBox("Error", "An Error has occured, please try again.");
                    messgaeBox.ShowModal(desktop);
                }
            };

            grid.Widgets.Add(username);
            grid.Widgets.Add(password);
            grid.Widgets.Add(mail);
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
