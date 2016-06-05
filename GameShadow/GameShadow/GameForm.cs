using GameShadow.GameData;
using GameShadow.GameLogic;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameShadow
{
    public partial class GameForm : Form
    {
        private Map _map;

        public GameForm()
        {
            var size = this.Size;
            // ISSUE: Using string[] arguments for CreateMap() is probably not a good idea
            _map = GameInitializer.CreateMap(
                new[] { size.Width.ToString(), size.Height.ToString() });

            InitializeComponent();
        }

        #region Private Methods
        private void MoveUIPlayer()
        {
            Invalidate();
        }

        #endregion

        #region Event Handlers
        private void OnGameFormPaint(object sender, PaintEventArgs e)
        {
            // ISSUE: FillRectangle takes the upper-left corner coordinates 
            e.Graphics.FillRectangle(Brushes.Red, _map.Player.PositionX, _map.Player.PositionY, 50, 50);
        }

        private void OnGameFormKeyDown(object sender, KeyEventArgs e)
        {
            // ISSUE: Moving speed is hardcoded :)
            int speed = 10;

            switch (e.KeyCode)
            {
                case Keys.Up:
                    Gameplay.UpdatePlayerPosition(_map.Player, _map.Player.PositionX,
                        _map.Player.PositionY - speed);
                    break;
                case Keys.Down:
                    Gameplay.UpdatePlayerPosition(_map.Player, _map.Player.PositionX,
                        _map.Player.PositionY + speed);
                    break;
                case Keys.Left:
                    Gameplay.UpdatePlayerPosition(_map.Player, _map.Player.PositionX - speed,
                        _map.Player.PositionY);
                    break;
                case Keys.Right:
                    Gameplay.UpdatePlayerPosition(_map.Player, _map.Player.PositionX + speed,
                        _map.Player.PositionY);
                    break;
            }

            // ISSUE: The player can exit the form borders :)) 
            MoveUIPlayer();
        }
        #endregion

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By SoftUni Team Eden Prime", "Game Shadow");
        }
    }
}
