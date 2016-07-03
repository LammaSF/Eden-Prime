namespace EmojiHunter.GameData.Emoticons
{
    public abstract class GoodEmoticon : Emoticon
    {
        protected GoodEmoticon(string name) : base(name)
        {
        }

        public Reward Reward { get; protected set; }
    }
}
