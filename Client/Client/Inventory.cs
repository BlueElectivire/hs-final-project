using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Client
{
    public class Inventory
    {
        private Item[] items;
        private Locket locket;
        private readonly List<Color> colors;

        public Inventory()
        {
            items = new Item[4];

            items[0] = new Item(Item.ItemType.Sword, 0);
            items[1] = new Item(Item.ItemType.Wand, 0);
            items[2] = new Item(Item.ItemType.Armor, 0);
            items[3] = new Item(Item.ItemType.Boots, 0);

            locket = null;

            colors = new List<Color>
            {
                Color.White
            };
        }

        public Item[] Items
        {
            get
            {
                return items;
            }
            set
            {
                items = value;
            }
        }
        public Locket Locket
        {
            get
            {
                return locket;
            }
            set
            {
                locket = value;
            }
        }
        public List<Color> Colors
        {
            get
            {
                return colors;
            }
        }
        public bool UpdateItem(Item item)
        {
            int i = item.Type switch
            {
                Item.ItemType.Sword => 0,
                Item.ItemType.Wand => 1,
                Item.ItemType.Armor => 2,
                _ => 3
            };

            if (items[i].Rank < item.Rank)
            {
                while (item.Rank >= colors.Count)
                    GenerateNewColor();

                items[i] = item;
                return true;
            }
            else
                return false;
        }
        public void GenerateNewColor()
        {
            Random r = new Random();
            float red = (float)r.NextDouble();
            float green = (float)r.NextDouble();
            float blue = (float)r.NextDouble();

            colors.Add(new Color(red, green, blue));
        }

        public void DrawInventory(SpriteBatch spriteBatch, GraphicsDeviceManager graphics, ContentManager content)
        {
            Color locketColor = Color.Gray;
            if (locket != null)
                locketColor = locket.Statboost switch
                {
                    Locket.Stat.CDR => Color.Blue,
                    Locket.Stat.Crit => Color.Yellow,
                    Locket.Stat.Pen => Color.Red,
                    _ => Color.Green
                };
            Texture2D locketTexture = content.Load<Texture2D>("Assets/Locket");
            Vector2 location = new Vector2(graphics.PreferredBackBufferWidth - locketTexture.Width * 2, 0);
            spriteBatch.Draw
            (
                locketTexture,
                location,
                null,
                locketColor,
                0f,
                Vector2.Zero,
                new Vector2(2, 2),
                SpriteEffects.None,
                0f
            );

            foreach (Item i in items)
            {
                string texture = i.Type switch
                {
                    Item.ItemType.Sword => "Assets/Sword",
                    Item.ItemType.Wand => "Assets/Wand",
                    Item.ItemType.Armor => "Assets/Armor",
                    _ => "Assets/Boots"
                };
                Texture2D itemTxtr = content.Load<Texture2D>(texture);
                location -= new Vector2(itemTxtr.Width * 2, 0);
                spriteBatch.Draw
                (
                    itemTxtr,
                    location,
                    null,
                    colors[i.Rank],
                    0f,
                    Vector2.Zero,
                    new Vector2(2, 2),
                    SpriteEffects.None,
                    0f
                );
            }
        }
    }
}
