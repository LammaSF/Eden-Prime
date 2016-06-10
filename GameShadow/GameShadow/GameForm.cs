using GameShadow.GameData;
using GameShadow.GameLogic;
using GameShadow.Properties;
using SpriteLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GameShadow
{
    public partial class GameForm : Form
    {
        private enum Directions { Down, Left, Right, Up, UpRight, UpLeft, DownRight, DownLeft }

        private const int HeroMovementSpeed = 10;
        private const int MonsterMovementSpeed = 5;
        private const int SpriteDimensions = 50; // 50px x 50px

        // ISSUE Hardcoded obstacle
        private readonly Dictionary<int, bool> ObstaclesByPosition =
            new Dictionary<int, bool>
            {
                [80] = true
            };

        #region Private Fields
        private static SpriteController _spriteController;
        private Sprite _hero;
        //private Sprite _bullet;
        private static Point _heroStartPoint = new Point(500, 500);
        private DateTime _heroLastMovement = DateTime.Now;
        private bool _heroIsMoving = false;
        private Directions _heroDirection = Directions.Down;
        public static Sprite _monster;
        //private Point _monsterStartPoint = new Point(500, 500);
        private DateTime _monsterLastMovement = DateTime.Now;
        //private bool _monsterIsMoving = false;

        #endregion

        #region Constructors

        public GameForm()
        {
            InitializeComponent();
            InitializeUIGameField();
            InitializeUIPlayer();
            //InitializeUIMonster();
        }

        #endregion

        #region Private Methods

        private void InitializeUIGameField()
        {
            picGameField.BackgroundImage = Resources.Background;
            picGameField.BackgroundImageLayout = ImageLayout.Stretch;
            _spriteController = new SpriteController(picGameField);
            _spriteController.DoTick += OnKeyPressed;

            label1.Parent = picGameField;
            label1.BackColor = Color.Transparent;
            label2.Parent = picGameField;
            label2.BackColor = Color.Transparent;
            lblHealth.Parent = picGameField;
            lblHealth.BackColor = Color.Transparent;
            lblKills.Parent = picGameField;
            lblKills.BackColor = Color.Transparent;

            GenerateUIObstacles();
        }

        private void GenerateUIObstacles()
        {
            //foreach (var obstacle in _game.ObstaclesByPosition)
            foreach (var obstacle in ObstaclesByPosition)
            {
                int positionX = obstacle.Key % 12;
                int positionY = obstacle.Key / 12;
                int uiObstaclePosX = positionX * SpriteDimensions;
                int uiObstaclePosY = positionY * SpriteDimensions;

                var uiObstacle = new Sprite(new Point(0, 0), _spriteController,
                    Resources.Trees, 120, 150, 2000, 1);
                uiObstacle.SetSize(new Size(50, 50));
                uiObstacle.PutBaseImageLocation(new Point(uiObstaclePosX, uiObstaclePosY));
                uiObstacle.SendToFront();
            }
        }

        private void InitializeUIPlayer()
        {
            _hero = new Sprite(new Point(0, 128), _spriteController,
                Resources.Heroes, 32, 32, 250, 3);
            _hero.SetSize(new Size(50, 50));
            _hero.AddAnimation(new Point(0, 160), Resources.Heroes, 32, 32, 250, 3);
            _hero.AddAnimation(new Point(0, 192), Resources.Heroes, 32, 32, 250, 3);
            _hero.AddAnimation(new Point(0, 224), Resources.Heroes, 32, 32, 250, 3);
            _hero.PutPictureBoxLocation(_heroStartPoint);
            _hero.MovementSpeed = HeroMovementSpeed;
            _hero.CannotMoveOutsideBox = true;
            //_hero.SpriteHitsSprite += Gameplay.WeHaveHit;
        }

        public static void InitializeUIMonster()
        {
            Random rnd = new Random();

            _monster = new Sprite(new Point(0, 0), _spriteController,
                Resources.Emoticon, 200, 198, 100, 35);
            _monster.SetSize(new Size(50, 50));
            _monster.PutPictureBoxLocation(_heroStartPoint);
            _monster.MovementSpeed = MonsterMovementSpeed;
            _monster.CannotMoveOutsideBox = true;
            _monster.AutomaticallyMoves = true;
            _monster.SpriteHitsPictureBox += Gameplay.SpriteBounces;
            _monster.SetSpriteDirectionDegrees(180);
            _monster.PutBaseImageLocation(new Point(rnd.Next(38, 500), rnd.Next(38, 500)));
            // TO DO - Handle collisions between 2 monsters (to go through each other)
            //_monster.SpriteHitsSprite += Gameplay.WeHaveHit;

            // _monster.MoveTo(_hero.BaseImageLocation);
        }

        private void MoveUIPlayer(int animationIndex, int directionDegrees, Directions direction)
        {
            if (_heroDirection != direction)
            {
                _hero.SetSpriteDirectionDegrees(directionDegrees);
                _hero.ChangeAnimation(animationIndex);
                _heroDirection = direction;
            }

            _heroIsMoving = true;
            _hero.MovementSpeed = 20;
            _hero.AutomaticallyMoves = true;
            //_monster.MoveTo(_hero.BaseImageLocation);// gada trygva kym geroq
        }

        private void CheckPlayerObstacleCollision()
        {
            Point directionPoint;
            if (IsPlayerObstacleCollision(out directionPoint))
                _hero.PutBaseImageLocation(directionPoint);
        }

        private bool IsPlayerObstacleCollision(out Point directionPoint)
        {
            int positionX = _hero.BaseImageLocation.X / SpriteDimensions;
            int positionY = _hero.BaseImageLocation.Y / SpriteDimensions;
            int posTopRight = positionY * 12 + positionX; // ISSUE hardcoded value
            int posTopLeft = posTopRight + 1;
            int posBottomRight = posTopRight + 12; // ISSUE hardcoded value
            int posBottomLeft = posTopLeft + 12; // ISSUE hardcoded value

            //if (_game.ObstaclesByPosition.ContainsKey(posTopRight)
            //    || _game.ObstaclesByPosition.ContainsKey(posTopLeft)
            //    || _game.ObstaclesByPosition.ContainsKey(posBottomRight)
            //    || _game.ObstaclesByPosition.ContainsKey(posBottomLeft))
            if (ObstaclesByPosition.ContainsKey(posTopRight)
               || ObstaclesByPosition.ContainsKey(posTopLeft)
               || ObstaclesByPosition.ContainsKey(posBottomRight)
               || ObstaclesByPosition.ContainsKey(posBottomLeft))
            {
                int imagePosX = _hero.BaseImageLocation.X;
                int imagePosY = _hero.BaseImageLocation.Y;

                switch (_heroDirection)
                {
                    case Directions.Down:
                        imagePosY -= _hero.BaseImageLocation.Y % SpriteDimensions + 1;
                        break;
                    case Directions.Left:
                        imagePosX += (SpriteDimensions
                            - _hero.BaseImageLocation.X % SpriteDimensions + 1);
                        break;
                    case Directions.Right:
                        imagePosX -= _hero.BaseImageLocation.X % SpriteDimensions + 1;
                        break;
                    case Directions.Up:
                        imagePosY += (SpriteDimensions
                             - _hero.BaseImageLocation.Y % SpriteDimensions + 1);
                        break;
                    case Directions.DownLeft:
                        int dl = Math.Min(
                            (SpriteDimensions
                            - _hero.BaseImageLocation.X % SpriteDimensions + 1),
                            _hero.BaseImageLocation.Y % SpriteDimensions + 1);
                        imagePosX += dl;
                        imagePosY -= dl;
                        break;
                    case Directions.DownRight:
                        int dr = Math.Min(
                            _hero.BaseImageLocation.X % SpriteDimensions + 1,
                            _hero.BaseImageLocation.Y % SpriteDimensions + 1);
                        imagePosX -= dr;
                        imagePosY -= dr;
                        break;
                    case Directions.UpLeft:
                        int ul = Math.Min(
                            (SpriteDimensions
                            - _hero.BaseImageLocation.X % SpriteDimensions + 1),
                            (SpriteDimensions
                            - _hero.BaseImageLocation.Y % SpriteDimensions + 1));
                        imagePosX += ul;
                        imagePosY += ul;
                        break;
                    case Directions.UpRight:
                        int ur = Math.Min(
                            _hero.BaseImageLocation.X % SpriteDimensions + 1,
                            (SpriteDimensions
                            - _hero.BaseImageLocation.Y % SpriteDimensions + 1));
                        imagePosX -= ur;
                        imagePosY += ur;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                directionPoint = new Point(imagePosX, imagePosY);
                return true;
            }

            directionPoint = new Point(-1, -1);
            return false;
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
            CheckPlayerObstacleCollision();

            TimeSpan duration = DateTime.Now - _heroLastMovement;
            if (duration.TotalMilliseconds < 100)
                return;
            _heroLastMovement = DateTime.Now;

            _heroIsMoving = false;
            bool keyDown = _spriteController.IsKeyPressed(Keys.Down);
            bool keyLeft = _spriteController.IsKeyPressed(Keys.Left);
            bool keyRight = _spriteController.IsKeyPressed(Keys.Right);
            bool keyUp = _spriteController.IsKeyPressed(Keys.Up);

            if (keyUp && keyLeft)
                MoveUIPlayer(1, 150, Directions.UpLeft); // move up left

            else if (keyUp && keyRight)
                MoveUIPlayer(2, 45, Directions.UpRight); // move up right

            else if (keyDown && keyLeft)
                MoveUIPlayer(1, 225, Directions.DownLeft); // move down left

            else if (keyDown && keyRight)
                MoveUIPlayer(2, -45, Directions.DownRight); // move down right

            else if (keyDown)
                MoveUIPlayer(0, 270, Directions.Down); // move down

            else if (keyLeft)
                MoveUIPlayer(1, 180, Directions.Left); // move left

            else if (keyRight)
                MoveUIPlayer(2, 0, Directions.Right); // move right

            else if (keyUp)
                MoveUIPlayer(3, 90, Directions.Up); // move up

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
                _hero.MovementSpeed = 0;

            bool keyEsc = _spriteController.IsKeyPressed(Keys.Escape);
            if (keyEsc)
                Close(); // exit 
        }

        #endregion

    }
}
