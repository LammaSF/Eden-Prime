namespace EmojiHunter.GameData
{
    public class Reward
    {
        public Reward(int health, int mana, int damage, int strength, int speed)
        {
            this.Health = health;
            this.Mana = mana;
            this.Damage = damage;
            this.Strength = strength;
            this.Speed = speed;
        }

        public int Health { get; private set; }

        public int Mana { get; private set; }

        public int Damage { get; private set; }

        public int Strength { get; private set; }

        public float Speed { get; private set; }

        public void AddReward(Hero hero)
        {
            hero.CurrentMaxHealth += this.Health;
            hero.CurrentMaxMana += this.Mana;
            hero.CurrentMaxDamage += this.Damage;
            hero.CurrentMaxStrength += this.Strength;
            hero.CurrentSpeedBonus += this.Speed; 
        }
    }
}
