namespace GameShadow.GameData
{
    public class Player : LivingCreature
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }        
        public int Gold { get; set; }
        public int ExperiencePoints { get; set; }
        public int Level { get; set; }

        public Player(int currentHitPoints, int maximumHitPoints, int golds, int expPoints, int levels,int posXs,int posYs) : base(currentHitPoints, maximumHitPoints)
        {
            // ISSUE: What happens if x, y is not valid position
            Gold = golds;
            ExperiencePoints = expPoints;
            Level = levels;
            PositionX = posXs;
            PositionY = posYs;
        }
    }
}
