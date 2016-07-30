namespace EmojiHunter.GameData
{
    using System;
    using System.Collections.Generic;
    using EmojiHunter.GameData.Maps;

    public class MapFactory
    {
        private readonly Dictionary<string, Map> mapByName =
            new Dictionary<string, Map>()
            {
                ["center"] = new CenterMap(),
                ["spring"] = new SpringMap()
            };

        public Map CreateMap(string mapName)
        {
            string name = mapName.ToLower();
            if (this.mapByName.ContainsKey(name))
            {
                return this.mapByName[name];
            }

            throw new InvalidOperationException("Such map name does not exist.");
        }
    }
}
