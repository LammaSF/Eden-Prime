using SpriteLibrary;

namespace GameShadow.GameData
{
    public class Player : SpritePayload
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public int Smiles { get; set; }
        public int Kills { get; set; }

        public Player(int health, int damage, int smiles, int kills, int posXs, int posYs)
        {
            // ISSUE: What happens if x, y is not valid position
            Health = health;
            Damage = damage;
            Smiles = smiles;
            Kills = kills;
            PositionX = posXs;
            PositionY = posYs;
        }
    }
}
