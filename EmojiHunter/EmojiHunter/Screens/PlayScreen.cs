namespace EmojiHunter.Screens
{
    using System.Linq;
    using System.Runtime.InteropServices;
    using Animations;
    using EmojiHunter.Models.Emoticons;
    using EmojiHunter.Serialization;
    using Factories;
    using GUIModels;
    using Helpers;
    using IO;
    using Models.Heroes;
    using Models.Maps;
    using Repository;
    using UIComponents;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class PlayScreen : Screen
    {
        private ContentManager content;
        private Rectangle screenRectangle;
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
        private EmojiHunterGame game;

        public PlayScreen(ContentManager content, string mapName, string heroName, EmojiHunterGame game, bool load)
        {
            this.content = content;
            this.mapName = mapName;
            this.heroName = heroName;
            this.game = game;
            this.screenRectangle = new Rectangle(
                0,
                0,
                Global.ScreenWidth,
                Global.ScreenHeight);
            this.Initialize();
            if (load)
            {
                this.Load();
            }
            else
            {
                this.StartNewGame();
            }
        }

        private void Initialize()
        {
            this.paused = false;
            this.isGameOver = false;
            UIEmoticonGenerator.CurrentEmoticonCount = 0;
            UIPotionGenerator.CurrentPotionCount = 0;
            UIObjectContainer.Reset();
            Global.Points = 0;
            Global.Kills = 0;
            this.map = new MapFactory().CreateMap(this.mapName);
            this.barTexture = this.content.Load<Texture2D>(@"Content\Bar");
            this.endScreen = this.content.Load<Texture2D>(@"Content\Gameover");
            this.font = this.content.Load<SpriteFont>(@"Content\Font");
            this.spriteData = new SpriteData();
            SpriteInitializer.InitializeSprites(this.spriteData, this.content);
        }

        private void Load()
        {
            Global.Kills = this.game.SerializationContainer.Kills;
            Global.Points = this.game.SerializationContainer.Points;
            this.hero = this.game.SerializationContainer.Hero;
            this.statsDrawer = new HeroStatisticsDrawer(this.hero, this.font);
            this.uiHero = new UIHero(
                this.spriteData.DuplicateSprite(nameof(Sagittarius)),
                this.hero,
                new UISight(this.spriteData.DuplicateSprite("Sight"))
                );
            this.actionController = new HeroActionController(this.uiHero, this.spriteData, InputManager.Instance);
            this.uiHero.SetStartPosition(this.game.SerializationContainer.HeroPosition);
            UIObjectContainer.AddUIObject(this.uiHero);
            UIObstacleGenerator.GenerateObstacles(this.spriteData, this.map);
            UIEmoticonGenerator.GenerateEmoticons(this.barTexture, this.spriteData, this.uiHero,
                this.game.SerializationContainer.Emoticons, this.game.SerializationContainer.EmoticonPositions);
        }

        private void StartNewGame()
        {
            this.hero = new HeroFactory().CreateHero(this.heroName);
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
                    this.game.CurrentScreen = new MenuScreen(this.content, this.game, null, Global.Points);
                }

                return;
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
                    || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                this.game.SerializationContainer = this.GetContainer();

                this.game.CurrentScreen = new MenuScreen(this.content, this.game, this.game.CurrentScreen, 0);
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

        private SerializationContainer GetContainer()
        {
            var sagittarius = this.uiHero.GameObject as Sagittarius;
            var heroPosition = this.uiHero.Position;
            var emoticons = UIObjectContainer.UIObjects
                .Where(uio => uio.GameObject is Emoticon)
                .Select(uio => uio.GameObject as Emoticon)
                .ToList();
            var emoticonPositions = UIObjectContainer.UIObjects
                .Where(uio => uio.GameObject is Emoticon)
                .Select(uio => uio.Sprite.Position)
                .ToList();
            return new SerializationContainer
            {
                Hero = sagittarius,
                HeroPosition = heroPosition,
                Emoticons = emoticons,
                EmoticonPositions = emoticonPositions,
                Kills = Global.Kills,
                Points = Global.Points
            };
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
