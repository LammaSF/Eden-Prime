namespace EmojiHunter.GUIModels.UIEmoticonMoveBehaviors
{
    using System;
    using Microsoft.Xna.Framework;

    public class CrazyMoveBehavior : MoveBehavior
    {
        public CrazyMoveBehavior(UIHero uiHero) : base(uiHero)
        {
        }

        public override void Move(UIEmoticon uiEmoticon)
        {
            // TO DO
            // You have access to this.UIHero.Position
            // You have access to uiEmoticon
            // uiEmoticon.Sprite.Position;
            // uiEmoticon.Direction;
            // uiEmoticon.Position;
            // uiEmoticon.GameObject.State.MovementSpeed;
        }
    }
}
