namespace EmojiHunter.Models.Emoticons.GoodEmoticons
{
    using System.Runtime.Serialization;
    using EmojiHunter.Contracts;
    using EmojiHunter.Models.Miscellaneous;
    using Emoticons;

    [DataContract]
    public class CheekyEmoticon : Emoticon
    {
        private const int ManaBoostValue = 1;

        private const int DefaultHealth = 100;

        private const int DefaultArmor = 20;

        private const int DefaultDamage = 0;

        private const float DefaultMovementSpeed = 0.2f;

        public CheekyEmoticon(string name) : base(name)
        {
            base.State.Health = DefaultHealth;
            base.State.Armor = DefaultArmor;
            base.State.Damage = DefaultDamage;
            base.State.MovementSpeed = DefaultMovementSpeed;
            this.Reward = new Reward(0, ManaBoostValue, 0, 0, 0);
        }

        [DataMember]
        public override IReward Reward { get; set; }
    }
}