using EmojiHunter.GameAnimation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EmojiHunter.UIComponents
{
    public class UIShot
    {
        private float speed;
        private Vector2 position;
        private Vector2 motion;

        public UIShot(AnimatedSprite sprite, int speed)
        {
            Sprite = sprite;
            this.speed = speed;
        }

        public AnimatedSprite Sprite { get; set; }

        public void Update(GameTime gameTime)
        {
            Move();
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

        public void SetInMotion(float x, float y)
        {
            this.motion.X = x;
            this.motion.Y = y;
        }

        public void Move()
        {
            this.position += this.motion * this.speed;
            this.Sprite.Position = this.position;
        }
    }
}
