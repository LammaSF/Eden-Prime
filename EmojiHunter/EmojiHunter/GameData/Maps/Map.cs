namespace EmojiHunter.GameData.Maps
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public abstract class Map
    {
        private Dictionary<Vector2, string> positionByObstacle;

        public Dictionary<Vector2, string> Obstacles =>
            new Dictionary<Vector2, string>(this.PositionByObstacle);

        public Dictionary<Vector2, string> PositionByObstacle
        {
            get
            {
                return this.positionByObstacle;
            }

            set
            {
                this.positionByObstacle = value;
            }
        }
    }
}
