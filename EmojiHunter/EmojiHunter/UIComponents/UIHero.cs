using EmojiHunter.GameAnimation;
using EmojiHunter.GameData;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

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

    public enum HeroState
    {
        Normal = 0,
        Shielded,
        Mirrored,
        Invisible,
        Frozen
    }


    public class UIHero : IUIObject
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

        private HeroState state;
        private InputManager inputManager;
        private Vector2 position;
        private Vector2 motion;
        private Direction lastDirection;
        private List<UIShot> uiShots;
        private AnimatedSprite spellShotSprite;
        private float lastShotElapsedTime;
        private float lastTeleportElapsedTime;

        public UIHero(AnimatedSprite sprite, Hero hero, UISight uiSight, AnimatedSprite spellShotSprite)
        {
            this.inputManager = InputManager.Instance;
            this.Sprite = sprite;
            this.Hero = hero;
            this.UISight = uiSight;
            this.spellShotSprite = spellShotSprite;
            this.spellShotSprite.AnimationIndex = 2;
            this.uiShots = new List<UIShot>();
        }

        public AnimatedSprite Sprite { get; set; }
        public Hero Hero { get; set; }
        public UISight UISight { get; set; }

        public void Update(GameTime gameTime)
        {
            this.inputManager.Update();
            CheckKeyboardInput(gameTime);
            Sprite.Update(gameTime);
            UISight.Update(gameTime);
            foreach (var uiShot in uiShots)
            {
                uiShot.Update(gameTime);
            }
        }

        private void CheckKeyboardInput(GameTime gameTime)
        {
            bool keyDown = inputManager.KeyDown(Keys.Down);
            bool keyLeft = inputManager.KeyDown(Keys.Left);
            bool keyRight = inputManager.KeyDown(Keys.Right);
            bool keyUp = inputManager.KeyDown(Keys.Up);
            bool keyShoot = inputManager.KeyDown(Keys.S);
            bool keyRotateLeft = inputManager.KeyDown(Keys.A);
            bool keyRotateRight = inputManager.KeyDown(Keys.D);
            bool keyTeleport = inputManager.KeyDown(Keys.T);
            bool keySprint = inputManager.IsKeyReleased(Keys.LeftShift);
            bool keyShield = inputManager.IsKeyReleased(Keys.Q);
            bool keyMirror = inputManager.IsKeyReleased(Keys.W);
            bool keyInvisible = inputManager.IsKeyReleased(Keys.E);

            if (keyUp && keyLeft)
                Move(1 + (int)this.state * 4, Direction.UpLeft); // move up left
            else if (keyUp && keyRight)
                Move(2 + (int)this.state * 4, Direction.UpRight); // move up right
            else if (keyDown && keyLeft)
                Move(1 + (int)this.state * 4, Direction.DownLeft); // move down left
            else if (keyDown && keyRight)
                Move(2 + (int)this.state * 4, Direction.DownRight); // move down right
            else if (keyDown)
                Move(0 + (int)this.state * 4, Direction.Down); // move down
            else if (keyLeft)
                Move(1 + (int)this.state * 4, Direction.Left); // move left
            else if (keyRight)
                Move(2 + (int)this.state * 4, Direction.Right); // move right
            else if (keyUp)
                Move(3 + (int)this.state * 4, Direction.Up); // move up

            if (keyRotateLeft)
            {
                Hero.ShootingAngle += Hero.SightSpeed;
            }
            else if (keyRotateRight)
            {
                Hero.ShootingAngle -= Hero.SightSpeed;
            }

            UISight.Move(Hero.ShootingAngle, this.position);

            lastShotElapsedTime += gameTime.ElapsedGameTime.Milliseconds;
            if (keyShoot)
            {
                if (lastShotElapsedTime > 500)
                {
                    var uiShot = new UIShot(this.spellShotSprite, Hero.ShootingSpeed);
                    uiShot.SetInStartPosition(this.position.X, this.position.Y);

                    var motionX = (float)Math.Cos(Hero.ShootingAngle * Math.PI / 180);
                    var motionY = (float)Math.Sin(Hero.ShootingAngle * Math.PI / 180);

                    uiShot.SetInMotion(motionX, motionY);

                    uiShots.Add(uiShot); //ISSUE: We never dispose of the shots!
                    lastShotElapsedTime = 0;
                }
            }

            lastTeleportElapsedTime += gameTime.ElapsedGameTime.Milliseconds;
            if (keyTeleport)
            {
                if (lastTeleportElapsedTime > 1000)
                {
                    Teleport();
                    lastTeleportElapsedTime = 0;
                }
            }

            if (keySprint)
            {
                Hero.IsRunning = (Hero.IsRunning == true)
                    ? false
                    : true;
            }

            // ISSUE hero should move to update visual state
            if (keyInvisible)
            {
                this.state = (this.state == HeroState.Invisible)
                    ? HeroState.Normal
                    : HeroState.Invisible;
            }

            if (keyShield)
            {
                this.state = (this.state == HeroState.Shielded)
                    ? HeroState.Normal
                    : HeroState.Shielded;
            }

            if (keyMirror)
            {
                this.state = (this.state == HeroState.Mirrored)
                    ? HeroState.Normal
                    : HeroState.Mirrored;
            }

            CheckForHeroObjectCollision();
        }

        private void CheckForHeroObjectCollision()
        {
            foreach (var uiObject in UIObjectContainer.UIObjects)
            {
                if (this != uiObject)
                {
                    if (this.Sprite.Rectangle.Intersects(uiObject.Sprite.Rectangle))
                    {
                        this.position -= this.Hero.MovementSpeed * this.motion;
                        this.Sprite.Position = this.position;
                    }

                    if (uiObject is UIEmoticon)
                    {
                        //TO DO
                    }

                    if (uiObject is UIShot)
                    {
                        //TO DO
                    }
                }
            }
        }

        private void Teleport()
        {
            if (lastDirection != Direction.None)
            {
                this.position += 150 * MotionByDirection[lastDirection];
                this.Sprite.Position = this.position;
            }
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
            UISight.Draw(spriteBatch);

            foreach (var uiShot in uiShots)
            {
                uiShot.Draw(spriteBatch);
            }
        }
    }
}
