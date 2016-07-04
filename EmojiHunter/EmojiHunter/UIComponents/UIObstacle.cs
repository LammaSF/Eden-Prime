using EmojiHunter.GameAnimation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EmojiHunter.UIComponents
{
    public class UIObstacle : IUIObject
    {
        public UIObstacle(AnimatedSprite sprite)
        {
            this.Sprite = sprite;
        }

        public AnimatedSprite Sprite { get; set; }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.Sprite.Draw(spriteBatch);
        }
    }
}
