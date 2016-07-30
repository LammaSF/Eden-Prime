namespace EmojiHunter.Helpers
{
    using System.Collections.Generic;
    using Animations;
    using Repository;
    using Models.Miscellaneous;
    using GUIModels;
    using Models.Maps;

    public static class UIObstacleGenerator
    {
        public static List<UIObstacle> GenerateObstacles(SpriteData spriteData, Map map)
        {
            var uiObstacles = new List<UIObstacle>();

            var obstacleByPosition = map.Obstacles;

            foreach (var pair in obstacleByPosition)
            {
                var sprite = spriteData.DuplicateSprite($"{pair.Value}");
                var uiObstacle = new UIObstacle(new Obstacle(), sprite);

                uiObstacle.Sprite.Position = pair.Key;

                UIObjectContainer.AddUIObject(uiObstacle);
                uiObstacles.Add(uiObstacle);
            }

            return uiObstacles;
        }
    } 
}
