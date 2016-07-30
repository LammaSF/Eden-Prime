namespace EmojiHunter.Contracts
{
    using EmojiHunter.Enumerations;

    public interface IShot
    {
        string ID { get; }

        SpellShotType Type { get; }
    }
}
