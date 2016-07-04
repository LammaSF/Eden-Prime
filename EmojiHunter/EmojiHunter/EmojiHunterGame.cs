using EmojiHunter.UIComponents;
using EmojiHunter.GameAnimation;
using EmojiHunter.GameData;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EmojiHunter.GameHelpers;
using EmojiHunter.GameData.Maps;

namespace EmojiHunter
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class EmojiHunterGame : Game
    {
        private GraphicsDeviceManager graphics;

        private SpriteBatch spriteBatch;

        private Rectangle screenRectangle;

        private Texture2D background;

        private SpriteData spriteData;

        private UIHero uiHero;

        private Hero hero;

        public EmojiHunterGame()
        {
            this.graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1600; // HARDCODED
            graphics.PreferredBackBufferHeight = 900; // HARDCODED
            //graphics.PreferredBackBufferWidth = 1280; // HARDCODED
            //graphics.PreferredBackBufferHeight = 720; // HARDCODED
            //graphics.ToggleFullScreen();

            screenRectangle = new Rectangle(
                0,
                0,
                graphics.PreferredBackBufferWidth,
                graphics.PreferredBackBufferHeight);
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
           
            SpriteInitializer.InitializeSprites(this.spriteData, Content);

            this.hero = new Hero("LightHero");
            this.uiHero = new UIHero(Content, this.spriteData, this.hero);
            this.uiHero.SetInStartPosition(
                new Vector2(150, graphics.PreferredBackBufferHeight - 182));

            UIObjectContainer.AddUIObject(this.uiHero);

            var map = new CenterMap();
            var uiObstacles = UIObstacleGenerator.GenerateObstacles(this.spriteData, map);

            foreach (var uiObstacle in uiObstacles)
            {
                UIObjectContainer.AddUIObject(uiObstacle);
            }

            var uiEmoticon = UIEmoticonGenerator.GenerateEmoticon(this.spriteData,
                this.uiHero.Position);
            UIObjectContainer.AddUIObject(uiEmoticon);
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
              Exit();
                


            foreach (var uiObject in UIObjectContainer.UIObjects)
            {
                uiObject.Update(gameTime);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            this.spriteBatch.Begin();

            this.spriteBatch.Draw(this.background, screenRectangle, Color.White);

            foreach (var uiObject in UIObjectContainer.UIObjects)
            {
                uiObject.Draw(this.spriteBatch);
            }

            this.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
