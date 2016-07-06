using EmojiHunter.GameData.Heroes;
using System;
using System.Collections.Generic;

namespace EmojiHunter.GameData
{
    public class HeroFactory
    {
        private readonly Dictionary<string, Hero> HeroByName =
            new Dictionary<string, Hero>()
            {
                ["sagittarius"] = new Sagittarius("Sagittarius"),
                ["aquarius"] = new Aquarius("Aquarius")
            };

        public Hero CreateHero(string heroName)
        {
            string name = heroName.ToLower();
            if (HeroByName.ContainsKey(name))
            {
                return HeroByName[name];
            }

            throw new InvalidOperationException("Such hero name does not exist.");
        }
    }
}
