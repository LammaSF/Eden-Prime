using GameShadow.GameData;

namespace GameShadow.GameLogic
{
    public static class GameInitializer
    {
        public static Map CreateMap(string[] mapArgs)
        {
            int length = int.Parse(mapArgs[0]);
            int width = int.Parse(mapArgs[1]);

            return new Map(length, width);
        }
    }
}
