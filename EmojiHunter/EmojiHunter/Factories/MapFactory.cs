namespace EmojiHunter.Factories
{
    using System;
    using System.Collections.Generic;
    using Models.Maps;

    public class MapFactory
    {
        private readonly Dictionary<string, Map> mapByName =
            new Dictionary<string, Map>()
            {
                [nameof(CenterMap)] = new CenterMap(),
                [nameof(SpringMap)] = new SpringMap()
            };

        public Map CreateMap(string mapName)
        {
            string name = mapName + nameof(Map);
            if (this.mapByName.ContainsKey(name))
            {
                return this.mapByName[name];
            }

            throw new InvalidOperationException();
        }
    }
}
