using System;
using EmojiHunter.GameAnimation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EmojiHunter.UIComponents
{
    public class UISight
    {
        private const int HeroSpriteSize = 32;
        private const double DistanceToHero = 1.5;
        private Vector2 position;

        public UISight(AnimatedSprite sprite)
        {
            Sprite = sprite;
        }

        public AnimatedSprite Sprite { get; set; }

        public void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }

        public void SetInStartPosition(float x, float y)
        {
            position.X = x;
            position.Y = y;

            Sprite.Position = position;
        }

        public void Move(float angle, Vector2 heroPosition)
        {
            int offsetX =
                (int)(DistanceToHero * HeroSpriteSize * Math.Cos(angle * Math.PI / 180));
            int offsetY =
                -(int)(DistanceToHero * HeroSpriteSize * Math.Sin(angle * Math.PI / 180));

            this.position.X = heroPosition.X + (HeroSpriteSize / 4) + offsetX;
            this.position.Y = heroPosition.Y + (HeroSpriteSize / 4) + offsetY;

            this.Sprite.Position = this.position;
        }
    }
}
