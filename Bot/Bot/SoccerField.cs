using Bot;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Robot
{
    public partial class SoccerField : Form
    {
        public RectangleF botRect;
        public RectangleF ballRect;
        public SoccerField()
        {
            InitializeComponent();
           
           
        }

        private void BotField_Load(object sender, EventArgs e)
        {
            myBot = new Robot(Field.Width / 2, Field.Height / 2, Refresher.Interval);

            myPen = new Pen(Color.Black);

            testPen = new Pen(Color.Red, 5);

            myBall = new Ball((Field.Width / 2) + 200, (Field.Height / 2) + 200, 15, 15);

            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                null, Field, new object[] { true });

            botRect = new RectangleF();
            ballRect = new RectangleF();
           
            
        }

        private void setRect()
        {
            botRect.X = myBot.center.X;
            botRect.Y = myBot.center.Y;
            botRect.Height = myBot.len/2;
            botRect.Width = myBot.len/2;

            ballRect.X = myBall.X;
            ballRect.Y = myBall.Y;
            ballRect.Height = 15;
            ballRect.Width = 15;

            Console.Write(botRect.ToString());

        }

        private void drawRects(PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Pen pen = new Pen(Color.Red);
            e.Graphics.DrawRectangle(pen, botRect.X, botRect.Y, botRect.Width, botRect.Height);
            e.Graphics.DrawRectangle(pen, ballRect.X, ballRect.Y, ballRect.Width, ballRect.Height);
        }

        private bool isCollide()
        {
            return botRect.IntersectsWith(ballRect);
        }
        private void Refresher_Tick(object sender, EventArgs e)
        {
            
            var angle = getFinalAngle();
            //Console.WriteLine("angle: " + angle);
            myBot.moveRobot(angle, getDistance());

            setRect();
            
            Field.Refresh();

            Console.WriteLine("Collision: {0}", isCollide());
        }

     
        private void Field_Paint(object sender, PaintEventArgs e)
        {
            CreateGraphics().SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            myBot.draw(e);
            myBall.draw(e);
            drawRects(e);
        }

        private float getDeltaY()
        {
            return myBot.center.Y - myBall.Y;
        }

        private float getDeltaX()
        {
            return myBot.center.X - myBall.X;
        }

        private double getDistance()
        {
            float tempX, tempY;
            double result;
            tempX = (float) Math.Pow((myBall.X - myBot.center.X),2);
            tempY = (float) Math.Pow((myBall.Y - myBot.center.Y),2);
            result = Math.Sqrt(tempX + tempY);

            return result;
        }

        public double getRelativeAngle()
        {
            // if the same x
            if (myBot.center.X == myBall.X)
            {
                if (myBot.center.Y > myBall.Y)
                {
                    return 270;
                }
                else if (myBot.center.Y < myBall.Y)
                {
                    return 90;
                }
            }

            var orientation = (double)(myBot.center.X < myBall.X ? 0 : 180);

            var deltaX = getDeltaX();
            var deltaY = getDeltaY();

            var angle = Math.Atan(deltaY / deltaX);

            var result = (angle * 180 / Math.PI);
            //Console.Write("result: {0} >>> ", result);
            result = (orientation - result);


            return result;
            
        }

        public double getFinalAngle()
        {
            var ra = getRelativeAngle();
            //Console.Write("Relative: {0}   Bot:  {1}  ", ra, myBot.angle.Degree);

            var fa = -(myBot.angle.Degree - ra);
            while ((fa < 0) || (fa >= 360))
            {
                if (fa < 0)
                {
                    fa += 360;
                }
                else
                {
                    fa -= 360;
                }
            }
            if (fa > 180)
            {
                fa = -(fa - 180);
            }
            return fa;
        }

        private Robot myBot;
        private Ball myBall;

        private Pen myPen;
        private Pen testPen;

        private float LeftValue;
        private float RightValue;

        private void Field_MouseClick(object sender, MouseEventArgs e)
        {
            myBall.X = e.X;
            myBall.Y = e.Y;
        }
    }
}
