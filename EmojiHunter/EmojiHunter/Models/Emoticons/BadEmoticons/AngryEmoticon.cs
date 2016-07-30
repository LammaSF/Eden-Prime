namespace EmojiHunter.Models.Emoticons.BadEmoticons
{
    public class AngryEmoticon : Emoticon
    {
        private const int DefaultHealth = 100;

        private const int DefaultArmor = 100;

        private const int DefaultDamage = 5;

        private const float DefaultMovementSpeed = 3f;

        public AngryEmoticon(string name) : base(name)
        {
            base.State.Health = DefaultHealth;
            base.State.Armor = DefaultArmor;
            base.State.Damage = DefaultDamage;
            base.State.MovementSpeed = DefaultMovementSpeed;
        }
    }
}