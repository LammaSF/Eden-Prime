namespace EmojiHunter.Contracts
{
    using Enumerations;

    public interface IShooting
    {
        float ShootingSpeed { get; set; }

        float ShootingDelay { get; set; }

        SpellShotType ShotType { get; set; }
    }
}
