namespace EmojiHunter.UIComponents
{
    using EmojiHunter.GameAnimation;
    using EmojiHunter.GameData;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class UIPotion : IUIObject
    {
        public UIPotion(Potion potion, AnimatedSprite sprite)
        {
            this.Potion = potion;
            this.Sprite = sprite;
        }

        public Potion Potion { get; set; }

        public AnimatedSprite Sprite { get; set; }

        public void Update(GameTime gameTime)
        {
            this.Sprite.Update(gameTime);    
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.Sprite.Draw(spriteBatch);
        }
    }
}
