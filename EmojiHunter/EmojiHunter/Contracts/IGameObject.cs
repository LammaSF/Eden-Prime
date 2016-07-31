namespace EmojiHunter.Contracts
{
    public interface IGameObject : IDestroyable, ICollidable
    {
        IReward Reward { get; set; }

        IState State { get; set; }
    }
}
