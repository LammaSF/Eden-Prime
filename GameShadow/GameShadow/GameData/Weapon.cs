using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShadow.GameData
{
    public class Weapon : Item
    {
        public int minimumDamage { get; set; }
        public int maximumDamage { get; set; }

        public Weapon(int id, string name, string namePlural, int minDamage, int maxDamage) : base(id, name, namePlural)
        {
            minimumDamage = minDamage;
            maximumDamage = maxDamage;
        }
    }
}
}
