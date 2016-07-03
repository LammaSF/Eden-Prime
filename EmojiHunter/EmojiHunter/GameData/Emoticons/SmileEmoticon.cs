namespace EmojiHunter.GameData.Emoticons
{
    public class SmileEmoticon : GoodEmoticon
    {
        private const int StrengthBoostValue = 5;

        private const int DefaultHealth = 100;

        private const int DefaultArmor = 20;

        private const float DefaultMovementSpeed = 1;

        private readonly Reward DefaultReward = new Reward(0, 0, 0, StrengthBoostValue, 0);

        public SmileEmoticon(string name) : base(name)
        {
            this.Health = DefaultHealth;
            this.Armor = DefaultArmor;
            this.MovementSpeed = MovementSpeed;
            this.Reward = DefaultReward;
        }
    }
}