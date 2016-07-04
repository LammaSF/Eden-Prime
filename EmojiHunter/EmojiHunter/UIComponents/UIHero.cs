using EmojiHunter.GameAnimation;
using EmojiHunter.GameData;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using EmojiHunter.GameData.Emoticons;
using Microsoft.Xna.Framework.Content;

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
        private HeroState state;
        private InputManager inputManager;
        private Vector2 motion;
        private Direction lastDirection;
        private List<UIShot> uiShots;
        private AnimatedSprite spellShotSprite;
        private float lastShotElapsedTime;
        private float lastTeleportElapsedTime;
        private float lastHeroEmoticonCollisionElapsedTime;

        public UIHero(ContentManager content, SpriteData spriteData, Hero hero)
        {
            this.inputManager = InputManager.Instance;
            this.font = content.Load<SpriteFont>(@"Content\Font");

            this.Hero = hero;
            this.Sprite = spriteData.DuplicateSprite(this.Hero.Name);
            this.UISight = new UISight(spriteData.DuplicateSprite("Sight"));
            this.spellShotSprite = spriteData.DuplicateSprite("SpellShot");
            this.spellShotSprite.AnimationIndex = 2;
            this.uiShots = new List<UIShot>();
        }

        public AnimatedSprite Sprite { get; set; }
        public Hero Hero { get; set; }
        public UISight UISight { get; set; }
        public Vector2 Position { get; private set; }

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

            UISight.Move(Hero.ShootingAngle, this.Position);

            lastShotElapsedTime += gameTime.ElapsedGameTime.Milliseconds;
            if (keyShoot)
            {
                if (lastShotElapsedTime > 500)
                {
                    var uiShot = new UIShot(this.spellShotSprite, Hero.ShootingSpeed);
                    uiShot.SetInStartPosition(this.Position.X, this.Position.Y);

                    var motionX = (float)Math.Cos(Hero.ShootingAngle * Math.PI / 180);
                    var motionY = -(float)Math.Sin(Hero.ShootingAngle * Math.PI / 180);

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

            CheckForHeroObjectCollision(gameTime);
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

                    // TO DO: Kill emoticon scenario
                }
                else
                {
                    var badEmoticon = uiEmoticon.Emoticon as BadEmoticon;

                    this.lastHeroEmoticonCollisionElapsedTime +=
                        gameTime.ElapsedGameTime.Milliseconds;

                    if (this.lastHeroEmoticonCollisionElapsedTime >
                        badEmoticon.AttackSpeed)
                    {
                        this.Hero.Health -= badEmoticon.Damage;
                        badEmoticon.Health -= this.Hero.Damage;

                        this.lastHeroEmoticonCollisionElapsedTime %= badEmoticon.AttackSpeed;
                        // TO DO: Kill emoticon scenario
                    }
                }
            }

            if (uiObject is UIShot)
            {
                //TO DO
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
        }

        public void SetInStartPosition(Vector2 position)
        {
            Position = position;
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

            spriteBatch.DrawString(this.font, $"Health: {this.Hero.Health}",
                new Vector2(20, 20), Color.Red);
            spriteBatch.DrawString(this.font, $"Armor: {this.Hero.Armor}",
                new Vector2(20, 50), Color.GreenYellow);
            spriteBatch.DrawString(this.font, $"Mana: {this.Hero.Mana}", 
                new Vector2(20, 80), Color.Blue);
            spriteBatch.DrawString(this.font, $"Strength:  {this.Hero.Strength}", 
                new Vector2(20, 110), Color.Yellow);
            spriteBatch.DrawString(this.font, $"Kills: {this.Hero.Kills}", 
                new Vector2(20, 140), Color.Black);
            spriteBatch.DrawString(this.font, $"Points:  {this.Hero.Points}", 
                new Vector2(20, 170), Color.Black);
        }
    }
}
