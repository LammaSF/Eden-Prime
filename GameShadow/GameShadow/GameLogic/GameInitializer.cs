using System;
using GameShadow.GameData;

namespace GameShadow.GameLogic
{
    public static class GameInitializer
    {
        public const int FieldWidth = 12;
        public const int FieldLength = 12;
        public const int MovableTerrainOdds = 90;
        public const int NoSpawnRadius = 3;
        public const int MonsterCount = 5;

        private static readonly int MaxFieldPosition = FieldWidth * FieldLength - 1;

        static void GenerateObstacles(Game game)
        {
            
            Random rnd = new Random();

            for (int y = 0; y < FieldWidth; y++)
            {
                for (int x = 0; x < FieldLength; x++)

                {
                    int r = rnd.Next(0, 100);
                    game.Field[x, y] = (r < MovableTerrainOdds) ? 0 : 1;
                    if (game.Field[x, y] == 1)
                    {
                        game.ObstaclesByPosition.Add((y * FieldLength + x),true);
                    }
                    else game.ObstaclesByPosition.Add((y * FieldLength + x), false);
                }
            }

        }


        public static void SpawnMonsters(Game game)
        {
            Random rnd = new Random();
            while (game.Monsters.Count != MonsterCount)
            {
                int position = rnd.Next(0, MaxFieldPosition);
                int positionX = position % FieldLength;
                int positionY = position / FieldLength;
                if (game.Field[positionX, positionY] == 0)
                {
                    int distanceToPlayer =
                        Math.Abs(positionX * positionX + positionY * positionY -
                        game.Player.PositionX * game.Player.PositionX + positionY * positionY);

                    if (distanceToPlayer > NoSpawnRadius * NoSpawnRadius)
                    {
                        Monster monster = new Monster(positionX, positionY);
                        game.Monsters.Add(monster);
                    }
                }
            }
        }
    }
}
