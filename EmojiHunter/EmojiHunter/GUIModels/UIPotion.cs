namespace EmojiHunter.GUIModels
{
    using System;
    using Contracts;
    using Animations;
    using Repository;
    using Helpers;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class UIPotion : IUIObject
    {
        public UIPotion(IGameObject potion, AnimatedSprite sprite)
        {
            this.GameObject = potion;
            this.GameObject.Destroy += this.OnDestroyEventHandler;
            this.Sprite = sprite;
        }

        public ISprite Sprite { get; set; }

        public IGameObject GameObject { get; set; }

        public void Update(GameTime gameTime)
        {
            this.Sprite.Update(gameTime);    
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.Sprite.Draw(spriteBatch);
        }

        private void OnDestroyEventHandler(object sender, EventArgs e)
        {
            UIPotionGenerator.CurrentPotionCount--;
            UIObjectContainer.RemoveUIObject(this.Sprite.ID);
            this.GameObject.Destroy -= this.OnDestroyEventHandler;
        }
    }
}
