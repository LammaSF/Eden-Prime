using EmojiHunter.GameAnimation;
using EmojiHunter.GameData;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using EmojiHunter.GameData.Emoticons;
using Microsoft.Xna.Framework.Content;
using EmojiHunter.GameHelpers;

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

        private SpriteFont font;

        private SpriteData spriteData;

        private HeroState state;

        private InputManager inputManager;

        private Vector2 motion;

        private Direction lastDirection;

        private float lastShotElapsedTime;

        private float lastTeleportElapsedTime;

        private float lastHeroEmoticonCollisionElapsedTime;

        public UIHero(ContentManager content, SpriteData spriteData, Hero hero)
        {
            this.inputManager = InputManager.Instance;
            this.font = content.Load<SpriteFont>(@"Content\Font");
            this.spriteData = spriteData; 

            this.Hero = hero;
            this.Sprite = spriteData.DuplicateSprite(this.Hero.Name);
            this.UISight = new UISight(spriteData.DuplicateSprite("Sight"));
        }

        public AnimatedSprite Sprite { get; set; }

        public Hero Hero { get; set; }

        public UISight UISight { get; set; }

        public Vector2 Position { get; private set; }

        public void SetInStartPosition(Vector2 position)
        {
            Position = position;
            Sprite.Position = position;
        }

        public void Update(GameTime gameTime)
        {
            this.inputManager.Update();
            CheckKeyboardInput(gameTime);
            Sprite.Update(gameTime);
            UISight.Update(gameTime);            
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
            UISight.Draw(spriteBatch);

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
                $"Kills: {this.Hero.Kills}",
                new Vector2(20, 140), 
                Color.Black);

            spriteBatch.DrawString(this.font,
                $"Points:  {this.Hero.Points}",
                new Vector2(20, 170),
                Color.Black);
        }

        private void CheckKeyboardInput(GameTime gameTime)
        {
            ProcessMovement(inputManager.KeyDown);

            ProcessShootingAngle(inputManager.KeyDown);

            UISight.Move(Hero.ShootingAngle, this.Position);            

            ProcessShooting(inputManager.KeyDown, gameTime);

            ProcessTeleportation(inputManager.KeyDown, gameTime);

            ProcessSprint(inputManager.IsKeyReleased);
            
            // ISSUE hero should move to update visual state            
      
            ProcessInvisibility(inputManager.IsKeyReleased);

            ProcessShield(inputManager.IsKeyReleased);

            ProcessMirror(inputManager.IsKeyReleased);            

            CheckForHeroObjectCollision(gameTime);
        }

        private void ProcessShootingAngle(Func<Keys[], bool> keyDown)
        {
            bool keyRotateLeft = inputManager.KeyDown(Keys.A);
            bool keyRotateRight = inputManager.KeyDown(Keys.D);

            if (keyRotateLeft)
            {
                Hero.ShootingAngle += Hero.SightSpeed;
            }
            else if (keyRotateRight)
            {
                Hero.ShootingAngle -= Hero.SightSpeed;
            }
        }

        private void ProcessMovement(Func<Keys[], bool> key)
        {
            bool keyDown = inputManager.KeyDown(Keys.Down);
            bool keyLeft = inputManager.KeyDown(Keys.Left);
            bool keyRight = inputManager.KeyDown(Keys.Right);
            bool keyUp = inputManager.KeyDown(Keys.Up);

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
        }

        private void ProcessMirror(Func<Keys[], bool> key)
        {
            bool keyMirror = inputManager.IsKeyReleased(Keys.W);
            if (keyMirror)
            {
                this.state = (this.state == HeroState.Mirrored)
                    ? HeroState.Normal
                    : HeroState.Mirrored;
            }
        }

        private void ProcessShield(Func<Keys[], bool> key)
        {
            bool keyShield = inputManager.IsKeyReleased(Keys.Q);
            if (keyShield)
            {
                this.state = (this.state == HeroState.Shielded)
                    ? HeroState.Normal
                    : HeroState.Shielded;
            }
        }

        private void ProcessInvisibility(Func<Keys[], bool> key)
        {
            bool keyInvisible = inputManager.IsKeyReleased(Keys.E);
            if (keyInvisible)
            {
                this.state = (this.state == HeroState.Invisible)
                    ? HeroState.Normal
                    : HeroState.Invisible;
            }
        }

        private void ProcessSprint(Func<Keys[], bool> key)
        {
            bool keySprint = inputManager.IsKeyReleased(Keys.LeftShift);
            if (keySprint)
            {
                Hero.IsRunning = (Hero.IsRunning == true)
                    ? false
                    : true;
            }
        }

        private void ProcessTeleportation(Func<Keys[], bool> key, GameTime gameTime)
        {
            bool keyTeleport = inputManager.KeyDown(Keys.T);
            lastTeleportElapsedTime += gameTime.ElapsedGameTime.Milliseconds;
            if (keyTeleport)
            {
                if (lastTeleportElapsedTime > 1000)
                {
                    Teleport();
                    lastTeleportElapsedTime = 0;
                }
            }
        }

        private void ProcessShooting(Func<Keys[], bool> keyDown, GameTime gameTime)
        {
            bool keyShoot = inputManager.KeyDown(Keys.S);
            lastShotElapsedTime += gameTime.ElapsedGameTime.Milliseconds;
            if (keyShoot)
            {
                if (lastShotElapsedTime > 500)
                {
                    var shot = new Shot()
                    {
                        ID = "Hero",
                        Damage = this.Hero.RangedDamage,
                        Type = this.Hero.ShotType
                    };

                    var sprite = this.spriteData.DuplicateSprite("SpellShot");
                    sprite.AnimationIndex = (int)this.Hero.ShotType;

                    var uiShot = new UIShot(shot, sprite, Hero.ShootingSpeed);
                    uiShot.SetInStartPosition(
                        this.Position.X + this.Sprite.Rectangle.Width / 2 - 
                            uiShot.Sprite.Rectangle.Width / 2,
                        this.Position.Y + this.Sprite.Rectangle.Height / 2 -
                            uiShot.Sprite.Rectangle.Height / 2
                        );

                    var motionX = (float)Math.Cos(Hero.ShootingAngle * Math.PI / 180);
                    var motionY = -(float)Math.Sin(Hero.ShootingAngle * Math.PI / 180);

                    uiShot.SetInMotion(motionX, motionY);

                    UIObjectContainer.AddUIObject(uiShot);
                    lastShotElapsedTime = 0;
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

                        ExecuteHeroObjectCollision(gameTime, uiObject);
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
                            this.Hero.Kills++;
                            this.Hero.Points += 5;
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
            if (lastDirection != Direction.None)
            {
                this.Position += 150 * MotionByDirection[lastDirection];
                this.Sprite.Position = this.Position;
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

            this.Position += this.Hero.MovementSpeed * this.motion;
            this.Sprite.Position = this.Position;

            if (IsOutsideMapBorders())
            {
                this.Position -= this.Hero.MovementSpeed * this.motion;
                this.Sprite.Position = this.Position;
            }
        }

        private bool IsOutsideMapBorders()
        {
            // Hardcoded much ?!
            return Position.X < 0
                || Position.Y < 0
                || Position.X > 1600 - this.Sprite.Rectangle.Width
                || Position.Y > 900 - this.Sprite.Rectangle.Height;
        }
    }
}
