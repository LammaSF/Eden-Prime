using EmojiHunter.GameAnimation;
using EmojiHunter.GameData;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;

namespace EmojiHunter.UIComponents
{
    public class UIEmoticon : IUIObject
    {
        private Vector2 position;
        private Vector2 direction;
        private Random random = new Random();

        public UIEmoticon(AnimatedSprite sprite, Emoticon emoticon)
        {
            Sprite = sprite;
            Emoticon = emoticon;
            this.direction = new Vector2(GetRandomFloat(), GetRandomFloat());
        }

        public AnimatedSprite Sprite { get; set; }

        public Emoticon Emoticon { get; set; }

        public void Update(GameTime gameTime)
        {
            Move();
            Sprite.Update(gameTime);
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

