namespace EmojiHunter.Models.Emoticons.GoodEmoticons
{
    using System.Runtime.Serialization;
    using Contracts;
    using Emoticons;
    using Miscellaneous;

    [DataContract]
    public class SmileEmoticon : Emoticon
    {
        private const int StrengthBoostValue = 1;

        private const int DefaultHealth = 100;

        private const int DefaultArmor = 20;

        private const int DefaultDamage = 0;

        private const float DefaultMovementSpeed = 0.2f;

        public SmileEmoticon(string name) : base(name)
        {
            base.State.Health = DefaultHealth;
            base.State.Armor = DefaultArmor;
            base.State.Damage = DefaultDamage;
            base.State.MovementSpeed = DefaultMovementSpeed;
            this.Reward = new Reward(0, 0, 0, StrengthBoostValue, 0);
        }

        [DataMember]
        public override IReward Reward { get; set; }
    }
}