using SpriteLibrary;

namespace GameShadow.GameData
{
    public enum EmoticonType
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
        Length
    }

    public class Emoticon : SpritePayload
    {
        public EmoticonType Type { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public int RewardSmiles { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public Emoticon(int positionX, int positionY)
        {
            PositionX = positionX;
            PositionY = positionY;
        }
    }
}