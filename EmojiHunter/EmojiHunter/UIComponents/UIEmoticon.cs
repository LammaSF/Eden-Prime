namespace EmojiHunter.UIComponents
{
    using System;
    using EmojiHunter.GameAnimation;
    using EmojiHunter.GameData;
    using EmojiHunter.GameData.Emoticons;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class UIEmoticon : IUIObject
    {
        private SpriteData spriteData;

        private Vector2 position;

        private Vector2 direction;

        private Random random = new Random();

        private bool isGoodEmoticon;

        private int lastShotElapsedTime;

        public UIEmoticon(SpriteData spriteData, AnimatedSprite sprite, Emoticon emoticon)
        {
            this.spriteData = spriteData;
            this.Sprite = sprite;
            this.Emoticon = emoticon;
            this.isGoodEmoticon = emoticon is GoodEmoticon;
            this.direction = new Vector2(this.GetRandomFloat(), this.GetRandomFloat());
        }

        public AnimatedSprite Sprite { get; set; }

        public Emoticon Emoticon { get; set; }

        public void Update(GameTime gameTime)
        {
            if (this.Emoticon is IShooting)
            {
                this.Shoot(gameTime);
            }

            this.Move();

            this.CheckForEmoticonObjectCollision();

            this.Sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.Sprite.Draw(spriteBatch);
        }

        public void SetInStartPosition(float x, float y)
        {
            this.position.X = x;
            this.position.Y = y;

            this.Sprite.Position = this.position;
        }

        private void CheckForEmoticonObjectCollision()
        {
            foreach (var uiObject in UIObjectContainer.UIObjects)
            {
                if (this != uiObject)
                {
                    if (this.Sprite.Rectangle.Intersects(uiObject.Sprite.Rectangle))
                    {
                        if (!(uiObject is UIShot))
                        {
                            this.direction = -this.direction;
                        }

                        if (uiObject is UIEmoticon
                            && !this.isGoodEmoticon)
                        {
                            var uiEmoticon = (uiObject as UIEmoticon);

                            if (uiEmoticon.isGoodEmoticon)
                            {
                                (uiEmoticon.Emoticon as GoodEmoticon).SetCrazyState();
                                uiEmoticon.Sprite.AnimationIndex = 3;
                            }
                        }
                    }
                }
            }
        }

        private void Shoot(GameTime gameTime)
        {
            var emoticon = this.Emoticon as IShooting;

            this.lastShotElapsedTime += gameTime.ElapsedGameTime.Milliseconds;
            if (this.lastShotElapsedTime > emoticon.ShootingDelay)
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
                    this.position.X + (this.Sprite.Rectangle.Width / 2) -
                        (uiShot.Sprite.Rectangle.Width / 2),
                    this.position.Y + (this.Sprite.Rectangle.Height / 2) -
                        (uiShot.Sprite.Rectangle.Height / 2));

                var motionX = (float)Math.Cos(this.random.Next(360) * Math.PI / 180);
                var motionY = -(float)Math.Sin(this.random.Next(360) * Math.PI / 180);

                uiShot.SetInMotion(motionX, motionY);

                UIObjectContainer.AddUIObject(uiShot);
                this.lastShotElapsedTime = 0;
            }
        }

        private void Move()
        {
            //// if leave the screen while moving left
            if (this.direction.X < 0 && this.position.X < 0) 
            {
                //// move right
                this.direction = new Vector2(Math.Abs(this.GetRandomFloat()), this.GetRandomFloat()); 
            }

            //// ISSUE - hardcoded
            if (this.direction.X > 0 && this.position.X > 1600 - this.Sprite.Rectangle.Width) 
            {
                this.direction = new Vector2(-Math.Abs(this.GetRandomFloat()), this.GetRandomFloat());
            }

            if (this.direction.Y < 0 && this.position.Y < 0)
            {
                this.direction = new Vector2(this.GetRandomFloat(), Math.Abs(this.GetRandomFloat()));
            }

            //// ISSUE - hardcoded
            if (this.direction.Y > 0 && this.position.Y > 900 - this.Sprite.Rectangle.Height) 
            {
                this.direction = new Vector2(this.GetRandomFloat(), -Math.Abs(this.GetRandomFloat()));
            }

            //// get unit velocity vector
            this.direction.Normalize(); 

            this.position += this.Emoticon.MovementSpeed * this.direction;
            this.Sprite.Position = this.position;
        }

        private float GetRandomFloat()
        {
            return (float)(((new Random()).NextDouble() * 2) - 1);
        }
    }
}
