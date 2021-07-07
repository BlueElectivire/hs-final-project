using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Client
{
    public class Shop : Tile
    {
        private Item item;
        private Locket locket;
        private bool isHealAvailable;

        public Shop(ContentManager content, Vector2 position, int level) : base(content, position, TileType.Obstacle)
        {
            Texture = Content.Load<Texture2D>("Assets/shop");

            isHealAvailable = true;

            Random r = new Random();
            item = r.Next(4) switch
            {
                1 => new Item(Item.ItemType.Wand, level),
                2 => new Item(Item.ItemType.Armor, level),
                3 => new Item(Item.ItemType.Boots, level),
                _ => new Item(Item.ItemType.Sword, level),
            };
            locket = r.Next(4) switch
            {
                1 => new Locket(Locket.Stat.Crit),
                2 => new Locket(Locket.Stat.Pen),
                3 => new Locket(Locket.Stat.CDR),
                _ => new Locket(Locket.Stat.Healboost),
            };
        }

        public void BuyItem(Hero hero)
        {
            if (item != null && hero.Gold >= item.Rank * 10)
            {
                if (hero.Inventory.UpdateItem(item))
                {
                    hero.Gold -= item.Rank * 10;
                    item = null;
                }
            }
        }
        public void BuyLocket(Hero hero)
        {
            if (locket != null && hero.Gold >= 100 && (hero.Inventory.Locket == null || hero.Inventory.Locket.Statboost != locket.Statboost))
            {
                hero.Inventory.Locket = locket;
                hero.Gold -= 100;
                locket = null;
            }
        }
        public void BuyHeal(Hero hero)
        {
            if (isHealAvailable && hero.Gold > 15)
            {
                hero.Gold -= 15;
                hero.CurrentHealth = hero.MaxHealth;
                isHealAvailable = false;
            }
        }

        public void DrawShop(SpriteBatch spriteBatch, GraphicsDeviceManager graphics, ContentManager content, Hero hero)
        {
            Vector2 mid = new Vector2(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2);

            SpriteFont font = Content.Load<SpriteFont>("font");

            Texture2D bg = content.Load<Texture2D>("Assets/shopOverlay");
            spriteBatch.Draw
            (
                bg,
                mid,
                null,
                Color.White,
                0f,
                new Vector2(bg.Width / 2, bg.Height / 2),
                new Vector2(3, 3),
                SpriteEffects.None,
                0f
            );

            if (isHealAvailable)
            {
                Texture2D pot = content.Load<Texture2D>("Assets/heal");
                spriteBatch.Draw
                (
                    pot,
                    mid - new Vector2(pot.Width * 3, 0),
                    null,
                    Color.White,
                    0f,
                    new Vector2(pot.Width / 2, pot.Height / 2),
                    new Vector2(3, 3),
                    SpriteEffects.None,
                    0f
                );

                string h = "15";
                spriteBatch.DrawString
                (
                    font,
                    h,
                    mid - new Vector2(pot.Width * 3, 0),
                    Color.White,
                    0f,
                    new Vector2(font.MeasureString(h).X / 2, font.MeasureString(h).Y / 2),
                    Vector2.One,
                    SpriteEffects.None,
                    0f
                );
            }

            if (item != null)
            {
                string itemTexture = item.Type switch
                {
                    Item.ItemType.Sword => "Assets/sword",
                    Item.ItemType.Wand => "Assets/wand",
                    Item.ItemType.Armor => "Assets/armor",
                    _ => "Assets/boots"
                };

                while (item.Rank > hero.Inventory.Colors.Count - 1)
                    hero.Inventory.GenerateNewColor();

                Texture2D i = content.Load<Texture2D>(itemTexture);
                spriteBatch.Draw
                (
                    i,
                    mid,
                    null,
                    hero.Inventory.Colors[item.Rank],
                    0f,
                    new Vector2(i.Width / 2, i.Height / 2),
                    new Vector2(3, 3),
                    SpriteEffects.None,
                    0f
                );

                string iStr = (item.Rank * 10).ToString();
                spriteBatch.DrawString
                (
                    font,
                    iStr,
                    mid,
                    Color.White,
                    0f,
                    new Vector2(font.MeasureString(iStr).X / 2, font.MeasureString(iStr).Y / 2),
                    Vector2.One,
                    SpriteEffects.None,
                    0f
                );
            }

            if (locket != null)
            {
                Texture2D l = content.Load<Texture2D>("Assets/locket");
                spriteBatch.Draw
                (
                    l,
                    mid + new Vector2(l.Width * 3, 0),
                    null,
                    locket.Statboost switch
                    {
                        Locket.Stat.Pen => Color.Red,
                        Locket.Stat.Crit => Color.Yellow,
                        Locket.Stat.CDR => Color.Blue,
                        _ => Color.Green
                    },
                    0f, 
                    new Vector2(l.Width / 2, l.Height / 2),
                    new Vector2(3, 3),
                    SpriteEffects.None,
                    0f
                );

                string lStr = "100";
                spriteBatch.DrawString
                (
                    font,
                    lStr,
                    mid + new Vector2(l.Width * 3, 0),
                    Color.White,
                    0f,
                    new Vector2(font.MeasureString(lStr).X / 2, font.MeasureString(lStr).Y / 2),
                    Vector2.One,
                    SpriteEffects.None,
                    0f
                );
            }
        }
    }
}
