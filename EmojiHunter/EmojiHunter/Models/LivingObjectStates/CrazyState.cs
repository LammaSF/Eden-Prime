namespace EmojiHunter.Models.LivingObjectStates
{
    public class CrazyState : State
    {
        private const int DefaultDamage = 50;

        private const float DefaultMovementSpeed = 4f;

        public CrazyState(int health, int armor) : base(health, armor, DefaultDamage, DefaultMovementSpeed)
        {
        }
    }
}
