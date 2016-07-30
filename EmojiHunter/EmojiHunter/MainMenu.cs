namespace EmojiHunter
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class MainMenu : Form
    {
        private string mapName;

        private string heroName;

        public MainMenu()
        {
            this.InitializeComponent();

            this.mapName = this.mapSpringLabel.Text;
            this.heroName = this.sagittariusHeroLabel.Text;
        }

        private void OnResumeButtonClick(object sender, EventArgs e)
        {
            // TO DO
        }

        private void OnNewGameButtonClick(object sender, EventArgs e)
        {
            using (var game = new EmojiHunterGame(this.mapName, this.heroName))
            {
                game.Run();
            }
        }

        private void OnSaveButtonClick(object sender, EventArgs e)
        {
            // TO DO
        }

        private void OnLoadButtonClick(object sender, EventArgs e)
        {
            // TO DO
        }

        private void OnOptionsButtonClick(object sender, EventArgs e)
        {
            this.mapLabel.Visible = true;
            this.mapCenterLabel.Visible = true;
            this.mapSpringLabel.Visible = true;
            this.heroLabel.Visible = true;
            this.aquariusHeroLabel.Visible = true;
            this.sagittariusHeroLabel.Visible = true;
            this.controlsLabel.Visible = true;
            this.highscoresLabel.Visible = false;
        }

        private void OnHighscoreButtonClick(object sender, EventArgs e)
        {
            this.mapLabel.Visible = false;
            this.mapCenterLabel.Visible = false;
            this.mapSpringLabel.Visible = false;
            this.heroLabel.Visible = false;
            this.aquariusHeroLabel.Visible = false;
            this.sagittariusHeroLabel.Visible = false;
            this.controlsLabel.Visible = false;
            this.highscoresLabel.Visible = true;
        }

        private void OnExitButtonClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OnMapCenterLabelClick(object sender, EventArgs e)
        {
            this.mapName = this.mapCenterLabel.Text;
            this.mapCenterLabel.ForeColor = Color.DarkRed;
            this.mapSpringLabel.ForeColor = Color.Black;
        }

        private void OnMapSpringLabelClick(object sender, EventArgs e)
        {
            this.mapName = this.mapSpringLabel.Text;
            this.mapSpringLabel.ForeColor = Color.DarkRed;
            this.mapCenterLabel.ForeColor = Color.Black;
        }

        private void OnAquariusHeroLabelClick(object sender, EventArgs e)
        {
            this.heroName = this.aquariusHeroLabel.Text;
            this.aquariusHeroLabel.ForeColor = Color.DarkRed;
            this.sagittariusHeroLabel.ForeColor = Color.Black;
        }

        private void OnSagittariusHeroLabelClick(object sender, EventArgs e)
        {
            this.heroName = this.sagittariusHeroLabel.Text;
            this.sagittariusHeroLabel.ForeColor = Color.DarkRed;
            this.aquariusHeroLabel.ForeColor = Color.Black;
        }
    }
}
