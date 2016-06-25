

namespace GameShadow.GameData.Emoticons
{
    using System;
   
    public class Location
    {
        public int X;
        public int Y;
        public Location (int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    public abstract class Emoticon
    {

        private int health;
        private int armor;
        private int movementSpeed;
        private Location location;


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

        public Location Location
        {
            get
            {
                return this.location;
            }
            set
            {
                this.location = value;
            }
        }

            protected  Emoticon (int x, int y)
        {
            this.location.X = x;
            this.location.Y = y;
        }
    }
}
