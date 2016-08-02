namespace EmojiHunter.Screens
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Helpers;
    using Serialization;
    using UIComponents;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class MenuScreen : Screen
    {
        private const string RelativePath = "data.xml";

        private const string HighPath = "highscore.xml";
            
        private const int PressDelay = 200;

        private const int MenuItemStartX = 100;
        
        private const int MenuItemStartY = 100;

        private const int MenuItemStepY = 100;

        private List<MenuItem> menuItems;

        private readonly Color outOfFocusColor = Color.Black;

        private readonly Color onFocusColor = Color.Red;
        
        private int currentIndex = 1;

        private ContentManager content;

        private SpriteFont font;

        private int elapsedTime;

        private EmojiHunterGame game;

        private Screen previousScreen;

        private Highscore highscore;

        private bool drawHighscore;

        public MenuScreen(ContentManager content, EmojiHunterGame game, Screen previousScreen, int score)
        {
            this.content = content;
            this.font = this.content.Load<SpriteFont>(@"Content\Font");
            this.menuItems = new List<MenuItem>();
            this.InitializeMenuItems();
            this.menuItems[this.currentIndex].Color = this.onFocusColor;
            this.game = game;
            this.previousScreen = previousScreen;
            this.LoadHighscores();
            this.highscore.AddScore(score);
            this.SaveHighscores();
        }

        private void SaveHighscores()
        {
            if (this.highscore != null)
            {
                var dataFilePath = PathHelper.GetDataFilePath(HighPath);
                SerializationHelper.Serialize(this.highscore, dataFilePath);
            }
        }

        private void LoadHighscores()
        {
            if (File.Exists(HighPath))
            {
                this.highscore = SerializationHelper.Deserialize<Highscore>(HighPath);
            }
            else
            {
                this.highscore = new Highscore();
            }
        }

        public override void Update(GameTime gameTime)
        {
            InputManager.Instance.Update();
            this.elapsedTime += gameTime.ElapsedGameTime.Milliseconds;

            if (InputManager.Instance.KeyDown(Keys.Down) 
                && this.elapsedTime > PressDelay)
            {
                this.menuItems[this.currentIndex++].Color = this.outOfFocusColor;
                this.currentIndex %= this.menuItems.Count;
                this.menuItems[this.currentIndex].Color = this.onFocusColor;
                this.elapsedTime = 0;
            }
            else if (InputManager.Instance.KeyDown(Keys.Up)
                && this.elapsedTime > PressDelay)
            {
                this.menuItems[this.currentIndex].Color = this.outOfFocusColor;
                this.currentIndex = (this.menuItems.Count + this.currentIndex - 1) % this.menuItems.Count;
                this.menuItems[this.currentIndex].Color = this.onFocusColor;
                this.elapsedTime = 0;
            }

            if (InputManager.Instance.KeyDown(Keys.Enter))
            {
                 this.menuItems[this.currentIndex].PressMenuItem();      
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (var menuItem in this.menuItems)
            {
                menuItem.Draw(spriteBatch);
            }

            if (drawHighscore)
            {
                this.highscore?.Draw(spriteBatch, this.font);
            }
        }

        private void InitializeMenuItems()
        {
            var positionY = MenuItemStartY;
            var menuItem = new MenuItem(this.font, MenuNames.ResumeMenuName, new Vector2(MenuItemStartX, positionY), this.outOfFocusColor);
            menuItem.Pressed += this.OnResumePressedEventHandler;
            this.menuItems.Add(menuItem);

            positionY += MenuItemStartY;
            menuItem = new MenuItem(this.font, MenuNames.NewGameMenuName, new Vector2(MenuItemStartX, positionY), this.outOfFocusColor);
            menuItem.Pressed += this.OnNewGamePressedEventHandler;
            this.menuItems.Add(menuItem);

            positionY += MenuItemStartY;
            menuItem = new MenuItem(this.font, MenuNames.SaveMenuName, new Vector2(MenuItemStartX, positionY), this.outOfFocusColor);
            menuItem.Pressed += this.OnSavePressedEventHandler;
            this.menuItems.Add(menuItem);

            positionY += MenuItemStartY;
            menuItem = new MenuItem(this.font, MenuNames.LoadMenuName, new Vector2(MenuItemStartX, positionY), this.outOfFocusColor);
            menuItem.Pressed += this.OnLoadPressedEventHandler;
            this.menuItems.Add(menuItem);

            positionY += MenuItemStartY;
            menuItem = new MenuItem(this.font, MenuNames.HighscoreMenuName, new Vector2(MenuItemStartX, positionY), this.outOfFocusColor);
            menuItem.Pressed += this.OnHighscorePressedEventHandler;
            this.menuItems.Add(menuItem);

            positionY += MenuItemStartY;
            menuItem = new MenuItem(this.font, MenuNames.ExitMenuName, new Vector2(MenuItemStartX, positionY), this.outOfFocusColor);
            menuItem.Pressed += this.OnExitPressedEventHandler;
            this.menuItems.Add(menuItem);
        }

        private void OnHighscorePressedEventHandler(object sender, EventArgs e)
        {
            this.drawHighscore = true;
        }

        private void OnExitPressedEventHandler(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void OnResumePressedEventHandler(object sender, EventArgs e)
        {
            if (this.previousScreen != null)
            {
                this.game.CurrentScreen = this.previousScreen;
            }
        }

        private void OnNewGamePressedEventHandler(object sender, EventArgs e)
        {
            this.game.CurrentScreen = new PlayScreen(this.content, Global.MapName, Global.HeroName, this.game, false);
        }

        private void OnSavePressedEventHandler(object sender, EventArgs e)
        {
            if (this.previousScreen != null)
            {
                var dataFilePath = PathHelper.GetDataFilePath(RelativePath);
                SerializationHelper.Serialize(this.game.SerializationContainer, dataFilePath);
            }
        }

        private void OnLoadPressedEventHandler(object sender, EventArgs e)
        {
            SerializationContainer container;
            var dataFilePath = PathHelper.GetDataFilePath(RelativePath);
            if (File.Exists(dataFilePath))
            {
                container = SerializationHelper.Deserialize<SerializationContainer>(dataFilePath);
                this.game.SerializationContainer = container;
            }

            this.game.CurrentScreen = new PlayScreen(this.content, Global.MapName, Global.HeroName, this.game, true);
        }
    }
}
