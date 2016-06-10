﻿using System;

namespace GameShadow.GameData
{
    public class LivingCreature
    {
        public int CurrentHitPoints { get; set; }
        public int MaximumHitPoints { get; set; }

        public LivingCreature() {}

        public LivingCreature(int currHitPoints, int maxHitPoints)
        {
            CurrentHitPoints = currHitPoints;
            MaximumHitPoints = maxHitPoints;
        }
    }
}
