namespace EmojiHunter.GUIModels.UIEmoticonMoveBehaviors
{
    using System;
    using Contracts;
    using Helpers;
    using Microsoft.Xna.Framework;

    public abstract class MoveBehavior : IMoveBehavior
    {
        protected const float DecreaseSpeedFactor = 1;
        private const int EmoticonSpriteSize = 50;
        private const int VicinityRadius = 150;
        protected static readonly int FieldWidth = Global.ScreenWidth - EmoticonSpriteSize - 1;
        protected static readonly int FieldHeight = Global.ScreenHeight - EmoticonSpriteSize - 1;

        protected MoveBehavior(UIHero uiHero)
        {
            this.UIHero = uiHero;
        }

        protected UIHero UIHero { get; }

        public abstract void Move(UIEmoticon uiEmoticon);

        protected bool HasLeftScreen(Vector2 position)
        {
            return position.X < 0 || position.X > FieldWidth || position.Y < 0 || position.Y > FieldHeight;
        }

        protected bool OutsideHeroVicinity(Vector2 displacement)
        {
            return Math.Pow(displacement.X, 2) + Math.Pow(displacement.Y, 2) > Math.Pow(VicinityRadius, 2);
        }
    }
}