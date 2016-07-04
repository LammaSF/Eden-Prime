using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace EmojiHunter.GameAnimation
{
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
        LightHero,
        DarkHero
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
        private const float SpellShotFrameDuration = 100f;
        private const float EmoticonFrameDuration = 250f;
        private const float DeadEmoticonFrameDuration = 250f;
        private const float FreezeEmoticonFrameDuration = 250f;
        private const float CrazyEmoticonFrameDuration = 250f;
        private const int HeroFrameCount = 3;
        private const int SightFrameCount = 1;
        private const int SpellShotFrameCount = 8;
        private const int EmoticonFrameCount = 10;
        private const int DeadEmoticonFrameCount = 3;
        private const int FreezeEmoticonFrameCount = 3;
        private const int CrazyEmoticonFrameCount = 3;

        public static void InitializeSprites(SpriteData spriteData, ContentManager content)
        {
            InitializeHeroSprite(spriteData, content);
            InitializeSightSprite(spriteData, content);
            InitializeSpellShotSprite(spriteData, content);
            InitializeEmoticonSprite(spriteData, content);
        }

        private static void InitializeHeroSprite(SpriteData spriteData, ContentManager content)
        {
            var texture = content.Load<Texture2D>(@"Content\LightHeroNormal");
            var sprite = new AnimatedSprite();

            AddHeroAnimations(texture, sprite);

            texture = content.Load<Texture2D>(@"Content\LightHeroShield");
            AddHeroAnimations(texture, sprite);

            texture = content.Load<Texture2D>(@"Content\LightHeroMirror");
            AddHeroAnimations(texture, sprite);

            texture = content.Load<Texture2D>(@"Content\LightHeroInvisible");
            AddHeroAnimations(texture, sprite);

            texture = content.Load<Texture2D>(@"Content\LightHeroFreeze");
            AddHeroAnimations(texture, sprite);

            sprite.Name = $"{HeroType.LightHero}";

            UpdateSpriteData(spriteData, sprite);
        }

        private static void AddHeroAnimations(Texture2D texture, AnimatedSprite sprite)
        {
            sprite.AddAnimation(texture, new Rectangle(0, 128, 32, 32),
                HeroFrameDuration, HeroFrameCount);
            sprite.AddAnimation(texture, new Rectangle(0, 160, 32, 32),
                HeroFrameDuration, HeroFrameCount);
            sprite.AddAnimation(texture, new Rectangle(0, 192, 32, 32),
                HeroFrameDuration, HeroFrameCount);
            sprite.AddAnimation(texture, new Rectangle(0, 224, 32, 32),
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
                spriteData.SpriteByName[sprite.Name] = sprite;
            else
                spriteData.SpriteByName.Add(sprite.Name, sprite);
        }
    }
}
