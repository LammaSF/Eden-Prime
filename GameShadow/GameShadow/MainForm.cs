using System;
using System.Windows.Forms;
using GameShadow.GameData;
using GameShadow.Serialization;
using System.IO;
using GameShadow.Properties;
using System.Media;
using SpriteLibrary;
using System.Drawing;

namespace GameShadow
{

    public partial class MainForm : Form
    {
        private const string RelativePath = "data.xml";

        public Button SaveButton
        {
            get
            {
                return saveButton;
            }
        }

        public Button ResumeButton
        {
            get
            {
                return resumeButton;
            }
        }

        public SpriteController Controller { get; set; }
        public GameForm GameForm { get; set; }

        public MainForm()
        {
            InitializeComponent();
            Size = new Size(610, 610);
            resumeButton.Enabled = false;
        }

        private void OnExitButtonClick(object sender, EventArgs e)
        {
            var soundPlayer = new SoundPlayer(Resources.Click);
            soundPlayer.Play();
            Application.Exit();
        }

        private void OnNewGameButtonClick(object sender, EventArgs e)
        {
            GameForm gameForm = new GameForm(this);
            if (GameForm != null)
            {
                GameForm.Close();
            }
            GameForm = gameForm;
            var soundPlayer = new SoundPlayer(Resources.Click);
            soundPlayer.Play();

            // sForm1.Disposing();
            gameForm.Show();


        }

        private void OnSaveButtonClick(object sender, EventArgs e)
        {
            var soundPlayer = new SoundPlayer(Resources.Click);
            soundPlayer.Play();
            var game = (Game)Tag;
            var dataFilePath = PathHelper.GetDataFilePath(RelativePath);
            SerializationHelper.Serialize(game, dataFilePath);
        }

        private void OnLoadButtonClick(object sender, EventArgs e)
        {
            var soundPlayer = new SoundPlayer(Resources.Click);
            soundPlayer.Play();
            if (GameForm != null)
            {
                GameForm.Close();
            }

            Game loadedGame = null;
            var dataFilePath = PathHelper.GetDataFilePath(RelativePath);
            if (File.Exists(dataFilePath))
            {
                loadedGame = SerializationHelper.Deserialize<Game>(dataFilePath);
                GameForm gameForm = new GameForm(this, loadedGame);
                GameForm = gameForm;
                gameForm.Show();
            }
            else
            {
                MessageBox.Show("No such file. Please start a new game!");






            }
            //   GameShadow.GameForm sForm1 = new GameShadow.GameForm(this);


        }
                
        private void OnResumeButtonClick(object sender, EventArgs e)
        {
            Controller.DoTick += GameForm.OnGameIteration;
            Controller.UnPause();
            GameForm.Show();
        }

        private void OnOptionsButtonClick(object sender, EventArgs e)
        {
            newGameButton.Visible = false;
            saveButton.Visible = false;
            resumeButton.Visible = false;
            loadButton.Visible = false;
            exitButton.Visible = false;
            optionsButton.Visible = false;
            txtOptions.Visible = true;
            backButton.Visible = true;

        }

        private void OnBackButtonClick(object sender, EventArgs e)
        {
            newGameButton.Visible = true;
            saveButton.Visible = true;
            resumeButton.Visible = true;
            loadButton.Visible = true;
            exitButton.Visible = true;
            optionsButton.Visible = true;
            txtOptions.Visible = false;
            backButton.Visible = false;
        }
    }
}
