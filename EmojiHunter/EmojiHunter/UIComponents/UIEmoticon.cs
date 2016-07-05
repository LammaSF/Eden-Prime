using EmojiHunter.GameAnimation;
using EmojiHunter.GameData;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace EmojiHunter.UIComponents
{
    public class UIEmoticon : IUIObject
    {
        private SpriteData spriteData;

        private Vector2 position;

        private Vector2 direction;

        private Random random = new Random();

        private int lastShotElapsedTime;

        public UIEmoticon(SpriteData spriteData, AnimatedSprite sprite, Emoticon emoticon)
        {
            this.spriteData = spriteData;
            this.Sprite = sprite;
            this.Emoticon = emoticon;
            this.direction = new Vector2(GetRandomFloat(), GetRandomFloat());
        }

        public AnimatedSprite Sprite { get; set; }

        public Emoticon Emoticon { get; set; }

        public void Update(GameTime gameTime)
        {
            if (this.Emoticon is IShooting)
            {
                Shoot(gameTime);
            }

            Move();

            Sprite.Update(gameTime);
        }

        private void Shoot(GameTime gameTime)
        {
            var emoticon = this.Emoticon as IShooting;

            lastShotElapsedTime += gameTime.ElapsedGameTime.Milliseconds;
            if (lastShotElapsedTime > emoticon.ShootingDelay)
            {
                var shot = new Shot()
                {
                    ID = this.Emoticon.Name,
                    Damage = emoticon.RangedDamage,
                    Type = emoticon.ShotType
                };

                var sprite = this.spriteData.DuplicateSprite("SpellShot");
                sprite.AnimationIndex = (int)(this.Emoticon as IShooting).ShotType;

                var uiShot = new UIShot(shot, sprite, emoticon.ShootingSpeed);
                uiShot.SetInStartPosition(
                    this.position.X + this.Sprite.Rectangle.Width / 2 -
                        uiShot.Sprite.Rectangle.Width / 2,
                    this.position.Y + this.Sprite.Rectangle.Height / 2 -
                        uiShot.Sprite.Rectangle.Height / 2
                    );

                var motionX = (float)Math.Cos(this.random.Next(360) * Math.PI / 180);
                var motionY = -(float)Math.Sin(this.random.Next(360) * Math.PI / 180);

                uiShot.SetInMotion(motionX, motionY);

                UIObjectContainer.AddUIObject(uiShot);
                lastShotElapsedTime = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }

        private void Move()
        {
            if (this.direction.X < 0 && this.position.X < 0) // if leave the screen while moving left
            {

                this.direction = new Vector2(Math.Abs(GetRandomFloat()), GetRandomFloat()); // move right
            }

            if (this.direction.X > 0 && this.position.X > 1600 - Sprite.Rectangle.Width) // ISSUE - hardcoded
            {

                this.direction = new Vector2(-Math.Abs(GetRandomFloat()), GetRandomFloat());
            }

            if (this.direction.Y < 0 && this.position.Y < 0)
            {

                this.direction = new Vector2(GetRandomFloat(), Math.Abs(GetRandomFloat()));
            }

            if (this.direction.Y > 0 && this.position.Y > 900 - Sprite.Rectangle.Height) // ISSUE - hardcoded
            {
                this.direction = new Vector2(GetRandomFloat(), -Math.Abs(GetRandomFloat()));
            }

            this.direction.Normalize(); // get unit velocity vector

            this.position += 5 * this.direction; // this.Emoticon.MovementSpeed - hardcoded
            this.Sprite.Position = this.position;
        }

        public void SetInStartPosition(float x, float y)
        {
            position.X = x;
            position.Y = y;

            Sprite.Position = position;
        }

        private float GetRandomFloat()
        {
            return (float)((new Random()).NextDouble() * 2 - 1);
        }
    }
}

