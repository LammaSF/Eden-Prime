using System;

using System.Windows.Forms;
using GameShadow.GameData;
using GameShadow.Serialization;
using System.Xml;
using GameShadow;
using System.IO;


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

        public MainForm()
        {
            InitializeComponent();
          
          //  SerializationHelper.Serialize(emoticon, dataFilePath);
          //  SerializationHelper.Serialize(player, dataFilePath);

            // Deserialize from data.xml
           
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
         
            Application.Exit();
        }
        
        private void newGameButton_Click(object sender, EventArgs e)
        {

            GameForm sForm1 = new GameForm(this);
       // sForm1.Disposing();
        sForm1.Show();
        

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var game = (Game)Tag;
            var dataFilePath = PathHelper.GetDataFilePath(RelativePath);
            SerializationHelper.Serialize(game, dataFilePath);
        }

        private void LoadGameButton_Click(object sender, EventArgs e)
        {
            Game loadedGame = null;
            var dataFilePath = PathHelper.GetDataFilePath(RelativePath);
            if (File.Exists(dataFilePath))
            {
                loadedGame = SerializationHelper.Deserialize<Game>(dataFilePath);
                GameForm sForm1 = new GameForm(this, loadedGame);
                sForm1.Show();
            }
            else
            {
                MessageBox.Show("No such file. Please start a new game!");






            }
            //   GameShadow.GameForm sForm1 = new GameShadow.GameForm(this);


        }
    }
}
