namespace EmojiHunter
{
    using EmojiHunter.Serialization;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Screens;
    using Helpers;

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

        public EmojiHunterGame()
        {
            this.graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = Global.ScreenWidth,
                PreferredBackBufferHeight = Global.ScreenHeight
            };

            //this.graphics.ToggleFullScreen();

            this.screenRectangle = new Rectangle(
                0,
                0, 
                this.graphics.PreferredBackBufferWidth, 
                this.graphics.PreferredBackBufferHeight);

        }

        public Screen CurrentScreen { get; set; }

        public SerializationContainer SerializationContainer { get; set; }
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
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
            this.background = this.Content.Load<Texture2D>(@"Content\Background");
            this.CurrentScreen = new MenuScreen(this.Content, this, null);
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
            this.CurrentScreen.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.CornflowerBlue);

            this.spriteBatch.Begin();
            this.spriteBatch.Draw(this.background, this.screenRectangle, Color.White);
            this.CurrentScreen.Draw(this.spriteBatch);
            this.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
