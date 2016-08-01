namespace EmojiHunter.Models.Maps
{
    using Enumerations;
    using Microsoft.Xna.Framework;

    public class SpringMap : Map
    {
        public SpringMap()
        {
            base.Obstacles =
                new System.Collections.Generic.Dictionary<Vector2, ObstacleType>()
                {
                    [new Vector2(800, 0)] = ObstacleType.Tree5,
                    [new Vector2(800, 350)] = ObstacleType.Tree5,
                    [new Vector2(800, 750)] = ObstacleType.Tree5,
                    [new Vector2(1200, 550)] = ObstacleType.Tree5,
                    [new Vector2(1200, 100)] = ObstacleType.Tree5,
                    [new Vector2(300, 300)] = ObstacleType.Tree1,
                    [new Vector2(100, 100)] = ObstacleType.Tree2
                };
        }
    }
}
