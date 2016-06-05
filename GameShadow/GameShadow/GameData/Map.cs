namespace GameShadow.GameData
{
    public class Map
    {
        public int Length { get; private set; }
        public int Width { get; private set; }
        public int[,] GameField { get; set; }
        public Player Player { get; private set; }

        public Map(int length, int width)
        {
            // TO DO: Exceptions for exceeded size limits
            Length = length;
            Width = width;
            GameField = new int[length, width];

            // ISSUE: Inflexible / hardcoded, to change variable after
            Player = new Player(20,20,100,0,1,length / 2, width / 2);
        }

    }
}
