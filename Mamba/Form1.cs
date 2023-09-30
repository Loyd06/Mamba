using System;
using System.Drawing.Imaging; //J'ai ajouter ceci pour le compresseur JPG.

namespace Mamba
{
    public partial class Form1 : Form
    {

        private List<Circle> Snake = new List<Circle>(); //Tout ce qui est lié au serpent, à la tête et au corps du serpent, tout sera ajouté à cette liste.
        private Circle food = new Circle();

        int maxWidth; //Largeur maximale à laquelle le serpent est autorisée à voyager.
        int maxHeight; //Hauteur maximale à laquelle le serpent est autorisée à voyager.

        int score;
        int highScore;

        Random rand = new Random();

        bool goLeft, goRight, goUp, goDown;



        public Form1()
        {
            InitializeComponent();

            new Settings(); //Pour appeler la class Settings.
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void KeyIsDown(object sender, KeyEventArgs e) //Ce constructeur est appelé lorsque le joueur enfonce une touche (flèche) du clavier.
        {                                                     //Si le serpent va à droite et que j'appuie à gauche, le serpent n'ira pas à gauche car sa signifie qu'il devra y aller sur son corps, c'est la même chose pour les autres directions.
            if (e.KeyCode == Keys.Left && Settings.directions != "right")
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right && Settings.directions != "left")
            {
                goRight = true;
            }
            if (e.KeyCode == Keys.Up && Settings.directions != "down")
            {
                goUp = true;
            }
            if (e.KeyCode == Keys.Down && Settings.directions != "up")
            {
                goDown = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e) //Ce construteur est appelé lorsque le joueur relâche une touche (flèche) du clavier.
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
        }

        private void StartGame(object sender, EventArgs e)
        {
            RestartGame(); //J'exécute la fonction RestartGame 
            NiveauxDeDifficulte();
        }

        private void TakeSnapShot(object sender, EventArgs e)
        {
            Label caption = new Label();
            caption.Text = "I scored: " + score + " and my HighScore is " + highScore + " on the Snake Game!!!";
            caption.Font = new Font("Ariel", 12, FontStyle.Bold);
            caption.ForeColor = Color.Purple;
            caption.AutoSize = false;
            caption.Width = picCanvas.Width;
            caption.TextAlign = ContentAlignment.MiddleCenter;
            picCanvas.Controls.Add(caption);

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = "Snake Game SnapShot";
            dialog.DefaultExt = "jpg";
            dialog.Filter = "JPG Image File | *.jpg";
            dialog.ValidateNames = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                int width = Convert.ToInt32(picCanvas.Width);
                int height = Convert.ToInt32(picCanvas.Height);

                Bitmap bmp = new Bitmap(Width, Height);
                picCanvas.DrawToBitmap(bmp, new Rectangle(0, 0, width, height));
                bmp.Save(dialog.FileName, ImageFormat.Jpeg);
                picCanvas.Controls.Remove(caption);

            }



        }

        private void NiveauxDeDifficulte()
        {

            if (NvDif.SelectedIndex == 0)
            {
                gameTimer.Interval = 60;
            }
            if (NvDif.SelectedIndex == 1)
            {
                gameTimer.Interval = 40;
            }
            if (NvDif.SelectedIndex == 2)
            {
                gameTimer.Interval = 20;
            }
        }



        private void GameTimerEvents(object sender, EventArgs e)
        {
            //je définis les directions

            if (goLeft)
            {
                Settings.directions = "left";
            }
            if (goRight)
            {
                Settings.directions = "right";
            }
            if (goDown)
            {
                Settings.directions = "down";
            }
            if (goUp)
            {
                Settings.directions = "up";
            }
            // fin des directions

            for (int i = Snake.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {

                    switch (Settings.directions)
                    {
                        case "left":
                            Snake[i].X--;
                            break;
                        case "right":
                            Snake[i].X++;
                            break;
                        case "down":
                            Snake[i].Y++;
                            break;
                        case "up":
                            Snake[i].Y--;
                            break;
                    }

                    if (Snake[i].X < 0)
                    {
                        Snake[i].X = maxWidth;
                    }

                    if (Snake[i].X > maxWidth)
                    {
                        Snake[i].X = 0;
                    }

                    if (Snake[i].Y < 0)
                    {
                        Snake[i].Y = maxHeight;
                    }
                    if (Snake[i].Y > maxHeight)
                    {
                        Snake[i].Y = 0;
                    }

                    if (Snake[i].X == food.X && Snake[i].Y == food.Y)
                    {
                        EatFood();
                    }

                    for (int j = 1; j < Snake.Count; j++)
                    {

                        if (Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y)
                        {
                            GameOver();
                        }



                    }

                }
                else
                {
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }


                picCanvas.Invalidate();

            }



        }

        private void UpdatePictureBoxGraphics(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            Brush snakeColour;

            for (int i = 0; i < Snake.Count; i++)
            {
                if (i == 0)
                {
                    snakeColour = Brushes.Black;
                }
                else
                {
                    snakeColour = Brushes.DarkGoldenrod;
                }

                canvas.FillEllipse(snakeColour, new Rectangle
                    (
                    Snake[i].X * Settings.Width,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));

            }

            canvas.FillEllipse(Brushes.DarkRed, new Rectangle
                  (
                  food.X * Settings.Width,
                  food.Y * Settings.Height,
                  Settings.Width, Settings.Height
                  ));
        }

        private void RestartGame()
        {
            maxWidth = picCanvas.Width / Settings.Width - 1; //Pour faire apparaitre le Snake de l'autre côté en largeur sur la map
            maxHeight = picCanvas.Height / Settings.Height - 1; //Pour faire apparaitre le Snake de l'autre côté en hauteur sur la map

            Snake.Clear();

            startButton.Enabled = false;
            snapButton.Enabled = false;
            NvDif.Enabled = false;
            score = 0;
            txtScore.Text = "Score: " + score;

            Circle head = new Circle { X = 10, Y = 5 }; //Ceci est le placement  du Snake en début de partie sur la map
            Snake.Add(head); // ajout de la tête du serpent à la List

            for (int i = 0; i < 10; i++) //boucle pour ajouter 10 autres parties du corps au Snake
            {
                Circle body = new Circle();
                Snake.Add(body);
            }

            food = new Circle { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) }; //La pomme qui est aléatoirement posé sur la map

            gameTimer.Start(); //j'éxecute le GameTimer pour que le chronomètre du jeu commence à tourner
        }

        private void EatFood()
        {
            score += 1;

            txtScore.Text = "Score: " + score;

            Circle body = new Circle
            {
                X = Snake[Snake.Count - 1].X,
                Y = Snake[Snake.Count - 1].Y
            };

            Snake.Add(body);

            food = new Circle { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };

        }

        private void GameOver()
        {
            gameTimer.Stop();
            startButton.Enabled = true;
            snapButton.Enabled = true;

            if (score > highScore)
            {
                highScore = score;

                txtHighScore.Text = "High Score: " + Environment.NewLine + highScore;
                txtHighScore.ForeColor = Color.Maroon;
                txtHighScore.TextAlign = ContentAlignment.MiddleCenter;
            }



        }
    }
}