using EmojiHunter.GameData.Maps;
using System;
using System.Collections.Generic;

namespace EmojiHunter.GameData
{
    class MapFactory
    {
        private readonly Dictionary<string, Map> MapByName =
            new Dictionary<string, Map>()
            {
                ["center"] = new CenterMap(),
                ["spring"] = new SpringMap()
            };

        public Map CreateMap(string mapName)
        {
            string name = mapName.ToLower();
            if (MapByName.ContainsKey(name))
            {
                return MapByName[name];
            }

            throw new InvalidOperationException("Such map name does not exist.");
        }
    }
}
