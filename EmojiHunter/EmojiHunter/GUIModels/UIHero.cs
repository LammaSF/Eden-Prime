namespace EmojiHunter.GUIModels
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Animations;
    using Helpers;
    using Models.Heroes;
    using Repository;
    using Enumerations;
    using Models.Miscellaneous;
    using UIComponents;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class UIHero : IUIObject
    {
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

        private SpriteFont font;

        private SpriteData spriteData;

        private HeroState state;

        private InputManager inputManager;

        private Vector2 direction;

        private Direction lastDirection;

        private float lastShotElapsedTime;

        private float lastTeleportElapsedTime;

        private float lastHeroEmoticonCollisionElapsedTime;

        private int elapsedTime;

        private Sagittarius sagittarius;

        public UIHero(ContentManager content, SpriteData spriteData, Hero hero)
        {
            this.inputManager = InputManager.Instance;
            this.font = content.Load<SpriteFont>(@"Content\Font");
            this.spriteData = spriteData;

            this.Hero = hero;
            this.GameObject = hero;

            if (hero is Sagittarius)
            {
                this.sagittarius = hero as Sagittarius;
            }

            this.Sprite = spriteData.DuplicateSprite(this.Hero.Name);
            this.UISight = new UISight(spriteData.DuplicateSprite("Sight"));
        }

        public ISprite Sprite { get; set; }

        public IGameObject GameObject { get; set; }

        public Hero Hero { get; set; }

        public UISight UISight { get; set; }

        public Vector2 Position { get; private set; }

        public void SetInStartPosition(Vector2 position)
        {
            this.Position = position;
            this.Sprite.Position = position;
        }

        public void Update(GameTime gameTime)
        {
            this.inputManager.Update();

            this.elapsedTime += gameTime.ElapsedGameTime.Milliseconds;

            this.CheckKeyboardInputSagittarius(gameTime);

            this.UISight.Update(gameTime);

            this.Sprite.Update(gameTime);

            if (this.Hero.IsRunning && this.elapsedTime >= 200)
            {
                this.Hero.Strength -= this.Hero.SprintStrengthCost;
            }

            this.elapsedTime %= 200;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.Sprite.Draw(spriteBatch);

            if (this.sagittarius != null)
            {
                this.UISight.Draw(spriteBatch);
            }

            spriteBatch.DrawString(
                this.font,
                $"Health: {this.Hero.Health} / {this.Hero.CurrentMaxHealth}",
                new Vector2(20, 20),
                Color.Red);

            spriteBatch.DrawString(
                this.font,
                $"Armor: {this.Hero.Armor} / {this.Hero.CurrentMaxArmor}",
                new Vector2(20, 50),
                Color.GreenYellow);

            spriteBatch.DrawString(
                this.font,
                $"Mana: {this.Hero.Mana} / {this.Hero.CurrentMaxMana}",
                new Vector2(20, 80),
                Color.Blue);

            spriteBatch.DrawString(
                this.font,
                $"Strength: {this.Hero.Strength} / {this.Hero.CurrentMaxStrength}",
                new Vector2(20, 110),
                Color.Yellow);

            spriteBatch.DrawString(this.font,
                $"Kills: {Global.Kills}",
                new Vector2(20, 140),
                Color.Black);

            spriteBatch.DrawString(this.font,
                $"Points:  {Global.Points}",
                new Vector2(20, 170),
                Color.Black);
        }

        private void CheckKeyboardInputSagittarius(GameTime gameTime)
        {
            this.ProcessMovement();

            this.ProcessShootingAngle();

            this.UISight.Move(this.sagittarius.ShootingAngle, this.Position);

            this.ProcessShooting(gameTime);

            this.ProcessTeleportation(gameTime);

            this.ProcessSprint();

            this.CheckForHeroObjectCollision(gameTime);
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
                if (this.Hero.Strength > 0)
                {
                    this.Hero.IsRunning = (this.Hero.IsRunning != true);
                }
            }

            if (this.Hero.Strength == 0)
            {
                this.Hero.IsRunning = false;
            }
        }

        private void ProcessTeleportation(GameTime gameTime)
        {
            bool keyTeleport = this.inputManager.KeyDown(Keys.T);
            this.lastTeleportElapsedTime += gameTime.ElapsedGameTime.Milliseconds;
            if (keyTeleport)
            {
                if (this.lastTeleportElapsedTime > 1000
                    && this.Hero.Mana >= this.Hero.TeleportManaCost)
                {
                    this.Teleport();
                    this.Hero.Mana -= this.Hero.TeleportManaCost;
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
                    && this.Hero.Mana >= this.sagittarius.ShootingManaCost)
                {
                    this.Hero.Mana -= this.sagittarius.ShootingManaCost;

                    var shot = new Shot(
                        nameof(Sagittarius),
                        this.sagittarius.ShotType,
                        this.Hero.Damage,
                        this.sagittarius.ShootingSpeed
                    );

                    var sprite = this.spriteData.DuplicateSprite("SpellShot");
                    sprite.AnimationIndex = (int)this.sagittarius.ShotType;

                    var uiShot = new UIShot(shot, sprite);
                    uiShot.SetStartPosition(
                        this.Position.X + this.Sprite.Rectangle.Width / 2 -
                            uiShot.Sprite.Rectangle.Width / 2,
                        this.Position.Y + this.Sprite.Rectangle.Height / 2 -
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
            this.Position -= this.Hero.State.MovementSpeed * this.direction;
            this.Sprite.Position = this.Position;
        }

        private void Teleport()
        {
            if (this.lastDirection != Direction.None)
            {
                this.Position += 150 * this.directions[this.lastDirection];
                this.Sprite.Position = this.Position;
            }
        }

        private void Move(int animationIndex, Direction direction)
        {
            if (this.lastDirection != direction)
            {
                this.Sprite.AnimationIndex = animationIndex;
                this.lastDirection = direction;
                this.direction = this.directions[direction];
            }

            this.Position += this.Hero.State.MovementSpeed * this.direction;
            this.Sprite.Position = this.Position;

            if (this.IsOutsideMapBorders())
            {
                this.AdjustPosition();
            }
        }

        private bool IsOutsideMapBorders()
        {
            // Hardcoded much ?!
            return this.Position.X < 0
                || this.Position.Y < 0
                || this.Position.X > 1600 - this.Sprite.Rectangle.Width
                || this.Position.Y > 900 - this.Sprite.Rectangle.Height;
        }
    }
}
