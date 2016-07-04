using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EmojiHunter.GameAnimation
{
    internal class Animation
    {
        private Texture2D texture;
        private Rectangle frame;
        private double elapsedTime;
        private double frameDuration;
        private int frameStartPositionX;
        private int frameStartPositionY;
        private int frameWidth;
        private int frameHeight;
        private int frameCount;
        private int currentFrame;

        public Animation(Animation animation)
        {
            this.texture = animation.texture;
            this.frame = animation.frame;
            this.frameStartPositionX = animation.frame.X;
            this.frameStartPositionY = animation.frame.Y;
            this.frameWidth = animation.frame.Width;
            this.frameHeight = animation.frame.Height;
            this.frameDuration = animation.frameDuration;
            this.frameCount = animation.frameCount;
        }

        public Animation(Texture2D texture, Rectangle frame, double frameDuration, int frameCount)
        {
            this.texture = texture;
            this.frame = frame;
            this.frameStartPositionX = frame.X;
            this.frameStartPositionY = frame.Y;
            this.frameWidth = frame.Width;
            this.frameHeight = frame.Height;
            this.frameDuration = frameDuration;
            this.frameCount = frameCount;
        }

        public Vector2 Position { get; set; }

        public void PlayAnimation(GameTime gameTime)
        {
            elapsedTime += gameTime.ElapsedGameTime.Milliseconds;
            frame.X = frameStartPositionX + currentFrame * frameWidth;

            if (elapsedTime >= frameDuration)
            {
                currentFrame = (currentFrame + 1) % frameCount;
                elapsedTime = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, Position, this.frame, Color.White);
        }

    }
}
