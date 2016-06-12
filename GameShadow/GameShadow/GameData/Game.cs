using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShadow.GameData
{
    public class Game
    {
        const int FieldSize = 50;
        const int FieldLength = 12; 
        const int FieldWidth = 12;
        public int fieldSize
        {
            get { return FieldSize; }
        }
        public int fieldLength
        {
            get { return FieldLength; }
        }
        public int fieldWidth
        {
            get { return FieldWidth; }
        }
        public Player Player { get; set; }
        public List<Emoticon> Emoticons { get; set; }
        public int[,] Field = new int[FieldLength, FieldWidth];
        public Dictionary<int, bool> ObstaclesByPosition = new Dictionary<int, bool>();

        public Game(Player player, List<Emoticon> emoticons, int[,] field)
        {
            Field = field;
            Player = player;
            Emoticons = emoticons;
        }
	  public Game()
		{
		}
    }

}
