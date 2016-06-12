using GameShadow.GameData;
using SpriteLibrary;
using System;
using System.Windows.Forms;

namespace GameShadow.GameLogic
{
    public static class Gameplay
    {
        static Random rnd = new Random();
        public static int xDistance;
        public static int yDistance;
        public static bool moved = false;
        public static void UpdatePlayerPosition(Player player, int x, int y)
        {
            player.PositionX = x;
            player.PositionY = y;
        }

        public static void SpriteBounces(object sender, EventArgs e)
        {
            Sprite me = (Sprite)sender;
            int degrees = (int)me.GetSpriteDegrees();
            if (Math.Abs(degrees) > 120)
            {
                me.SetSpriteDirectionDegrees(0);//go right
            }
            else
            {
                me.SetSpriteDirectionDegrees(180); //go back left
            }
        }
        
        //public static void UpdatePlayerHealth(Player player, int damage)
        //{
        //    player.CurrentHitPoints -= damage;
        //}

        //        public static void UpdateMonsterPosition(Emoticon monster, Player player, Game game)
        //        {
        //            xDistance = monster.PositionX - player.PositionX;
        //            yDistance = monster.PositionY - player.PositionY;
        //            moved = false;

        //            if (xDistance == 0 & yDistance == 0) // MonsterAttacksHero();
        //                if (xDistance == 0)
        //                    MoveVertically(monster, game);
        //                else if (yDistance == 0)
        //                    MoveHorizontally(monster, game);
        //                else
        //                if (rnd.Next(0, 2) == 0)
        //                {
        //                    MoveHorizontally(monster, game);
        //                    if (moved == false) MoveVertically(monster, game);
        //                }
        //                else
        //                {
        //                    MoveVertically(monster, game);
        //                    if (moved == false) MoveHorizontally(monster, game);
        //                }
        //            if (moved == false) MoveRandomly(monster, game);

        //        }
        //       static void MoveVertically(Emoticon monster, Game game)
        //{
        //    if (xDistance > 0)
        //        MoveLeft(monster, game);
        //    else MoveRight(monster, game);
        //}

        //static void MoveHorizontally(Emoticon monster, Game game)
        //{
        //    if (yDistance > 0) MoveDown(monster, game);
        //    else MoveUp(monster, game);
        //}

        //static void MoveLeft(Emoticon monster, Game game)
        //{
        //    if (monster.PositionX > 0 & game.Field[monster.PositionX - 1, monster.PositionY] == 0)
        //    {
        //        monster.PositionX--;
        //        moved = true;
        //    }
        //}
        //static void MoveRight(Emoticon monster, Game game)
        //{
        //    if (monster.PositionX < game.fieldLength - 1 & game.Field[monster.PositionX + 1, monster.PositionY] == 0)
        //    {
        //        monster.PositionX++;
        //        moved = true;
        //    }
        //}
        //static void MoveDown(Emoticon monster, Game game)
        //{
        //    if (monster.PositionY > 0 & game.Field[monster.PositionX, monster.PositionY - 1] == 0)
        //    {
        //        monster.PositionY--;
        //        moved = true;
        //    }
        //}
        //static void MoveUp(Emoticon monster, Game game)
        //{
        //    if (monster.PositionY < game.fieldWidth - 1 & game.Field[monster.PositionX, monster.PositionY + 1] == 0)
        //    {
        //        monster.PositionY++;
        //        moved = true;
        //    }

        //}
        //static void MoveRandomly(Emoticon monster, Game game)
        //{
        //            if (monster.PositionX > 0 & game.Field[monster.PositionX - 1, monster.PositionY] == 0)
        //            {
        //                monster.PositionX--;
        //                moved = true;
        //            }
        //            if (monster.PositionY > 0 & game.Field[monster.PositionX, monster.PositionY - 1] == 0)
        //            {
        //                monster.PositionY--;
        //                moved = true;
        //            }
        //            if (monster.PositionY < game.fieldWidth - 1 & game.Field[monster.PositionX, monster.PositionY + 1] == 0)
        //            {
        //                monster.PositionY++;
        //                moved = true;
        //            }
        //            else if (monster.PositionX < game.fieldLength - 1 & game.Field[monster.PositionX + 1, monster.PositionY] == 0)
        //                {
        //                    monster.PositionX++;
        //                    moved = true;
        //                }

        //        }
        //   
    }
}
