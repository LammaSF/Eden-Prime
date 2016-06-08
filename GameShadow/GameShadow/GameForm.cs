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
        private const int MonsterMovementSpeed = 5;

        #region Private Fields
        private SpriteController _spriteController;
        private Sprite _hero;
        private Sprite _bullet;
        private Point _heroStartPoint = new Point(500, 500);
        private DateTime _heroLastMovement = DateTime.Now;
        private bool _heroIsMoving = false;
        private Directions _direction = Directions.None;
        private Sprite _monster;
        //private Point _monsterStartPoint = new Point(500, 500);
        private DateTime _monsterLastMovement = DateTime.Now;
        private bool _monsterIsMoving = false;

        #endregion

        #region Constructors

        public GameForm()
        {
            InitializeComponent();
            InitializeUIGameField();
            InitializeUIPlayer();
            InitializeUIMonster();
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
            _hero.SpriteHitsSprite += Gameplay.WeHaveHit;
        }
        private void InitializeUIMonster()
        {
            Random rnd = new Random();

            _monster = new Sprite(new Point(0, 0), _spriteController,
                Resources.FishMonster, 190, 210, 250, 5);
            _monster.SetSize(new Size(75, 75));
            _monster.AddAnimation(new Point(0, 200), Resources.FishMonster, 200, 200, 250, 5);
            _monster.AddAnimation(new Point(0, 400), Resources.FishMonster, 200, 200, 250, 5);
            _monster.AddAnimation(new Point(0, 600), Resources.FishMonster, 200, 200, 250, 5);
            _monster.PutPictureBoxLocation(_heroStartPoint);
            _monster.MovementSpeed = MonsterMovementSpeed;
            _monster.CannotMoveOutsideBox = true;
            _monster.AutomaticallyMoves = true;
            _monster.SpriteHitsPictureBox += Gameplay.SpriteBounces;
            _monster.SetSpriteDirectionDegrees(180);
            _monster.PutBaseImageLocation(new Point(rnd.Next(38, 500), rnd.Next(38, 500)));
            // TO DO - Handle collisions between 2 monsters (to go through each other)
            //_monster.SpriteHitsSprite += Gameplay.WeHaveHit;

            _monster.MoveTo(_hero.BaseImageLocation);
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
            _monster.MoveTo(_hero.BaseImageLocation);// gada trygva kym geroq
        }
        //private void ShootBullets(int animationIndex, int directionDegrees, Directions direction)
        //{
        //    _bullet = new Sprite(new Point(0, 0), _spriteController,
        //       Resources.Bullet, 70, 70, 250, 3);
        //    _bullet.SetSize(new Size(25, 25));
        //    _bullet.AddAnimation(new Point(0, 70), Resources.Bullet, 70, 70, 250, 3);
        //    _bullet.AddAnimation(new Point(0, 140), Resources.Bullet, 70, 70, 250, 3);
        //    _bullet.AddAnimation(new Point(0, 200), Resources.Bullet, 70, 70, 250, 3);
        //    _bullet.PutBaseImageLocation(_heroStartPoint);
        //    _bullet.PutPictureBoxLocation(_heroStartPoint);
        //    _bullet.MovementSpeed = HeroMovementSpeed;
        //   // _bullet.CannotMoveOutsideBox = true;
        //    _bullet.AutomaticallyMoves = true;
        //    _bullet.SetSpriteDirectionDegrees(directionDegrees);
        //    _bullet.ChangeAnimation(animationIndex);
        // NE RABOTI
        //}
        


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
            bool keyEsc = _spriteController.IsKeyPressed(Keys.Escape);
            bool keySpace = _spriteController.IsKeyPressed(Keys.Space);
            if (!keySpace)
            {
                if (keyUp && keyLeft)
                {
                    keyUp = keyLeft = false;
                    MoveUIPlayer(0, 150, Directions.Down); // move up left
                }
                if (keyUp && keyRight)
                {
                    keyUp = keyRight = false;
                    MoveUIPlayer(0, 45, Directions.Down); // move up right
                }
                if (keyDown && keyLeft)
                {
                    keyDown = keyLeft = false;
                    MoveUIPlayer(0, 225, Directions.Down); // move down left
                }
                if (keyDown && keyRight)
                {
                    keyDown = keyRight = false;
                    MoveUIPlayer(0, -45, Directions.Down); // move down right
                }

                if (keyDown)
                    MoveUIPlayer(0, 270, Directions.Down); // move down

                if (keyLeft)
                    MoveUIPlayer(1, 180, Directions.Left); // move left

                if (keyRight)
                    MoveUIPlayer(2, 0, Directions.Right); // move right

                if (keyUp)
                    MoveUIPlayer(3, 90, Directions.Up); // move up

            }
            //else
            //{
            //    if (keyDown)
            //        ShootBullets(0, 270, Directions.Down); // shoot down

            //    if (keyLeft)
            //        ShootBullets(1, 180, Directions.Left); // shoot left

            //    if (keyRight)
            //        ShootBullets(2, 0, Directions.Right); // shoot right

            //    if (keyUp)
            //        ShootBullets(3, 90, Directions.Up); // shoot up
            //}
            if (!_heroIsMoving)
            {
                _direction = Directions.None;
                _hero.MovementSpeed = 0;
            }

            if (keyEsc)
                Application.Exit();// exit 
        }

        #endregion

    }
}
