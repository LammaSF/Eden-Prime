using EmojiHunter.GameAnimation;
using EmojiHunter.GameData;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace EmojiHunter.UIComponents
{
    public enum Direction
    {
        Right,
        UpRight,
        Up,
        UpLeft,
        Left,
        DownLeft,
        Down,
        DownRight,
        None
    }

    public class UIHero
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

        private InputManager inputManager;
        private Vector2 position;
        private Vector2 motion;
        private Direction lastDirection;

        public UIHero(AnimatedSprite sprite, Hero hero)
        {
            this.inputManager = InputManager.Instance;
            Sprite = sprite;
            Hero = hero;
        }

        public AnimatedSprite Sprite { get; set; }
        public Hero Hero { get; set; }

        public void Update(GameTime gameTime)
        {
            this.inputManager.Update();
            CheckKeyboardInput();
            Sprite.Update(gameTime);
        }

        private void CheckKeyboardInput()
        {
            bool keyDown = inputManager.KeyDown(Keys.Down);
            bool keyLeft = inputManager.KeyDown(Keys.Left);
            bool keyRight = inputManager.KeyDown(Keys.Right);
            bool keyUp = inputManager.KeyDown(Keys.Up);
            bool keyShoot = inputManager.KeyDown(Keys.S);
            bool keyRotateLeft = inputManager.KeyDown(Keys.A);
            bool keyRotateRight = inputManager.KeyDown(Keys.D);
            bool keyTeleport = inputManager.KeyDown(Keys.T);

            if (keyUp && keyLeft)
                Move(1, Direction.UpLeft); // move up left
            else if (keyUp && keyRight)
                Move(2, Direction.UpRight); // move up right
            else if (keyDown && keyLeft)
                Move(1, Direction.DownLeft); // move down left
            else if (keyDown && keyRight)
                Move(2, Direction.DownRight); // move down right
            else if (keyDown)
                Move(0, Direction.Down); // move down
            else if (keyLeft)
                Move(1, Direction.Left); // move left
            else if (keyRight)
                Move(2, Direction.Right); // move right
            else if (keyUp)
                Move(3, Direction.Up); // move up
        }

        private void Move(int animationIndex, Direction direction)
        {
            if (this.lastDirection != direction)
            {
                this.Sprite.AnimationIndex = animationIndex;
                this.lastDirection = direction;
                this.motion = MotionByDirection[direction];
            }

            this.position += this.Hero.MovementSpeed * this.motion;
            this.Sprite.Position = this.position;
        }

        public void SetInStartPosition(float x, float y)
        {
            position.X = x;
            position.Y = y;

            Sprite.Position = position;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }
    }
}
