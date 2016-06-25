

namespace GameShadow.GameData.Emoticons
{
    public abstract class GoodEmoticon : Emoticon

    {
        private int reward;

        public int Reward
        {
            get
            {
                return this.reward;
            }

            set
            {
                this.reward = value;
            }
        }

        protected  GoodEmoticon(int x, int y) :
            base(x, y)
        {
        }
    }
}
