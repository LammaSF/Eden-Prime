namespace EmojiHunter
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    using GameAnimation;
    using GameData;
    using GameData.Maps;
    using GameHelpers;
    using UIComponents;
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class EmojiHunterGame : Game
    {
        private const int PauseDelay = 500; // in ms

        private const int ScreenWidth = 1600;

        private const int ScreenHeight = 900;

        private GraphicsDeviceManager graphics;

        private SpriteBatch spriteBatch;

        private Rectangle screenRectangle;

        private Texture2D background;

        private Texture2D endScreen;

        private SpriteData spriteData;

        private UIHero uiHero;

        private Hero hero;

        private Map map;

        private bool paused;

        private bool isGameOver;

        private int lastPauseElapsedTime;

        public EmojiHunterGame(string mapName, string heroName)
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.graphics.PreferredBackBufferWidth = ScreenWidth; 
            this.graphics.PreferredBackBufferHeight = ScreenHeight;
            //this.graphics.ToggleFullScreen();

            this.map = new MapFactory().CreateMap(mapName);
            this.hero = new HeroFactory().CreateHero(heroName);

            this.screenRectangle = new Rectangle(
                0,
                0,
                graphics.PreferredBackBufferWidth,
                graphics.PreferredBackBufferHeight);

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
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            this.spriteBatch = new SpriteBatch(GraphicsDevice);

            this.spriteData = new SpriteData();

            this.background = Content.Load<Texture2D>(@"Content\Background");

            this.endScreen = Content.Load<Texture2D>(@"Content\Gameover");

            SpriteInitializer.InitializeSprites(this.spriteData, Content);
            
            // ***Desperate need of refactoring...
            this.uiHero = new UIHero(Content, this.spriteData, this.hero);
            // That is not hardcoded at all! Believe me!
            this.uiHero.SetInStartPosition(
                new Vector2(150, graphics.PreferredBackBufferHeight - 182)); 

            UIObjectContainer.AddUIObject(this.uiHero);
            // ***End of need :)

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
            if (isGameOver)
            {
                return;
            }

            this.lastPauseElapsedTime += gameTime.ElapsedGameTime.Milliseconds;

            if ((GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed 
                || Keyboard.GetState().IsKeyDown(Keys.Escape))
                && lastPauseElapsedTime > PauseDelay)
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
            GraphicsDevice.Clear(Color.CornflowerBlue);

            this.spriteBatch.Begin();

            if (isGameOver)
            {
                this.spriteBatch.Draw(this.endScreen, screenRectangle, Color.White);
            }
            else
            {
                this.spriteBatch.Draw(this.background, screenRectangle, Color.White);

                foreach (var uiObject in UIObjectContainer.UIObjects)
                {
                    uiObject.Draw(this.spriteBatch);
                }
            }

            this.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
