namespace EmojiHunter.GameData
{
    using System;
   
    public abstract class Emoticon
    {
        private string name;

        private int health;

        private int armor;

        private int movementSpeed;

        protected Emoticon (string name)
        {
            this.name = name;
        }

        public string Name => this.name;

        public int Health
        {
            get
            {
                return this.health;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Health cannot be negative");
                }

                this.health = value;
            }
        }

        public int Armor
        {
            get
            {
                return this.armor;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Armor cannot be negative");
                }

                this.armor = value;
            }
        }

        public int MovementSpeed
        {
            get
            {
                return this.movementSpeed;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Emoticon speed cannot be negative");
                }

                this.movementSpeed = value;
            }
        }

    }
}
