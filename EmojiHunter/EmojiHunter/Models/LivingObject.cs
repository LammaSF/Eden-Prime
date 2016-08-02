namespace EmojiHunter.Models
{
    using System;
    using System.Runtime.Serialization;
    using Contracts;

    [DataContract]
    public abstract class LivingObject : GameObject
    {
        protected LivingObject(string name)
        {
            this.Name = name;
        }

        public override event EventHandler Destroy;
        [DataMember]
        public string Name { get; set; }

        public override void ReactOnCollision(IGameObject other)
        {
            if (this.State.Armor <= 0)
            {
                this.State.Health -= other.State.Damage;
            }
            else
            {
                this.State.Armor -= other.State.Damage;
            }

            if (this.State.Health <= 0)
            {
                this.Destroy?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
