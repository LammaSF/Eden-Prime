namespace EmojiHunter.Screens
{
    using System;
    using EmojiHunter.Animations;
    using EmojiHunter.Factories;
    using EmojiHunter.GUIModels;
    using EmojiHunter.Helpers;
    using EmojiHunter.IO;
    using EmojiHunter.Models.Heroes;
    using EmojiHunter.Models.Maps;
    using EmojiHunter.Repository;
    using EmojiHunter.UIComponents;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class PlayScreen : Screen
    {
        private ContentManager content;
        private Rectangle screenRectangle;
        private Texture2D background;
        private Texture2D endScreen;
        private SpriteFont font;
        private SpriteData spriteData;
        private HeroStatisticsDrawer statsDrawer;
        private HeroActionController actionController;
        private UIHero uiHero;
        private string mapName;
        private string heroName;
        private Hero hero;
        private Map map;
        private int lastPauseElapsedTime;
        private Texture2D barTexture;
        private bool isGameOver;
        public bool paused;

        public PlayScreen(ContentManager content, string mapName, string heroName)
        {
            this.content = content;
            this.mapName = mapName;
            this.heroName = heroName;

            this.Initialize();
        }

        private void Initialize()
        {
            UIEmoticonGenerator.CurrentEmoticonCount = 0;
            UIPotionGenerator.CurrentPotionCount = 0;
            UIObjectContainer.Reset();
            this.map = new MapFactory().CreateMap(this.mapName);
            this.hero = new HeroFactory().CreateHero(this.heroName);
            this.paused = false;
            this.isGameOver = false;
            this.barTexture = this.content.Load<Texture2D>(@"Content\Bar");
            this.background = this.content.Load<Texture2D>(@"Content\Background");
            this.endScreen = this.content.Load<Texture2D>(@"Content\Gameover");
            this.font = this.content.Load<SpriteFont>(@"Content\Font");
            this.spriteData = new SpriteData();
            SpriteInitializer.InitializeSprites(this.spriteData, this.content);
            this.statsDrawer = new HeroStatisticsDrawer(this.hero, this.font);
            this.uiHero = new UIHero(
                this.spriteData.DuplicateSprite(nameof(Sagittarius)),
                this.hero,
                new UISight(this.spriteData.DuplicateSprite("Sight"))
                );
            this.actionController = new HeroActionController(this.uiHero, this.spriteData, InputManager.Instance);
            this.uiHero.SetStartPosition(
                new Vector2(150, Global.ScreenHeight - 182));
            UIObjectContainer.AddUIObject(this.uiHero);
            UIObstacleGenerator.GenerateObstacles(this.spriteData, this.map);
        }

        public override void Update(GameTime gameTime)
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
                || Keyboard.GetState().IsKeyDown(Keys.P))
                && this.lastPauseElapsedTime > Global.PauseDelay)
            {
                this.paused = !this.paused;
                this.lastPauseElapsedTime = 0;
            }

            if (!this.paused)
            {
                if (UIEmoticonGenerator.CurrentEmoticonCount <
                    UIEmoticonGenerator.MaxEmoticonCount)
                {
                    UIEmoticonGenerator.GenerateEmoticon(this.barTexture, this.spriteData, this.uiHero);
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
            }

            if (this.hero.Health == 0)
            {
                this.isGameOver = true;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (this.isGameOver)
            {
                spriteBatch.Draw(this.endScreen, this.screenRectangle, Color.White);
            }
            else
            {
                foreach (var uiObject in UIObjectContainer.UIObjects)
                {
                    uiObject.Draw(spriteBatch);
                }

                this.statsDrawer.Draw(spriteBatch);
            }
        }
    }
}
