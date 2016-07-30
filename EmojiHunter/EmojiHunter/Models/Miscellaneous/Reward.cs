namespace EmojiHunter.Models.Miscellaneous
{
    using Contracts;

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

        public int Health { get; }

        public int Mana { get; }

        public int Damage { get; }

        public int Strength { get; }

        public float Speed { get; }
    }
}
