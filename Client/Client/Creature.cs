using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Timers;

namespace Client
{
    public abstract class Creature : GameEntity
    {
        private Tile tile;
        private int maxHealth;
        private int currentHealth;
        private int attackDamage;
        private int armor;
        private int attackRange;
        private int tick;
        private Direction facing;
        private bool isStunned;
        private DateTime? stunStart;
        private TimeSpan stunDuration;
        private int level;
        private bool isAlive;
        protected int cycle;
        private readonly Timer moveTimer;
        private bool canMove;

        public Creature(ContentManager content, Tile tile, int maxHealth, int attackDamage, int armor, int attackRange, bool isStunned, int level, bool isAlive) 
            : base(content, tile.Position)
        {
            this.tile = tile;
            this.maxHealth = maxHealth;
            currentHealth = maxHealth;
            this.attackDamage = attackDamage;
            this.armor = armor;
            this.attackRange = attackRange;
            tick = -1;
            facing = Direction.Down;
            this.isStunned = isStunned;
            stunDuration = TimeSpan.Zero;
            this.level = level;
            this.isAlive = isAlive;
            cycle = 0;
            canMove = true;
            moveTimer = new Timer(500)
            {
                AutoReset = true,
                Enabled = true
            };
            moveTimer.Elapsed += MoveTimer_Elapsed;
        }

        private void MoveTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            canMove = true;
        }

        public Tile Tile
        {
            get
            {
                return tile;
            }
            set
            {
                tile = value;
                Position = tile.Position;
            }
        }
        public int MaxHealth
        {
            get
            {
                return maxHealth;
            }
            set
            {
                maxHealth = value;
            }
        }
        public int CurrentHealth
        {
            get
            {
                return currentHealth;
            }
            set
            {
                currentHealth = value;
            }
        }
        public int AttackDamage
        {
            get
            {
                return attackDamage;
            }
            set
            {
                attackDamage = value;
            }
        }
        public int Armor
        {
            get
            {
                return armor;
            }
            set
            {
                armor = value;
            }
        }
        public int AttackRange
        {
            get
            {
                return attackRange;
            }
            set
            {
                attackRange = value;
            }
        }
        public int Tick
        {
            get
            {
                return tick;
            }
            set
            {
                tick = value;
            }
        }
        public Direction Facing
        {
            get
            {
                return facing;
            }
            set
            {
                facing = value;
            }
        }
        public bool IsStunned
        {
            get
            {
                return isStunned;
            }
            set
            {
                isStunned = value;
            }
        }
        public TimeSpan StunDuration
        {
            get
            {
                return stunDuration;
            }
            set
            {
                stunDuration = value;
            }
        }
        public int Level
        {
            get
            {
                return level;
            }
            set
            {
                level = value;
            }
        }
        public bool IsAlive
        {
            get
            {
                return isAlive;
            }
            set
            {
                isAlive = value;
            }
        }
        public bool CanMove
        {
            get
            {
                return canMove;
            }
            set
            {
                canMove = value;
            }
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 drawPosition)
        {
            if (Facing == Direction.Right)
                spriteBatch.Draw(
                    Texture,
                    drawPosition,
                    null,
                    Color.White,
                    0f,
                    new Vector2(Texture.Width / 2, Texture.Height / 2),
                    Vector2.One,
                    SpriteEffects.FlipHorizontally,
                    0f
                );
            else
                base.Draw(spriteBatch, drawPosition);
        }
        public override void Update(GameTime gameTime, List<GameEntity> gameEntities) 
        {
            if (isStunned)
            {
                Stun();
            }
        }

        public abstract void Attack(List<Creature> creatures);
        public void Stun()
        {
            if (stunStart == null) 
                stunStart = DateTime.Now;
            else if (DateTime.Now - stunStart >= stunDuration)
            {
                stunStart = null;
                stunDuration = TimeSpan.Zero;
                isStunned = false;
            }
        }
        public void Stun(int stunDuration)
        {
            this.stunDuration += new TimeSpan(0, 0, stunDuration);
        }
        public virtual bool TakeDamage(int damage)
        {
            currentHealth -= Math.Max(damage - armor, 1);
            if (currentHealth <= 0)
            {
                Die();
                return true;
            }
            return false;
        }
        public virtual bool TakeDamage(int damage, int pen)
        {
            currentHealth -= Math.Max(damage - (armor - pen), 1);
            if (currentHealth <= 0)
            {
                Die();
                return true;
            }
            return false;
        }
        public virtual void Heal(int amount)
        {
            currentHealth += amount;
            if (currentHealth > MaxHealth)
                currentHealth = maxHealth;
        }
        public void Die()
        {
            isAlive = false;
        }
    }
}
