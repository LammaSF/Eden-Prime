namespace EmojiHunter.Models.LivingObjectStates
{
    using System.Runtime.Serialization;

    [DataContract]
    public class NormalState : State
    {
        public NormalState(int health, int armor, int damage, float movementSpeed) : base(health, armor, damage, movementSpeed)
        {
        }
    }
}
