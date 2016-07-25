using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace EmojiHunter.GameAnimation
{
    public class AnimatedSprite
    {
        private static ulong id;

        private Rectangle rectangle;

        private List<Animation> animations;

        public AnimatedSprite()
        {
            this.animations = new List<Animation>();
        }

        public AnimatedSprite(AnimatedSprite sprite)
        {
            this.animations = new List<Animation>();

            foreach (var animation in sprite.animations)
            {
                animations.Add(new Animation(animation));
            }

            this.rectangle = new Rectangle(sprite.Rectangle.X, sprite.Rectangle.Y,
                sprite.Rectangle.Width, sprite.Rectangle.Height);
            this.ID = AnimatedSprite.id;
            AnimatedSprite.id++;
        }

        public AnimatedSprite(Texture2D texture, Rectangle frame, float frameDuration, int frameCount) : this()
        {
            AddAnimation(texture, frame, frameDuration, frameCount);
        }

        public ulong ID { get; private set; }

        public string Name { get; set; }

        public int AnimationIndex { get; set; }

        public Rectangle Rectangle => this.rectangle;

        public Vector2 Position
        {
            get
            {
                return animations[AnimationIndex].Position;
            }

            set
            {
                animations[AnimationIndex].Position = value;
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
            this.animations[AnimationIndex].PlayAnimation(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.animations[AnimationIndex].Draw(spriteBatch);
        }
    }
}
