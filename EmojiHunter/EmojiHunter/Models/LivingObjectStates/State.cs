namespace EmojiHunter.Models.LivingObjectStates
{
    using System.Runtime.Serialization;
    using Contracts;

    [DataContract]
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

        [DataMember]
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

        [DataMember]
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

        [DataMember]
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

        [DataMember]
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
