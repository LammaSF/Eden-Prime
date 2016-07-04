using EmojiHunter.GameAnimation;
using Microsoft.Xna.Framework;

namespace EmojiHunter.GameData.Maps
{
    public class CenterMap : Map
    {
        public CenterMap()
        {
            base.positionByObstacle =
                new System.Collections.Generic.Dictionary<Vector2, string>()
                {
                    [new Vector2(800, 300)] = $"{ObstacleType.Tree1}",
                    [new Vector2(800, 520)] = $"{ObstacleType.Tree2}",
                    [new Vector2(1100, 320)] = $"{ObstacleType.Tree3}",
                    [new Vector2(600, 600)] = $"{ObstacleType.Tree1}",
                    [new Vector2(700, 200)] = $"{ObstacleType.Tree3}",
                    [new Vector2(550, 200)] = $"{ObstacleType.Tree4}",
                    [new Vector2(900, 380)] = $"{ObstacleType.Tree6}",
                    [new Vector2(200, 540)] = $"{ObstacleType.Tree7}",
                };
        }
    }
}
