using System;
using EmojiHunter.GameAnimation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EmojiHunter.UIComponents
{
    public class UIPotion : IUIObject
    {
        public UIPotion(AnimatedSprite sprite)
        {
            this.Sprite = sprite;
        }

        public AnimatedSprite Sprite { get; set; }

        public void Update(GameTime gameTime)
        {
            this.Sprite.Update(gameTime);    
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.Sprite.Draw(spriteBatch);
        }

    }
}
