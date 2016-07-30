namespace EmojiHunter.Contracts
{
    using System.Collections.Generic;
    using Enumerations;
    using Microsoft.Xna.Framework;

    public interface IMap
    {
        Dictionary<Vector2, ObstacleType> Obstacles { get; }
    }
}