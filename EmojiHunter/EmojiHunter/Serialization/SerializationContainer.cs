namespace EmojiHunter.Serialization
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Microsoft.Xna.Framework;
    using Models.Emoticons;
    using Models.Heroes;

    [DataContract]
    public class SerializationContainer
    {
        [DataMember]
        public IList<Emoticon> Emoticons { get; set; }

        [DataMember]
        public IList<Vector2> EmoticonPositions { get; set; }

        [DataMember]
        public Sagittarius Hero { get; set; }

        [DataMember]
        public Vector2 HeroPosition { get; set; }

        [DataMember]
        public int Points { get; set; }

        [DataMember]
        public int Kills { get; set; }
    }
}
