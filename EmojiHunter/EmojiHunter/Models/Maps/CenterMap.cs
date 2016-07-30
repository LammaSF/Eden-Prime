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
                    [new Vector2(200, 300)] = ObstacleType.Tree1,
                    [new Vector2(300, 520)] = ObstacleType.Tree2,
                    [new Vector2(740, 300)] = ObstacleType.Tree3,
                    [new Vector2(740, 500)] = ObstacleType.Tree1,
                    [new Vector2(740, 700)] = ObstacleType.Tree3,
                    [new Vector2(740, 100)] = ObstacleType.Tree4,
                    [new Vector2(1000, 280)] = ObstacleType.Tree6,
                    [new Vector2(1000, 540)] = ObstacleType.Tree7
                };
        }
    }
}
