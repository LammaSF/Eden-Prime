namespace EmojiHunter.GUIModels
{
    using Contracts;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class UIObstacle : IUIObject
    {
        public UIObstacle(IGameObject obstacle, ISprite sprite)
        {
            this.Sprite = sprite;
            this.GameObject = obstacle;
        }

        public ISprite Sprite { get; set; }

        public IGameObject GameObject { get; set; }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.Sprite.Draw(spriteBatch);
        }
    }
}
