using System.Collections.Generic;

namespace EmojiHunter.GameAnimation
{
    internal class SpriteData
    {
        public Dictionary<string, AnimatedSprite> SpriteByName { get; private set; }

        public SpriteData()
        {
            SpriteByName = new Dictionary<string, AnimatedSprite>();
        }

        public AnimatedSprite DuplicateSprite(AnimatedSprite sprite)
        {
            if (sprite == null)
                return null;
            return new AnimatedSprite(sprite);
        }

        public AnimatedSprite DuplicateSprite(string spriteName)
        {
            if (SpriteByName.ContainsKey(spriteName))
                return DuplicateSprite(SpriteByName[spriteName]);

            return null;
        }
    }
}
