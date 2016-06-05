using System;

namespace GameShadow.GameData
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NamePlural { get; set; }

        public Item(int ids, string names, string namePlurals)
        {
            Id = ids;
            Name = names;
            NamePlural = namePlurals;
        }
    }
}
