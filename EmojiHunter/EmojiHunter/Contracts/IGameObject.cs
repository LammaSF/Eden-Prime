namespace EmojiHunter.Contracts
{
    public interface IGameObject : IDestroyable, ICollidable
    {
        IReward Reward { get; }

        IState State { get; set; }
    }
}
