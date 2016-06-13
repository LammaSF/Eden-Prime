using SpriteLibrary;
using System.Runtime.Serialization;

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
    [DataContract]
    public class Emoticon : SpritePayload
    {
        [DataMember]
        public EmoticonType Type { get; set; }
        [DataMember]
        public int Health { get; set; }
        [DataMember]
        public int Damage { get; set; }
        [DataMember]
        public int RewardSmiles { get; set; }
        [DataMember]
        public int PositionX { get; set; }
        [DataMember]
        public int PositionY { get; set; }
       
        public Emoticon(int positionX, int positionY)
        {
            PositionX = positionX;
            PositionY = positionY;
        }
    }
}