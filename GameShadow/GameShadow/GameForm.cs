using GameShadow.GameData;
using GameShadow.GameHelpers;
using GameShadow.GameLogic;
using GameShadow.Properties;
using SpriteLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace GameShadow
{
    public partial class GameForm : Form
    {
        private enum Directions
        {
            Right = 0,
            UpRight = 45,
            Up = 90,
            UpLeft = 135,
            Left = 180,
            DownLeft = 225,
            Down = 270,
            DownRight = 315,
            None
        }

        private const int HeroMovementSpeed = 10;
        private const int MonsterMovementSpeed = 5;
        private const int BulletMovementSpeed = 30;
        private const int SpriteDimensions = 50; // 50px x 50px
        private const int HeroStartPositionX = 500;
        private const int HeroStartPositionY = 500;

        #region Private Fields
        private Game _game;
        private static SpriteController _spriteController;
        private Sprite _hero, _bullet, _sight, _monster, _monsterBullet;
        private static Point _heroStartPoint = new Point(500, 500);
        private DateTime _heroLastMovement = DateTime.Now;
        private DateTime lastShot = DateTime.Now;
        private DateTime monsterLastShot = DateTime.Now;
        private bool _heroIsMoving = false;
        private Directions _heroDirection = Directions.Down;
        //private Point _monsterStartPoint = new Point(500, 500);
        private DateTime _monsterLastMovement = DateTime.Now;
        //private bool _monsterIsMoving = false;
        private int shootingAngle = 90;
        public int kills = 0;// tezi da vlqzat posle v klasa na geroq
        public int playerHealth = 20;// tezi da vlqzat posle v klasa na geroq


        #endregion

        #region Constructors

        public GameForm()
        {
            InitializeComponent();
            InitializeGame();
            InitializeUIGameField();
            InitializeUIPlayer();
            InitializeUIMonster();
            InitializeUISight();
            InitializeUIBullet();
            InitializeMonsterBullet();
        }

        #endregion

        #region Private Methods
        private void InitializeGame()
        {
            int positionX = HeroStartPositionX / SpriteDimensions;
            int positionY = HeroStartPositionY / SpriteDimensions;
            var player = new Player(positionX, positionY);
            _game = new Game(player);

            GameInitializer.GenerateObstacles(_game);
            GameInitializer.GenerateEmoticions(_game);
        }

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
            lblHealth.Text = playerHealth.ToString();

            GenerateUIObstacles();
        }

        private void GenerateUIObstacles()
        {
            foreach (var obstacle in _game.ObstaclesByPosition)
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
            _hero.SetName("hero");
            //_hero.SpriteHitsSprite += WeHaveHit;
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

        private void InitializeMonsterBullet()
        {
            _monsterBullet = new Sprite(new Point(0, 375), _spriteController,
            Resources.Magicballs, 75, 75, 100, 8);
            _monsterBullet.SetSize(new Size(40, 40));
            _monsterBullet.CannotMoveOutsideBox = false;

            _monsterBullet.SetName("monsterShot");
            //_bullet.SpriteHitsSprite += WeHaveHit;
        }


        private void MoveUISight()
        {
            _sight.AutomaticallyMoves = true;

            Point where = _hero.PictureBoxLocation;

            // offset gives the initial position of the bullet defined by the shooting angle - COMMIT
            int offsetX = (int)(_hero.VisibleWidth * Math.Cos(shootingAngle * Math.PI / 180));
            int offsetY = (int)(-_hero.VisibleHeight * Math.Sin(shootingAngle * Math.PI / 180));

            where = new Point(where.X + offsetX, where.Y + offsetY);

            _sight.PutPictureBoxLocation(where);
        }

        private void MoveUIPlayer(int animationIndex, Directions direction)
        {
            var directionDegrees = (int)direction;

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

            //_sight.AutomaticallyMoves = true;

            //Point where = _hero.PictureBoxLocation;

            //// offset gives the initial position of the bullet defined by the shooting angle - COMMIT
            //int offsetX = (int)(_hero.VisibleWidth * Math.Cos(shootingAngle * Math.PI / 180));
            //int offsetY = (int)(-_hero.VisibleHeight * Math.Sin(shootingAngle * Math.PI / 180));

            //where = new Point(where.X + offsetX, where.Y + offsetY);

            //_sight.PutPictureBoxLocation(where);
        }

        private void CheckPlayerObstacleCollision()
        {
            Point directionPoint;
            if (IsPlayerObstacleCollision(out directionPoint))
                _hero.PutBaseImageLocation(directionPoint);
        }

        public void WeHaveHit(object sender, SpriteEventArgs e)
        {
            // ako shot e udaril zvqr
            Sprite me = (Sprite)sender;

            if (e.TargetSprite.SpriteOriginName == "shot")
            {
                kills++;
                lblKills.Text = kills.ToString();
                me.Destroy();
                e.TargetSprite.Destroy();
                SoundPlayer newPlayer = new SoundPlayer(Resources.Tboom);
                newPlayer.Play();
                InitializeUIMonster();
            }
            else if (e.TargetSprite.SpriteName == "hero")
            {
                kills++;
                lblKills.Text = kills.ToString();
                playerHealth -= 5;
                lblHealth.Text = playerHealth.ToString();
                me.Destroy();
                //e.TargetSprite.Destroy();
                SoundPlayer newPlayer = new SoundPlayer(Resources.Tboom);
                newPlayer.Play();
                InitializeUIMonster();
            }
        }

        private void MonsterMakeShot()
        {
            TimeSpan MonsterShotDuration = DateTime.Now - monsterLastShot;
            if (MonsterShotDuration.TotalMilliseconds > 2300)
            {
                //We make a new shot sprite.
                Sprite newsprite = _spriteController.DuplicateSprite("monsterShot");
                if (newsprite != null)
                {
                    //We figure out where to put the shot
                    Point where = _monster.PictureBoxLocation; // COMMIT
                    where = new Point(where.X, where.Y); // COMMIT
                    newsprite.PutPictureBoxLocation(where);
                    //We tell the sprite to automatically move
                    newsprite.AutomaticallyMoves = true;
                    //We give it a direction, up
                    newsprite.SetSpriteDirectionDegrees(270);
                    //we give it a speed for how fast it moves.
                    newsprite.MovementSpeed = 50;
                }
                monsterLastShot = DateTime.Now;
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

            if (_game.ObstaclesByPosition.ContainsKey(posTopRight)
               || _game.ObstaclesByPosition.ContainsKey(posTopLeft)
               || _game.ObstaclesByPosition.ContainsKey(posBottomRight)
               || _game.ObstaclesByPosition.ContainsKey(posBottomLeft))

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
            MonsterMakeShot();
            MoveUISight();

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
                MoveUIPlayer(1, Directions.UpLeft); // move up left
            else if (keyUp && keyRight)
                MoveUIPlayer(2, Directions.UpRight); // move up right
            else if (keyDown && keyLeft)
                MoveUIPlayer(1, Directions.DownLeft); // move down left
            else if (keyDown && keyRight)
                MoveUIPlayer(2, Directions.DownRight); // move down right
            else if (keyDown)
                MoveUIPlayer(0, Directions.Down); // move down
            else if (keyLeft)
                MoveUIPlayer(1, Directions.Left); // move left
            else if (keyRight)
                MoveUIPlayer(2, Directions.Right); // move right
            else if (keyUp)
                MoveUIPlayer(3, Directions.Up); // move up

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
                        int halfwit = 0; // COMMIT
                        int halfhit = 0; // COMMIT
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
                MoveUISight(); // COMMIT
            }
            else if (directionDown)
            {
                shootingAngle -= 10;
                MoveUISight(); // COMMIT
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
