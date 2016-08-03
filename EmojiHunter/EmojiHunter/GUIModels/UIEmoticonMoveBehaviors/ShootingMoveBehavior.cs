namespace EmojiHunter.GUIModels.UIEmoticonMoveBehaviors
{
    public class ShootingMoveBehavior : MoveBehavior
    {
        public ShootingMoveBehavior(UIHero uiHero) : base(uiHero)
        {
        }

        public override void Move(UIEmoticon uiEmoticon)
        {
            var direction = this.UIHero.Position - uiEmoticon.Position;

            var displacement = direction;
            if (OutsideHeroVicinity(displacement))
            {
                direction.Normalize();
                uiEmoticon.Direction = direction;

                if (!HasLeftScreen(uiEmoticon.Position))
                {
                    uiEmoticon.Position += uiEmoticon.Direction * (DecreaseSpeedFactor * uiEmoticon.GameObject.State.MovementSpeed);
                }
                uiEmoticon.Sprite.Position = uiEmoticon.Position;
            }
        }
    }
}
