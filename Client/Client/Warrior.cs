using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Linq;

namespace Client
{
    public class Warrior : Hero
    {
        //private DateTime? time;
        //private int buff;
        public Warrior(ContentManager content, Tile tile, int maxHealth, int attackDamage, int armor, int attackRange) 
            : base(content, tile, maxHealth, attackDamage, armor, attackRange)
        {
            Texture = Content.Load<Texture2D>("Assets/warriorWalkDown0");
        }

        public override void LevelUp()
        {
            //stat upgrades
            MaxHealth += 3;
            CurrentHealth += 3;
            AttackDamage += 3;

            //level change
            Exp -= Level * 10;
            Level++;
        }
        public override void Attack(List<Creature> creatures)
        {
            Tick++;
            if (Tick == 5)
            {
                Random r = new Random();
                bool hit = false;
                for (int i = 0; i <= AttackRange; i++)
                    foreach (Enemy e in creatures.FindAll(item => item is Enemy))
                        if (!hit && IsInRange(e, i))
                        {
                            int bonus = e.Level * 5;
                            if (Inventory.Locket != null && Inventory.Locket.Statboost == Locket.Stat.Pen)
                            {
                                if (e.TakeDamage(AttackDamage + Inventory.Items[0].Rank + Inventory.Items[1].Rank, Level))
                                {
                                    Exp += bonus;
                                    Gold += bonus;
                                    Score += bonus;
                                }
                            }
                            else if (Inventory.Locket != null && Inventory.Locket.Statboost == Locket.Stat.Crit && r.Next(4) == 0)
                            {
                                if (e.TakeDamage((AttackDamage + Inventory.Items[0].Rank + Inventory.Items[1].Rank) * 2))
                                {
                                    Exp += bonus;
                                    Gold += bonus;
                                    Score = bonus;
                                }
                            }
                            else if (e.TakeDamage(AttackDamage + Inventory.Items[0].Rank + Inventory.Items[1].Rank))
                            {
                                Exp += bonus;
                                Gold += bonus;
                                Score += bonus;
                            }
                            hit = true;
                        }
                Tick = -1;
            }
        }
        public override bool TakeDamage(int damage)
        {
            CurrentHealth -= damage - (Armor + 2 * Inventory.Items[2].Rank + Inventory.Items[3].Rank);
            if (CurrentHealth <= 0)
            {
                Die();
                return true;
            }
            return false;
        }
        public override void TextureChange(int max, Direction old, int action)
        {
            string texture = "Assets/warrior";
            texture += action switch
            {
                0 => "Walk",
                1 => "Attack",
                _ => "Ult"
            };
            if (action == 0 || action == 1)
                texture += Facing switch
                {
                    Direction.Up => "Up",
                    Direction.Down => "Down",
                    _ => "Left"
                };
            if (old != Facing || cycle >= max)
                cycle = -1;
            cycle++;
            texture += cycle;
            Texture = Content.Load<Texture2D>(texture);
        }
    }
}
