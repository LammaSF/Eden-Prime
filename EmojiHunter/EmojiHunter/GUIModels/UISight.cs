namespace EmojiHunter.GUIModels
{
    using System;
    using Contracts;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class UISight : Contracts.IDrawable, Contracts.IUpdateable
    {
        private const int HeroSpriteSize = 32;

        private const double DistanceToHero = 1.5;

        private ISprite sprite;

        private Vector2 position;

        public UISight(ISprite sprite)
        {
            this.sprite = sprite;
        }

        public void Update(GameTime gameTime)
        {
            this.sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.sprite.Draw(spriteBatch);
        }

        public void SetInStartPosition(float x, float y)
        {
            this.position.X = x;
            this.position.Y = y;

            this.sprite.Position = this.position;
        }

        public void Move(float angle, Vector2 heroPosition)
        {
            int offsetX =
                (int)(DistanceToHero * HeroSpriteSize * Math.Cos(angle * Math.PI / 180));
            int offsetY =
                -(int)(DistanceToHero * HeroSpriteSize * Math.Sin(angle * Math.PI / 180));

            this.position.X = heroPosition.X + HeroSpriteSize / 4 + offsetX;
            this.position.Y = heroPosition.Y + HeroSpriteSize / 4 + offsetY;

            this.sprite.Position = this.position;
        }
    }
}
