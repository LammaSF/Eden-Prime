using System.Collections.Generic;
using System.Drawing;

namespace GameShadow.GameData
{
    public class Game
    {
        public Player Player { get; set; }
        public List<Emoticon> Emoticons { get; set; }
        public List<Point> StaticEnemyBalls { get; set; }
        public Dictionary<Point, Point> MovingEnemyBalls { get; set; } 
        public Dictionary<Point, Directions> PlayerSunballs { get; set; }
        public Dictionary<int, bool> ObstaclesByPosition { get; set; }

        public Game(Player player)
        {
            Player = player;
            Emoticons = new List<Emoticon>();
            StaticEnemyBalls = new List<Point>();
            MovingEnemyBalls = new Dictionary<Point, Point>();
            PlayerSunballs = new Dictionary<Point, Directions>();
            ObstaclesByPosition = new Dictionary<int, bool>();
        }
    }
}