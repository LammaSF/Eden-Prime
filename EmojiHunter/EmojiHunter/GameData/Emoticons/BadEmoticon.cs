using System;

namespace EmojiHunter.GameData.Emoticons
{
    public abstract class BadEmoticon : Emoticon
    {
        private int damage;

        private int attackSpeed;

        protected BadEmoticon(string name) : base(name)
        {
        }

        public int Damage
        {
            get
            {
                return this.damage;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Emoticon's damage cannot be negative");
                }

                this.damage = value;
            }
        }

        public int AttackSpeed
        {
            get
            {
                return this.attackSpeed;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Emoticon's attack speed cannot be negative");
                }

                this.attackSpeed = value;
            }
        }       
    }
}
