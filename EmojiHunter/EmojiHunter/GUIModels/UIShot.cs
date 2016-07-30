namespace EmojiHunter.GUIModels
{
    using System;
    using Contracts;
    using EmojiHunter.Repository;
    using Helpers;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class UIShot : IUIObject
    {
        private float speed;

        private Vector2 position;

        private Vector2 direction;

        public UIShot(IGameObject gameObject, ISprite sprite)
        {
            this.GameObject = gameObject;
            this.GameObject.Destroy += this.OnDestroyEventHandler;
            this.speed = gameObject.State.MovementSpeed;
            this.Sprite = sprite;
            UIObjectContainer.AddUIObject(this);
        }

        public ISprite Sprite { get; set; }

        public IGameObject GameObject { get; set; }

        public void Update(GameTime gameTime)
        {
            this.Move();

            this.CheckForShotObjectCollision();

            if (this.IsOutsideMapBorders())
            {
                UIObjectContainer.RemoveUIObject(this.Sprite.ID);
                return;
            }

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

        public void SetDirection(float x, float y)
        {
            this.direction.X = x;
            this.direction.Y = y;
        }

        private bool IsOutsideMapBorders()
        {
            return this.position.X < -this.Sprite.Rectangle.Width
                || this.position.Y < -this.Sprite.Rectangle.Height
                || this.position.X > Global.ScreenWidth + this.Sprite.Rectangle.Width
                || this.position.Y > Global.ScreenHeight + this.Sprite.Rectangle.Height;
        }

        private void Move()
        {
            this.position += this.direction * this.speed;
            this.Sprite.Position = this.position;
        }

        private void CheckForShotObjectCollision()
        {
            foreach (var uiObject in UIObjectContainer.UIObjects)
            {
                if (this != uiObject
                    && this.Sprite.Rectangle.Intersects(uiObject.Sprite.Rectangle))
                {
                    this.ExecuteObjectCollision(uiObject);
                }
            }
        }

        private void ExecuteObjectCollision(IUIObject uiObject)
        {
            this.GameObject.ReactOnCollision(uiObject.GameObject);
            uiObject.GameObject.ReactOnCollision(this.GameObject);
        }

        private void OnDestroyEventHandler(object sender, EventArgs e)
        {
            UIObjectContainer.RemoveUIObject(this.Sprite.ID);
            this.GameObject.Destroy -= this.OnDestroyEventHandler;
        }
    }
}
