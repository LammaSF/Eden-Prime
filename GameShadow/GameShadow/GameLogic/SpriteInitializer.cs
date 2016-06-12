using GameShadow.GameData;
using GameShadow.Properties;
using SpriteLibrary;
using System.Drawing;

namespace GameShadow.GameLogic
{
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
        private const int SpriteDimensions = 50; // 50px x 50px
        private static readonly Size SpriteSize = 
            new Size(SpriteDimensions, SpriteDimensions);
        
        #region Public Methods
        public static void InitializeSprites(SpriteController controller, Sprite sprite)
        {
            InitializeHeroSprite(controller, sprite);
            InitializeEmoticonSprite(controller, sprite);
            InitializeTreeSprite(controller, sprite);
            InitializeCrosshairSprite(controller, sprite);
            InitializeSunballSprite(controller, sprite);
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
            sprite.SetSize(SpriteSize);
            sprite.SetName($"{SpriteNames.Hero}");
        }

        private static void InitializeEmoticonSprite(SpriteController controller, Sprite sprite)
        {
            for (EmoticonType emoticon = 0; emoticon < EmoticonType.Length; emoticon++)
            {
                int index = (int)emoticon;
                sprite = new Sprite(new Point(0, index * 50), controller,
                    Resources.Emoticons, 50, 50, 300, 10);
                sprite.SetSize(SpriteSize);
                sprite.SetName($"{emoticon}");
            }
        }

        private static void InitializeTreeSprite(SpriteController controller, Sprite sprite)
        {
            sprite = new Sprite(new Point(0, 0), controller,
                Resources.Trees, 120, 150, 100000, 1);
            sprite.SetSize(SpriteSize);
            sprite.SetName($"{SpriteNames.ObstacleTree1}");
        }

        private static void InitializeSunballSprite(SpriteController controller, Sprite sprite)
        {
            sprite = new Sprite(new Point(0, 675), controller,
                Resources.Magicballs, 75, 75, 100, 8);
            sprite.SetSize(SpriteSize);
            sprite.SetName($"{SpriteNames.Sunball}");
        }

        private static void InitializeCrosshairSprite(SpriteController controller, Sprite sprite)
        {
            sprite = new Sprite(new Point(0, 0), controller,
                Resources.Crosshair, 24, 24, 0, 1);
            sprite.SetSize(new Size(24, 24));
            sprite.SetName($"{SpriteNames.Crosshair}");
        }

        #endregion
    }
}
