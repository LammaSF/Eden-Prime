namespace EmojiHunter.IO
{
    using GUIModels;
    using UIComponents;

    public class HeroActionController
    {
        private UIHero uiHero;

        private InputManager inputManager;

        public HeroActionController(UIHero uiHero, InputManager inputManager)
        {
            this.uiHero = uiHero;
            this.inputManager = inputManager;
        }


    }
}
