namespace EmojiHunter.Contracts
{
    public interface IReward
    {
        int Health { get; }

        int Mana { get; }

        int Damage { get; }

        int Strength { get; }

        float Speed { get; }
    }
}
