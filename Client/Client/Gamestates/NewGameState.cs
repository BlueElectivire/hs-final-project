using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Myra.Graphics2D.UI;
using Service;

namespace Client.Gamestates
{
    public class NewGameState : GameState
    {
        readonly User user;
        public NewGameState(GraphicsDevice graphicsDevice, User user) : base(graphicsDevice)
        {
            this.user = user;
        }

        public override void Initialize()
        {
            Grid grid = new Grid
            {
                ColumnSpacing = 8,
                RowSpacing = 8
            };

            grid.ColumnsProportions.Add(new Proportion(ProportionType.Auto));
            grid.ColumnsProportions.Add(new Proportion(ProportionType.Auto));
            grid.RowsProportions.Add(new Proportion(ProportionType.Auto));
            grid.RowsProportions.Add(new Proportion(ProportionType.Auto));
            grid.RowsProportions.Add(new Proportion(ProportionType.Auto));
            grid.RowsProportions.Add(new Proportion(ProportionType.Auto));

            TextButton warrior = new TextButton
            {
                GridColumn = 0,
                GridRow = 1,
                Text = "Warrior"
            };
            TextButton vampire = new TextButton
            {
                GridColumn = 1,
                GridRow = 1,
                Text = "Vampire"
            };
            TextButton rogue = new TextButton
            {
                GridColumn = 0,
                GridRow = 2,
                Text = "Rogue"
            };
            TextButton sorceress = new TextButton
            {
                GridColumn = 1,
                GridRow = 2,
                Text = "Sorceress"
            };


            warrior.Click += (s, a) =>
            {
                GameStateManager.Instance.AddScreen(new PlayState(graphicsDevice, user, PlayState.HeroType.Warrior));
            };
            sorceress.Click += (s, a) =>
            {
                GameStateManager.Instance.AddScreen(new PlayState(graphicsDevice, user, PlayState.HeroType.Sorceress));
            };
            rogue.Click += (s, a) =>
            {
                GameStateManager.Instance.AddScreen(new PlayState(graphicsDevice, user, PlayState.HeroType.Rogue));
            };
            vampire.Click += (s, a) =>
            {
                GameStateManager.Instance.AddScreen(new PlayState(graphicsDevice, user, PlayState.HeroType.Vampire));
            };

            grid.Widgets.Add(new Label
            {
                GridColumn = 0,
                GridColumnSpan = 2,
                GridRow = 0,
                Text = "Choose Your Character"
            });
            grid.Widgets.Add(warrior);
            grid.Widgets.Add(sorceress);
            grid.Widgets.Add(rogue);
            grid.Widgets.Add(vampire);

            desktop = new Desktop
            {
                Root = grid
            };
        }

        public override void LoadContent(ContentManager content)
        {
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
