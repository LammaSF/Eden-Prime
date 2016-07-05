namespace EmojiHunter.GameData
{
    using System;
   
    public abstract class Emoticon
    {
        private string name;

        private int health;

        private int armor;

        private float movementSpeed;

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
                    value = 0;
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

            set
            {
                if (value < 0)
                {
                    value = 0;
                }

                this.armor = value;
            }
        }

        public float MovementSpeed
        {
            get
            {
                return this.movementSpeed;
            }

            set
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
