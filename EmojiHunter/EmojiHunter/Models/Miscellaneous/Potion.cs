namespace EmojiHunter.Models.Miscellaneous
{
    using System;
    using Contracts;
    using Enumerations;
    using Heroes;

    public class Potion : GameObject
    {
        private const int Value = 50;

        private PotionType potionType;

        public Potion(PotionType potionType)
        {
            this.potionType = potionType;
        }

        public override event EventHandler Destroy;

        public override void ReactOnCollision(IGameObject other)
        {
            if (other is Hero)
            {
                var hero = other as Hero;

                switch (this.potionType)
                {
                    case PotionType.HealthPotion:
                        hero.Health += Potion.Value;
                        break;
                    case PotionType.ArmorPotion:
                        hero.Armor += Potion.Value;
                        break;
                    case PotionType.ManaPotion:
                        hero.Mana += Potion.Value;
                        break;
                    case PotionType.StrengthPotion:
                        hero.Strength += Potion.Value;
                        break;
                    case PotionType.Length:
                        break;
                }

                this.Destroy?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
