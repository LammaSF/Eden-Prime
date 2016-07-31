namespace EmojiHunter.Helpers
{
    using System;
    using System.Linq;
    using Animations;
    using Contracts;
    using GUIModels.UIEmoticonMoveBehaviors;
    using Repository;
    using Enumerations;
    using Factories;
    using GUIModels;

    public class UIEmoticonGenerator
    {
        public const int MaxEmoticonCount = 5;

        private const int GoodEmoticonPercentage = 50;

        private const int NoSpawnRadius = 50;

        private const int EmoticonSpriteSize = 50;

        private static readonly int FieldWidth = Global.ScreenWidth - EmoticonSpriteSize - 1;

        private static readonly int FieldHeight = Global.ScreenHeight - EmoticonSpriteSize - 1;

        private static EmoticonFactory emoticonFactory;

        private static Random random;

        static UIEmoticonGenerator()
        {
            UIEmoticonGenerator.random = new Random();
            UIEmoticonGenerator.emoticonFactory = new EmoticonFactory();
        }

        public static int CurrentEmoticonCount { get; set; }

        public static UIEmoticon GenerateEmoticon(SpriteData spriteData, UIHero uiHero)
        {
            var chance = random.Next(100);

            var emoticonType = (chance < GoodEmoticonPercentage)
                ? (EmoticonType)random.Next(5)
                : (EmoticonType)random.Next(5, 10);

            var emoticon = emoticonFactory.CreateEmoticon($"{emoticonType}");

            IMoveBehavior moveBehavior;
            if (emoticon is IMelee)
            {
                moveBehavior = new MeleeMoveBehavior(uiHero);                
            }
            else if (emoticon is IShooting)
            {
                moveBehavior = new ShootingMoveBehavior(uiHero);
            }
            else
            {
                moveBehavior = new RunAwayMoveBehavior(uiHero);
            }

            var sprite = spriteData.DuplicateSprite(emoticon.Name);
            var uiEmoticon = new UIEmoticon(spriteData, emoticon, sprite, uiHero)
            {
                MoveBehavior = moveBehavior
            };

            while (true)
            {
                int positionX = random.Next(1, FieldWidth);
                int positionY = random.Next(1, FieldHeight);

                float distanceToPlayer =
                    ((positionX - uiHero.Position.X)
                    * (positionX - uiHero.Position.X))
                    + ((positionY - uiHero.Position.Y)
                    * (positionY - uiHero.Position.Y));

                if (distanceToPlayer > NoSpawnRadius * NoSpawnRadius)
                {
                    uiEmoticon.SetStartPosition(positionX, positionY);

                    if (UIObjectContainer.UIObjects
                        .Any(x => x.Sprite.Rectangle.Intersects(sprite.Rectangle)))
                    {
                        continue;
                    }

                    UIObjectContainer.AddUIObject(uiEmoticon);
                    UIEmoticonGenerator.CurrentEmoticonCount++;
                    return uiEmoticon;
                }
            }
        }
    }
}
