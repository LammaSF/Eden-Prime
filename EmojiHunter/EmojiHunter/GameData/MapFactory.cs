namespace EmojiHunter.GameData
{
    using System;
    using System.Collections.Generic;
    using EmojiHunter.GameData.Maps;

    public class MapFactory
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
            if (this.MapByName.ContainsKey(name))
            {
                return this.MapByName[name];
            }

            throw new InvalidOperationException("Such map name does not exist.");
        }
    }
}
