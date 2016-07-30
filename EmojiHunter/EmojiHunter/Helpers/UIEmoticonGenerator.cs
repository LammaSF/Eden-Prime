namespace EmojiHunter.Helpers
{
    using System;
    using System.Linq;
    using Animations;
    using Repository;
    using Enumerations;
    using Factories;
    using GUIModels;
    using Microsoft.Xna.Framework;

    public class UIEmoticonGenerator
    {
        public const int MaxEmoticonCount = 5;

        private const int GoodEmoticonPercentage = 0;

        private const int NoSpawnRadius = 50;

        private const int EmoticonSpriteSize = 50;

        public static int CurrentEmoticonCount;

        private static readonly int FieldWidth = 1600 - EmoticonSpriteSize - 1;

        private static readonly int FieldHeight = 900 - EmoticonSpriteSize - 1;

        private static EmoticonFactory emoticonFactory;

        private static Random random;

        static UIEmoticonGenerator()
        {
            UIEmoticonGenerator.random = new Random();
            UIEmoticonGenerator.emoticonFactory = new EmoticonFactory();
        }

        public static UIEmoticon GenerateEmoticon(SpriteData spriteData, Vector2 heroPosition)
        {
            var chance = random.Next(100);

            var emoticonType = (chance < GoodEmoticonPercentage)
                ? (EmoticonType)random.Next(5)
                : (EmoticonType)random.Next(5, 10);

            var emoticon = emoticonFactory.CreateEmoticon($"{emoticonType}");

            var sprite = spriteData.DuplicateSprite(emoticon.Name);

            var uiEmoticon = new UIEmoticon(spriteData, emoticon, sprite);

            while (true)
            {
                int positionX = random.Next(1, FieldWidth);
                int positionY = random.Next(1, FieldHeight);

                float distanceToPlayer =
                    (positionX - heroPosition.X)
                    * (positionX - heroPosition.X)
                    + (positionY - heroPosition.Y)
                    * (positionY - heroPosition.Y);

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
