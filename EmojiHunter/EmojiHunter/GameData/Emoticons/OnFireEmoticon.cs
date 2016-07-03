namespace EmojiHunter.GameData.Emoticons
{
    public class OnFireEmoticon : BadEmoticon
    {
        private const int DefaultHealth = 100;

        private const int DefaultArmor = 50;

        private const int DefaultDamage = 5;

        private const int DefaultAttackSpeed = 100; // in ms

        private const float DefaultMovementSpeed = 1;

        public OnFireEmoticon(string name) : base(name)
        {
            this.Health = DefaultHealth;
            this.Armor = DefaultArmor;
            this.Damage = DefaultDamage;
            this.AttackSpeed = DefaultAttackSpeed;
        }
    }
}