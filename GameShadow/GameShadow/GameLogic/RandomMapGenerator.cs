using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



    class RandomMapGenerator
    {
        static void Main(string[] args)
        {
        int n = 10;// dimentions of the map (map.X)
        int m = 10;// map.Y
        int[,] tiles = new int [m,n];
        bool[,] isWalkable = new bool [m,n];
        // 3 types of tiles - 0 = grass(walkable), 1= rock (not walkable),2= water (not walkable)
        Random rnd = new Random();

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)

            {
                int r = rnd.Next(0, 100);
                tiles[i, j] =  (r < 75) ? 0 : (r < 85) ? 1 : 2;
                if (tiles[i, j] == 0) isWalkable[i, j] = true;
                else isWalkable[i, j] = false;
            }
        }
        for (int i = 0; i < n; i++)
        {
            for (int x = 0; x < m; x++)
                Console.Write(tiles[i, x].ToString() + " ");
            Console.WriteLine();
        }
        Console.ReadKey();
    }
    }

