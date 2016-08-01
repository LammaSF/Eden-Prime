namespace MapSerializer
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Enumerations;

    [DataContract]
    public class ObstacleContainer
    {
        public ObstacleContainer(Dictionary<CustomPoint, ObstacleType> obstacles)
        {
            this.Obstacles = obstacles;
        }

        [DataMember]
        public Dictionary<CustomPoint, ObstacleType> Obstacles { get; }
    }
}
