using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShadow.GameData
{
    class Game
    {
        const int FieldHeight = 600;
        const int FieldWidth = 600;
        public Player Player { get; set; }
        public List<Monster> Monsters { get; set; }

        public Game(Player player, List<Monster> monsters)
        {
            int[,] Field = new int[FieldHeight, FieldWidth];
            player = Player;
            monsters = Monsters;
        }
    }
}
