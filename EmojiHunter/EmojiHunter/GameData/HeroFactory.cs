namespace EmojiHunter.GameData
{
    using System;
    using System.Collections.Generic;
    using EmojiHunter.GameData.Heroes;

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
            if (this.HeroByName.ContainsKey(name))
            {
                return this.HeroByName[name];
            }

            throw new InvalidOperationException("Such hero name does not exist.");
        }
    }
}
