namespace EmojiHunter.Models.Emoticons.GoodEmoticons
{
    using System.Runtime.Serialization;
    using EmojiHunter.Contracts;
    using EmojiHunter.Models.Emoticons;
    using EmojiHunter.Models.Miscellaneous;

    [DataContract]
    public class LoveEmoticon : Emoticon
    {
        private const int HealthBoostValue = 1;

        private const int DefaultHealth = 100;

        private const int DefaultArmor = 40;

        private const int DefaultDamage = 0;

        private const float DefaultMovementSpeed = 0.2f;

        public LoveEmoticon(string name) : base(name)
        {
            base.State.Health = DefaultHealth;
            base.State.Armor = DefaultArmor;
            base.State.Damage = DefaultDamage;
            base.State.MovementSpeed = DefaultMovementSpeed;
            this.Reward = new Reward(HealthBoostValue, 0, 0, 0, 0);
        }
        
        [DataMember]
        public override IReward Reward { get; set; }
    }
}
