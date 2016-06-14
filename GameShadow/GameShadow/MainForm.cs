using System;

using System.Windows.Forms;
using GameShadow.GameData;
using GameShadow.Serialization;
using System.Xml;
using GameShadow;
using System.IO;
using GameShadow.Properties;
using System.Media;
using SpriteLibrary;

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

        public SpriteController Controller { get; set; }
        public GameForm GameForm { get; set; }

        public MainForm()
        {
            InitializeComponent();

            //  SerializationHelper.Serialize(emoticon, dataFilePath);
            //  SerializationHelper.Serialize(player, dataFilePath);

            // Deserialize from data.xml

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            var soundPlayer = new SoundPlayer(Resources.Click);
            soundPlayer.Play();
            Application.Exit();
        }

        private void newGameButton_Click(object sender, EventArgs e)
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

        private void saveButton_Click(object sender, EventArgs e)
        {
            var soundPlayer = new SoundPlayer(Resources.Click);
            soundPlayer.Play();
            var game = (Game)Tag;
            var dataFilePath = PathHelper.GetDataFilePath(RelativePath);
            SerializationHelper.Serialize(game, dataFilePath);
        }

        private void LoadGameButton_Click(object sender, EventArgs e)
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
    }
}
