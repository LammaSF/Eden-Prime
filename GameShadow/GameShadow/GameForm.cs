using GameShadow.GameData;
using GameShadow.GameLogic;
using GameShadow.Properties;
using SpriteLibrary;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameShadow
{
    public partial class GameForm : Form
    {
        private enum Directions { Down, Left, Right, Up, None }

        private const int HeroMovementSpeed = 20;

        #region Private Fields
        private SpriteController _spriteController;
        private Sprite _hero;
        private Point _heroStartPoint = new Point(300, 300);
        private DateTime _heroLastMovement = DateTime.Now;
        private bool _heroIsMoving = false;
        private Directions _direction = Directions.None;

        #endregion

        #region Constructors
        public GameForm()
        {
            InitializeComponent();

            InitializeUIGameField();
            InitializeUIPlayer();
        }

        #endregion

        #region Private Methods
        private void InitializeUIGameField()
        {
            picGameField.BackgroundImage = Resources.Background;
            picGameField.BackgroundImageLayout = ImageLayout.Stretch;
            _spriteController = new SpriteController(picGameField);
            _spriteController.DoTick += OnKeyPressed;
        }

        private void InitializeUIPlayer()
        {
            _hero = new Sprite(new Point(0, 0), _spriteController,
                Resources.MaleWizard, 32, 32, 250, 3);
            _hero.SetSize(new Size(50, 50));
            _hero.AddAnimation(new Point(0, 32), Resources.MaleWizard, 32, 32, 250, 3);
            _hero.AddAnimation(new Point(0, 64), Resources.MaleWizard, 32, 32, 250, 3);
            _hero.AddAnimation(new Point(0, 96), Resources.MaleWizard, 32, 32, 250, 3);
            _hero.PutPictureBoxLocation(_heroStartPoint);
            _hero.MovementSpeed = HeroMovementSpeed;
            _hero.CannotMoveOutsideBox = true;
        }

        private void MoveUIPlayer(int animationIndex, int directionDegrees, Directions direction)
        {
            if (_direction != direction)
            {
                _hero.SetSpriteDirectionDegrees(directionDegrees);
                _hero.ChangeAnimation(animationIndex);
                _direction = direction;
            }

            _heroIsMoving = true;
            _hero.MovementSpeed = 20;
            _hero.AutomaticallyMoves = true;
        }

        #endregion

        #region Event Handlers
        private void OnKeyPressed(object sender, EventArgs e)
        {
            TimeSpan duration = DateTime.Now - _heroLastMovement;
            if (duration.TotalMilliseconds < 100)
                return;
            _heroLastMovement = DateTime.Now;

            _heroIsMoving = false;
            bool keyDown = _spriteController.IsKeyPressed(Keys.Down);
            bool keyLeft = _spriteController.IsKeyPressed(Keys.Left);
            bool keyRight = _spriteController.IsKeyPressed(Keys.Right);
            bool keyUp = _spriteController.IsKeyPressed(Keys.Up);

            if (keyDown)
                MoveUIPlayer(0, 270, Directions.Down); // move down

            if (keyLeft)
                MoveUIPlayer(1, 180, Directions.Left); // move left

            if (keyRight)
                MoveUIPlayer(2, 0, Directions.Right); // move right

            if (keyUp)
                MoveUIPlayer(3, 90, Directions.Up); // move up

            if (!_heroIsMoving)
            {
                _direction = Directions.None;
                _hero.MovementSpeed = 0;
            }
        }

        #endregion

    }
}
