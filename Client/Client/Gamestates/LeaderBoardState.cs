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
    public class LeaderBoardState : GameState
    {
        private GameServiceClient srvc;
        public LeaderBoardState(GraphicsDevice graphicsDevice) : base(graphicsDevice)
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
                ColumnSpacing = 8,
                RowSpacing = 8
            };

            grid.ColumnsProportions.Add(new Proportion(ProportionType.Auto));
            grid.RowsProportions.Add(new Proportion(ProportionType.Auto));
            grid.RowsProportions.Add(new Proportion(ProportionType.Auto));

            grid.Widgets.Add(new Label
            {
                GridColumn = 0,
                GridRow = 0,
                Text = "Leaderboard"
            });

            ScrollViewer scrollViewer = new ScrollViewer()
            {
                GridColumn = 0,
                GridRow = 1,
                ClipToBounds = false,
                HorizontalAlignment = HorizontalAlignment.Right
            };

            grid.Widgets.Add(scrollViewer);

            Grid scoreTable = new Grid
            {
                ColumnSpacing = 10,
                RowSpacing = 8,
                ShowGridLines = true
            };

            scrollViewer.Content = scoreTable;

            scoreTable.ColumnsProportions.Add(new Proportion(ProportionType.Auto));
            scoreTable.ColumnsProportions.Add(new Proportion(ProportionType.Auto));
            scoreTable.ColumnsProportions.Add(new Proportion(ProportionType.Auto));
            scoreTable.ColumnsProportions.Add(new Proportion(ProportionType.Auto));
            scoreTable.ColumnsProportions.Add(new Proportion(ProportionType.Auto));
            scoreTable.ColumnsProportions.Add(new Proportion(ProportionType.Pixels, 15));
            scoreTable.RowsProportions.Add(new Proportion(ProportionType.Auto));

            scoreTable.Widgets.Add(new Label
            {
                GridColumn = 0,
                GridRow = 0,
                Text = "Game ID"
            });
            scoreTable.Widgets.Add(new Label
            {
                GridColumn = 1,
                GridRow = 0,
                Text = "Player"
            });
            scoreTable.Widgets.Add(new Label
            {
                GridColumn = 2,
                GridRow = 0,
                Text = "Role"
            });
            scoreTable.Widgets.Add(new Label
            {
                GridColumn = 3,
                GridRow = 0,
                Text = "Round"
            });
            scoreTable.Widgets.Add(new Label
            {
                GridColumn = 4,
                GridRow = 0,
                Text = "Score"
            });

            int count = 1;
            
            ScoreList scores = srvc.GetAllScoresAsync().Result;
            foreach (Score s in scores)
            {
                scoreTable.RowsProportions.Add(new Proportion(ProportionType.Auto));
                scoreTable.Widgets.Add(new Label
                {
                    GridColumn = 0,
                    GridRow = count,
                    Text = s.Id.ToString()
                });
                scoreTable.Widgets.Add(new Label
                {
                    GridColumn = 1,
                    GridRow = count,
                    Text = s.User.Username
                });
                scoreTable.Widgets.Add(new Label
                {
                    GridColumn = 2,
                    GridRow = count,
                    Text = s.Role.Type
                });
                scoreTable.Widgets.Add(new Label
                {
                    GridColumn = 3,
                    GridRow = count,
                    Text = s.Level.ToString()
                });
                scoreTable.Widgets.Add(new Label
                {
                    GridColumn = 4,
                    GridRow = count,
                    Text = s.Points.ToString()
                });

                count++;
            }

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
