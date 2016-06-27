using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace EmojiHunter.GameAnimation
{
    internal class AnimatedSprite
    {
        private List<Animation> animations;

        public AnimatedSprite(AnimatedSprite sprite)
        {
            this.animations = sprite.animations;
        }

        public AnimatedSprite(Texture2D texture, Rectangle frame, float frameDuration, int frameCount)
        {
            this.animations = new List<Animation>();
            AddAnimation(texture, frame, frameDuration, frameCount);
        }

        public string Name { get; set; }
        public int AnimationIndex { get; set; }
        public Vector2 Position
        {
            get
            {
                return animations[AnimationIndex].Position;
            }

            set
            {
                animations[AnimationIndex].Position = value;
            }
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
