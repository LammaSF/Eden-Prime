namespace EmojiHunter.Contracts
{
    public interface IReward
    {
        int Health { get; set; }

        int Mana { get; set; }

        int Damage { get; set; }

        int Strength { get; set; }

        float Speed { get; set; }
    }
}
