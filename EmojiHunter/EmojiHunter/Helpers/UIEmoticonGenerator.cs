namespace EmojiHunter.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Animations;
    using Contracts;
    using Models.Emoticons;
    using GUIModels.UIEmoticonMoveBehaviors;
    using Repository;
    using Enumerations;
    using Factories;
    using GUIModels;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class UIEmoticonGenerator
    {
        public const int MaxCrazyCount = 1;

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

        public static int CurrentCrazyCount { get; set; }

        public static int CurrentEmoticonCount { get; set; }

        public static UIEmoticon GenerateEmoticon(Texture2D barTexture2D, SpriteData spriteData, UIHero uiHero)
        {
            var chance = random.Next(100);

            var emoticonType = (chance < GoodEmoticonPercentage)
                ? (EmoticonType)random.Next(5)
                : (EmoticonType)random.Next(5, 10);

            var emoticon = emoticonFactory.CreateEmoticon(emoticonType);

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
            var uiEmoticon = new UIEmoticon(barTexture2D, spriteData, emoticon, sprite, uiHero)
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

        public static void GenerateEmoticons(Texture2D barTexture, SpriteData spriteData, UIHero uiHero, IList<Emoticon> emoticons, IList<Vector2> emoticonPositions)
        {
            for (int index = 0; index < emoticons.Count; index++)
            {
                IMoveBehavior moveBehavior;
                if (emoticons[index] is IMelee)
                {
                    moveBehavior = new MeleeMoveBehavior(uiHero);
                }
                else if (emoticons[index] is IShooting)
                {
                    moveBehavior = new ShootingMoveBehavior(uiHero);
                }
                else
                {
                    moveBehavior = new RunAwayMoveBehavior(uiHero);
                }

                var sprite = spriteData.DuplicateSprite(emoticons[index].Name);
                var uiEmoticon = new UIEmoticon(barTexture, spriteData, emoticons[index], sprite, uiHero)
                {
                    MoveBehavior = moveBehavior
                };

                uiEmoticon.SetStartPosition(emoticonPositions[index].X, emoticonPositions[index].Y);
                UIObjectContainer.AddUIObject(uiEmoticon);
                UIEmoticonGenerator.CurrentEmoticonCount++;
            }
        }
    }
}
