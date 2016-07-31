namespace EmojiHunter.Models.Emoticons
{
    using Contracts;

    public abstract class Emoticon : LivingObject
    {
        protected Emoticon(string name) : base(name)
        {
        }

        public override void ReactOnCollision(IGameObject other)
        {
            if (other is Emoticon)
            {
                return;
            }
            
            base.ReactOnCollision(other);
        }
    }
}
