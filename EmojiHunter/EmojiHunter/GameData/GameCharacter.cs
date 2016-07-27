namespace EmojiHunter.GameData
{
    using System;

    public abstract class GameCharacter
    {
        protected int health;

        protected int armor;

        protected float movementSpeed;

        private string name;

        protected GameCharacter(string name)
        {
            this.name = name;
        }

        public string Name => this.name;

        public virtual int Health
        {
            get
            {
                return this.health;
            }

            set
            {
                if (value < 0)
                {
                    value = 0;
                }

                this.health = value;
            }
        }

        public virtual int Armor
        {
            get
            {
                return this.armor;
            }

            set
            {
                if (value < 0)
                {
                    value = 0;
                }

                this.armor = value;
            }
        }

        public virtual float MovementSpeed
        {
            get
            {
                return this.movementSpeed;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Speed cannot be negative");
                }

                this.movementSpeed = value;
            }
        }
    }
}
