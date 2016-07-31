namespace EmojiHunter.Models
{
    using System;
    using Contracts;
    using LivingObjectStates;
    using Miscellaneous;

    public abstract class GameObject : IGameObject
    {
        private readonly IState defaultState;

        protected GameObject()
        {
            this.defaultState = new DefaultState();
            this.Reward = new Reward(0, 0, 0, 0, 0);
        }

        public virtual event EventHandler Destroy;

        public virtual IReward Reward { get; set; }

        public virtual IState State
        {
            get { return this.defaultState; }

            set { }
        }

        public abstract void ReactOnCollision(IGameObject other);
    }
}
