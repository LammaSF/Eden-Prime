﻿namespace EmojiHunter.IO
{
    using Contracts;
    using Helpers;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class HeroStatisticsDrawer : Contracts.IDrawable
    {
        private IHero hero;

        private SpriteFont font;

        public HeroStatisticsDrawer(IHero hero, SpriteFont font)
        {
            this.hero = hero;
            this.font = font;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(
                this.font,
                $"Health: {this.hero.Health} / {this.hero.CurrentMaxHealth}",
                new Vector2(20, 20),
                Color.Red);

            spriteBatch.DrawString(
                this.font,
                $"Armor: {this.hero.Armor} / {this.hero.CurrentMaxArmor}",
                new Vector2(230, 20),
                Color.GreenYellow);

            spriteBatch.DrawString(
                this.font,
                $"Mana: {this.hero.Mana} / {this.hero.CurrentMaxMana}",
                new Vector2(410, 20),
                Color.Blue);

            spriteBatch.DrawString(
                this.font,
                $"Strength: {this.hero.Strength} / {this.hero.CurrentMaxStrength}",
                new Vector2(600, 20),
                Color.Yellow);

            spriteBatch.DrawString(this.font,
                $"Kills: {Global.Kills}",
                new Vector2(1340, 20),
                Color.Black);

            spriteBatch.DrawString(this.font,
                $"Points:  {Global.Points}",
                new Vector2(1450, 20),
                Color.Black);
        }
    }
}
