using EmojiHunter.UIComponents;
using EmojiHunter.GameAnimation;
using EmojiHunter.GameData;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EmojiHunter
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class EmojiHunterGame : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private SpriteData spriteData;
        private UIEmoticon uiEmoticon;
        private UIHero uiHero;
        private Hero hero;
        private Emoticon emoticon;
        private AnimatedSprite sprite;

        private Rectangle screenRectangle;

        public EmojiHunterGame()
        {
            this.graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            this.screenRectangle = new Rectangle(
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

            SpriteInitializer.InitializeSprites(this.spriteData, Content);

            this.emoticon = new Emoticon("OnfireEmoticon");
            this.sprite = spriteData.DuplicateSprite(this.emoticon.Name);
            this.uiEmoticon = new UIEmoticon(this.sprite, this.emoticon);
            this.uiEmoticon.Sprite.AnimationIndex = 3;

            this.hero = new Hero("LightHero");
            this.sprite = spriteData.DuplicateSprite(this.hero.Name);
            this.uiHero = new UIHero(this.sprite, this.hero);

            StartGame();
        }

        private void StartGame()
        {
            this.uiEmoticon.SetInStartPosition(100, 100);
            this.uiHero.SetInStartPosition(200, 200);
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

            if (InputManager.Instance.KeyDown(Keys.Right))
                // to do - move right

            if (InputManager.Instance.KeyDown(Keys.Left))
                    // to do - move right

            if (InputManager.Instance.KeyDown(Keys.Up))
                        // to do - move right

            if (InputManager.Instance.KeyDown(Keys.Down))
                            // to do - move right


            this.uiEmoticon.Update(gameTime);
            this.uiHero.Update(gameTime);

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

            this.uiEmoticon.Draw(this.spriteBatch);
            this.uiHero.Draw(this.spriteBatch);

            this.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
