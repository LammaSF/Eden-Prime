namespace EmojiHunter.Models
{
    using System;
    using System.Runtime.Serialization;
    using Contracts;
    using LivingObjectStates;
    using Miscellaneous;

    [KnownType(typeof(Reward))]
    [KnownType(typeof(State))]
    [KnownType(typeof(FreezeState))]
    [KnownType(typeof(DefaultState))]
    [KnownType(typeof(NormalState))]
    [KnownType(typeof(CrazyState))]
    [DataContract]
    public abstract class GameObject : IGameObject
    {
        protected GameObject()
        {
            this.State = new DefaultState();
            this.Reward = new Reward(0, 0, 0, 0, 0);
        }

        public virtual event EventHandler Destroy;

        [DataMember]
        public virtual IReward Reward { get; set; }

        [DataMember]
        public virtual IState State { get; set; }

        public abstract void ReactOnCollision(IGameObject other);
    }
}
