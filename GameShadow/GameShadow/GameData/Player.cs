using SpriteLibrary;
using System.Runtime.Serialization;

namespace GameShadow.GameData
{
    [DataContract]
    public class Player : SpritePayload
    {
        private const int DefaultHealth = 100;
        private const int DefaultDamage = 40;
        [DataMember]
        private int _health;
        [DataMember]
        private int _smiles;
        [DataMember]
        public int Health
        {
            get { return _health; }
            set
            {
                _health = value;
                if (_health > DefaultHealth)
                    _health = DefaultHealth;
            }
        }
        [DataMember]
        public int Smiles
        {
            get { return _smiles; }
            set
            {
                _smiles = value;
                if (_smiles < 0)
                    _smiles = 0;
            }
        }
        [DataMember]
        public int PositionX { get; set; }
        [DataMember]
        public int PositionY { get; set; }
        [DataMember]
        public int Damage { get; set; }
        [DataMember]
        public int Kills { get; set; }

        public Player(int positionX, int positionY)
        {
            PositionX = positionX;
            PositionY = positionY;
            Health = DefaultHealth;
            Damage = DefaultDamage;
        }
    }
}