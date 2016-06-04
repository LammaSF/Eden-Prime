using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShadow.GameData
{
    public class Monster : LivingCreature
    {
        public int id { get; set; }
        public string name { get; set; }
        public int maximumDamage { get; set; }
        public int rewardExperiencePoints { get; set; }
        public int rewardGold { get; set; }

        public Monster(int ids, string names, int maxDamage, int rewardExpPoints, int rewGold, int currentHitPoints, int maximumHitPoints)
            : base(currentHitPoints, maximumHitPoints)
        {
            id = ids;
            name = names;
            maximumDamage = maxDamage;
            rewardExperiencePoints = rewardExpPoints;
            rewardGold = rewardGold;
        }
    }
}
