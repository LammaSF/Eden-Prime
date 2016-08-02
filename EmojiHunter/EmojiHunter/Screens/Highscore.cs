namespace EmojiHunter.Screens
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    [DataContract]
    public class Highscore
    {
        private const int ScoreCount = 10;

        public Highscore()
        {
            this.Scores = new List<int>(new []{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
        }

        [DataMember]
        public List<int> Scores { get; set; }

        public void AddScore(int score)
        {
            this.Scores.Add(score);
            this.Scores = this.Scores
                .OrderByDescending(s => s)
                .Take(ScoreCount)
                .ToList();
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont spriteFont)
        {
            spriteBatch.DrawString(spriteFont, $"#1: {this.Scores[0]} pts", new Vector2(400, 200), Color.DarkRed);
            spriteBatch.DrawString(spriteFont, $"#2: {this.Scores[1]} pts", new Vector2(400, 240), Color.Red);
            spriteBatch.DrawString(spriteFont, $"#3: {this.Scores[2]} pts", new Vector2(400, 280), Color.Orange);
            spriteBatch.DrawString(spriteFont, $"#4: {this.Scores[3]} pts", new Vector2(400, 320), Color.Yellow);
            spriteBatch.DrawString(spriteFont, $"#5: {this.Scores[4]} pts", new Vector2(400, 360), Color.Green);
            spriteBatch.DrawString(spriteFont, $"#6: {this.Scores[5]} pts", new Vector2(400, 400), Color.LightBlue);
            spriteBatch.DrawString(spriteFont, $"#7: {this.Scores[6]} pts", new Vector2(400, 440), Color.Blue);
            spriteBatch.DrawString(spriteFont, $"#8: {this.Scores[7]} pts", new Vector2(400, 480), Color.DarkBlue);
            spriteBatch.DrawString(spriteFont, $"#9: {this.Scores[8]} pts", new Vector2(400, 520), Color.Violet);
            spriteBatch.DrawString(spriteFont, $"#10: {this.Scores[9]} pts", new Vector2(400, 560), Color.Black);
        }
    }
}
