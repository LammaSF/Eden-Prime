using EmojiHunter.GameAnimation;
using EmojiHunter.GameData.Maps;
using EmojiHunter.UIComponents;
using System.Collections.Generic;

namespace EmojiHunter.GameHelpers
{
    public static class UIObstacleGenerator
    {
        public static List<UIObstacle> GenerateObstacles(SpriteData spriteData, Map map)
        {
            var uiObstacles = new List<UIObstacle>();

            var obstacleByPosition = map.Obstacles;

            foreach (var pair in obstacleByPosition)
            {
                var sprite = spriteData.DuplicateSprite(pair.Value);
                var uiObstacle = new UIObstacle(sprite);

                uiObstacle.Sprite.Position = pair.Key;

                UIObjectContainer.AddUIObject(uiObstacle);
                uiObstacles.Add(uiObstacle);
            }

            return uiObstacles;
        }
    } 
}
