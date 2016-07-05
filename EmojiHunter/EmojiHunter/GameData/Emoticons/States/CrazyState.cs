﻿namespace EmojiHunter.GameData.Emoticons.States
{
    public class CrazyState : IEmoticonState
    {
        private const int DefaultDamage = 50;

        private const float DefaultMovementSpeed = 15f;

        public int Damage => DefaultDamage;

        public float MovementSpeed => DefaultMovementSpeed;
    }
}
