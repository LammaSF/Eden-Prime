namespace EmojiHunter.GameData
{
    using EmojiHunter.GameAnimation;

    public interface IShooting
    {
        int RangedDamage { get; set; }

        float ShootingSpeed { get; }

        float ShootingDelay { get; }

        SpellShotType ShotType { get; }
    }
}
