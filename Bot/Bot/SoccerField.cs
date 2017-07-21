using Bot;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Robot
{
    public partial class SoccerField : Form
    {
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

           
           
            
        }

        private void Refresher_Tick(object sender, EventArgs e)
        {
            var angle = getFinalAngle();
            Console.WriteLine("angle: " + angle);
            myBot.moveRobot(angle, getDistance());
            Field.Refresh();
        }

        private void LeftBar_Scroll(object sender, EventArgs e)
        {
            LeftValue = (LeftBar.Value / (float)LeftBar.Maximum);
            leftSpeed.Text = LeftValue + "";
            //printLeftRightValues();
        }

        private void RightBar_Scroll(object sender, EventArgs e)
        {
            RightValue = (RightBar.Value / (float)RightBar.Maximum);
            rightSpeed.Text = RightValue + "";
            //printLeftRightValues();
        }

        private void printLeftRightValues()
        {
            Console.WriteLine("(" + LeftValue + ", " + RightValue + ")");
        }

        private void Field_Paint(object sender, PaintEventArgs e)
        {
            CreateGraphics().SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            myBot.draw(e);
            myBall.draw(e);
        }

        private float getDeltaY()
        {
            return myBall.Y - myBot.front.Y;
        }

        private float getDeltaX()
        {
            return myBall.X - myBot.front.X;
        }

        private double getDistance()
        {
            float tempX, tempY;
            double result;
            tempX = (float) Math.Pow((myBall.X - myBot.front.X),2);
            tempY = (float) Math.Pow((myBall.Y - myBot.front.Y),2);
            result = Math.Sqrt(tempX + tempY);

            return result;
        }

        public double findAngle()
        {
            float result;
            float deltaY = getDeltaY();
            float deltaX = getDeltaX();
            result = (float)Math.Asin(deltaX / getDistance());
            double deg = (result * 180 / Math.PI);
            //myBot.robotAngle = new Angle(result);
           
            //Console.WriteLine("result: " + deg);
            return deg;
        }

        public int getOrientation()
        {
            float deltaX = getDeltaX();
            float deltaY = getDeltaY();
            Console.Write("deltaX: {0}   deltaY: {1}", deltaX, deltaY);
            int orientation = 0;

            if (deltaX > 0 && deltaY < 0)
            {
                orientation = 1;
            }
            else if (deltaX < 0 && deltaY < 0)
            {
                orientation = 2;
            }
            else if (deltaX < 0 && deltaY > 0)
            {
                orientation = 3;
            }
            else if (deltaX > 0 && deltaY > 0)
            {
                orientation = 4;
            }
            else if (deltaX == 0 && (myBall.Y < myBot.front.Y))
            {
                orientation = 5;
            }
            else if (deltaX == 0 && (myBall.Y > myBot.front.Y))
            {
                orientation = 7;
            }
            else if (deltaY == 0 && (myBall.X < myBot.front.X))
            {
                orientation = 6;
            }
            else if (deltaY == 0 && (myBall.X > myBot.front.X))
            {
                orientation = 8;
            }
            else if (deltaX == 0 && deltaY == 0)
            {
                orientation = 9;
            }

            return orientation;
        }

        public float getRelativeAngle()
        {
            int orientation = getOrientation();
            Console.Write("Orientation: " + orientation + "    ");
            float result, angle;
            angle = (float)Math.Abs(findAngle());

            switch (orientation)
            {
                case 1:
                    result = angle;
                    break;
                case 2:
                    result = angle + 90;
                    break;
                case 3:
                    result = angle + 180;
                    break;
                case 4:
                    result = (angle - 90);
                    break;
                case 5:
                    result = 90;
                    break;
                case 6:
                    result = 180;
                    break;
                case 7:
                    result = 270;
                    break;
                case 8:
                    result = 360;
                    break;
                default:
                    result = 0;
                    break;
            }
            return result;
        }

        public double getFinalAngle()
        {

            return -(myBot.angle.Degree - getRelativeAngle());
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
