namespace EmojiHunter.GUIModels
{
    using System;
    using Animations;
    using Contracts;
    using Helpers;
    using Models.Emoticons;
    using Models.Miscellaneous;
    using Repository;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class UIEmoticon : IUIObject
    {
        private SpriteData spriteData;

        private Vector2 position;

        private Vector2 direction;

        private Random random = new Random();

        private bool isShooting;

        private int lastShotElapsedTime;

        public UIEmoticon(SpriteData spriteData, IGameObject emoticon, ISprite sprite)
        {
            this.spriteData = spriteData;
            this.Sprite = sprite;
            this.GameObject = emoticon;
            this.GameObject.Destroy += this.OnDestroyEventHandler;
            this.direction = new Vector2(this.GetRandomFloat(), this.GetRandomFloat());
            this.isShooting = emoticon is IShooting;
        }

        public ISprite Sprite { get; set; }

        public IGameObject GameObject { get; set; }

        public void Update(GameTime gameTime)
        {
            if (this.isShooting)
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

        public void SetStartPosition(float x, float y)
        {
            this.position.X = x;
            this.position.Y = y;

            this.Sprite.Position = this.position;
        }

        private void CheckForEmoticonObjectCollision()
        {
            foreach (var uiObject in UIObjectContainer.UIObjects)
            {
                if (this != uiObject
                    && this.Sprite.Rectangle.Intersects(uiObject.Sprite.Rectangle))
                {
                    this.GameObject.ReactOnCollision(uiObject.GameObject);
                    this.direction = -this.direction;
                }
            }
        }

        private void Shoot(GameTime gameTime)
        {
            var emoticon = this.GameObject as IShooting;

            this.lastShotElapsedTime += gameTime.ElapsedGameTime.Milliseconds;
            if (this.lastShotElapsedTime > emoticon.ShootingDelay)
            {
                var shot = new Shot(
                    (this.GameObject as Emoticon).Name + nameof(Emoticon),
                    emoticon.ShotType,
                    this.GameObject.State.Damage,
                    emoticon.ShootingSpeed
                    );

                var sprite = this.spriteData.DuplicateSprite("SpellShot");
                sprite.AnimationIndex = (int)(emoticon).ShotType;

                var uiShot = new UIShot(shot, sprite);
                uiShot.SetStartPosition(
                    this.position.X + this.Sprite.Rectangle.Width / 2 -
                        uiShot.Sprite.Rectangle.Width / 2,
                    this.position.Y + this.Sprite.Rectangle.Height / 2 -
                        uiShot.Sprite.Rectangle.Height / 2);

                var motionX = (float)Math.Cos(this.random.Next(360) * Math.PI / 180);
                var motionY = -(float)Math.Sin(this.random.Next(360) * Math.PI / 180);

                uiShot.SetDirection(motionX, motionY);

                this.lastShotElapsedTime = 0;
            }
        }

        private void Move()
        {
            if (this.direction.X < 0 && this.position.X < 0) // if leave the screen while moving left
            {
                this.direction = new Vector2(Math.Abs(this.GetRandomFloat()), this.GetRandomFloat()); // move right
            }

            if (this.direction.X > 0 && this.position.X > 1600 - this.Sprite.Rectangle.Width) // ISSUE - hardcoded
            {
                this.direction = new Vector2(-Math.Abs(this.GetRandomFloat()), this.GetRandomFloat());
            }

            if (this.direction.Y < 0 && this.position.Y < 0)
            {
                this.direction = new Vector2(this.GetRandomFloat(), Math.Abs(this.GetRandomFloat()));
            }

            if (this.direction.Y > 0 && this.position.Y > 900 - this.Sprite.Rectangle.Height) // ISSUE - hardcoded
            {
                this.direction = new Vector2(this.GetRandomFloat(), -Math.Abs(this.GetRandomFloat()));
            }

            this.direction.Normalize(); // get unit velocity vector

            this.position += this.GameObject.State.MovementSpeed * this.direction;
            this.Sprite.Position = this.position;
        }

        private float GetRandomFloat()
        {
            return (float)((new Random()).NextDouble() * 2 - 1);
        }

        private void OnDestroyEventHandler(object sender, EventArgs e)
        {
            UIObjectContainer.RemoveUIObject(this.Sprite.ID);
            UIEmoticonGenerator.CurrentEmoticonCount--;
            Global.Kills++;
            Global.Points += 5;

            this.GameObject.Destroy -= this.OnDestroyEventHandler;
        }
    }
}
