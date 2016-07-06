namespace EmojiHunter.GameData.Heroes
{
    public class Aquarius : Hero
    {
        private const int DefaultInvisibilityManaCost = 1; // per 100 ms 

        private const int DefaultShieldingManaCost = 1; // per 100 ms 

        private const int DefaultReflectingManaCost = 1; // per 100 ms 

        public Aquarius(string name) : base(name)
        {
            this.IsInvisible = false;
            this.IsShielded = false;
            this.IsReflecting = false;
        }

        public bool IsInvisible { get; set; }

        public bool IsShielded { get; set; }

        public bool IsReflecting { get; set; }

        public int InvisibilityManaCost => DefaultInvisibilityManaCost;

        public int ShieldingManaCost => DefaultShieldingManaCost;

        public int ReflectingManaCost => DefaultReflectingManaCost;

    }
}
