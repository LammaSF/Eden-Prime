namespace EmojiHunter
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using GameAnimation;
    using System;
    using Animations;
    using UIComponents;
    using Factories;
    using Helpers;
    using IO;
    using Models.Heroes;
    using Models.Maps;
    using Repository;
    using GUIModels;

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    /// 
    public class EmojiHunterGame : Game
    {
        private GraphicsDeviceManager graphics;

        private SpriteBatch spriteBatch;

        private Rectangle screenRectangle;

        private Texture2D background;

        private Texture2D endScreen;

        private SpriteFont font;

        private SpriteData spriteData;

        private HeroStatisticsDrawer statsDrawer;

        private HeroActionController actionController;

        private UIHero uiHero;

        private Hero hero;

        private Map map;

        private bool paused;

        private bool isGameOver;

        private int lastPauseElapsedTime;

        public EmojiHunterGame(string mapName, string heroName)
        {
            this.graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = Global.ScreenWidth,
                PreferredBackBufferHeight = Global.ScreenHeight
            };

            //this.graphics.ToggleFullScreen();

            this.map = new MapFactory().CreateMap(mapName);
            this.hero = new HeroFactory().CreateHero(heroName);

            this.screenRectangle = new Rectangle(
                0,
                0, 
                this.graphics.PreferredBackBufferWidth, 
                this.graphics.PreferredBackBufferHeight);

            this.paused = false;
            this.isGameOver = false;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            //// TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
            this.spriteData = new SpriteData();

            this.background = this.Content.Load<Texture2D>(@"Content\Background");
            this.endScreen = this.Content.Load<Texture2D>(@"Content\Gameover");
            this.font = this.Content.Load<SpriteFont>(@"Content\Font");

            SpriteInitializer.InitializeSprites(this.spriteData, this.Content);

            this.statsDrawer = new HeroStatisticsDrawer(this.hero, this.font);
            this.uiHero = new UIHero(
                this.spriteData.DuplicateSprite(nameof(Sagittarius)),
                this.hero,
                new UISight(this.spriteData.DuplicateSprite("Sight"))
                );
            this.actionController = new HeroActionController(this.uiHero, this.spriteData, InputManager.Instance);

            //// That is not hardcoded at all! Believe me!
            this.uiHero.SetStartPosition(
                new Vector2(150, this.graphics.PreferredBackBufferHeight - 182));

            // ***End of need :)
            UIObjectContainer.AddUIObject(this.uiHero);
            UIObstacleGenerator.GenerateObstacles(this.spriteData, this.map);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (this.isGameOver)
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
                    || Keyboard.GetState().IsKeyDown(Keys.Escape))
                {
                    Environment.Exit(0);
                }

                return;
            }

            this.lastPauseElapsedTime += gameTime.ElapsedGameTime.Milliseconds;

            if ((GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
                || Keyboard.GetState().IsKeyDown(Keys.Escape))
                && lastPauseElapsedTime > Global.PauseDelay)
            {
                this.paused = !this.paused;
                this.lastPauseElapsedTime = 0;
            }

            if (!this.paused)
            {
                if (UIEmoticonGenerator.CurrentEmoticonCount <
                    UIEmoticonGenerator.MaxEmoticonCount)
                {
                    UIEmoticonGenerator.GenerateEmoticon(this.spriteData, this.uiHero.Position);
                }

                if (UIPotionGenerator.CurrentPotionCount < UIPotionGenerator.MaxPotionCount)
                {
                    UIPotionGenerator.GeneratePotion(this.spriteData);
                }

                var uiObjects = UIObjectContainer.UIObjects;
                for (int index = uiObjects.Count - 1; index >= 0; index--)
                {
                    uiObjects[index].Update(gameTime);
                }

                this.actionController.Update(gameTime);

                base.Update(gameTime);
            }

            if (this.hero.Health == 0)
            {
                this.isGameOver = true;
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.CornflowerBlue);

            this.spriteBatch.Begin();

            if (this.isGameOver)
            {
                this.spriteBatch.Draw(this.endScreen, this.screenRectangle, Color.White);
            }
            else
            {
                this.spriteBatch.Draw(this.background, this.screenRectangle, Color.White);

                foreach (var uiObject in UIObjectContainer.UIObjects)
                {
                    uiObject.Draw(this.spriteBatch);
                }

                this.statsDrawer.Draw(this.spriteBatch);
            }

            this.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
