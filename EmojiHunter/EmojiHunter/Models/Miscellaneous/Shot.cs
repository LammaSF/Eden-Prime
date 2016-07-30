namespace EmojiHunter.Models.Miscellaneous
{
    using System;
    using Contracts;
    using Enumerations;

    public class Shot : GameObject, IShot
    {
        public Shot(string id, SpellShotType type, int damage, float speed)
        {
            this.ID = id;
            this.Type = type;
            base.State.Damage = damage;
            base.State.MovementSpeed = speed;
        }

        public override event EventHandler Destroy;

        public string ID { get; }

        public SpellShotType Type { get; }

        public override void ReactOnCollision(IGameObject other)
        {
            if (this.ID == other.GetType().Name)
            {
                return;
            }

            this.Destroy?.Invoke(this, EventArgs.Empty);
        }
    }
}
