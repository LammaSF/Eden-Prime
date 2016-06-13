using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;

namespace GameShadow.GameData
{
    [DataContract]
    public class Game
    {
        [DataMember]
        public Player Player { get; set; }
        [DataMember]
        public List<Emoticon> Emoticons { get; set; }
        [DataMember]
        public List<Point> StaticEnemyBalls { get; set; }
        [DataMember]
        public Dictionary<Point, Point> MovingEnemyBalls { get; set; }
        [DataMember]
        public Dictionary<Point, Directions> PlayerSunballs { get; set; }
        [DataMember]
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