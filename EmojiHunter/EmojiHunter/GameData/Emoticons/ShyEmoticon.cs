namespace EmojiHunter.GameData.Emoticons
{
    public class ShyEmoticon : GoodEmoticon
    {
        private const int SpeedBoostValue = 2;

        private const int DefaultHealth = 200;

        private const int DefaultArmor = 20;

        private const float DefaultMovementSpeed = 1;

        private readonly Reward DefaultReward = new Reward(0, 0, 0, 0, SpeedBoostValue);

        public ShyEmoticon(string name) : base(name)
        {
            this.Health = DefaultHealth;
            this.Armor = DefaultArmor;
            this.MovementSpeed = MovementSpeed;
            this.Reward = DefaultReward;
        }
    }
}