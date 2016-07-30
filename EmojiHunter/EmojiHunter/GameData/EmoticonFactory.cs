namespace EmojiHunter.GameData
{
    using System;
    using System.Collections.Generic;
    using Emoticons;

    public class EmoticonFactory
    {
        private readonly Dictionary<string, Emoticon> еmoticonByName =
            new Dictionary<string, Emoticon>()
            {
                ["smile"] = new SmileEmoticon("Smile"),
                ["cheeky"] = new CheekyEmoticon("Cheeky"),
                ["grin"] = new GrinEmoticon("Grin"),
                ["love"] = new LoveEmoticon("Love"),
                ["sad"] = new SadEmoticon("Sad"),
                ["shouting"] = new ShoutingEmoticon("Shouting"),
                ["shy"] = new ShyEmoticon("Shy"),
                ["cry"] = new CryEmoticon("Cry"),
                ["angry"] = new AngryEmoticon("Angry"),
                ["onfire"] = new OnFireEmoticon("Onfire")
            };

        public Emoticon CreateEmoticon(string emoticonName)
        {
            string name = emoticonName.ToLower();
            if (this.еmoticonByName.ContainsKey(name))
            {
                return this.еmoticonByName[name];
            }

            throw new InvalidOperationException("Such emoticon name does not exist.");
        }
    }
}
