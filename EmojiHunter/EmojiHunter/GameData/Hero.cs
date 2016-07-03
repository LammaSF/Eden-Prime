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
        private bool isRunning;

        public Hero(string name)
        {
            Name = name;
            MovementSpeed = 1;
            SightSpeed = 10;
            ShootingSpeed = 10;
        }

        public int Damage { get; internal set; }
        public int Health { get; internal set; }

        public bool IsRunning
        {
            get { return this.isRunning; }

            set
            {
                this.isRunning = value;
                MovementSpeed = (this.IsRunning) ? 5 : 1;
            }
        }

        public int MaxDamage { get; internal set; }
        public int MaxHealth { get; internal set; }
        public int MaxMana { get; internal set; }
        public float MaxSpeed { get; internal set; }
        public int MaxStrength { get; internal set; }
        public float MovementSpeed { get; set; }
        public string Name { get; set; }
        public int ShootingAngle { get; internal set; }
        public int ShootingSpeed { get; internal set; }
        public int SightSpeed { get; internal set; }
    }
}
