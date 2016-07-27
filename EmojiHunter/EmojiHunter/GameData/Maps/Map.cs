namespace EmojiHunter.GameData.Maps
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public abstract class Map
    {
        protected Dictionary<Vector2, string> positionByObstacle;

        public Dictionary<Vector2, string> Obstacles =>
            new Dictionary<Vector2, string>(this.positionByObstacle);
    }
}
