namespace EmojiHunter.Factories
{
    using System;
    using System.Collections.Generic;
    using Models.Heroes;

    public class HeroFactory
    {
        private readonly Dictionary<string, Hero> heroByName =
            new Dictionary<string, Hero>()
            {
                [nameof(Sagittarius)] = new Sagittarius(nameof(Sagittarius)),
            };

        public Hero CreateHero(string heroName)
        {
            string name = heroName;
            if (this.heroByName.ContainsKey(name))
            {
                return this.heroByName[name];
            }

            throw new InvalidOperationException();
        }
    }
}
