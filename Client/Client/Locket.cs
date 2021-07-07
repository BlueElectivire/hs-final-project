using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    public class Locket : Item
    {
        private Stat statboost;

        public Locket(Stat statboost) : base(ItemType.Locket, 1)
        {
            this.statboost = statboost;
        }

        public Stat Statboost
        {
            get
            {
                return statboost;
            }
            set
            {
                statboost = value;
            }
        }
        public enum Stat
        {
            Crit, Pen, Healboost, CDR
        }
    }
}
