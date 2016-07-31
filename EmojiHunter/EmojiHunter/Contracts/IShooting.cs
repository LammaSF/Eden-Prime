namespace EmojiHunter.Contracts
{
    using Enumerations;

    public interface IShooting
    {
        float ShootingSpeed { get; }

        float ShootingDelay { get; }

        SpellShotType ShotType { get; set; }
    }
}
