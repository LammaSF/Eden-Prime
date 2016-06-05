using GameShadow.GameData;

namespace GameShadow.GameLogic
{
    public static class Gameplay
    {
        public static void UpdatePlayerPosition(Player player, int x, int y)
        {
            player.PositionX = x;
            player.PositionY = y;
        }
    }
}
