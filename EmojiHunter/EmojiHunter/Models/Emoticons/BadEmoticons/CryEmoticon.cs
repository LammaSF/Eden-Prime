namespace EmojiHunter.Models.Emoticons.BadEmoticons
{
    using Contracts;
    using Miscellaneous;
    using Enumerations;
    using Emoticons;

    public class CryEmoticon : Emoticon, IShooting
    {
        private const int DefaultHealth = 100;

        private const int DefaultArmor = 50;

        private const int DefaultDamage = 10;

        private const float DefaultMovementSpeed = 2f;

        private const float DefaultShootingSpeed = 4f;

        private const float DefaultShootingDelay = 3000f;

        private const SpellShotType DefaultShotType = SpellShotType.Iceball;

        public CryEmoticon(string name) : base(name)
        {
            base.State.Health = DefaultHealth;
            base.State.Armor = DefaultArmor;
            base.State.Damage = DefaultDamage;
            base.State.MovementSpeed = DefaultMovementSpeed;
        }

        public float ShootingSpeed => DefaultShootingSpeed;

        public float ShootingDelay => DefaultShootingDelay;

        public SpellShotType ShotType => DefaultShotType;

        public override void ReactOnCollision(IGameObject other)
        {
            if (other is Shot && (other as Shot).ID == nameof(CryEmoticon))
            {
                return;
            }

            base.ReactOnCollision(other);
        }
    }
}