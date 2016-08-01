namespace EmojiHunter.Models.Maps
{
    using Enumerations;
    using Microsoft.Xna.Framework;

    public class CenterMap : Map
    {
        public CenterMap()
        {
            base.Obstacles =
                new System.Collections.Generic.Dictionary<Vector2, ObstacleType>()
                {
                    [new Vector2(150, 0)] = ObstacleType.Tree4,
                    [new Vector2(0, 300)] = ObstacleType.Tree6,
                    [new Vector2(200, 600)] = ObstacleType.Tree4,
                    [new Vector2(740, 0)] = ObstacleType.Tree3,
                    [new Vector2(740, 740)] = ObstacleType.Tree3,
                    [new Vector2(1300, 200)] = ObstacleType.Tree6,
                    [new Vector2(1300, 600)] = ObstacleType.Tree7
                };
        }
    }
}
