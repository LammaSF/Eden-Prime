using GameShadow.GameData;
using GameShadow.GameHelpers;
using GameShadow.Properties;
using SpriteLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace GameShadow
{
    public enum Directions
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

    public partial class GameForm : Form
    {

        #region Constants and Readonly Fields
        private const int HeroMovementSpeed = 12;
        private const int EmoticonMovementSpeed = 6;
        private const int EnemyBallMovementSpeed = 20;
        private const int BallMovementSpeed = 120;
        private const int SightSpeed = 20;
        private const int SpriteSize = 50; // 50px x 50px
        private const int HeroStartPositionX = 500;
        private const int HeroStartPositionY = 500;
        private const int MovementInputDelay = 100; // in ms
        private const int ShootingInputDelay = 500; // in ms
        private const int TeleportDelay = 1000; // in ms
        private const int EmoticonShootingDelay = 2000; // in ms
        private const int InitialShootingAngle = 135;

        private static readonly Point HeroStartPoint =
            new Point(HeroStartPositionX, HeroStartPositionY);
        private readonly int ReducedFieldLength;
        private readonly int ReducedFieldWidth;
        #endregion

        #region Private Fields
        private Game _game;
        private SpriteController _spriteController;
        private Sprite _hero, _sight, _emoticon;
        private List<Sprite> _uiEmoticons = new List<Sprite>();
        private DateTime _heroLastMovement = DateTime.Now;
        private DateTime _heroLastShot = DateTime.Now;
        private DateTime _heroLastTeleport = DateTime.Now;
        private DateTime _emoticonLastShot = DateTime.Now;
        private Directions _heroDirection = Directions.Down;
        private bool _heroIsMoving = false;
        private int _heroShootingAngle = InitialShootingAngle;
        private int _emoticonCount = GameInitializer.EmoticonCount;
        private MainForm _mainForm;
        private bool _paused = false;
        private bool _gameOver = false;

        #endregion

        #region Constructors

        public GameForm()
        {
            InitializeComponent();
            Size = new Size(610, 610);
            picGameField.Size = new Size(600, 600);
            ReducedFieldLength = picGameField.Size.Width / SpriteSize;
            ReducedFieldWidth = picGameField.Size.Height / SpriteSize;

            InitializeGame();
            InitializeUIGameField();
            InitializeUIPlayer();
            InitializeUIMonster();
            InitializeUISight();
        }

        public GameForm(MainForm mainForm) : this()
        {
            _mainForm = mainForm;
        }

        public GameForm(MainForm mainForm, Game game)
        {
            _game = game;
            _mainForm = mainForm;

            InitializeComponent();
            Size = new Size(610, 610);
            picGameField.Size = new Size(600, 600);
            ReducedFieldLength = picGameField.Size.Width / SpriteSize;
            ReducedFieldWidth = picGameField.Size.Height / SpriteSize;

            InitializeUIGameField();
            LoadUIPlayer();
            InitializeUIMonster();
            InitializeUISight();
        }

        #endregion

        #region Private Methods

        private void InitializeGame()
        {
            int positionX = HeroStartPositionX / SpriteSize;
            int positionY = HeroStartPositionY / SpriteSize;
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
            _spriteController.DoTick += OnGameIteration;

            SpriteInitializer.InitializeSprites(_spriteController, null);

            lblHealth.Parent = picGameField;
            lblHealth.BackColor = Color.Transparent;
            lblKills.Parent = picGameField;
            lblKills.BackColor = Color.Transparent;
            lblHealthValue.Parent = picGameField;
            lblHealthValue.BackColor = Color.Transparent;
            lblKillsValue.Parent = picGameField;
            lblKillsValue.BackColor = Color.Transparent;
            lblHealthValue.Text = $"{_game.Player.Health}";
            lblEmojiValue.Parent = picGameField;
            lblEmojiValue.BackColor = Color.Transparent;
            lblEmojiValue.Text = $"{_game.Player.Smiles}";
            lblEmoji.Parent = picGameField;
            lblEmoji.BackColor = Color.Transparent;

            DrawUIObtacles();
            DrawUIEmoticons();
        }

        private void DrawUIObtacles()
        {
            foreach (var obstacle in _game.ObstaclesByPosition)
            {
                int positionX = obstacle.Key % ReducedFieldLength;
                int positionY = obstacle.Key / ReducedFieldWidth;
                int uiObstacleX = positionX * SpriteSize;
                int uiObstacleY = positionY * SpriteSize;

                var uiObstacle = _spriteController.DuplicateSprite($"{SpriteNames.ObstacleTree1}");
                uiObstacle.PutPictureBoxLocation(new Point(uiObstacleX, uiObstacleY));
            }
        }

        private void DrawUIEmoticons()
        {
            foreach (var emoticon in _game.Emoticons)
            {
                int uiEmoticonX = emoticon.PositionX * SpriteSize;
                int uiEmoticonY = emoticon.PositionY * SpriteSize;
                string emoticonName = $"{emoticon.Type}";

                var uiEmoticon = _spriteController
                    .DuplicateSprite(emoticonName);
                uiEmoticon.MovementSpeed = EmoticonMovementSpeed;
                uiEmoticon.CannotMoveOutsideBox = true;
                uiEmoticon.payload = emoticon;
                uiEmoticon.PutPictureBoxLocation(new Point(uiEmoticonX, uiEmoticonY));

                _uiEmoticons.Add(uiEmoticon);
            }
        }

        private void LoadUIPlayer()
        {
            _hero = new Sprite(_spriteController
                .DuplicateSprite($"{SpriteNames.Hero}"));
            _hero.CannotMoveOutsideBox = true;
            int imagePositionX = _game.Player.PositionX * SpriteSize;
            int imagePositionY = _game.Player.PositionY * SpriteSize;
            var location = new Point(imagePositionX, imagePositionY);
            _hero.PutBaseImageLocation(location);
            _hero.SpriteHitsSprite += OnHeroObjectCollision;
            _hero.payload = _game.Player;
        }

        private void InitializeUIPlayer()
        {
            _hero = new Sprite(_spriteController
                .DuplicateSprite($"{SpriteNames.Hero}"));
            _hero.CannotMoveOutsideBox = true;
            _hero.PutBaseImageLocation(HeroStartPoint);
            _hero.SpriteHitsSprite += OnHeroObjectCollision;
            _hero.payload = _game.Player;
        }

        private void InitializeUIMonster()
        {
            if (_gameOver)
            {
                return;
            }
            Random rnd = new Random();

            _emoticon = _spriteController.DuplicateSprite($"{SpriteNames.EmoticonOnFire}");
            _emoticon.MovementSpeed = EmoticonMovementSpeed;
            _emoticon.CannotMoveOutsideBox = true;
            _emoticon.AutomaticallyMoves = true;
            _emoticon.SpriteHitsPictureBox += OnEmoticonEdgeCollision;
            _emoticon.SetSpriteDirectionDegrees(180);
            _emoticon.PutBaseImageLocation(new Point(rnd.Next(38, 500), rnd.Next(38, 500)));
        }

        private void InitializeUISight()
        {
            _sight = new Sprite(_spriteController
                .DuplicateSprite($"{SpriteNames.Crosshair}"));

            Point location = _hero.PictureBoxLocation;
            _sight.PutPictureBoxLocation(location);
            _sight.CannotMoveOutsideBox = true;
            _sight.AutomaticallyMoves = true;
        }

        private void MoveUISight()
        {
            Point location = new Point(_hero.PictureBoxLocation.X, _hero.PictureBoxLocation.Y);

            int offsetX =
                (int)(_hero.VisibleWidth * Math.Cos(_heroShootingAngle * Math.PI / 180));
            int offsetY =
                (int)(-_hero.VisibleHeight * Math.Sin(_heroShootingAngle * Math.PI / 180));

            location = new Point(location.X + _hero.VisibleWidth / 4 + offsetX,
                location.Y + offsetY);
            _sight.PutPictureBoxLocation(location);
            _sight.AutomaticallyMoves = true;
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
            _hero.MovementSpeed = HeroMovementSpeed;
            _hero.AutomaticallyMoves = true;
        }

        private void TeleportUIPlayer()
        {
            int destinationX = _hero.BaseImageLocation.X;
            int destinationY = _hero.BaseImageLocation.Y;

            switch (_heroDirection)
            {
                case Directions.Down:
                    destinationY += 200;
                    break;
                case Directions.Left:
                    destinationX -= 160;
                    break;
                case Directions.Right:
                    destinationX += 160;
                    break;
                case Directions.Up:
                    destinationY -= 200;
                    break;
                case Directions.UpRight:
                    destinationX += 160;
                    destinationY -= 160;
                    break;
                case Directions.UpLeft:
                    destinationX -= 160;
                    destinationY -= 160;
                    break;
                case Directions.DownRight:
                    destinationX += 160;
                    destinationY += 160;
                    break;
                case Directions.DownLeft:
                    destinationX -= 160;
                    destinationY += 160;
                    break;
                default:
                    break;
            }

            if (destinationX > 25 && destinationX < 575 && destinationY > 25 && destinationY < 575)
            {
                _hero.PutBaseImageLocation(new Point(destinationX, destinationY));
            }
        }

        private void MoveUIEmoticons()
        {
            foreach (var uiEmoticon in _uiEmoticons)
            {
                var emoticon = (Emoticon)uiEmoticon.payload;

                if (emoticon.Type == EmoticonType.EmoticonAngry)
                {
                    uiEmoticon.MoveTo(_hero.BaseImageLocation);
                }
                else
                {
                    var angle = (int)_heroDirection;
                    uiEmoticon.SetSpriteDirectionDegrees(angle);
                }

                uiEmoticon.AutomaticallyMoves = true;
            }
        }

        private void CheckPlayerObstacleCollision()
        {
            Point directionPoint;
            if (IsPlayerObstacleCollision(out directionPoint))
                _hero.PutBaseImageLocation(directionPoint);
        }

        private bool IsPlayerObstacleCollision(out Point directionPoint)
        {
            int positionX = _hero.BaseImageLocation.X / SpriteSize;
            int positionY = _hero.BaseImageLocation.Y / SpriteSize;
            int posTopRight = positionY * ReducedFieldLength + positionX;
            int posTopLeft = posTopRight + 1;
            int posBottomRight = posTopRight + ReducedFieldLength;
            int posBottomLeft = posTopLeft + ReducedFieldLength;

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
                        imagePosY -= _hero.BaseImageLocation.Y % SpriteSize + 1;
                        break;
                    case Directions.Left:
                        imagePosX += (SpriteSize
                            - _hero.BaseImageLocation.X % SpriteSize + 1);
                        break;
                    case Directions.Right:
                        imagePosX -= _hero.BaseImageLocation.X % SpriteSize + 1;
                        break;
                    case Directions.Up:
                        imagePosY += (SpriteSize
                             - _hero.BaseImageLocation.Y % SpriteSize + 1);
                        break;
                    case Directions.DownLeft:
                        int dl = Math.Min(
                            (SpriteSize
                            - _hero.BaseImageLocation.X % SpriteSize + 1),
                            _hero.BaseImageLocation.Y % SpriteSize + 1);
                        imagePosX += dl;
                        imagePosY -= dl;
                        break;
                    case Directions.DownRight:
                        int dr = Math.Min(
                            _hero.BaseImageLocation.X % SpriteSize + 1,
                            _hero.BaseImageLocation.Y % SpriteSize + 1);
                        imagePosX -= dr;
                        imagePosY -= dr;
                        break;
                    case Directions.UpLeft:
                        int ul = Math.Min(
                            (SpriteSize
                            - _hero.BaseImageLocation.X % SpriteSize + 1),
                            (SpriteSize
                            - _hero.BaseImageLocation.Y % SpriteSize + 1));
                        imagePosX += ul;
                        imagePosY += ul;
                        break;
                    case Directions.UpRight:
                        int ur = Math.Min(
                            _hero.BaseImageLocation.X % SpriteSize + 1,
                            (SpriteSize
                            - _hero.BaseImageLocation.Y % SpriteSize + 1));
                        imagePosX -= ur;
                        imagePosY += ur;
                        break;
                    default:
                        break;
                }

                directionPoint = new Point(imagePosX, imagePosY);
                return true;
            }

            directionPoint = new Point(-1, -1);
            return false;
        }

        private void CreateNewEmoticonGroup()
        {
            if (_gameOver)
            {
                return;
            }
            if (_uiEmoticons.Count == 0)
            {
                _game.Player.PositionX = _hero.BaseImageLocation.X / SpriteSize;
                _game.Player.PositionY = _hero.BaseImageLocation.Y / SpriteSize;
                _game.Emoticons.Clear();
                GameInitializer.GenerateEmoticions(_game);
                DrawUIEmoticons();
                _emoticonCount = GameInitializer.EmoticonCount;
            }
        }

        private void MakeEmoticonShot()
        {
            TimeSpan EmoticonShotDuration = DateTime.Now - _emoticonLastShot;
            if (EmoticonShotDuration.TotalMilliseconds > EmoticonShootingDelay)
            {
                Sprite sprite = _spriteController
                    .DuplicateSprite($"{SpriteNames.EnemyBall}");
                if (sprite != null)
                {
                    var soundPlayer = new SoundPlayer(Resources.emoShot);
                    soundPlayer.Play();
                    Point location = _emoticon.BaseImageLocation;

                    sprite.PutBaseImageLocation(location);

                    location = _hero.BaseImageLocation;
                    sprite.MoveTo(location);
                    sprite.MovementSpeed = EnemyBallMovementSpeed;
                    sprite.AutomaticallyMoves = true;

                    sprite.SpriteHitsSprite += OnBallObjectCollision;
                }

                _emoticonLastShot = DateTime.Now;
            }
        }

        private void UpdateGameInfo()
        {
            _game.Player.PositionX = _hero.BaseImageLocation.X / SpriteSize;
            _game.Player.PositionY = _hero.BaseImageLocation.Y / SpriteSize;
            _game.Emoticons.Clear();

            foreach (var uiEmoticon in _uiEmoticons)
            {
                var emoticon = (Emoticon)uiEmoticon.payload;
                emoticon.PositionX = uiEmoticon.BaseImageLocation.X / SpriteSize;
                emoticon.PositionY = uiEmoticon.BaseImageLocation.Y / SpriteSize;
                _game.Emoticons.Add(emoticon);
            }

        }

        private void GameOver()
        {
            _gameOver = true;
            List<Sprite> allSprites = _spriteController.AllSprites();
            _spriteController.Pause();
            _spriteController.DoTick -= OnGameIteration;

            for (int i = allSprites.Count - 1; i >= 0; i--)
            {
                allSprites[i].Destroy();
            }
            picGameField.BackgroundImage = Resources.Gameover;
            picGameField.BackgroundImageLayout = ImageLayout.Stretch;
            _spriteController.DoTick += OnEndGame;
        }

        #endregion

        #region Event Handlers

        public void OnGameIteration(object sender, EventArgs e)
        {
            CheckPlayerObstacleCollision();
            MakeEmoticonShot();
            MoveUISight();

            TimeSpan duration = DateTime.Now - _heroLastMovement;
            if (duration.TotalMilliseconds < MovementInputDelay)
                return;
            _heroLastMovement = DateTime.Now;

            _heroIsMoving = false;
            bool keyPGUP = _spriteController.IsKeyPressed(Keys.PageUp);
            bool keyPGDN = _spriteController.IsKeyPressed(Keys.PageDown);
            bool keyHome = _spriteController.IsKeyPressed(Keys.Home);
            bool keyEnd = _spriteController.IsKeyPressed(Keys.End);
            bool keyDown = _spriteController.IsKeyPressed(Keys.Down);
            bool keyLeft = _spriteController.IsKeyPressed(Keys.Left);
            bool keyRight = _spriteController.IsKeyPressed(Keys.Right);
            bool keyUp = _spriteController.IsKeyPressed(Keys.Up);
            bool keySpace = _spriteController.IsKeyPressed(Keys.Space);
            bool keyS = _spriteController.IsKeyPressed(Keys.S);
            bool keyC = _spriteController.IsKeyPressed(Keys.C);
            bool directionUp = _spriteController.IsKeyPressed(Keys.A);
            bool directionDown = _spriteController.IsKeyPressed(Keys.D);
            bool keyTeleport = _spriteController.IsKeyPressed(Keys.T);

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

            if (keySpace || keyC || keyS)
            {
                TimeSpan Duration = DateTime.Now - _heroLastShot;
                if (Duration.TotalMilliseconds > ShootingInputDelay)
                {
                    Sprite sprite = _spriteController.
                        DuplicateSprite($"{SpriteNames.Sunball}");
                    if (sprite != null)
                    {
                        var soundPlayer = new SoundPlayer(Resources.Shoot);
                        soundPlayer.Play();
                        Point location = _hero.PictureBoxLocation;
                        int halfwit = 0; // ?!
                        int halfhit = 0; // ?!
                        location = new Point(location.X + halfwit, location.Y - halfhit);
                        sprite.PutPictureBoxLocation(location);
                        sprite.SetSpriteDirectionDegrees(_heroShootingAngle);
                        sprite.MovementSpeed = BallMovementSpeed;
                        sprite.AutomaticallyMoves = true;
                        sprite.SpriteHitsSprite += OnBallObjectCollision;
                    }
                    _heroLastShot = DateTime.Now;
                }
            }

            duration = DateTime.Now - _heroLastTeleport;
            if (keyTeleport)
            {
                if (duration.TotalMilliseconds > TeleportDelay)
                {
                    TeleportUIPlayer();
                    _heroLastTeleport = DateTime.Now;
                }
            }

            if (directionUp)
            {
                _heroShootingAngle += SightSpeed;
                MoveUISight();
            }
            else if (directionDown)
            {
                _heroShootingAngle -= SightSpeed;
                MoveUISight();
            }

            MoveUIEmoticons();

            if (!_heroIsMoving)
                _hero.MovementSpeed = 0;

            bool keyEsc = _spriteController.IsKeyPressed(Keys.Escape);
            if (keyEsc)
            {
                _paused = true;
                _spriteController.Pause();
                _spriteController.DoTick -= OnGameIteration;
                UpdateGameInfo();
                Hide();
                _mainForm.Tag = _game;
                _mainForm.SaveButton.Enabled = true;
                _mainForm.ResumeButton.Visible = true;
                _mainForm.Controller = _spriteController;
            }
        }



        private void OnEndGame(object sender, EventArgs e)
        {
            bool keyEsc = _spriteController.IsKeyPressed(Keys.Escape);
            if (keyEsc)
            {
                _mainForm.ResumeButton.Visible = false;
                _spriteController.DoTick -= OnEndGame;
                Close();
            }
        }

        private void OnHeroObjectCollision(object sender, SpriteEventArgs e)
        {
            if (e.TargetSprite.SpriteOriginName == $"{SpriteNames.ObstacleTree1}")
            {
                return;
            }
            else if (e.TargetSprite.SpriteOriginName == $"{SpriteNames.EnemyBall}")
            {
                e.TargetSprite.Destroy();

                var player = (Player)_hero.payload;
                player.Health -= 10;
                if (player.Health < 1)
                {
                    GameOver();
                }
                lblHealthValue.Text = $"{player.Health}";

                var soundPlayer = new SoundPlayer(Resources.Hit);
                soundPlayer.Play();
            }
            else if (e.TargetSprite.SpriteOriginName == $"{SpriteNames.EmoticonSmile}")
            {
                _uiEmoticons.Remove(e.TargetSprite);
                e.TargetSprite.Destroy();
                _emoticonCount--;
                var player = (Player)_hero.payload;
                player.Smiles++;
                lblEmojiValue.Text = player.Smiles.ToString();
                var soundPlayer = new SoundPlayer(Resources.GotSmile);
                soundPlayer.Play();
            }
            else if (e.TargetSprite.SpriteOriginName == $"{SpriteNames.EmoticonCheeky}")
            {
                _uiEmoticons.Remove(e.TargetSprite);
                e.TargetSprite.Destroy();
                _emoticonCount--;
                var player = (Player)_hero.payload;
                player.Smiles += 2;
                lblEmojiValue.Text = player.Smiles.ToString();
                var soundPlayer = new SoundPlayer(Resources.GotSmile);
                soundPlayer.Play();
            }
            else if (e.TargetSprite.SpriteOriginName == $"{SpriteNames.EmoticonGrin}")
            {
                _uiEmoticons.Remove(e.TargetSprite);
                e.TargetSprite.Destroy();
                _emoticonCount--;
                var player = (Player)_hero.payload;
                player.Smiles += 3;
                lblEmojiValue.Text = player.Smiles.ToString();
                var soundPlayer = new SoundPlayer(Resources.GotSmile);
                soundPlayer.Play();
            }
            else if (e.TargetSprite.SpriteOriginName == $"{SpriteNames.EmoticonLove}")
            {
                _uiEmoticons.Remove(e.TargetSprite);
                e.TargetSprite.Destroy();
                _emoticonCount--;
                var player = (Player)_hero.payload;
                player.Health += 50;
                lblHealthValue.Text = $"{player.Health}";
                var soundPlayer = new SoundPlayer(Resources.Health);
                soundPlayer.Play();
            }
            else if (e.TargetSprite.SpriteOriginName == $"{SpriteNames.EmoticonAngry}")
            {
                _uiEmoticons.Remove(e.TargetSprite);
                e.TargetSprite.Destroy();
                _emoticonCount--;
                var player = (Player)_hero.payload;
                player.Health -= 10;
                if (player.Health < 1)
                {
                    GameOver();
                }
                player.Kills++;
                lblHealthValue.Text = $"{player.Health}";
                lblKillsValue.Text = $"{player.Kills}";
                var soundPlayer = new SoundPlayer(Resources.WrongEmo);
                soundPlayer.Play();
            }
            else if (e.TargetSprite.SpriteOriginName == $"{SpriteNames.EmoticonOnFire}")
            {
                //_uiEmoticons.Remove(e.TargetSprite);
                e.TargetSprite.Destroy();
                //_emoticonCount--;
                var player = (Player)_hero.payload;
                player.Health -= 10;
                if (player.Health < 1)
                {
                    GameOver();
                }
                player.Kills++;
                lblHealthValue.Text = $"{player.Health}";
                lblKillsValue.Text = $"{player.Kills}";
                InitializeUIMonster();
                var soundPlayer = new SoundPlayer(Resources.WrongEmo);
                soundPlayer.Play();
            }


            CreateNewEmoticonGroup();
        }

        private void OnBallObjectCollision(object sender, SpriteEventArgs e)
        {
            if (e.TargetSprite.SpriteOriginName == $"{SpriteNames.ObstacleTree1}")
            {
                var ball = (Sprite)sender;
                ball.Destroy();
            }
            else if (((Sprite)sender).SpriteOriginName == $"{SpriteNames.EnemyBall}")
            {
                if (e.TargetSprite.payload is Emoticon) // DOES NOT WORK
                {
                    var ball = (Sprite)sender;
                    ball.Destroy();
                    _uiEmoticons.Remove(e.TargetSprite);
                    e.TargetSprite.Destroy();
                    _emoticonCount--;
                }
            }
            else if (e.TargetSprite.SpriteOriginName == $"{SpriteNames.EmoticonSmile}")
            {
                var ball = (Sprite)sender;
                ball.Destroy();
                _uiEmoticons.Remove(e.TargetSprite);
                e.TargetSprite.Destroy();
                _emoticonCount--;
                var player = (Player)_hero.payload;
                player.Smiles--;
                player.Kills++;
                lblKillsValue.Text = $"{player.Kills}";
            }
            else if (e.TargetSprite.SpriteOriginName == $"{SpriteNames.EmoticonCheeky}")
            {
                var ball = (Sprite)sender;
                ball.Destroy();
                _uiEmoticons.Remove(e.TargetSprite);
                e.TargetSprite.Destroy();
                _emoticonCount--;
                var player = (Player)_hero.payload;
                player.Smiles -= 2;
                player.Kills++;
                lblKillsValue.Text = $"{player.Kills}";
            }
            else if (e.TargetSprite.SpriteOriginName == $"{SpriteNames.EmoticonGrin}")
            {
                var ball = (Sprite)sender;
                ball.Destroy();
                _uiEmoticons.Remove(e.TargetSprite);
                e.TargetSprite.Destroy();
                _emoticonCount--;
                var player = (Player)_hero.payload;
                player.Smiles -= 3;
                player.Kills++;
                lblKillsValue.Text = $"{player.Kills}";
            }
            else if (e.TargetSprite.SpriteOriginName == $"{SpriteNames.EmoticonLove}")
            {
                var ball = (Sprite)sender;
                ball.Destroy();
                e.TargetSprite.Destroy();
                _uiEmoticons.Remove(e.TargetSprite);
                _emoticonCount--;
                var player = (Player)_hero.payload;
                player.Smiles -= 20;
                player.Kills++;
                lblKillsValue.Text = $"{player.Kills}";
            }
            else if (e.TargetSprite.SpriteOriginName == $"{SpriteNames.EmoticonAngry}")
            {
                var ball = (Sprite)sender;
                ball.Destroy();
                _uiEmoticons.Remove(e.TargetSprite);
                e.TargetSprite.Destroy();
                _emoticonCount--;
                var player = (Player)_hero.payload;
                player.Kills++;
                lblKillsValue.Text = $"{player.Kills}";
            }
            else if (e.TargetSprite.SpriteOriginName == $"{SpriteNames.EmoticonOnFire}"
                && ((Sprite)sender).SpriteOriginName != $"{SpriteNames.EnemyBall}")
            {
                var ball = (Sprite)sender;
                ball.Destroy();
                //_uiEmoticons.Remove(e.TargetSprite);
                e.TargetSprite.Destroy();
                //_emoticonCount--;
                var player = (Player)_hero.payload;
                player.Kills++;
                lblKillsValue.Text = $"{player.Kills}";
                InitializeUIMonster();
            }
            else if (e.TargetSprite.SpriteOriginName == $"{SpriteNames.EnemyBall}")
            {
                var ball = (Sprite)sender;
                ball.Destroy();
                e.TargetSprite.Destroy();
            }

            CreateNewEmoticonGroup();
        }

        private void OnEmoticonEdgeCollision(object sender, EventArgs e)
        {
            var sprite = (Sprite)sender;
            int degrees = (int)sprite.GetSpriteDegrees();
            if (Math.Abs(degrees) > 120)
            {
                sprite.SetSpriteDirectionDegrees(0);//go right
            }
            else
            {
                sprite.SetSpriteDirectionDegrees(180); //go back left
            }
        }

        #endregion
    }
}
