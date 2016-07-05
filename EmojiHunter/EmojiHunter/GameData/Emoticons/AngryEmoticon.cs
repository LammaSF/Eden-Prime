namespace EmojiHunter.GameData.Emoticons
{
    public class AngryEmoticon : BadEmoticon
    {
        private const int DefaultHealth = 100;

        private const int DefaultArmor = 100;

        private const int DefaultDamage = 25;

        private const int DefaultAttackSpeed = 100; // in ms

        private const float DefaultMovementSpeed = 3f;

        public AngryEmoticon(string name) : base(name)
        {
            this.Health = DefaultHealth;
            this.Armor = DefaultArmor;
            this.Damage = DefaultDamage;
            this.MovementSpeed = DefaultMovementSpeed;
            this.AttackSpeed = DefaultAttackSpeed;
        }
    }
}