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
        private const int BulletMovementSpeed = 30;

        // ISSUE Hardcoded obstacle
        private readonly Dictionary<int, bool> ObstaclesByPosition =
            new Dictionary<int, bool>
            {
                [80] = true
            };

       
        
        #region Private Fields
        private static SpriteController _spriteController;
        private Sprite _hero, _bullet, _sight, _monster;
        private static Point _heroStartPoint = new Point(500, 500);
        private DateTime _heroLastMovement = DateTime.Now;
        private DateTime lastShot = DateTime.Now;
        private bool _heroIsMoving = false;
        private Directions _heroDirection = Directions.Down;
        //private Point _monsterStartPoint = new Point(500, 500);
        private DateTime _monsterLastMovement = DateTime.Now;
        //private bool _monsterIsMoving = false;
        private int shootingAngle = 90;
        public int kills = 0;

        #endregion

        #region Constructors

        public GameForm()
        {
            InitializeComponent();
            InitializeUIGameField();
            InitializeUIPlayer();
            InitializeUIMonster();
            InitializeUISight();
            InitializeUIBullet();
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
        
        private void InitializeUISight()
        {
            _sight = new Sprite(new Point(0, 0), _spriteController,
                Resources.Crosshair, 24, 24, 0, 1);
            _sight.SetSize(new Size(24, 24));
            _sight.AutomaticallyMoves = true;

            Point where = _hero.PictureBoxLocation;

            _sight.PutPictureBoxLocation(where);
            _sight.CannotMoveOutsideBox = true;
           // _hero.SpriteHitsSprite += WeHaveHit;
        }


        public void InitializeUIMonster()
        {
            Random rnd = new Random();

            _monster = new Sprite(new Point(0, 0), _spriteController,
                Resources.Emoticons, 50, 50, 100, 10);
            _monster.SetSize(new Size(50, 50));
            _monster.PutPictureBoxLocation(_heroStartPoint);
            _monster.MovementSpeed = MonsterMovementSpeed;
            _monster.CannotMoveOutsideBox = true;
            _monster.AutomaticallyMoves = true;
            _monster.SpriteHitsPictureBox += Gameplay.SpriteBounces;
            _monster.SetSpriteDirectionDegrees(180);
            _monster.PutBaseImageLocation(new Point(rnd.Next(38, 500), rnd.Next(38, 500)));
            // TO DO - Handle collisions between 2 monsters (to go through each other)
            _monster.SpriteHitsSprite += WeHaveHit;

            // _monster.MoveTo(_hero.BaseImageLocation);
        }

        private void InitializeUIBullet()
        {
            _bullet = new Sprite(new Point(0, 675), _spriteController,
                Resources.Magicballs, 75, 75, 100, 8);
            _bullet.SetSize(new Size(40, 40));
            _bullet.CannotMoveOutsideBox = false;

            _bullet.SetName("shot");
            //_bullet.SpriteHitsSprite += WeHaveHit;
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
            _hero.MovementSpeed = 10;
            _hero.AutomaticallyMoves = true;
            //_monster.MoveTo(_hero.BaseImageLocation);// gada trygva kym geroq

            _sight.AutomaticallyMoves = true;

            Point where = _hero.PictureBoxLocation;

            _sight.PutPictureBoxLocation(where);
        }

        private void CheckPlayerObstacleCollision()
        {
            Point directionPoint;
            if (IsPlayerObstacleCollision(out directionPoint))
                _hero.PutBaseImageLocation(directionPoint);
        }

        public  void WeHaveHit(object sender, SpriteEventArgs e)
        {
            // ako shot e udaril zvqr
            Sprite me = (Sprite)sender;
            
            if (e.TargetSprite.SpriteOriginName == "shot")
            {
                kills++;
                lblKills.Text = kills.ToString();
                me.Destroy();
                    e.TargetSprite.Destroy();
               InitializeUIMonster();
            }
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
            bool keySpace = _spriteController.IsKeyPressed(Keys.Space);
            bool directionUp = _spriteController.IsKeyPressed(Keys.A);
            bool directionDown = _spriteController.IsKeyPressed(Keys.D);

            if (keyUp && keyLeft)
                MoveUIPlayer(1, 150, Directions.UpLeft); // move up left

            else if (keyUp && keyRight)
                MoveUIPlayer(2, 45, Directions.UpRight); // move up right

            else if (keyDown && keyLeft)
                MoveUIPlayer(1, 225, Directions.DownLeft); // move down left

            else if (keyDown && keyRight)
                MoveUIPlayer(2, -45, Directions.DownRight); // move down right

            else if (keyDown)
            {
                MoveUIPlayer(0, 270, Directions.Down); // move down
            }

            else if (keyLeft)
                MoveUIPlayer(1, 180, Directions.Left); // move left

            else if (keyRight)
                MoveUIPlayer(2, 0, Directions.Right); // move right

            else if (keyUp)
                MoveUIPlayer(3, 90, Directions.Up); // move up

            if (keySpace)
            {
                TimeSpan Duration = DateTime.Now - lastShot;
                if (Duration.TotalMilliseconds > 300)
                {
                    //We make a new shot sprite.
                    Sprite newsprite = _spriteController.DuplicateSprite("shot");
                    if (newsprite != null)
                    {
                        //We figure out where to put the shot
                        Point where = _hero.PictureBoxLocation;
                        int halfwit = 30;//Spaceship.VisibleWidth / 2;
                        halfwit = halfwit - (newsprite.VisibleWidth / 2);
                        int halfhit = -30 + newsprite.VisibleHeight / 2;
                        where = new Point(where.X + halfwit, where.Y - halfhit);
                        newsprite.PutPictureBoxLocation(where);
                        //We tell the sprite to automatically move
                        newsprite.AutomaticallyMoves = true;
                        //We give it a direction, up
                        newsprite.SetSpriteDirectionDegrees(shootingAngle);
                        //we give it a speed for how fast it moves.
                        newsprite.MovementSpeed = 120;
                    }
                    lastShot = DateTime.Now;
                }



            }

            if (directionUp)
            {
                shootingAngle += 10;
            }
            else if (directionDown)
            {
                shootingAngle -= 10;
            }



            if (!_heroIsMoving)
                _hero.MovementSpeed = 0;

            bool keyEsc = _spriteController.IsKeyPressed(Keys.Escape);
            if (keyEsc)
                Close(); // exit 




        }

        #endregion

    }
}
