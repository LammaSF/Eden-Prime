namespace EmojiHunter.UIComponents
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using System;
    using System.Collections.Generic;

    using GameAnimation;
    using GameData;
    using GameData.Emoticons;
    using GameData.Heroes;
    using GameHelpers;

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

        private SpriteFont font;

        private SpriteData spriteData;

        private HeroState state;

        private InputManager inputManager;

        private Vector2 motion;

        private Direction lastDirection;

        private float lastShotElapsedTime;

        private float lastTeleportElapsedTime;

        private float lastHeroEmoticonCollisionElapsedTime;

        private int elapsedTime;

        private Sagittarius sagittarius;

        private Aquarius aquarius;

        public UIHero(ContentManager content, SpriteData spriteData, Hero hero)
        {
            this.inputManager = InputManager.Instance;
            this.font = content.Load<SpriteFont>(@"Content\Font");
            this.spriteData = spriteData;

            this.Hero = hero;

            if (hero is Sagittarius)
            {
                this.sagittarius = hero as Sagittarius;
            }
            else
            {
                this.aquarius = hero as Aquarius;
            }

            this.Sprite = spriteData.DuplicateSprite(this.Hero.Name);
            this.UISight = new UISight(spriteData.DuplicateSprite("Sight"));
        }

        public AnimatedSprite Sprite { get; set; }

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

            if (this.sagittarius != null)
            {
                this.CheckKeyboardInputSagittarius(gameTime);

                this.UISight.Update(gameTime);
            }
            else
            {
                this.CheckKeyboardInputAquarius(gameTime);
            }

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
                UISight.Draw(spriteBatch);
            }

            spriteBatch.DrawString(
                this.font,
                $"Health: {this.Hero.Health} / {this.Hero.CurrentMaxHealth}",
                new Vector2(20, 20),
                Color.Red);

            spriteBatch.DrawString(
                this.font,
                $"Armor: {this.Hero.Armor} / {Hero.MaxArmor}",
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

        private void CheckKeyboardInputAquarius(GameTime gameTime)
        {
            this.ProcessMovement();

            this.ProcessTeleportation(gameTime);

            this.ProcessSprint();

            //// ISSUE hero should move to update visual state  

            this.ProcessInvisibility();

            this.ProcessShield();

            this.ProcessMirror();

            this.CheckForHeroObjectCollision(gameTime);
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
                this.Move(1 + ((int)this.state * 4), Direction.UpLeft);
            }
            else if (keyUp && keyRight)
            {
                //// move up right
                this.Move(2 + ((int)this.state * 4), Direction.UpRight);
            }
            else if (keyDown && keyLeft)
            {
                //// move down left
                this.Move(1 + ((int)this.state * 4), Direction.DownLeft);
            }
            else if (keyDown && keyRight)
            {
                //// move down right
                this.Move(2 + ((int)this.state * 4), Direction.DownRight);
            }
            else if (keyDown)
            {
                //// move down
                this.Move(0 + ((int)this.state * 4), Direction.Down);
            }
            else if (keyLeft)
            {
                //// move left
                this.Move(1 + ((int)this.state * 4), Direction.Left);
            }
            else if (keyRight)
            {
                //// move right
                this.Move(2 + ((int)this.state * 4), Direction.Right);
            }
            else if (keyUp)
            {
                //// move up
                this.Move(3 + ((int)this.state * 4), Direction.Up);
            }
        }

        private void ProcessMirror()
        {
            bool keyMirror = this.inputManager.IsKeyReleased(Keys.W);
            if (keyMirror)
            {
                this.state = (this.state == HeroState.Mirrored)
                    ? HeroState.Normal
                    : HeroState.Mirrored;
            }
        }

        private void ProcessShield()
        {
            bool keyShield = this.inputManager.IsKeyReleased(Keys.Q);
            if (keyShield)
            {
                this.state = (this.state == HeroState.Shielded)
                    ? HeroState.Normal
                    : HeroState.Shielded;
            }
        }

        private void ProcessInvisibility()
        {
            bool keyInvisible = this.inputManager.IsKeyReleased(Keys.E);
            if (keyInvisible)
            {
                this.state = (this.state == HeroState.Invisible)
                    ? HeroState.Normal
                    : HeroState.Invisible;
            }
        }

        private void ProcessSprint()
        {
            bool keySprint = this.inputManager.IsKeyReleased(Keys.LeftShift);
            if (keySprint)
            {
                if (this.Hero.Strength > 0)
                {
                    this.Hero.IsRunning = (Hero.IsRunning == true)
                        ? false
                        : true;
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

                    var shot = new Shot()
                    {
                        ID = "Hero",
                        Damage = this.sagittarius.RangedDamage,
                        Type = this.sagittarius.ShotType
                    };

                    var sprite = this.spriteData.DuplicateSprite("SpellShot");
                    sprite.AnimationIndex = (int)this.sagittarius.ShotType;

                    var uiShot = new UIShot(shot, sprite, this.sagittarius.ShootingSpeed);
                    uiShot.SetInStartPosition(
                        this.Position.X + (this.Sprite.Rectangle.Width / 2) -
                            (uiShot.Sprite.Rectangle.Width / 2),
                        this.Position.Y + (this.Sprite.Rectangle.Height / 2) -
                            (uiShot.Sprite.Rectangle.Height / 2));

                    var motionX = (float)Math.Cos(this.sagittarius.ShootingAngle
                        * Math.PI / 180);
                    var motionY = -(float)Math.Sin(this.sagittarius.ShootingAngle
                        * Math.PI / 180);

                    uiShot.SetInMotion(motionX, motionY);

                    UIObjectContainer.AddUIObject(uiShot);
                    this.lastShotElapsedTime = 0;
                }
            }
        }

        private void CheckForHeroObjectCollision(GameTime gameTime)
        {
            foreach (var uiObject in UIObjectContainer.UIObjects)
            {
                if (this != uiObject)
                {
                    if (this.Sprite.Rectangle.Intersects(uiObject.Sprite.Rectangle))
                    {
                        this.Position -= this.Hero.MovementSpeed * this.motion;
                        this.Sprite.Position = this.Position;

                        this.ExecuteHeroObjectCollision(gameTime, uiObject);
                    }
                }
            }
        }

        private void ExecuteHeroObjectCollision(GameTime gameTime, IUIObject uiObject)
        {
            if (uiObject is UIEmoticon)
            {
                var uiEmoticon = uiObject as UIEmoticon;

                if (uiEmoticon.Emoticon is GoodEmoticon)
                {
                    var goodEmoticon = uiEmoticon.Emoticon as GoodEmoticon;

                    goodEmoticon.Reward.AddReward(this.Hero);

                    if (this.Hero.Armor == 0)
                    {
                        this.Hero.Health -= goodEmoticon.State.Damage;
                    }
                    else
                    {
                        this.Hero.Armor -= goodEmoticon.State.Damage;
                    }

                    UIEmoticonGenerator.CurrentEmoticonCount--;
                    UIObjectContainer.RemoveUIObject(uiEmoticon.Sprite.ID);
                }
                else
                {
                    var badEmoticon = uiEmoticon.Emoticon as BadEmoticon;

                    this.lastHeroEmoticonCollisionElapsedTime +=
                        gameTime.ElapsedGameTime.Milliseconds;

                    if (this.lastHeroEmoticonCollisionElapsedTime >
                        badEmoticon.AttackSpeed)
                    {
                        if (this.Hero.Armor == 0)
                        {
                            this.Hero.Health -= badEmoticon.Damage;
                        }
                        else
                        {
                            this.Hero.Armor -= badEmoticon.Damage;
                        }

                        if (badEmoticon.Armor == 0)
                        {
                            badEmoticon.Health -= this.Hero.Damage;
                        }
                        else
                        {
                            badEmoticon.Armor -= this.Hero.Damage;
                        }

                        if (badEmoticon.Health == 0)
                        {
                            UIObjectContainer.RemoveUIObject(uiEmoticon.Sprite.ID);
                            UIEmoticonGenerator.CurrentEmoticonCount--;
                            Global.Kills++;
                            Global.Points += 5;
                        }

                        this.lastHeroEmoticonCollisionElapsedTime %= badEmoticon.AttackSpeed;
                    }
                }
            }
            else if (uiObject is UIShot)
            {
                var uiShot = (UIShot)uiObject;

                if (uiShot.Shot.ID != "Hero")
                {
                    if (this.Hero.Armor == 0)
                    {
                        this.Hero.Health -= uiShot.Shot.Damage;
                    }
                    else
                    {
                        this.Hero.Armor -= uiShot.Shot.Damage;
                    }

                    UIObjectContainer.RemoveUIObject(uiShot.Sprite.ID);
                }
            }
            else if (uiObject is UIPotion)
            {
                var uiPotion = (UIPotion)uiObject;

                switch (uiPotion.Potion.Type)
                {
                    case PotionType.HealthPotion:
                        this.Hero.Health += Potion.Value;
                        break;
                    case PotionType.ArmorPotion:
                        this.Hero.Armor += Potion.Value;
                        break;
                    case PotionType.ManaPotion:
                        this.Hero.Mana += Potion.Value;
                        break;
                    case PotionType.StrengthPotion:
                        this.Hero.Strength += Potion.Value;
                        break;
                    case PotionType.Length:
                        break;
                }

                UIPotionGenerator.CurrentPotionCount--;
                UIObjectContainer.RemoveUIObject(uiPotion.Sprite.ID);
            }
        }

        private void Teleport()
        {
            if (this.lastDirection != Direction.None)
            {
                this.Position += 150 * this.MotionByDirection[this.lastDirection];
                this.Sprite.Position = this.Position;
            }
        }

        private void Move(int animationIndex, Direction direction)
        {
            if (this.lastDirection != direction)
            {
                this.Sprite.AnimationIndex = animationIndex;
                this.lastDirection = direction;
                this.motion = this.MotionByDirection[direction];
            }

            this.Position += this.Hero.MovementSpeed * this.motion;
            this.Sprite.Position = this.Position;

            if (this.IsOutsideMapBorders())
            {
                this.Position -= this.Hero.MovementSpeed * this.motion;
                this.Sprite.Position = this.Position;
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
