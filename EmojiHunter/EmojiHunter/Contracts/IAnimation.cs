namespace EmojiHunter.Contracts
{
    using Microsoft.Xna.Framework;

    public interface IAnimation : IDrawable
    {
        Vector2 Position { get; set; }

        Vector2 Size { get; set; }

        void PlayAnimation(GameTime gameTime);
    }
}
