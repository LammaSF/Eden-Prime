namespace EmojiHunter.Factories
{
    using System;
    using System.Collections.Generic;
    using Models.Emoticons.GoodEmoticons;
    using Models.Emoticons;
    using Models.Emoticons.BadEmoticons;
    using Enumerations;

    public class EmoticonFactory
    {
        public Emoticon CreateEmoticon(EmoticonType emoticonType)
        {
            switch (emoticonType)
            {
                case EmoticonType.Angry:
                    return new AngryEmoticon("Angry");
                case EmoticonType.Cheeky:
                    return new CheekyEmoticon("Cheeky");
                case EmoticonType.Cry:
                    return new CryEmoticon("Cry");
                case EmoticonType.Grin:
                    return new GrinEmoticon("Grin");
                case EmoticonType.Love:
                    return new LoveEmoticon("Love");
                case EmoticonType.Onfire:
                    return new OnfireEmoticon("Onfire");
                case EmoticonType.Sad:
                    return new SadEmoticon("Sad");
                case EmoticonType.Shouting:
                    return new ShoutingEmoticon("Shouting");
                case EmoticonType.Shy:
                    return new ShyEmoticon("Shy");
                case EmoticonType.Smile:
                    return new SmileEmoticon("Smile");
              
                default:
                    throw new InvalidOperationException("Such emoticon type does not exist.");
            }
            
        }
    }
}
