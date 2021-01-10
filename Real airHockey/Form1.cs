using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace airHockey
{
    public partial class Form1 : Form
    {
        int paddle1X = 10;
        int paddle1Y = 170;
        int player1Score = 0;

        int paddle2X = 580;
        int paddle2Y = 170;
        int player2Score = 0;

        int paddleWidth = 10;
        int paddleHeight = 25;
        int paddleSpeed = 6;

        int recWidth = 7;
        int recHeight = 175;
        int TLY = 0;
        int TLX = 0;
        int BLY = 260;
        int BLX = 0;
        int TRY = 0;
        int TRX = 580;
        int BRY = 260;
        int BRX = 580;

        int ballX = 295;
        int ballY = 195;
        double ballXSpeed = 6;
        double ballYSpeed = -6;
        int ballWidth = 10;
        int ballHeight = 10;

        bool wDown = false;
        bool sDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;
        bool dDown = false;
        bool aDown = false;
        bool rightArrowDown = false;
        bool leftArrowDown = false;

        SolidBrush blueBrush = new SolidBrush(Color.DodgerBlue);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        Font screenFont = new Font("Consolas", 12);


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
            }

        }
        //My code doesn't work and i'm not sure why. When I started the project i did take your game engine (which probably won't raise my marks any)
        //But in my Designer it says that GameTimer is never referenced and to me it looks like GameTimer is referenced so i'm not sure whats wrong with it.
        //Now the program won't run but I had it running before on your cloned repository that I changed.
        private void GameTimer_Tick(object sender, EventArgs e)
        {

            ballX += Convert.ToInt32(ballXSpeed);
            ballY += Convert.ToInt32(ballYSpeed);


            if (wDown == true && paddle1Y > 0)
            {
                paddle1Y -= paddleSpeed;
            }

            if (sDown == true && paddle1Y < this.Height - paddleHeight)
            {
                paddle1Y += paddleSpeed;
            }
            if (aDown == true && paddle1X > 0)
            {
                paddle1X -= paddleSpeed;
            }

            if (dDown == true && paddle1X < this.Width - paddleWidth)
            {
                paddle1X += paddleSpeed;
            }


            if (upArrowDown == true && paddle2Y > 0)
            {
                paddle2Y -= paddleSpeed;
            }
            if (leftArrowDown == true && paddle2X > 0)
            {
                paddle2X -= paddleSpeed;
            }

            if (rightArrowDown == true && paddle2X < this.Width - paddleWidth)
            {
                paddle2X += paddleSpeed;
            }

            if (downArrowDown == true && paddle2Y < this.Height - paddleHeight)
            {
                paddle2Y += paddleSpeed;
            }


            if (ballY < 0 || ballY > this.Height - ballHeight)
            {
                ballYSpeed *= -1;

            }


            Rectangle player1Rec = new Rectangle(paddle1X, paddle1Y, paddleWidth, paddleHeight);
            Rectangle player2Rec = new Rectangle(paddle2X, paddle2Y, paddleWidth, paddleHeight);
            Rectangle ballRec = new Rectangle(ballX, ballY, ballWidth, ballHeight);
            Rectangle goalBR = new Rectangle(BRX, BRY, recWidth, recHeight);
            Rectangle goalTR = new Rectangle(TRX, TRY, recWidth, recHeight);
            Rectangle goalTL = new Rectangle(TLX, TLY, recWidth, recHeight);
            Rectangle goalBL = new Rectangle(BLX, BLY, recWidth, recHeight);

            if (player1Rec.IntersectsWith(ballRec))
            {
                ballXSpeed *= -1.1;

                ballX = paddle1X + paddleWidth + 1;
            }
            else if (player2Rec.IntersectsWith(ballRec))
            {
                ballXSpeed *= -1.1;

                ballX = paddle2X - ballWidth - 1;
            }

            if (ballX < 0)
            {
                player2Score++;
                ballX = 295;
                ballY = 195;

                paddle1Y = 170;
                paddle2Y = 170;
                paddle2X = 580;
                paddle1X = 10;

                ballXSpeed = 6;

            }
            else if (ballX > 600)
            {
                player1Score++;

                ballX = 295;
                ballY = 195;

                paddle1Y = 170;
                paddle2Y = 170;
                paddle2X = 580;
                paddle1X = 10;

                ballXSpeed = 6;

            }
            else if (goalTL.IntersectsWith(ballRec))
            {
                ballXSpeed *= -1;
                ballX = TLX + ballWidth + 1;
            }
            else if (goalBL.IntersectsWith(ballRec))
            {
                ballXSpeed *= -1;
                ballX = BLX + ballWidth + 1;
            }
            else if (goalTR.IntersectsWith(ballRec))
            {
                ballXSpeed *= -1;
                ballX = TRX - ballWidth - 1;
            }
            else if (goalBR.IntersectsWith(ballRec))
            {
                ballXSpeed *= -1;
                ballX = BRX - ballWidth - 1;
            }

            if (player1Score == 3 || player2Score == 3)
            {
                GameTimer.Enabled = false;
            }


            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(whiteBrush, ballX, ballY, ballWidth, ballHeight);

            e.Graphics.FillRectangle(redBrush, paddle1X, paddle1Y, paddleWidth, paddleHeight);
            e.Graphics.FillRectangle(blueBrush, paddle2X, paddle2Y, paddleWidth, paddleHeight);

            e.Graphics.FillRectangle(whiteBrush, BRX, BRY, recWidth, recHeight);
            e.Graphics.FillRectangle(whiteBrush, BLX, BLY, recWidth, recHeight);
            e.Graphics.FillRectangle(whiteBrush, TLX, TLY, recWidth, recHeight);
            e.Graphics.FillRectangle(whiteBrush, TRX, TRY, recWidth, recHeight);

            e.Graphics.DrawString($"{player1Score}", screenFont, whiteBrush, 280, 10);
            e.Graphics.DrawString($"{player2Score}", screenFont, whiteBrush, 310, 10);

        }
    }
    
    
}
