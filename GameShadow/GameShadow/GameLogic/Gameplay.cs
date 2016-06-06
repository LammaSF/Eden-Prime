﻿using GameShadow.GameData;
using SpriteLibrary;
using System;
using System.Windows.Forms;

namespace GameShadow.GameLogic
{
    public static class Gameplay
    {
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
        public static void WeHaveHit(object sender, SpriteEventArgs e)
        {
           // MessageBox.Show(" Ooooops ! Malko se blysnahme .");
            e.TargetSprite.Destroy();
        }
    }
}
