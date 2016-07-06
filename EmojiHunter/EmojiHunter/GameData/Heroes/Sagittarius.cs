using EmojiHunter.GameAnimation;

namespace EmojiHunter.GameData.Heroes
{
    public class Sagittarius : Hero, IShooting
    {
        private const int DefaultShootingManaCost = 5;

        private const SpellShotType DefaultShotType = SpellShotType.Sunball;

        private const float DefaultShootingSpeed = 10f;

        private const float DefaultShootingDelay = 500f; // in ms

        private const float DefaultShootingAngle = 45f; // in degrees

        private const float DefaultSightSpeed = 7;

        public Sagittarius(string name) : base(name)
        {
            this.ShootingAngle = DefaultShootingAngle;
        }

        public int ShootingManaCost => DefaultShootingManaCost;

        public float ShootingAngle { get; set; }

        public float ShootingSpeed => DefaultShootingSpeed;

        public float ShootingDelay => DefaultShootingDelay;

        public float SightSpeed => DefaultSightSpeed;

        public SpellShotType ShotType => DefaultShotType;

        public int RangedDamage
        {
            get { return base.Damage; }

            set
            {
                if (value > CurrentMaxDamage)
                {
                    value = CurrentMaxDamage;
                }

                this.Damage = value;
            }
        }
    }
}
