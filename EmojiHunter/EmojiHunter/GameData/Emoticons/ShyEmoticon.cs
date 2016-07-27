namespace EmojiHunter.GameData.Emoticons
{
    public class ShyEmoticon : GoodEmoticon
    {
        private const int SpeedBoostValue = 2;

        private const int DefaultHealth = 200;

        private const int DefaultArmor = 20;

        private readonly Reward defaultReward = new Reward(0, 0, 0, 0, SpeedBoostValue);

        public ShyEmoticon(string name) : base(name)
        {
            this.Health = DefaultHealth;
            this.Armor = DefaultArmor;
            this.Reward = this.defaultReward;
        }
    }
}