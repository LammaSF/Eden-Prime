using GameShadow.GameData;
using GameShadow.Properties;
using SpriteLibrary;
using System.Drawing;

namespace GameShadow.GameHelpers
{
    public enum DeadEmoticons
    {
        DeadSmile,
        DeadCheeky,
        DeadGrin,
        DeadLove,
        DeadSad,
        DeadShouting,
        DeadShy,
        DeadCry,
        DeadAngry,
        DeadOnFire,
        Length,
    }

    public enum SpriteNames
    {
        EmoticonSmile,
        EmoticonCheeky,
        EmoticonGrin,
        EmoticonLove,
        EmoticonSad,
        EmoticonShouting,
        EmoticonShy,
        EmoticonCry,
        EmoticonAngry,
        EmoticonOnFire,
        DeadSmile,
        DeadCheeky,
        DeadGrin,
        DeadLove,
        DeadSad,
        DeadShouting,
        DeadShy,
        DeadCry,
        DeadAngry,
        DeadOnFire,
        FreezeSmile,
        FreezeCheeky,
        FreezeGrin,
        FreezeLove,
        FreezeSad,
        FreezeShouting,
        FreezeShy,
        FreezeCry,
        FreezeAngry,
        FreezeOnFire,
        CrazySmile,
        CrazyCheeky,
        CrazyGrin,
        CrazyLove,
        CrazySad,
        CrazyShouting,
        CrazyShy,
        CrazyCry,
        CrazyAngry,
        CrazyOnFire,
        ObstacleTree1,
        ObstacleTree2,
        ObstacleTree3,
        ObstacleTree4,
        ObstacleTree5,
        ObstacleTree6,
        ObstacleTree7,
        Hero,
        Crosshair,
        Fireball,
        Iceball,
        Sunball,
        EnemyBall
    }

    public static class SpriteInitializer
    {
        #region Constants and Readonly Fields
        private const int HeroSpriteDimensions = 50; // 50 px x 50 px
        private const int MagicBallDimensions = 30; // 24 px x 24 px
        private const int CrosshairDimensions = 24; // 24 px x 24 px

        private static readonly Size HeroSpriteSize =
            new Size(HeroSpriteDimensions, HeroSpriteDimensions);
        private static readonly Size MagicBallSpriteSize =
            new Size(MagicBallDimensions, MagicBallDimensions);
        private static readonly Size CrosshairSpriteSize =
            new Size(CrosshairDimensions, CrosshairDimensions);

        #endregion

        #region Public Methods
        public static void InitializeSprites(SpriteController controller, Sprite sprite)
        {
            InitializeHeroSprite(controller, sprite);
            InitializeEmoticonSprite(controller, sprite);
            InitializeTreeSprite(controller, sprite);
            InitializeCrosshairSprite(controller, sprite);
            InitializeSunballSprite(controller, sprite);
            InitializeIceballSprite(controller, sprite);
            InitializeEnemyBallSprite(controller, sprite);
            InitializeDeadEmoticonSprite(controller, sprite);
        }

        #endregion

        #region Private Methods
        private static void InitializeHeroSprite(SpriteController controller, Sprite sprite)
        {
            sprite = new Sprite(new Point(0, 128), controller,
                Resources.Heroes, 32, 32, 250, 3);
            sprite.AddAnimation(new Point(0, 160), Resources.Heroes, 32, 32, 250, 3);
            sprite.AddAnimation(new Point(0, 192), Resources.Heroes, 32, 32, 250, 3);
            sprite.AddAnimation(new Point(0, 224), Resources.Heroes, 32, 32, 250, 3);
            sprite.SetSize(HeroSpriteSize);
            sprite.SetName($"{SpriteNames.Hero}");
        }

        private static void InitializeEmoticonSprite(SpriteController controller, Sprite sprite)
        {
            for (EmoticonType emoticon = 0; emoticon < EmoticonType.Length; emoticon++)
            {
                int index = (int)emoticon;
                sprite = new Sprite(new Point(0, index * 50), controller,
                    Resources.Emoticons, 50, 50, 300, 10);
                sprite.SetSize(HeroSpriteSize);
                sprite.SetName($"{emoticon}");
            }
        }

        private static void InitializeTreeSprite(SpriteController controller, Sprite sprite)
        {
            sprite = new Sprite(new Point(0, 0), controller,
                Resources.Trees, 120, 150, 100000, 1);
            sprite.SetSize(HeroSpriteSize);
            sprite.SetName($"{SpriteNames.ObstacleTree1}");
        }

        private static void InitializeSunballSprite(SpriteController controller, Sprite sprite)
        {
            sprite = new Sprite(new Point(0, 675), controller,
                Resources.Magicballs, 75, 75, 100, 8);
            sprite.SetSize(MagicBallSpriteSize);
            sprite.SetName($"{SpriteNames.Sunball}");
        }

        private static void InitializeIceballSprite(SpriteController controller, Sprite sprite)
        {
            sprite = new Sprite(new Point(0, 375), controller,
                Resources.Magicballs, 75, 75, 100, 8);
            sprite.SetSize(MagicBallSpriteSize);
            sprite.SetName($"{SpriteNames.Iceball}");
        }

        private static void InitializeEnemyBallSprite(SpriteController controller, Sprite sprite)
        {
            sprite = new Sprite(new Point(0, 225), controller,
                Resources.Magicballs, 75, 75, 100, 8);
            sprite.SetSize(MagicBallSpriteSize);
            sprite.SetName($"{SpriteNames.EnemyBall}");
        }

        private static void InitializeCrosshairSprite(SpriteController controller, Sprite sprite)
        {
            sprite = new Sprite(new Point(0, 0), controller,
                Resources.Crosshair, 24, 24, 0, 1);
            sprite.SetSize(CrosshairSpriteSize);
            sprite.SetName($"{SpriteNames.Crosshair}");
        }

        private static void InitializeDeadEmoticonSprite(SpriteController controller, Sprite sprite)
        {
            for (DeadEmoticons emoticon = 0; emoticon < DeadEmoticons.Length; emoticon++)
            {
                int index = (int)emoticon;
                sprite = new Sprite(new Point(500, index * 50), controller,
                                    Resources.Emoticons, 50, 50, 300, 3);
                sprite.SetSize(HeroSpriteSize);
                sprite.SetName($"{emoticon}");
            }
        }
        #endregion

    }
}
