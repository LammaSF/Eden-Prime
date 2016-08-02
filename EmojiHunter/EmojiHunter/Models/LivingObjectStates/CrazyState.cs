namespace EmojiHunter.Models.LivingObjectStates
{
    using System.Runtime.Serialization;

    [DataContract]
    public class CrazyState : State
    {
        private const int DefaultDamage = 50;

        private const float DefaultMovementSpeed = 4f;

        public CrazyState(int health, int armor) : base(health, armor, DefaultDamage, DefaultMovementSpeed)
        {
        }
    }
}
