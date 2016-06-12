using System.Collections.Generic;

namespace GameShadow.GameData
{
    public class Game
    {
        public Player Player { get; set; }
        public List<Emoticon> Emoticons { get; set; }
        public Dictionary<int, bool> ObstaclesByPosition { get; set; }

        public Game(Player player)
        {
            Player = player;
            Emoticons = new List<Emoticon>();
            ObstaclesByPosition = new Dictionary<int, bool>();
        }
    }
}