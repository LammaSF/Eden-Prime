using SpriteLibrary;
using System;

namespace GameShadow.GameData
{
    public enum EmoticonType
    {
        Smile, Sad
    }

    public class Emoticon : SpritePayload
    {
        public EmoticonType Type { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public int RewardSmiles { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public Emoticon(EmoticonType type, int health, int damage, int rewardSmiles, int posX, int posY)
        {
            Type = type;
            Health = health;
            Damage = damage;
            RewardSmiles = rewardSmiles;
            PositionX = posX;
            PositionY = posY;
        }

        public Emoticon(int posX, int posY)
        {
            PositionX = posX;
            PositionY = posY;
        }
    }
}
