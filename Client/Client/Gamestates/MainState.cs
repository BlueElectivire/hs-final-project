using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Myra.Graphics2D.UI;
using Service;

namespace Client.Gamestates
{
    public class MainState : GameState
    {
        public User user;
        public MainState(GraphicsDevice graphicsDevice, User user) : base(graphicsDevice)
        {
            this.user = user;
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
            grid.RowsProportions.Add(new Proportion(ProportionType.Auto));

            Label label = new Label
            {
                GridColumn = 0,
                GridRow = 0,
                Text = "GAME"
            };
            TextButton newGame = new TextButton
            {
                GridRow = 1,
                Text = "New Game"
            };
            TextButton lb = new TextButton
            {
                GridRow = 2,
                Text = "Leaderboard"
            };

            newGame.Click += (s, a) =>
            {
                GameStateManager.Instance.AddScreen(new NewGameState(graphicsDevice, user));
            };
            lb.Click += (s, a) =>
            {
                GameStateManager.Instance.AddScreen(new LeaderBoardState(graphicsDevice));
            };

            grid.Widgets.Add(label);
            grid.Widgets.Add(newGame);
            grid.Widgets.Add(lb);

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
