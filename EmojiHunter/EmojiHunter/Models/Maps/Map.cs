namespace EmojiHunter.Models.Maps
{
    using System.Collections.Generic;
    using Contracts;
    using Enumerations;
    using Microsoft.Xna.Framework;

    public abstract class Map : IMap
    {
        private Dictionary<Vector2, ObstacleType> positionByObstacle;

        public Dictionary<Vector2, ObstacleType> Obstacles
        {
            get
            {
                return new Dictionary<Vector2, ObstacleType>(this.positionByObstacle);
            }

            protected set
            {
                this.positionByObstacle = value;
            }
        }
    }
}
