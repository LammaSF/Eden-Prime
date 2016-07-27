namespace EmojiHunter.GameHelpers
{
    using System;
    using System.Linq;
    using EmojiHunter.GameAnimation;
    using EmojiHunter.GameData;
    using EmojiHunter.UIComponents;
    using Microsoft.Xna.Framework;

    public static class UIPotionGenerator
    {
        public const int MaxPotionCount = 3;

        private const int PotionSpriteSize = 30;

        private static int currentPotionCount;

        private static readonly int FieldWidth = 1600 - PotionSpriteSize - 1;

        private static readonly int FieldHeight = 900 - PotionSpriteSize - 1;

        private static Random random;

        public static int CurrentPotionCount
        {
            get
            {
                return currentPotionCount;
            }

            set
            {
                currentPotionCount = value;
            }
        }

        static UIPotionGenerator()
        {
            UIPotionGenerator.random = new Random();
        }

        public static UIPotion GeneratePotion(SpriteData spriteData)
        {
            var potionType = (PotionType)random.Next((int)PotionType.Length);

            var potion = new Potion() { Type = potionType };

            var sprite = spriteData.DuplicateSprite($"{potionType}");

            var uiPotion = new UIPotion(potion, sprite);

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
                UIPotionGenerator.CurrentPotionCount++;
                return uiPotion;
            }
        }
    }
}
