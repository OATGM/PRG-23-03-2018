using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using static System.Windows.Controls.Canvas;

namespace kocka_a_mys
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int BlockSize = 40;
        private int Score = 0;
        VyberPozic vp = new VyberPozic();
        public MainWindow()
        {
            InitializeComponent();
            SetUpdateTimer();
            SetSpeedTimer();
            this.DataContext = this;
            StartGame();
            
        }

        private void StartGame()
        {
            scoreText.Text = "Score:";
            Score = 0;
            mainCanvas.Children.Clear();
            tail.Clear();
            CreateMap();
            SetLeft(kocka, VyberPozic.kockaX);
            SetTop(kocka, VyberPozic.kockaY);
            mainCanvas.Children.Add(kocka);
            SetLeft(mouse, VyberPozic.mysX);
            SetTop(mouse, VyberPozic.mysY);
            mainCanvas.Children.Add(mouse);
        }

        #region Graphics
        private double X { get; set; }
        private double Y { get; set; }
        public List<Rect> walls = new List<Rect>();
        private void CreateMap()
        {
            X = 0;
            Y = 0;
            for (int i = 0; i < Map.map.GetLength(0); i++)
            {
                for (int j = 0; j < Map.map.GetLength(1); j++)
                {
                    switch (Map.map[i, j])
                    {
                        case 1:
                            createBorderBlock(); SetTop(borderBlock, Y); SetLeft(borderBlock, X);                   
                            break;
                        case 2:
                            createStone(); SetTop(stone, Y); SetLeft(stone, X);
                            break;
                        case 3:
                            createHole(); SetTop(hole, Y + BlockSize / 2); SetLeft(hole, X + BlockSize / 2);
                            break;
                    }
                    X += BlockSize;
                }
                X = 0;
                Y += BlockSize;
            }
        }

        public List<Rect> tail = new List<Rect>();

        private void CreateTail()
        {
            createTailBlock();
            SetTop(tailBlock, LastPosition.Y);
            SetLeft(tailBlock, LastPosition.X);
            tail.Add(new Rect(LastPosition.X, LastPosition.Y, tailBlock.Width, tailBlock.Height));
        }

        private Rectangle borderBlock;
        public void createBorderBlock()
        {
            borderBlock = new Rectangle();
            borderBlock.Width = BlockSize; borderBlock.Height = BlockSize;
            Panel.SetZIndex(borderBlock, 15);
            borderBlock.Fill = Brushes.IndianRed;
            mainCanvas.Children.Add(borderBlock);
        }

        private Ellipse stone;
        public void createStone()
        {
            stone = new Ellipse();
            stone.Width = BlockSize; stone.Height = BlockSize;
            Panel.SetZIndex(stone, 20);
            stone.Fill = Brushes.Gray;
            mainCanvas.Children.Add(stone);
        }

        private Ellipse hole;
        public void createHole()
        {
            hole = new Ellipse();
            hole.Width = BlockSize / 2; hole.Height = BlockSize / 2;
            Panel.SetZIndex(hole, 20);
            hole.Fill = Brushes.Black;
            mainCanvas.Children.Add(hole);
        }

        private Rectangle tailBlock;
        public void createTailBlock()
        {
            tailBlock = new Rectangle();
            tailBlock.Width = BlockSize; tailBlock.Height = BlockSize;
            Panel.SetZIndex(tailBlock, 5);
            tailBlock.Fill = Brushes.Green;
            mainCanvas.Children.Add(tailBlock);
        }
        #endregion

        #region movement
        Direction direction = Direction.right;
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            //cat movement
            if (e.Key == Key.NumPad4 & direction != Direction.right) direction = Direction.left;
            if (e.Key == Key.NumPad6 & direction != Direction.left) direction = Direction.right;
            if (e.Key == Key.NumPad8 & direction != Direction.down) direction = Direction.up;
            if (e.Key == Key.NumPad2 & direction != Direction.up) direction = Direction.down;
            if (e.Key == Key.NumPad9 & direction != Direction.ld) direction = Direction.rt;
            if (e.Key == Key.NumPad1 & direction != Direction.rt) direction = Direction.ld;
            if (e.Key == Key.NumPad7 & direction != Direction.rd) direction = Direction.lt;
            if (e.Key == Key.NumPad3 & direction != Direction.lt) direction = Direction.rd;

            //mouse movement
            if (e.Key == Key.A /*& Map.map[LeftArrayOfMouse - 1, TopArrayOfMouse] != 1*/) SetLeft(mouse, GetLeft(mouse) - 2 * BlockSize);
            if (e.Key == Key.D /*& Map.map[LeftArrayOfMouse + 1, TopArrayOfMouse] != 1*/) SetLeft(mouse, GetLeft(mouse) +  2 * BlockSize);
            if (e.Key == Key.W /*& Map.map[LeftArrayOfMouse, TopArrayOfMouse - 1] != 1*/) SetTop(mouse, GetTop(mouse) - 2 * BlockSize);
            if (e.Key == Key.S /*& Map.map[LeftArrayOfMouse, TopArrayOfMouse + 1] != 1*/) SetTop(mouse, GetTop(mouse) + 2 * BlockSize);
        }

        DispatcherTimer update = new DispatcherTimer();
        private void SetUpdateTimer()
        {
            update.Tick += Update;
            update.Interval = TimeSpan.FromMilliseconds(500);
            update.Start();
        }

        DispatcherTimer speedTimer = new DispatcherTimer();
        private void SetSpeedTimer()
        {
            speedTimer.Tick += speedtimer;
            speedTimer.Interval = TimeSpan.FromMilliseconds(10);
            speedTimer.Start();
        }

        private void speedtimer(object sender, EventArgs e)
        {
            TroughWalls();
        }

        private void Update(object sender, EventArgs e)
        {
            scoreText.Text = "Score: " + Score;
            Detection();
            CatMovement();
            CreateTail();
            CheckCollision();
        }

        private void CatMovement()
        {
            if (direction == Direction.left & Map.map[LeftArray - 1, TopArray] != 1 & Map.map[LeftArray - 1, TopArray] != 2)
            {
                SetLeft(kocka, GetLeft(kocka) - BlockSize);
                Score++;
            }
            if (direction == Direction.right & Map.map[LeftArray + 1, TopArray] != 1 & Map.map[LeftArray + 1, TopArray] != 2)
            {
                SetLeft(kocka, GetLeft(kocka) + BlockSize);
                Score++;
            }
            if (direction == Direction.up & Map.map[LeftArray, TopArray - 1] != 1 & Map.map[LeftArray, TopArray - 1] != 2)
            {
                SetTop(kocka, GetTop(kocka) - BlockSize);
                Score++;
            }
            if (direction == Direction.down & Map.map[LeftArray, TopArray + 1] != 1 & Map.map[LeftArray, TopArray + 1] != 2)
            {
                SetTop(kocka, GetTop(kocka) + BlockSize);
                Score++;
            }
            if (direction == Direction.rt & Map.map[LeftArray + 1, TopArray - 1] != 1 & Map.map[LeftArray + 1, TopArray - 1] != 2)
            {
                SetTop(kocka, GetTop(kocka) - BlockSize);
                SetLeft(kocka, GetLeft(kocka) + BlockSize);
                Score++;
            }
            if (direction == Direction.lt & Map.map[LeftArray - 1, TopArray - 1] != 1 & Map.map[LeftArray - 1, TopArray - 1] != 2)
            {
                SetTop(kocka, GetTop(kocka) - BlockSize);
                SetLeft(kocka, GetLeft(kocka) - BlockSize);
                Score++;
            }
            if (direction == Direction.ld & Map.map[LeftArray - 1, TopArray + 1] != 1 & Map.map[LeftArray - 1, TopArray + 1] != 2)
            {
                SetTop(kocka, GetTop(kocka) + BlockSize);
                SetLeft(kocka, GetLeft(kocka) - BlockSize);
                Score++;
            }
            if (direction == Direction.rd & Map.map[LeftArray + 1, TopArray + 1] != 1 & Map.map[LeftArray + 1, TopArray + 1] != 2)
            {
                SetTop(kocka, GetTop(kocka) + BlockSize);
                SetLeft(kocka, GetLeft(kocka) + BlockSize);
                Score++;
            }
        }
        #endregion

        #region detection
        private int LeftArray { get; set; }
        private int TopArray { get; set; }
        private int LeftArrayOfMouse { get; set; }
        private int TopArrayOfMouse { get; set; }
        private Point LastPosition { get; set; }
        private void Detection()
        {
            for (int i = 0; i < Map.map.GetLength(0); i++)
            {
                for (int j = 0; j < Map.map.GetLength(1); j++)
                {
                    if (GetLeft(kocka) + 1 > i * BlockSize & GetLeft(kocka) + 1 < i * BlockSize + BlockSize
                        & GetTop(kocka) + 1 > j * BlockSize & GetTop(kocka) + 1 < j * BlockSize + BlockSize)
                    {
                        LeftArray = i;
                        TopArray = j;
                    }
                    if (GetLeft(mouse) + 1 > i * BlockSize & GetLeft(mouse) + 1 < i * BlockSize + BlockSize
                        & GetTop(mouse) + 1 > j * BlockSize & GetTop(mouse) + 1 < j * BlockSize + BlockSize)
                    {
                        LeftArrayOfMouse = i;
                        TopArrayOfMouse = j;
                    }
                }
            }
            LastPosition = new Point(GetLeft(kocka), GetTop(kocka));
        }

        private void TroughWalls()
        {
            if (GetLeft(mouse) < 40)
            {
                SetLeft(mouse, 520);
            }
            if (GetLeft(mouse) > 520)
            {
                SetLeft(mouse, 40);
            }
            if (GetTop(mouse) < 40)
            {
                SetTop(mouse, 520);
            }
            if (GetTop(mouse) > 520)
            {
                SetTop(mouse, 40);
            }
        }
        #endregion

        #region collision
        private Rect MysRect;
        private Rect KockaRect;
        private Rect holeRect;
        private void CheckCollision()
        {
            MysRect = new Rect(GetLeft(mouse), GetTop(mouse), mouse.Width, mouse.Height);
            KockaRect = new Rect(GetLeft(kocka), GetTop(kocka), kocka.Width, kocka.Height);
            holeRect = new Rect(GetLeft(hole), GetTop(hole), hole.Width, hole.Height);
            if (holeRect.IntersectsWith(KockaRect))
            {
                StartGame();
            }

            Rect[] pole = new Rect[tail.Count];

            tail.CopyTo(pole);

            foreach (Rect r in pole)
            {
                if (r.IntersectsWith(MysRect))
                {
                    StartGame();
                }
            }
        }
        #endregion

        private void mainCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //MessageBox.Show(LeftArray.ToString() + TopArray.ToString());
        }
    }
}
