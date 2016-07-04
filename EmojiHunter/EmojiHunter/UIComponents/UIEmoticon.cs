using EmojiHunter.GameAnimation;
using EmojiHunter.GameData;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace EmojiHunter.UIComponents
{
    public class UIEmoticon : IUIObject
    {
        private readonly Dictionary<Direction, Vector2> MotionByDirection =
            new Dictionary<Direction, Vector2>()
            {
                [Direction.Right] = new Vector2(1, 0),
                [Direction.UpRight] = new Vector2(1, -1),
                [Direction.Up] = new Vector2(0, -1),
                [Direction.UpLeft] = new Vector2(-1, -1),
                [Direction.Left] = new Vector2(-1, 0),
                [Direction.DownLeft] = new Vector2(-1, 1),
                [Direction.Down] = new Vector2(0, 1),
                [Direction.DownRight] = new Vector2(1, 1),
                [Direction.None] = new Vector2(0, 0)
            };

        private Vector2 position;
        private Direction direction = Direction.Right; // Hardcoded initial direction

        public UIEmoticon(AnimatedSprite sprite, Emoticon emoticon)
        {
            Sprite = sprite;
            Emoticon = emoticon;
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
            if (this.direction == Direction.Left && this.position.X < 0)
            {

                this.direction = Direction.Right;
            }

            if (this.direction == Direction.Right && this.position.X > 1600 - Sprite.Rectangle.Width) // ISSUE - hardcoded
            {

                this.direction = Direction.Left;
            }

            this.position += 5 * MotionByDirection[direction]; // this.Emoticon.MovementSpeed - hardcoded
            this.Sprite.Position = this.position;
        }

        public void SetInStartPosition(float x, float y)
        {
            position.X = x;
            position.Y = y;

            Sprite.Position = position;
        }
    }
}

