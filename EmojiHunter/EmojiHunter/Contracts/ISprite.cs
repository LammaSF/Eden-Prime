namespace EmojiHunter.Contracts
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public interface ISprite : IUpdateable, IDrawable
    {
        ulong ID { get; }

        string Name { get; set; }

        int AnimationIndex { get; set; }

        Rectangle Rectangle { get; }

        Vector2 Position { get; set; }

        void SetSize(int width, int height);

        void AddAnimation(Texture2D texture, Rectangle frame, double frameDuration, int frameCount);
    }
}
