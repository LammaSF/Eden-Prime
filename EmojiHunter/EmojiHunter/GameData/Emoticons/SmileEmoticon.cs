namespace EmojiHunter.GameData.Emoticons
{
    public class SmileEmoticon : GoodEmoticon
    {
        private const int StrengthBoostValue = 5;

        private const int DefaultHealth = 100;

        private const int DefaultArmor = 20;

        private readonly Reward defaultReward = new Reward(0, 0, 0, StrengthBoostValue, 0);

        public SmileEmoticon(string name) : base(name)
        {
            this.Health = DefaultHealth;
            this.Armor = DefaultArmor;
            this.Reward = this.defaultReward;
        }
    }
}