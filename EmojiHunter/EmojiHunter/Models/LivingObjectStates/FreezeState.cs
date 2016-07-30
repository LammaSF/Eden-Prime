namespace EmojiHunter.Models.LivingObjectStates
{
    public class FreezeState : State
    {
        private const int DefaultDamage = 0;

        private const float DefaultMovementSpeed = 0f;

        public FreezeState(int health, int armor) : base(health, armor, DefaultDamage, DefaultMovementSpeed)
        {
        }
    }
}
