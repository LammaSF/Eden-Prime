using EmojiHunter.GameAnimation;

namespace EmojiHunter.GameData
{
    public interface IShooting
    {
        int RangedDamage { get; set; }

        float ShootingSpeed { get; }

        float ShootingDelay { get; }

        SpellShotType ShotType { get; }
    }
}
