using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    public class Item 
    {
        private ItemType type;
        private int rank;

        public Item(ItemType type, int level)
        {
            this.type = type;
            rank = Math.Max(CalculateRank(level), 0);
        }

        public ItemType Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }
        public int Rank
        {
            get
            {
                return rank;
            }
            set
            {
                rank = value;
            }
        }

        public int CalculateRank(int level)
        {
            int rank = 0;
            int count = 0;

            for (int i = 0;i < level;i++)
            {
                count++;
                if (count > rank)
                {
                    rank++;
                    count = 0;
                }
            }

            return rank;
        }

        public enum ItemType 
        {
            Sword, Wand, Armor, Boots, Locket
        }
    }
}
