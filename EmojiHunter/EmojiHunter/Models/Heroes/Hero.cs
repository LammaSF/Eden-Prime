namespace EmojiHunter.Models.Heroes
{
    using Contracts;
    using Models;

    public abstract class Hero : LivingObject, IHero
    {
        #region Constants

        private const int DefaultSprintStrengthCost = 1; // per 200 ms 

        private const int DefaultTeleportManaCost = 20;

        private const float InitialWalkSpeed = 1.5f;

        private const float InitialRunSpeed = 3f;

        private const float MaxWalkSpeed = 2f;

        private const float MaxRunSpeed = 5f;

        private const int InitialHealth = 100;

        private const int InitialArmor = 0;

        private const int InitialMana = 100;

        private const int InitialStrength = 100;

        private const int InitialDamage = 25;

        private const int MaxHealth = 200;

        private const int MaxArmor = 100;

        private const int MaxMana = 150;

        private const int MaxStrength = 150;

        private const int MaxDamage = 75;

        #endregion

        #region Private Fields

        private bool isRunning;

        private float walkSpeed;

        private float runSpeed;

        private float currentSpeedBonus;

        private int mana;

        private int strength;

        private int currentMaxHealth;

        private int currentMaxMana;

        private int currentMaxStrength;

        private int currentMaxDamage;

        #endregion

        #region Constructors

        protected Hero(string name) : base(name)
        {
            base.State.MovementSpeed = InitialWalkSpeed;
            base.State.Health = InitialHealth;
            base.State.Armor = InitialArmor;
            base.State.Damage = InitialDamage;
            this.WalkSpeed = InitialWalkSpeed;
            this.RunSpeed = InitialRunSpeed;
            this.CurrentSpeedBonus = 0;
            this.CurrentMaxHealth = InitialHealth;
            this.CurrentMaxMana = InitialMana;
            this.CurrentMaxStrength = InitialStrength;
            this.CurrentMaxDamage = InitialDamage;
            this.Mana = InitialMana;
            this.Strength = InitialStrength;
        }

        #endregion

        #region Properties
        
        public int SprintStrengthCost => DefaultSprintStrengthCost;

        public int TeleportManaCost => DefaultTeleportManaCost;

        public int Health
        {
            get
            {
                return this.State.Health;
            }

            set
            {
                if (value > this.CurrentMaxHealth)
                {
                    value = this.CurrentMaxHealth;
                }

                this.State.Health = value;
            }
        }

        public int CurrentMaxHealth
        {
            get
            {
                return this.currentMaxHealth;
            }

            set
            {
                if (value > MaxHealth)
                {
                    value = MaxHealth;
                }

                this.currentMaxHealth = value;
            }
        }

        public int Armor
        {
            get
            {
                return this.State.Armor;
            }

            set
            {
                if (value > MaxArmor)
                {
                    value = MaxArmor;
                }

                this.State.Armor = value;
            }
        }

        public int CurrentMaxArmor => MaxArmor;

        public int Mana
        {
            get
            {
                return this.mana;
            }

            set
            {
                if (value > this.CurrentMaxMana)
                {
                    value = this.CurrentMaxMana;
                }

                this.mana = value;
            }
        }

        public int CurrentMaxMana
        {
            get
            {
                return this.currentMaxMana;
            }

            set
            {
                if (value > MaxMana)
                {
                    value = MaxMana;
                }

                this.currentMaxMana = value;
            }
        }

        public int Strength
        {
            get
            {
                return this.strength;
            }

            set
            {
                if (value > this.CurrentMaxStrength)
                {
                    value = this.CurrentMaxStrength;
                }

                this.strength = value;
            }
        }

        public int CurrentMaxStrength
        {
            get
            {
                return this.currentMaxStrength;
            }

            set
            {
                if (value > MaxStrength)
                {
                    value = MaxStrength;
                }

                this.currentMaxStrength = value;
            }
        }

        public int Damage
        {
            get
            {
                return this.State.Damage;
            }

            set
            {
                if (value > this.CurrentMaxDamage)
                {
                    value = this.CurrentMaxDamage;
                }

                this.State.Damage = value;
            }
        }

        public int CurrentMaxDamage
        {
            get
            {
                return this.currentMaxDamage;
            }

            set
            {
                if (value > MaxDamage)
                {
                    value = MaxDamage;
                }

                this.currentMaxDamage = value;
            }
        }

        public bool IsRunning
        {
            get
            {
                return this.isRunning;
            }

            set
            {
                this.isRunning = value;
                this.State.MovementSpeed = (this.IsRunning)
                    ? this.RunSpeed
                    : this.WalkSpeed;
            }
        }

        private float WalkSpeed
        {
            get
            {
                return this.walkSpeed;
            }

            set
            {
                if (value > MaxWalkSpeed)
                {
                    value = MaxWalkSpeed;
                }

                this.walkSpeed = value;
            }
        }

        private float RunSpeed
        {
            get
            {
                return this.runSpeed;
            }

            set
            {
                if (value > MaxRunSpeed)
                {
                    value = MaxRunSpeed;
                }

                this.runSpeed = value;
            }
        }

        private float CurrentSpeedBonus
        {
            get
            {
                return this.currentSpeedBonus;
            }

            set
            {
                this.currentSpeedBonus = value;

                this.WalkSpeed = InitialWalkSpeed + this.currentSpeedBonus;

                this.RunSpeed = InitialRunSpeed + this.currentSpeedBonus;
            }
        }

        #endregion

        #region Public Methods

        public override void ReactOnCollision(IGameObject other)
        {
            this.TakeReward(other.Reward);

            base.ReactOnCollision(other);
        }
        
        #endregion

        #region Private Methods

        private void TakeReward(IReward reward)
        {
            this.CurrentMaxHealth += reward.Health;
            this.CurrentMaxMana += reward.Mana;
            this.CurrentMaxDamage += reward.Damage;
            this.CurrentMaxStrength += reward.Strength;
            this.CurrentSpeedBonus += reward.Speed;
        }

        #endregion
    }
}
