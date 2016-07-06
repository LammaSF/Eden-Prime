using EmojiHunter.GameAnimation;

namespace EmojiHunter.GameData
{
    public abstract class Hero
    {
        #region Constants

        private const int DefaultSprintStrengthCost = 1; // per 100 ms 

        private const int DefaultTeleportManaCost = 20;

        private const SpellShotType DefaultShotType = SpellShotType.Sunball;

        private const float DefaultShootingSpeed = 10f;

        private const float DefaultShootingDelay = 500f; // in ms

        private const float DefaultShootingAngle = 45f; // in degrees

        private const float DefaultSightSpeed = 7;

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

        public const int MaxArmor = 100;

        private const int MaxMana = 150;

        private const int MaxStrength = 150;

        private const int MaxDamage = 75;

        #endregion

        #region Private Fields

        private bool isRunning;

        private float walkSpeed;

        private float runSpeed;

        private float currentSpeedBonus;

        private int health;

        private int armor;

        private int mana;

        private int strength;

        private int damage;

        private int currentMaxHealth;

        private int currentMaxMana;

        private int currentMaxStrength;

        private int currentMaxDamage;

        #endregion

        #region Constructors

        public Hero(string name)
        {
            this.Name = name;
            this.MovementSpeed = InitialWalkSpeed;
            this.WalkSpeed = InitialWalkSpeed;
            this.RunSpeed = InitialRunSpeed;
            this.CurrentSpeedBonus = 0;
            this.CurrentMaxHealth = InitialHealth;
            this.CurrentMaxMana = InitialMana;
            this.CurrentMaxStrength = InitialStrength;
            this.CurrentMaxDamage = InitialDamage;
            this.Health = InitialHealth;
            this.Armor = InitialArmor;
            this.Mana = InitialMana;
            this.Strength = InitialStrength;
            this.Damage = InitialDamage;
        }

        #endregion

        #region Properties

        public string Name { get; }

        public int SprintStrengthCost => DefaultSprintStrengthCost;

        public int TeleportManaCost => DefaultTeleportManaCost;

        public bool IsRunning
        {
            get { return this.isRunning; }

            set
            {
                this.isRunning = value;
                this.MovementSpeed = (this.IsRunning)
                    ? this.RunSpeed
                    : this.WalkSpeed;
            }
        }

        public float MovementSpeed { get; private set; }

        public float WalkSpeed
        {
            get { return this.walkSpeed; }

            set
            {
                if (value > MaxWalkSpeed)
                {
                    value = MaxWalkSpeed;
                }

                this.walkSpeed = value;
            }
        }

        public float RunSpeed
        {
            get { return this.runSpeed; }

            set
            {
                if (value > MaxRunSpeed)
                {
                    value = MaxRunSpeed;
                }

                this.runSpeed = value;
            }
        }

        public float CurrentSpeedBonus
        {
            get { return this.currentSpeedBonus; }

            set
            {
                this.currentSpeedBonus = value;

                this.WalkSpeed = InitialWalkSpeed + this.currentSpeedBonus;
                this.RunSpeed = InitialRunSpeed + this.currentSpeedBonus;
            }
        }

        public int Health
        {
            get { return this.health; }

            set
            {
                if (value > CurrentMaxHealth)
                {
                    value = CurrentMaxHealth;
                }
                else if (value < 0)
                {
                    value = 0;
                }

                this.health = value;
            }
        }

        public int CurrentMaxHealth
        {
            get { return this.currentMaxHealth; }

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
            get { return this.armor; }

            set
            {
                if (value > MaxArmor)
                {
                    value = MaxArmor;
                }
                else if (value < 0)
                {
                    value = 0;
                }

                this.armor = value;
            }
        }

        public int Mana
        {
            get { return this.mana; }

            set
            {
                if (value > CurrentMaxMana)
                {
                    value = CurrentMaxMana;
                }

                this.mana = value;
            }
        }

        public int CurrentMaxMana
        {
            get { return this.currentMaxMana; }

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
            get { return this.strength; }

            set
            {
                if (value > CurrentMaxStrength)
                {
                    value = CurrentMaxStrength;
                }

                this.strength = value;
            }
        }

        public int CurrentMaxStrength
        {
            get { return this.currentMaxStrength; }

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
            get { return this.damage; }

            set
            {
                if (value > CurrentMaxDamage)
                {
                    value = CurrentMaxDamage;
                }

                this.damage = value;
            }
        }

        public int CurrentMaxDamage
        {
            get { return this.currentMaxDamage; }

            set
            {
                if (value > MaxDamage)
                {
                    value = MaxDamage;
                }

                this.currentMaxDamage = value;
            }
        }

        public int Kills { get; set; }

        public int Points { get; set; }

        #endregion
    }
}
