namespace EmojiHunter.GUIModels.UIEmoticonMoveBehaviors
{
    using Contracts;

    public abstract class MoveBehavior : IMoveBehavior
    {
        protected MoveBehavior(UIHero uiHero)
        {
            this.UIHero = uiHero;
        }

        protected UIHero UIHero { get; }

        public abstract void Move(UIEmoticon uiEmoticon);
    }
}
