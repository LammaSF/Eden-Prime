namespace EmojiHunter.GameData.Emoticons.States
{
    class NormalState : IEmoticonState
    {
        private const int DefaultDamage = 0;

        private const float DefaultMovementSpeed = 3f;

        public int Damage => DefaultDamage;

        public float MovementSpeed => DefaultMovementSpeed;

    }
}
