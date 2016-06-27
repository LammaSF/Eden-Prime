using EmojiHunter.GameAnimation;
using EmojiHunter.GameData;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EmojiHunter.UIComponents
{
    internal class UIEmoticon
    {
        private Vector2 position;

        public UIEmoticon(AnimatedSprite sprite, Emoticon emoticon)
        {
            Sprite = sprite;
            Emoticon = emoticon;
        }

        public AnimatedSprite Sprite { get; set; }
        public Emoticon Emoticon { get; set; }

        public void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);               
        }

        public void SetInStartPosition(float x, float y)
        {
            position.X = x;
            position.Y = y;

            Sprite.Position = position;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }
    }
}

