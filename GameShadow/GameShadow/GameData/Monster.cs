using System;

namespace GameShadow.GameData
{
    public class Monster : LivingCreature
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaximumDamage { get; set; }
        public int RewardExperiencePoints { get; set; }
        public int RewardGold { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public Monster(int ids, string names, int maxDamage, int rewardExpPoints, int rewGold, int currentHitPoints, int maximumHitPoints, int posX, int posY)
            : base(currentHitPoints, maximumHitPoints)
        {
            Id = ids;
            Name = names;
            MaximumDamage = maxDamage;
            RewardExperiencePoints = rewardExpPoints;
            RewardGold = rewGold;
            PositionX = posX;
            PositionY = posY;

        }
    }
}
