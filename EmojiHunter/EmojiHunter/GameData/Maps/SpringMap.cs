namespace EmojiHunter.GameData.Maps
{
    using EmojiHunter.GameAnimation;
    using Microsoft.Xna.Framework;

    public class SpringMap : Map
    {
        public SpringMap()
        {
            this.PositionByObstacle =
                new System.Collections.Generic.Dictionary<Vector2, string>()
                {
                    [new Vector2(800, 100)] = $"{ObstacleType.Tree5}",
                    [new Vector2(800, 350)] = $"{ObstacleType.Tree5}",
                    [new Vector2(800, 600)] = $"{ObstacleType.Tree5}",
                    [new Vector2(1100, 450)] = $"{ObstacleType.Tree5}",
                    [new Vector2(1100, 200)] = $"{ObstacleType.Tree5}",
                    [new Vector2(300, 300)] = $"{ObstacleType.Tree1}",
                    [new Vector2(200, 100)] = $"{ObstacleType.Tree2}",
                };
        }
    }
}
