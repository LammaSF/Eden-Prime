namespace EmojiHunter.GameData.Emoticons
{
    public class CheekyEmoticon : GoodEmoticon
    {
        private const int ManaBoostValue = 10;

        private const int DefaultHealth = 100;

        private const int DefaultArmor = 20;

        private readonly Reward DefaultReward = new Reward(0, ManaBoostValue, 0, 0, 0);

        public CheekyEmoticon(string name) : base(name)
        {
            this.Health = DefaultHealth;
            this.Armor = DefaultArmor;
            this.Reward = DefaultReward;
        }
    }
}