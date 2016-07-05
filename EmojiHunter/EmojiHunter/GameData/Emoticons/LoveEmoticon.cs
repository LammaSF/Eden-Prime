namespace EmojiHunter.GameData.Emoticons
{
    public class LoveEmoticon : GoodEmoticon
    {
            private const int HealthBoostValue = 5;

            private const int DefaultHealth = 70;

            private const int DefaultArmor = 40;

            private const float DefaultMovementSpeed = 1;

            private readonly Reward DefaultReward = new Reward(HealthBoostValue,0, 0, 0, 0);

            public LoveEmoticon(string name) : base(name)
            {
                this.Health = DefaultHealth;
                this.Armor = DefaultArmor;
                this.MovementSpeed = MovementSpeed;
                this.Reward = DefaultReward;
            }
    }
}
