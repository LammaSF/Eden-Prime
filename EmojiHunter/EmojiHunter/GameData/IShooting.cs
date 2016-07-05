using EmojiHunter.GameAnimation;

namespace EmojiHunter.GameData
{
    interface IShooting
    {
        int RangedDamage { get; set; }

        float ShootingSpeed { get; }

        float ShootingDelay { get; }

        SpellShotType ShotType { get; }
    }
}
