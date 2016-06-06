using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using GameShadow;


namespace Hello
{
    public partial class Game : Form
    {
        public Game()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
         
            Application.Exit();
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
        
        GameShadow.GameForm sForm1 = new GameShadow.GameForm();
       // sForm1.Disposing();
        sForm1.Show();
         


        }
    }
}
