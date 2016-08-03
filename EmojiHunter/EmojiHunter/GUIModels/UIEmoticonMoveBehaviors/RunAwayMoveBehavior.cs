namespace EmojiHunter.GUIModels.UIEmoticonMoveBehaviors
{
    public class RunAwayMoveBehavior : MoveBehavior
    {
        public RunAwayMoveBehavior(UIHero uiHero) : base(uiHero)
        {
        }

        public override void Move(UIEmoticon uiEmoticon)
        {
            var direction = this.UIHero.Position - uiEmoticon.Position;
            direction.Normalize();

            if (uiEmoticon.Position.X <= 0 || uiEmoticon.Position.X >= FieldWidth)
            {
                direction.X = 0;
            }

            if (uiEmoticon.Position.Y <= 0 || uiEmoticon.Position.Y >= FieldHeight)
            {
                direction.Y = 0;
            }

            uiEmoticon.Direction = -direction;
            uiEmoticon.Position += uiEmoticon.Direction * (DecreaseSpeedFactor * uiEmoticon.GameObject.State.MovementSpeed);
            uiEmoticon.Sprite.Position = uiEmoticon.Position;
        }
    }
}
