namespace EmojiHunter.Animations
{
    using System.Collections.Generic;
    using Contracts;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class AnimatedSprite : ISprite
    {
        private static ulong id;

        private Rectangle rectangle;

        private List<IAnimation> animations;

        public AnimatedSprite()
        {
            this.animations = new List<IAnimation>();
        }

        public AnimatedSprite(AnimatedSprite sprite)
        {
            this.animations = new List<IAnimation>();

            foreach (var animation in sprite.animations)
            {
                this.animations.Add(new Animation((Animation   )animation));
            }

            this.rectangle = new Rectangle(sprite.Rectangle.X, sprite.Rectangle.Y,
                sprite.Rectangle.Width, sprite.Rectangle.Height);
            this.ID = AnimatedSprite.id;
            AnimatedSprite.id++;
        }

        public AnimatedSprite(Texture2D texture, Rectangle frame, float frameDuration, int frameCount) : this()
        {
            this.AddAnimation(texture, frame, frameDuration, frameCount);
        }

        public ulong ID { get; private set; }

        public string Name { get; set; }

        public int AnimationIndex { get; set; }

        public Rectangle Rectangle => this.rectangle;

        public Vector2 Position
        {
            get
            {
                return this.animations[this.AnimationIndex].Position;
            }

            set
            {
                this.animations[this.AnimationIndex].Position = value;
                this.rectangle.X = (int)value.X;
                this.rectangle.Y = (int)value.Y;
            }
        }

        public void SetSize(int width, int height)
        {
            this.rectangle.Width = width;
            this.rectangle.Height = height;
        }

        public void AddAnimation(Texture2D texture, Rectangle frame, double frameDuration, int frameCount)
        {
            var animation = new Animation(texture, frame, frameDuration, frameCount);
            this.animations.Add(animation);
        }

        public void Update(GameTime gameTime)
        {
            this.animations[this.AnimationIndex].PlayAnimation(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.animations[this.AnimationIndex].Draw(spriteBatch);
        }
    }
}
