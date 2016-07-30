namespace EmojiHunter.Contracts
{
    public interface IUIObject : IUpdateable, IDrawable
    {
        ISprite Sprite { get; set; }

        IGameObject GameObject { get; set; }
    }
}
