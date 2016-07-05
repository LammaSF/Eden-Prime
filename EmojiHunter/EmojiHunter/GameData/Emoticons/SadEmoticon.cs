namespace EmojiHunter.GameData.Emoticons
{
    public class SadEmoticon : BadEmoticon
    {
        private const int DefaultHealth = 100;

        private const int DefaultArmor = 25;

        private const int DefaultDamage = 15;

        private const int DefaultAttackSpeed = 100; // in ms

        private const float DefaultMovementSpeed = 2.5f;

        public SadEmoticon(string name) : base(name)
        {
            this.Health = DefaultHealth;
            this.Armor = DefaultArmor;
            this.Damage = DefaultDamage;
            this.MovementSpeed = DefaultMovementSpeed;
            this.AttackSpeed = DefaultAttackSpeed;
        }
    }
}