using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EmojiHunter.UIComponents
{
    internal class UIEmoticon
    {
        private Vector2 motion;
        private Vector2 position;

        private float ballSpeed = 2;

        private Texture2D texture;
        private Rectangle screenBounds;
        private Rectangle destRect;
        private Rectangle sourceRect;

        float elapsed;
        float delay = 250f;
        int frames = 0;

        public UIEmoticon(Texture2D texture, Rectangle screenBounds)
        {
            this.texture = texture;
            this.screenBounds = screenBounds;
            this.destRect = new Rectangle((int)position.X, (int)position.Y, 50, 50);
            this.sourceRect = new Rectangle(0, 0, 50, 50);
        }

        public void Update(GameTime gameTime)
        {
            elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (elapsed >= delay)
            {
                if (frames >= 9)
                {
                    frames = 0;
                }
                else
                {
                    frames++;
                }
                elapsed = 0;
            }

            this.sourceRect.X = 50 * frames;

            position += motion * ballSpeed;
            CheckWallCollision();
            this.destRect.X = (int)position.X;
            this.destRect.Y = (int)position.Y;
            

        }

        private void CheckWallCollision()
        {
            if (position.X < 0)
            {
                position.X = 0;
                motion.X *= -1;
            }
            if (position.X + 50 > screenBounds.Width)
            {
                position.X = screenBounds.Width - 50;
                motion.X *= -1;
            }
            if (position.Y < 0)
            {
                position.Y = 0;
                motion.Y *= -1;
            }
            if (position.Y + 50 > screenBounds.Height)
            {
                position.Y = screenBounds.Height - 50;
                motion.Y *= -1;
            }
        }

        public void SetInStartPosition()
        {
            motion = new Vector2(1, -1);

            position.X = 100;
            position.Y = 100;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, destRect, sourceRect, Color.White);
        }
    }
}

