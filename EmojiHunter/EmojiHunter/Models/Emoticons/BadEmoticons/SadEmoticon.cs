namespace EmojiHunter.Models.Emoticons.BadEmoticons
{
    using System.Runtime.Serialization;
    using Contracts;

    [DataContract]
    public class SadEmoticon : Emoticon, IMelee
    {
        private const int DefaultHealth = 100;

        private const int DefaultArmor = 25;

        private const int DefaultDamage = 3;

        private const float DefaultMovementSpeed = 2.5f;

        public SadEmoticon(string name) : base(name)
        {
            base.State.Health = DefaultHealth;
            base.State.Armor = DefaultArmor;
            base.State.Damage = DefaultDamage;
            base.State.MovementSpeed = DefaultMovementSpeed;
        }
    }
}