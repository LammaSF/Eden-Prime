using EmojiHunter.GameAnimation;
using EmojiHunter.GameData;
using EmojiHunter.UIComponents;
using Microsoft.Xna.Framework;
using System;
using System.Linq;

namespace EmojiHunter.GameHelpers
{
    public class UIEmoticonGenerator
    {
        private const int GoodEmoticonPercentage = 25;

        private const int NoSpawnRadius = 50;

        private const int EmoticonSpriteSize = 50;

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

            var uiEmoticon = new UIEmoticon(sprite, emoticon);

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
                    uiEmoticon.SetInStartPosition(positionX, positionY);

                    if (UIObjectContainer.UIObjects
                        .Any(x => x.Sprite.Rectangle.Intersects(sprite.Rectangle)))
                    {
                        continue;
                    }

                    return uiEmoticon;
                }
            }
        }
    }
}
