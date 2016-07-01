using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace EmojiHunter.GameData
{
    public class Hero
    {
        

        public Hero(string name)
        {
            Name = name;
            MovementSpeed = 1;
            SightSpeed = 10;
        }

        public float MovementSpeed { get; set; }
        public string Name { get; set; }
        public int ShootingAngle { get; internal set; }
        public int SightSpeed { get; internal set; }
    }
}
