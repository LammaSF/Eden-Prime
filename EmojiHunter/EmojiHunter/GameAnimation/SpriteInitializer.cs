using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace EmojiHunter.GameAnimation
{
    public enum PotionType
    {
        HealthPotion,
        ArmorPotion,
        ManaPotion,
        StrengthPotion,
        Length
    }

    public enum ObstacleType
    {
        Tree1,
        Tree2,
        Tree3,
        Tree4,
        Tree5,
        Tree6,
        Tree7,
        Length
    }

    public enum EmoticonType
    {
        Smile,
        Cheeky,
        Grin,
        Love,
        Shy,
        Sad,
        Shouting,
        Cry,
        Angry,
        Onfire,
        Length
    }

    public enum HeroType
    {
        Aquarius,
        Sagittarius,
        Length
    }

    public enum SpellShotType
    {
        Sunball,
        Fireball,
        Iceball,
        Mine
    }

    public enum MiscellaneousType
    {
        Sight,
        SpellShot
    }

    public static class SpriteInitializer
    {
        private const float HeroFrameDuration = 250f;
        private const float SightFrameDuration = 100000f;
        private const float ObstacleFrameDuration = 100000f;
        private const float PotionFrameDuration = 500f;
        private const float SpellShotFrameDuration = 100f;
        private const float EmoticonFrameDuration = 250f;
        private const float DeadEmoticonFrameDuration = 250f;
        private const float FreezeEmoticonFrameDuration = 250f;
        private const float CrazyEmoticonFrameDuration = 250f;
        private const int HeroFrameCount = 3;
        private const int SightFrameCount = 1;
        private const int ObstacleFrameCount = 1;
        private const int PotionFrameCount = 3;
        private const int SpellShotFrameCount = 8;
        private const int EmoticonFrameCount = 10;
        private const int DeadEmoticonFrameCount = 3;
        private const int FreezeEmoticonFrameCount = 3;
        private const int CrazyEmoticonFrameCount = 3;

        private static readonly Dictionary<ObstacleType, Rectangle> RectangleByObstacle =
            new Dictionary<ObstacleType, Rectangle>()
            {
                [ObstacleType.Tree1] = new Rectangle(10, 2, 100, 157),
                [ObstacleType.Tree2] = new Rectangle(124, 27, 83, 134),
                [ObstacleType.Tree3] = new Rectangle(217, 5, 128, 160),
                [ObstacleType.Tree4] = new Rectangle(356, 18, 109, 145),
                [ObstacleType.Tree5] = new Rectangle(10, 173, 90, 153),
                [ObstacleType.Tree6] = new Rectangle(116, 186, 94, 134),
                [ObstacleType.Tree7] = new Rectangle(220, 170, 86, 158),
            };

        public static void InitializeSprites(SpriteData spriteData, ContentManager content)
        {
            InitializeHeroSprite(spriteData, content);
            InitializeSightSprite(spriteData, content);
            InitializeSpellShotSprite(spriteData, content);
            InitializeEmoticonSprite(spriteData, content);
            InitializeObstacleSprite(spriteData, content);
            InitializePotionSprite(spriteData, content);
        }

        private static void InitializePotionSprite(SpriteData spriteData, ContentManager content)
        {
            var texture = content.Load<Texture2D>(@"Content\Potions");
            for (PotionType item = 0; item < PotionType.Length; item++)
            {
                int index = (int)item;

                var sprite = new AnimatedSprite(texture, new Rectangle(0, 30 * index, 30, 30),
                    PotionFrameDuration, PotionFrameCount);
                sprite.SetSize(30, 30);
                sprite.Name = $"{item}";

                UpdateSpriteData(spriteData, sprite);
            }
        }

        private static void InitializeObstacleSprite(SpriteData spriteData, ContentManager content)
        {
            var texture = content.Load<Texture2D>(@"Content\Trees");
            for (ObstacleType obstacle = 0; obstacle < ObstacleType.Length; obstacle++)
            {
                var sprite = new AnimatedSprite(texture, RectangleByObstacle[obstacle],
                    ObstacleFrameDuration, ObstacleFrameCount);
                sprite.SetSize(RectangleByObstacle[obstacle].Width,
                    RectangleByObstacle[obstacle].Height);
                sprite.Name = $"{obstacle}";

                UpdateSpriteData(spriteData, sprite);
            }
        }

        private static void InitializeHeroSprite(SpriteData spriteData, ContentManager content)
        {
            for (HeroType hero = 0; hero < HeroType.Length; hero++)
            {
                var index = (int)hero;

                var texture = content.Load<Texture2D>(@"Content\LightHeroNormal");
                var sprite = new AnimatedSprite();

                AddHeroAnimations(texture, sprite, index);

                texture = content.Load<Texture2D>(@"Content\LightHeroShield");
                AddHeroAnimations(texture, sprite, index);

                texture = content.Load<Texture2D>(@"Content\LightHeroMirror");
                AddHeroAnimations(texture, sprite, index);

                texture = content.Load<Texture2D>(@"Content\LightHeroInvisible");
                AddHeroAnimations(texture, sprite, index);

                texture = content.Load<Texture2D>(@"Content\LightHeroFreeze");
                AddHeroAnimations(texture, sprite, index);

                sprite.Name = $"{hero}";

                UpdateSpriteData(spriteData, sprite);
            }
        }

        private static void AddHeroAnimations(Texture2D texture, AnimatedSprite sprite, int index)
        {
            sprite.AddAnimation(texture, new Rectangle(0, index * 128, 32, 32),
                HeroFrameDuration, HeroFrameCount);
            sprite.AddAnimation(texture, new Rectangle(0, (index * 128) + 32, 32, 32),
                HeroFrameDuration, HeroFrameCount);
            sprite.AddAnimation(texture, new Rectangle(0, (index * 128) + 64, 32, 32),
                HeroFrameDuration, HeroFrameCount);
            sprite.AddAnimation(texture, new Rectangle(0, (index * 128) + 96, 32, 32),
                HeroFrameDuration, HeroFrameCount);
            sprite.SetSize(32, 32);
        }

        private static void InitializeEmoticonSprite(SpriteData spriteData, ContentManager content)
        {
            var texture = content.Load<Texture2D>(@"Content\Emoticons");
            for (EmoticonType emoticon = 0; emoticon < EmoticonType.Length; emoticon++)
            {
                int index = (int)emoticon;
                var sprite = new AnimatedSprite(texture, new Rectangle(0, index * 50, 50, 50),
                    EmoticonFrameDuration, EmoticonFrameCount);

                sprite.AddAnimation(texture, new Rectangle(500, index * 50, 50, 50),
                    DeadEmoticonFrameDuration, DeadEmoticonFrameCount);
                sprite.AddAnimation(texture, new Rectangle(650, index * 50, 50, 50),
                    FreezeEmoticonFrameDuration, FreezeEmoticonFrameCount);
                sprite.AddAnimation(texture, new Rectangle(800, index * 50, 50, 50),
                    CrazyEmoticonFrameDuration, CrazyEmoticonFrameCount);
                sprite.SetSize(50, 50);

                sprite.Name = $"{emoticon}";

                UpdateSpriteData(spriteData, sprite);
            }
        }

        public static void InitializeSightSprite(SpriteData spriteData, ContentManager content)
        {
            var texture = content.Load<Texture2D>(@"Content\Crosshair");
            var sprite = new AnimatedSprite(texture, new Rectangle(0, 0, 24, 24),
                SightFrameDuration, SightFrameCount);
            sprite.SetSize(24, 24);
            sprite.Name = $"{MiscellaneousType.Sight}";

            UpdateSpriteData(spriteData, sprite);
        }

        private static void InitializeSpellShotSprite(SpriteData spriteData, ContentManager content)
        {
            var texture = content.Load<Texture2D>(@"Content\Magicballs");
            var sprite = new AnimatedSprite(texture, new Rectangle(0, 675, 75, 75),
                SpellShotFrameDuration, SpellShotFrameCount);

            sprite.AddAnimation(texture, new Rectangle(0, 75, 75, 75),
                SpellShotFrameDuration, SpellShotFrameCount);
            sprite.AddAnimation(texture, new Rectangle(0, 375, 75, 75),
                SpellShotFrameDuration, SpellShotFrameCount);
            sprite.AddAnimation(texture, new Rectangle(0, 225, 75, 75),
                SpellShotFrameDuration, SpellShotFrameCount);
            sprite.SetSize(75, 75);
            sprite.Name = $"{MiscellaneousType.SpellShot}";

            UpdateSpriteData(spriteData, sprite);
        }

        private static void UpdateSpriteData(SpriteData spriteData, AnimatedSprite sprite)
        {
            if (spriteData.SpriteByName.ContainsKey(sprite.Name))
            {
                spriteData.SpriteByName[sprite.Name] = sprite;
            }
            else
            {
                spriteData.SpriteByName.Add(sprite.Name, sprite);
            }
        }
    }
}
