using System;
using GameShadow.GameData;

namespace GameShadow.GameLogic
{
    public static class GameInitializer
    {
        public const int FieldWidth = 12;
        public const int FieldLength = 12;
        public const int NoSpawnRadius = 3;
        public const int MonsterCount = 5;

        private static readonly int MaxFieldPosition = FieldWidth * FieldLength - 1;

        public static void SpawnMonsters(Game game)
        {
            Random rnd = new Random();
            while (game.Monsters.Count != MonsterCount)
            {
                int position = rnd.Next(0, MaxFieldPosition);
                int positionX = position % FieldLength;
                int positionY = position / FieldWidth;

                int distanceToPlayer =
                    Math.Abs(positionX * positionX + positionY * positionY -
                    game.Player.PositionX * game.Player.PositionX + positionY * positionY);

                if(distanceToPlayer > NoSpawnRadius * NoSpawnRadius)
                {
                    Monster monster = new Monster(positionX, positionY);
                    game.Monsters.Add(monster);
                }
            }
        }
    }
}
