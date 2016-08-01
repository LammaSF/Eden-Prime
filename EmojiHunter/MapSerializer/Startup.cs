namespace MapSerializer
{
    using System.Collections.Generic;
    using Enumerations;
    using Serialization;

    public class Startup
    {
        private const string fileName = "Center.xml";

        public static void Main()
        {
            var obstacles = new Dictionary<CustomPoint, ObstacleType>()
            {
                [new CustomPoint(150, 0)] = ObstacleType.Tree4,
                [new CustomPoint(0, 300)] = ObstacleType.Tree6,
                [new CustomPoint(200, 600)] = ObstacleType.Tree4,
                [new CustomPoint(740, 0)] = ObstacleType.Tree3,
                [new CustomPoint(740, 740)] = ObstacleType.Tree3,
                [new CustomPoint(1300, 200)] = ObstacleType.Tree6,
                [new CustomPoint(1300, 600)] = ObstacleType.Tree7
            };

            var obstacleContainer = new ObstacleContainer(obstacles);

            var dataFilePath = PathHelper.GetDataFilePath(fileName);
            SerializationHelper.Serialize(obstacleContainer, dataFilePath);
        }
    }
}
