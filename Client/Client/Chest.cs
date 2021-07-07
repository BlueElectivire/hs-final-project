using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Client
{
    public class Chest : Tile
    {
        public Chest(ContentManager content, Vector2 position) : base(content, position, TileType.Obstacle)
        {
        }

        public Item GenerateLoot(int level)
        {
            Random r = new Random();
            Item loot = new Item(r.Next(4) switch { 0 => Item.ItemType.Sword, 1 => Item.ItemType.Wand, 2 => Item.ItemType.Armor, _ => Item.ItemType.Boots}, level);

            Texture = Content.Load<Texture2D>("Assets/chest1");

            return loot;
        }
    }
}
