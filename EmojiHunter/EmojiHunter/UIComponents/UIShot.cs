namespace EmojiHunter.UIComponents
{
    using EmojiHunter.GameAnimation;
    using EmojiHunter.GameData;
    using EmojiHunter.GameHelpers;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class UIShot : IUIObject
    {
        private float speed;
        private Vector2 position;
        private Vector2 motion;

        public UIShot(Shot shot, AnimatedSprite sprite, float speed)
        {
            this.Shot = shot;
            this.Sprite = sprite;
            this.speed = speed;
        }

        public AnimatedSprite Sprite { get; set; }

        public Shot Shot { get; set; }

        public void Update(GameTime gameTime)
        {
            this.Move();

            this.CheckForShotObjectCollision();

            if (this.IsOutsideMapBorders())
            {
                UIObjectContainer.RemoveUIObject(this.Sprite.ID);
                return;
            }

            this.Sprite.Update(gameTime);
        }

        private bool IsOutsideMapBorders()
        {
            // Hardcoded much ?!
            return this.position.X < -this.Sprite.Rectangle.Width
                || this.position.Y < -this.Sprite.Rectangle.Height
                || this.position.X > 1600 + this.Sprite.Rectangle.Width
                || this.position.Y > 900 + this.Sprite.Rectangle.Height;
        }

        private void CheckForShotObjectCollision()
        {
            foreach (var uiObject in UIObjectContainer.UIObjects)
            {
                if (this != uiObject)
                {
                    if (this.Sprite.Rectangle.Intersects(uiObject.Sprite.Rectangle))
                    {
                        if (uiObject is UIShot)
                        {
                            UIObjectContainer.RemoveUIObject((uiObject as UIShot).Sprite.ID);
                            UIObjectContainer.RemoveUIObject(this.Sprite.ID);
                            return;
                        }
                        else if (uiObject is UIEmoticon)
                        {
                            if (this.Shot.ID == "Hero")
                            {
                                var uiEmoticon = uiObject as UIEmoticon;

                                if (uiEmoticon.Emoticon.Armor == 0)
                                {
                                    uiEmoticon.Emoticon.Health -= this.Shot.Damage;
                                }
                                else
                                {
                                    uiEmoticon.Emoticon.Armor -= this.Shot.Damage;
                                }

                                if (uiEmoticon.Emoticon.Health == 0)
                                {
                                    UIObjectContainer.RemoveUIObject(uiEmoticon.Sprite.ID);
                                    UIEmoticonGenerator.CurrentEmoticonCount--;
                                    Global.Kills++;
                                    Global.Points += 5;
                                }

                                UIObjectContainer.RemoveUIObject(this.Sprite.ID);
                                return;
                            }
                        }
                        else if (uiObject is UIObstacle)
                        {
                            UIObjectContainer.RemoveUIObject(this.Sprite.ID);
                            return;
                        }
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.Sprite.Draw(spriteBatch);
        }

        public void SetInStartPosition(float x, float y)
        {
            this.position.X = x;
            this.position.Y = y;

            this.Sprite.Position = this.position;
        }

        public void SetInMotion(float x, float y)
        {
            this.motion.X = x;
            this.motion.Y = y;
        }

        public void Move()
        {
            this.position += this.motion * this.speed;
            this.Sprite.Position = this.position;
        }
    }
}
