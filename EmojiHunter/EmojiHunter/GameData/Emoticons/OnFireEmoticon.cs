using EmojiHunter.GameAnimation;

namespace EmojiHunter.GameData.Emoticons
{
    public class OnFireEmoticon : BadEmoticon, IShooting
    {
        private const int DefaultHealth = 100;

        private const int DefaultArmor = 50;

        private const int DefaultDamage = 5;

        private const int DefaultAttackSpeed = 100; // in ms

        private const float DefaultMovementSpeed = 4f;

        private const int DefaultRangedDamage = 75;

        private const float DefaultShootingSpeed = 8f;

        private const float DefaultShootingDelay = 3000f;

        private const SpellShotType DefaultShotType = SpellShotType.Fireball;

        public OnFireEmoticon(string name) : base(name)
        {
            this.Health = DefaultHealth;
            this.Armor = DefaultArmor;
            this.Damage = DefaultDamage;
            this.MovementSpeed = DefaultMovementSpeed;
            this.AttackSpeed = DefaultAttackSpeed;
        }

        public int RangedDamage
        {
            get { return DefaultRangedDamage; }

            set { }
        }

        public float ShootingSpeed => DefaultShootingSpeed;

        public float ShootingDelay => DefaultShootingDelay;

        public SpellShotType ShotType => DefaultShotType;
    }
}