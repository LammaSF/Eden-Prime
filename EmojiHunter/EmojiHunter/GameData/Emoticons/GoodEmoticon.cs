namespace EmojiHunter.GameData.Emoticons
{
    using EmojiHunter.GameData.Emoticons.States;

    public abstract class GoodEmoticon : Emoticon
    {
        private NormalState normalState;

        private CrazyState crazyState;

        protected GoodEmoticon(string name) : base(name)
        {
            this.normalState = new NormalState();
            this.crazyState = new CrazyState();
            this.State = this.normalState;
        }

        public Reward Reward { get; protected set; }

        public IEmoticonState State { get; private set; }

        public void SetCrazyState()
        {
            this.State = this.crazyState;
            this.MovementSpeed = this.State.MovementSpeed;
        }

        public void SetNormalState()
        {
            this.State = this.normalState;
            this.MovementSpeed = this.State.MovementSpeed;
        }
    }
}
