namespace EmojiHunter.UIComponents
{
    using EmojiHunter.GameAnimation;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public interface IUIObject
    {
        AnimatedSprite Sprite { get; set; }

        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch);
    }
}
