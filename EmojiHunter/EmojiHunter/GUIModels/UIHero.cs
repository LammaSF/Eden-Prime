namespace EmojiHunter.GUIModels
{
    using Contracts;
    using Repository;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class UIHero : IUIObject
    {
        private const int AdjustionConstant = 2;

        public UIHero(ISprite sprite, IGameObject hero, UISight uiSight)
        {
            this.GameObject = hero;
            this.Sprite = sprite;
            this.UISight = uiSight; 
        }

        public ISprite Sprite { get; set; }

        public IGameObject GameObject { get; set; }

        public UISight UISight { get; }

        public Vector2 Direction { get; set; }

        public Vector2 Position { get; set; }

        public void SetStartPosition(Vector2 position)
        {
            this.Position = position;
            this.Sprite.Position = position;
        }

        public void Update(GameTime gameTime)
        {
            this.CheckForHeroObjectCollision(gameTime);
            this.Sprite.Update(gameTime);
            this.UISight.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.Sprite.Draw(spriteBatch);
            this.UISight.Draw(spriteBatch);
        }

        private void CheckForHeroObjectCollision(GameTime gameTime)
        {
            foreach (var uiObject in UIObjectContainer.UIObjects)
            {
                if (this != uiObject
                    && this.Sprite.Rectangle.Intersects(uiObject.Sprite.Rectangle))
                {
                    this.ExecuteHeroObjectCollision(gameTime, uiObject);
                    this.AdjustPosition();
                }
            }
        }

        private void ExecuteHeroObjectCollision(GameTime gameTime, IUIObject uiObject)
        {
            this.GameObject.ReactOnCollision(uiObject.GameObject);
            uiObject.GameObject.ReactOnCollision(this.GameObject);
        }

        private void AdjustPosition()
        {
            this.Position -= AdjustionConstant * this.Direction;
            this.Sprite.Position = this.Position;
        }
    }
}
