using EmojiHunter.GameAnimation;
using EmojiHunter.UIComponents;
using Microsoft.Xna.Framework;
using System;
using System.Linq;

namespace EmojiHunter.GameHelpers
{
    public static class UIPotionGenerator
    {
        private const int EmoticonSpriteSize = 30;

        private static readonly int FieldWidth = 1600 - EmoticonSpriteSize - 1;

        private static readonly int FieldHeight = 900 - EmoticonSpriteSize - 1;

        private static Random random;

        static UIPotionGenerator()
        {
            UIPotionGenerator.random = new Random();
        }

        public static UIPotion GeneratePotion(SpriteData spriteData)
        {
            var potion = (PotionType)random.Next((int)PotionType.Length);

            var sprite = spriteData.DuplicateSprite($"{potion}");

            var uiPotion = new UIPotion(sprite);

            while (true)
            {
                int positionX = random.Next(1, FieldWidth);
                int positionY = random.Next(1, FieldHeight);
                
                uiPotion.Sprite.Position = new Vector2(positionX, positionY);

                if (UIObjectContainer.UIObjects
                    .Any(x => x.Sprite.Rectangle.Intersects(sprite.Rectangle)))
                {
                    continue;
                }

                UIObjectContainer.AddUIObject(uiPotion);
                return uiPotion;
            }
        }
    }
}
