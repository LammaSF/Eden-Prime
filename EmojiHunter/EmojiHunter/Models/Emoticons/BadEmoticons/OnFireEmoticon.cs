namespace EmojiHunter.Models.Emoticons.BadEmoticons
{
    using System.Runtime.Serialization;
    using Contracts;
    using Enumerations;
    using Emoticons;
    using Miscellaneous;

    [DataContract]
    public class OnfireEmoticon : Emoticon, IShooting
    {
        private const int DefaultHealth = 100;

        private const int DefaultArmor = 50;

        private const int DefaultDamage = 15;

        private const float DefaultMovementSpeed = 2f;

        private const float DefaultShootingSpeed = 8f;

        private const float DefaultShootingDelay = 3000f;

        private const SpellShotType DefaultShotType = SpellShotType.Fireball;

        public OnfireEmoticon(string name) : base(name)
        {
            base.State.Health = DefaultHealth;
            base.State.Armor = DefaultArmor;
            base.State.Damage = DefaultDamage;
            base.State.MovementSpeed = DefaultMovementSpeed;
            this.ShotType = DefaultShotType;
            this.ShootingSpeed = DefaultShootingSpeed;
            this.ShootingDelay = DefaultShootingDelay;
        }
        [DataMember]
        public float ShootingSpeed { get; set; }

        [DataMember]
        public float ShootingDelay { get; set; }

        [DataMember]
        public SpellShotType ShotType { get; set; }

        public override void ReactOnCollision(IGameObject other)
        {
            if (other is Shot && ((Shot) other).ID == nameof(OnfireEmoticon))
            {
                return;
            }

            base.ReactOnCollision(other);
        }
    }
}