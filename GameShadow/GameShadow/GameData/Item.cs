using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShadow.GameData
{
    public class Item
    {
        public int id { get; set; }
        public string name { get; set; }
        public string namePlural { get; set; }

        public Item(int ids, string names, string namePlurals)
        {
            id = ids;
            name = names;
            namePlural = namePlurals;
        }
    }
}
