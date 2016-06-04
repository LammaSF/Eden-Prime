using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShadow.GameData
{
    public class LivingCreature
    {
        public int currentHitPoints { get; set; }
        public int maximumHitPoints { get; set; }

        public LivingCreature(int currHitPoints, int maxHitPoints)
        {
            currentHitPoints = currHitPoints;
            maximumHitPoints = maxHitPoints;
        }
    }
}
