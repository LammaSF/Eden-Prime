namespace GameShadow.GameData
{
    public class Player : LivingCreature
    {
        public int posX { get; set; }
        public int posY { get; set; }        
        public int gold { get; set; }
        public int experiencePoints { get; set; }
        public int level { get; set; }

        public Player(int currentHitPoints, int maximumHitPoints, int golds, int expPoints, int levels,int posXs,int posYs) : base(currentHitPoints, maximumHitPoints)
        {
            // ISSUE: What happens if x, y is not valid position
            gold = golds;
            experiencePoints = expPoints;
            level = levels;
            posX = posXs;
            posY = posYs;
        }
    }
}
