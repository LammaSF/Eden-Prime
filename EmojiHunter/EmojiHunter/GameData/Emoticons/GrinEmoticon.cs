namespace EmojiHunter.GameData.Emoticons
{
    public class GrinEmoticon : GoodEmoticon
    {
            private const int DamageBoostValue = 5;

            private const int DefaultHealth = 100;

            private const int DefaultArmor = 20;

            private const float DefaultMovementSpeed = 1;

            private readonly Reward DefaultReward = new Reward(0, 0, DamageBoostValue, 0, 0);

            public GrinEmoticon(string name) : base(name)
            {
                this.Health = DefaultHealth;
                this.Armor = DefaultArmor;
                this.MovementSpeed = MovementSpeed;
                this.Reward = DefaultReward;
            }
      
    }
}