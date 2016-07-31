namespace EmojiHunter.IO
{
    using System;
    using System.Collections.Generic;
    using Animations;
    using Helpers;
    using Models.Miscellaneous;
    using Models.Heroes;
    using Enumerations;
    using GUIModels;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using UIComponents;

    public class HeroActionController : Contracts.IUpdateable
    {
        private const int SprintCostDelay = 200; // in ms

        private const int TeleportDelay = 1000; // in ms

        private const int TeleportStep = 150;

        private readonly Dictionary<Direction, Vector2> directions =
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

        private SpriteData spriteData;

        private HeroState state;

        private UIHero uiHero;

        private Sagittarius sagittarius;

        private InputManager inputManager;

        private Direction lastDirection;

        private float lastShotElapsedTime;

        private float lastTeleportElapsedTime;

        private int elapsedTime;

        public HeroActionController(UIHero uiHero, SpriteData spriteData, InputManager inputManager)
        {
            this.uiHero = uiHero;
            this.sagittarius = this.uiHero.GameObject as Sagittarius;
            this.spriteData = spriteData;
            this.inputManager = inputManager;
        }
        
        public void Update(GameTime gameTime)
        {
            this.elapsedTime += gameTime.ElapsedGameTime.Milliseconds;
            this.inputManager.Update();
            this.CheckKeyboardInput(gameTime);

            if (this.sagittarius.IsRunning && this.elapsedTime >= SprintCostDelay)
            {
                this.sagittarius.Strength -= this.sagittarius.SprintStrengthCost;
            }

            this.elapsedTime %= SprintCostDelay;
        }

        private void CheckKeyboardInput(GameTime gameTime)
        {
            this.ProcessMovement();
            this.ProcessShootingAngle();
            this.uiHero.UISight.Move(this.sagittarius.ShootingAngle, this.uiHero.Position);
            this.ProcessShootingSpellType();
            this.ProcessShooting(gameTime);
            this.ProcessTeleportation(gameTime);
            this.ProcessSprint();
        }

        private void ProcessShootingAngle()
        {
            bool keyRotateLeft = this.inputManager.KeyDown(Keys.A);
            bool keyRotateRight = this.inputManager.KeyDown(Keys.D);

            if (keyRotateLeft)
            {
                this.sagittarius.ShootingAngle += this.sagittarius.SightSpeed;
            }
            else if (keyRotateRight)
            {
                this.sagittarius.ShootingAngle -= this.sagittarius.SightSpeed;
            }
        }

        private void ProcessShootingSpellType()
        {
            bool keySunball = this.inputManager.KeyDown(Keys.Q);
            bool keyIceball = this.inputManager.KeyDown(Keys.W);

            if (keySunball)
            {
                this.sagittarius.ShotType = SpellShotType.Sunball;
            }
            else if (keyIceball)
            {
                this.sagittarius.ShotType = SpellShotType.Iceball;
            }
        }

        private void ProcessMovement()
        {
            bool keyDown = this.inputManager.KeyDown(Keys.Down);
            bool keyLeft = this.inputManager.KeyDown(Keys.Left);
            bool keyRight = this.inputManager.KeyDown(Keys.Right);
            bool keyUp = this.inputManager.KeyDown(Keys.Up);

            if (keyUp && keyLeft)
            {
                //// move up left
                this.Move(1 + (int)this.state * 4, Direction.UpLeft);
            }
            else if (keyUp && keyRight)
            {
                //// move up right
                this.Move(2 + (int)this.state * 4, Direction.UpRight);
            }
            else if (keyDown && keyLeft)
            {
                //// move down left
                this.Move(1 + (int)this.state * 4, Direction.DownLeft);
            }
            else if (keyDown && keyRight)
            {
                //// move down right
                this.Move(2 + (int)this.state * 4, Direction.DownRight);
            }
            else if (keyDown)
            {
                //// move down
                this.Move(0 + (int)this.state * 4, Direction.Down);
            }
            else if (keyLeft)
            {
                //// move left
                this.Move(1 + (int)this.state * 4, Direction.Left);
            }
            else if (keyRight)
            {
                //// move right
                this.Move(2 + (int)this.state * 4, Direction.Right);
            }
            else if (keyUp)
            {
                //// move up
                this.Move(3 + (int)this.state * 4, Direction.Up);
            }
        }

        private void ProcessSprint()
        {
            bool keySprint = this.inputManager.IsKeyReleased(Keys.LeftShift);
            if (keySprint)
            {
                if (this.sagittarius.Strength > 0)
                {
                    this.sagittarius.IsRunning = (this.sagittarius.IsRunning != true);
                }
            }

            if (this.sagittarius.Strength == 0)
            {
                this.sagittarius.IsRunning = false;
            }
        }

        private void ProcessTeleportation(GameTime gameTime)
        {
            bool keyTeleport = this.inputManager.KeyDown(Keys.T);
            this.lastTeleportElapsedTime += gameTime.ElapsedGameTime.Milliseconds;
            if (keyTeleport)
            {
                if (this.lastTeleportElapsedTime > TeleportDelay
                    && this.sagittarius.Mana >= this.sagittarius.TeleportManaCost)
                {
                    this.Teleport();
                    this.sagittarius.Mana -= this.sagittarius.TeleportManaCost;
                    this.lastTeleportElapsedTime = 0;
                }
            }
        }

        private void ProcessShooting(GameTime gameTime)
        {
            bool keyShoot = this.inputManager.KeyDown(Keys.S);
            this.lastShotElapsedTime += gameTime.ElapsedGameTime.Milliseconds;
            if (keyShoot)
            {
                if (this.lastShotElapsedTime > this.sagittarius.ShootingDelay
                    && this.sagittarius.Mana >= this.sagittarius.ShootingManaCost)
                {
                    this.sagittarius.Mana -= this.sagittarius.ShootingManaCost;

                    var shot = new Shot(
                        nameof(Sagittarius),
                        this.sagittarius.ShotType,
                        this.sagittarius.Damage,
                        this.sagittarius.ShootingSpeed
                    );

                    var sprite = this.spriteData.DuplicateSprite("SpellShot");
                    sprite.AnimationIndex = (int)this.sagittarius.ShotType;

                    var uiShot = new UIShot(shot, sprite);
                    uiShot.SetStartPosition(
                        this.uiHero.Position.X + this.uiHero.Sprite.Rectangle.Width / 2 -
                            uiShot.Sprite.Rectangle.Width / 2,
                        this.uiHero.Position.Y + this.uiHero.Sprite.Rectangle.Height / 2 -
                            uiShot.Sprite.Rectangle.Height / 2);

                    var motionX = (float)Math.Cos(this.sagittarius.ShootingAngle
                        * Math.PI / 180);
                    var motionY = -(float)Math.Sin(this.sagittarius.ShootingAngle
                        * Math.PI / 180);

                    uiShot.SetDirection(motionX, motionY);

                    this.lastShotElapsedTime = 0;
                }
            }
        }

        private void Teleport()
        {
            if (this.lastDirection != Direction.None)
            {
                this.uiHero.Position += TeleportStep * this.directions[this.lastDirection];
                this.uiHero.Sprite.Position = this.uiHero.Position;
            }
        }

        private void Move(int animationIndex, Direction direction)
        {
            if (this.lastDirection != direction)
            {
                this.uiHero.Sprite.AnimationIndex = animationIndex;
                this.lastDirection = direction;
                this.uiHero.Direction = this.directions[direction];
            }

            this.uiHero.Position += this.sagittarius.State.MovementSpeed * this.uiHero.Direction;
            this.uiHero.Sprite.Position = this.uiHero.Position;

            if (this.IsOutsideMapBorders())
            {
                this.uiHero.Position -= this.sagittarius.State.MovementSpeed * this.uiHero.Direction;
                this.uiHero.Sprite.Position = this.uiHero.Position;
            }
        }

        private bool IsOutsideMapBorders()
        {
            // Hardcoded much ?!
            return this.uiHero.Position.X < 0
                || this.uiHero.Position.Y < 0
                || this.uiHero.Position.X > Global.ScreenWidth - this.uiHero.Sprite.Rectangle.Width
                || this.uiHero.Position.Y > Global.ScreenHeight - this.uiHero.Sprite.Rectangle.Height;
        }

    }
}
