using SpriteLibrary;

namespace GameShadow.GameData
{
    public class Player : SpritePayload
    {
        private const int DefaultHealth = 100;
        private const int DefaultDamage = 40;

        private int _health;
        private int _smiles;

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

        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int Damage { get; set; }
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