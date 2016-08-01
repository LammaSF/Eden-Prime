namespace EmojiHunter.Animations
{
    using Contracts;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class Animation : IAnimation
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
            this.Size = animation.Size;
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

        public Vector2 Size { get; set; }

        public Rectangle Rectangle => new Rectangle((int) this.Position.X, (int) this.Position.Y, (int) this.Size.X, (int) this.Size.Y);

        public void PlayAnimation(GameTime gameTime)
        {
            this.elapsedTime += gameTime.ElapsedGameTime.Milliseconds;
            this.frame.X = this.frameStartPositionX + (this.currentFrame * this.frameWidth);

            if (this.elapsedTime >= this.frameDuration)
            {
                this.currentFrame = (this.currentFrame + 1) % this.frameCount;
                this.elapsedTime = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.Rectangle, this.frame, Color.White);
        }
    }
}
