namespace EmojiHunter.Models.Heroes
{
    using System.Runtime.Serialization;
    using Contracts;
    using Enumerations;
    using Miscellaneous;

    [DataContract]
    public class Sagittarius : Hero, IShooting
    {
        private const int DefaultShootingManaCost = 1;

        private const SpellShotType DefaultShotType = SpellShotType.Sunball;

        private const float DefaultShootingSpeed = 10f;

        private const float DefaultShootingDelay = 500f; // in ms

        private const float DefaultShootingAngle = 45f; // in degrees

        private const float DefaultSightSpeed = 7;

        public Sagittarius(string name) : base(name)
        {
            this.ShootingAngle = DefaultShootingAngle;
            this.ShotType = DefaultShotType;
            this.ShootingSpeed = DefaultShootingSpeed;
            this.ShootingDelay = DefaultShootingDelay;
            this.SightSpeed = DefaultSightSpeed;
            this.ShootingManaCost = DefaultShootingManaCost;
        }
        [DataMember]
        public int ShootingManaCost { get; set; }

        [DataMember]
        public float ShootingAngle { get; set; }

        [DataMember]
        public float ShootingSpeed { get; set; }

        [DataMember]
        public float ShootingDelay { get; set; }

        [DataMember]
        public float SightSpeed { get; set; }

        [DataMember]
        public SpellShotType ShotType { get; set; }

        public override void ReactOnCollision(IGameObject other)
        {
            if (other is Shot && (other as Shot).ID == nameof(Sagittarius))
            {
                return;
            }

            base.ReactOnCollision(other);
        }
    }
}
