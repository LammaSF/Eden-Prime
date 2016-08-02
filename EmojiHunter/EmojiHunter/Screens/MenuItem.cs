namespace EmojiHunter.Screens
{
    using System;
    using EmojiHunter.UIComponents;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class MenuItem
    {
        private SpriteFont font;

        private string message;

        private Vector2 position;

        public MenuItem(SpriteFont font, string message, Vector2 position, Color color)
        {
            this.font = font;
            this.message = message;
            this.position = position;
            this.Color = color;
        }

        public Color Color { get; set; }

        public event EventHandler Pressed;

        public void PressMenuItem()
        {
            this.Pressed?.Invoke(this, EventArgs.Empty);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(
                this.font,
                this.message,
                this.position,
                this.Color,
                0f,
                new Vector2(0, 0), 
                new Vector2(2, 2),
                SpriteEffects.None, 
                0f);
        }
    }
}
