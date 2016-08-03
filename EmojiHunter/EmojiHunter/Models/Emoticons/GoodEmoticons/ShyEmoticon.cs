namespace EmojiHunter.Models.Emoticons.GoodEmoticons
{
    using System.Runtime.Serialization;
    using EmojiHunter.Contracts;
    using EmojiHunter.Models.Emoticons;
    using EmojiHunter.Models.Miscellaneous;

    [DataContract]
    public class ShyEmoticon : Emoticon
    {
        private const float SpeedBoostValue = 0.05f;

        private const int DefaultHealth = 100;

        private const int DefaultArmor = 20;

        private const int DefaultDamage = 0;

        private const float DefaultMovementSpeed = 0.2f;

        public ShyEmoticon(string name) : base(name)
        {
            base.State.Health = DefaultHealth;
            base.State.Armor = DefaultArmor;
            base.State.Damage = DefaultDamage;
            base.State.MovementSpeed = DefaultMovementSpeed;
            this.Reward = new Reward(0, 0, 0, 0, SpeedBoostValue);
        }

        [DataMember]
        public override IReward Reward { get; set; }
    }
}