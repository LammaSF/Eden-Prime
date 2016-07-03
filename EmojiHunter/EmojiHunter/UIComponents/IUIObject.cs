using EmojiHunter.GameAnimation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EmojiHunter.UIComponents
{
    public interface IUIObject
    {
        AnimatedSprite Sprite { get; set; }

        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch);
    }
}
