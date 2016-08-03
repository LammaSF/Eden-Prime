namespace EmojiHunter.GUIModels.UIEmoticonMoveBehaviors
{
    public class MeleeMoveBehavior : MoveBehavior
    {
        public MeleeMoveBehavior(UIHero uiHero) : base(uiHero)
        {
        }

        public override void Move(UIEmoticon uiEmoticon)
        {
            var direction = this.UIHero.Position - uiEmoticon.Position;
            direction.Normalize();
            uiEmoticon.Direction = direction;

            if (!HasLeftScreen(uiEmoticon.Position))
            {
                uiEmoticon.Position += uiEmoticon.Direction * ((int)(DecreaseSpeedFactor * uiEmoticon.GameObject.State.MovementSpeed));
            }

            uiEmoticon.Sprite.Position = uiEmoticon.Position;
        }
    }
}
