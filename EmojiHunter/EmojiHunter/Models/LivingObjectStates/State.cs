namespace EmojiHunter.Models.LivingObjectStates
{
    using Contracts;

    public abstract class State : IState
    {
        private int health;

        private int armor;

        private int damage;

        private float movementSpeed;

        protected State(int health, int armor, int damage, float movementSpeed)
        {
            this.Health = health;
            this.Armor = armor;
            this.Damage = damage;
            this.MovementSpeed = movementSpeed;
        }

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

        public int Damage
        {
            get
            {
                return this.damage;
            }

            set
            {
                if (value < 0)
                {
                    value = 0;
                }

                this.damage = value;
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
                    value = 0;
                }

                this.movementSpeed = value;
            }
        }
    }
}
