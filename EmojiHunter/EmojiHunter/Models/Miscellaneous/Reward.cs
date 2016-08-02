namespace EmojiHunter.Models.Miscellaneous
{
    using System.Runtime.Serialization;
    using Contracts;

    [DataContract]
    public class Reward : IReward
    {
        public Reward(int health, int mana, int damage, int strength, float speed)
        {
            this.Health = health;
            this.Mana = mana;
            this.Damage = damage;
            this.Strength = strength;
            this.Speed = speed;
        }

        [DataMember]
        public int Health { get; set; }

        [DataMember]
        public int Mana { get; set; }

        [DataMember]
        public int Damage { get; set; }

        [DataMember]
        public int Strength { get; set; }

        [DataMember]
        public float Speed { get; set; }
    }
}
