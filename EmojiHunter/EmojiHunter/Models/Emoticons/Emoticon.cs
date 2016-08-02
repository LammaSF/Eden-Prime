namespace EmojiHunter.Models.Emoticons
{
    using System.Runtime.Serialization;
    using Contracts;
    using BadEmoticons;
    using GoodEmoticons;

    [KnownType(typeof(SadEmoticon))]
    [KnownType(typeof(AngryEmoticon))]
    [KnownType(typeof(OnfireEmoticon))]
    [KnownType(typeof(CryEmoticon))]
    [KnownType(typeof(ShyEmoticon))]
    [KnownType(typeof(ShoutingEmoticon))]
    [KnownType(typeof(SmileEmoticon))]
    [KnownType(typeof(CheekyEmoticon))]
    [KnownType(typeof(GrinEmoticon))]
    [KnownType(typeof(LoveEmoticon))]
    [DataContract]
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
