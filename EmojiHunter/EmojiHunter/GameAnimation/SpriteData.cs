namespace EmojiHunter.GameAnimation
{
    using System.Collections.Generic;

    public class SpriteData
    {
        public SpriteData()
        {
            this.SpriteByName = new Dictionary<string, AnimatedSprite>();
        }

        public Dictionary<string, AnimatedSprite> SpriteByName { get; private set; }

        public AnimatedSprite DuplicateSprite(AnimatedSprite sprite)
        {
            if (sprite == null)
            {
                return null;
            }

            return new AnimatedSprite(sprite);
        }

        public AnimatedSprite DuplicateSprite(string spriteName)
        {
            if (this.SpriteByName.ContainsKey(spriteName))
            {
                return this.DuplicateSprite(this.SpriteByName[spriteName]);
            }

            return null;
        }
    }
}
