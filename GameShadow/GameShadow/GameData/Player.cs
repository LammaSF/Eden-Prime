namespace GameShadow.GameData
{
    public class Player
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Player(int x, int y)
        {
            // ISSUE: What happens if x, y is not valid position
            X = x;
            Y = y;  
        }
    }
}
