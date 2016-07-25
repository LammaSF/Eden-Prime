using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace EmojiHunter.GameData.Maps
{
    public abstract class Map
    {
        protected Dictionary<Vector2, string> positionByObstacle;

        public Dictionary<Vector2, string> Obstacles =>
            new Dictionary<Vector2, string>(this.positionByObstacle);
    }
}
