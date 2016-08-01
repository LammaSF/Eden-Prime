namespace EmojiHunter.Factories
{
    using System;
    using System.Collections.Generic;
    using Models.Emoticons.GoodEmoticons;
    using Models.Emoticons;
    using Models.Emoticons.BadEmoticons;

    public class EmoticonFactory
    {
        private readonly Dictionary<string, Func<Emoticon>> getEmoticonByName =
            new Dictionary<string, Func<Emoticon>>()
            {
                ["smile"] = () => new SmileEmoticon("Smile"),
                ["cheeky"] = () => new CheekyEmoticon("Cheeky"),
                ["grin"] = () => new GrinEmoticon("Grin"),
                ["love"] = () => new LoveEmoticon("Love"),
                ["sad"] = () => new SadEmoticon("Sad"),
                ["shouting"] = () => new ShoutingEmoticon("Shouting"),
                ["shy"] = () => new ShyEmoticon("Shy"),
                ["cry"] = () => new CryEmoticon("Cry"),
                ["angry"] = () => new AngryEmoticon("Angry"),
                ["onfire"] = () => new OnfireEmoticon("Onfire")
            };

        public Emoticon CreateEmoticon(string emoticonName)
        {
            string name = emoticonName.ToLower();
            if (this.getEmoticonByName.ContainsKey(name))
            {
                return this.getEmoticonByName[name]();
            }

            throw new InvalidOperationException("Such emoticon name does not exist.");
        }
    }
}
