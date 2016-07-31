﻿namespace EmojiHunter.GUIModels
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
        private UIHero uiHero;

        private SpriteData spriteData;

        private bool isShooting;

        private int lastShotElapsedTime;

        private IMoveBehavior moveBehavior;

        public UIEmoticon(SpriteData spriteData, IGameObject emoticon, ISprite sprite, UIHero uiHero)
        {
            this.spriteData = spriteData;
            this.Sprite = sprite;
            this.GameObject = emoticon;
            this.GameObject.Destroy += this.OnDestroyEventHandler;
            this.isShooting = emoticon is IShooting;
            this.uiHero = uiHero;
        }

        public Vector2 Position { get; set; }

        public Vector2 Direction { get; set; }

        public ISprite Sprite { get; set; }

        public IGameObject GameObject { get; set; }

        public IMoveBehavior MoveBehavior
        {
            set
            {
                this.moveBehavior = value;
            }
        }

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
            this.Position = new Vector2(x, y);
            this.Sprite.Position = this.Position;
        }

        private void CheckForEmoticonObjectCollision()
        {
            foreach (var uiObject in UIObjectContainer.UIObjects)
            {
                if (this != uiObject
                    && this.Sprite.Rectangle.Intersects(uiObject.Sprite.Rectangle))
                {
                    this.GameObject.ReactOnCollision(uiObject.GameObject);
                    this.Direction = -this.Direction;
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

                var positionX = this.Position.X + this.Sprite.Rectangle.Width / 2 - uiShot.Sprite.Rectangle.Width / 2;
                var positionY = this.Position.Y + this.Sprite.Rectangle.Height / 2 - uiShot.Sprite.Rectangle.Height / 2;

                uiShot.SetStartPosition(positionX, positionY);

                var differenceX = positionX - this.uiHero.Position.X;
                var differenceY = positionY - this.uiHero.Position.Y;
                int sign = (differenceX >= 0) ? -1 : 1;
                var shootingAngle = Math.Atan(differenceY / differenceX);
                var directionX = sign * (float)Math.Cos(shootingAngle);
                var directionY = sign * (float)Math.Sin(shootingAngle);

                uiShot.SetDirection(directionX, directionY);

                this.lastShotElapsedTime = 0;
            }
        }

        private void Move()
        {
            this.moveBehavior.Move(this);
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
