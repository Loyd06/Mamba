using System;
namespace Mamba
{
    public partial class Form1 : Form
    {

        private List<Circle> Snake = new List<Circle>();
        private Circle food = new Circle();

        int maxWidht;
        int maxHeight;

        int score;
        int highScore;

        Random rand = new Random();

        bool goLeft, goRight, goUp, goDown;



        public Form1()
        {
            InitializeComponent();

            new Settings();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && Settings.directions != "right")
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right && Settings.directions != "left") 
            {
                goRight = true;
            }
            if(e.KeyCode == Keys.Up && Settings.directions != "down")
            {
                goUp = true;
            }
            if(e.KeyCode == Keys.Down && Settings.directions != "up") 
            {
                goDown = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
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
            RestartGame();
        }

        private void TakeSnapShot(object sender, EventArgs e)
        {

        }

        private void GameTimerEvents(object sender, EventArgs e)
        {

        }

        private void UpdatePictureBoxGraphics(object sender, PaintEventArgs e)
        {

        }

        private void RestartGame()
        {

        }

        private void EatFood()
        {

        }

        private void GameOver()
        {

        }
    }
}