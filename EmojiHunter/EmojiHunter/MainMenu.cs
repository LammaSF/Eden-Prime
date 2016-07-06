

namespace EmojiHunter
{
using System;
using System.Windows.Forms;
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
          
            using (var game = new EmojiHunterGame("Spring", "Sagittarius"))
                game.Run();
            
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OptionsButton_Click(object sender, EventArgs e)
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

        private void backButton_Click(object sender, EventArgs e)
        {
            newGameButton.Visible = true;
          //  saveButton.Visible = true;
            resumeButton.Visible = true;
         //   loadButton.Visible = true;
            exitButton.Visible = true;
            optionsButton.Visible = true;
            txtOptions.Visible = false;
            backButton.Visible = false;
        }

        private void resumeButton_Click(object sender, EventArgs e)
        {
            //Controller.DoTick += GameMenu.OnGameIteration;
           // Controller.UnPause();
            
        }

        private void loadButton_Click(object sender, EventArgs e)
        {

        }
    }
    
}
