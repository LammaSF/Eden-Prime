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
            Random randomNumber = new Random();
            int directionXComponent = randomNumber.Next(-10, 10);
            int directionYComponent = randomNumber.Next(-10, 10);
            int movementSpeed = randomNumber.Next(-10, 10);

            var direction = new Vector2(directionXComponent, directionYComponent);
            direction.Normalize();
            uiEmoticon.Direction = direction;
            uiEmoticon.Position += uiEmoticon.Direction * movementSpeed;
            uiEmoticon.Sprite.Position = uiEmoticon.Position;

            if (uiEmoticon.Position.X < 0)
            {
                uiEmoticon.Position += new Vector2(10, 0);
            }
            else if (uiEmoticon.Position.X > FieldWidth)
            {
                uiEmoticon.Position -= new Vector2(10, 0);
            }
            else if (uiEmoticon.Position.Y < 0)
            {
                uiEmoticon.Position += new Vector2(0, 10);
            }
            else if (uiEmoticon.Position.Y > FieldHeight)
            {
                uiEmoticon.Position -= new Vector2(0, 10);
            }
        }
    }
}
