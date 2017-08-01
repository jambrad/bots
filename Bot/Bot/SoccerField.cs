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

            myBall = new Ball((Field.Width / 2) + 200, (Field.Height / 2) + 200, 30, 30, Refresher.Interval);
            

            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                null, Field, new object[] { true });

            botRect = new RectangleF();
            ballRect = new RectangleF();
           
            
        }

      
        private bool isCollide()
        {
            PointF[] points = myBot.getFrontPoints();
            var A = points[0];
            var B = points[1];
            var C = myBall.center;//new PointF((float)myBall.center.X, (float)myBall.center.Y);

            return myBall.isCollideWithBot(A, B, C);
           //return myBall.isCollideWithBot(myBot.getFrontPoints());
            
        }
        private void Refresher_Tick(object sender, EventArgs e)
        {
            
            double angle = getFinalAngle();
            //Console.WriteLine("angle: " + angle);
            myBot.moveRobot(angle, getDistance());
            if (isCollide())
            {
                myBall.brush = new SolidBrush(Color.LightGreen);
                myBall.handleCollision(.7f, myBot.angle);
            }
            else
            {
                myBall.brush = new SolidBrush(Color.DarkRed);
            }

           
            Field.Refresh();

            
        }

     
        private void Field_Paint(object sender, PaintEventArgs e)
        {
            CreateGraphics().SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            myBot.draw(e);
            myBall.draw(e);
            /*if(myBot.isFrontingBall())
                projectBallToFront(e);
             * */
        }

        private float getDeltaY()
        {
            return myBot.center.Y - myBall.center.Y;
        }

        private float getDeltaX()
        {
            return myBot.center.X - myBall.center.X;
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
            if (myBot.center.X == myBall.center.X)
            {
                if (myBot.center.Y > myBall.center.Y)
                {
                    return 270;
                }
                else if (myBot.center.Y < myBall.center.Y)
                {
                    return 90;
                }
            }

            var orientation = (double)(myBot.center.X < myBall.center.X ? 0 : 180);

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
                fa = -(180 - (fa % 180));
            }
            return fa;
        }

        public void projectBallToFront(PaintEventArgs e)
        {
            PointF[] frontPoints = myBot.getFrontPoints();
            var Ax = frontPoints[0].X;
            var Ay = frontPoints[0].Y;
            var Bx = frontPoints[1].X;
            var By = frontPoints[1].Y;
            var Cx = myBall.X;
            var Cy = myBall.Y;
            var t =((Cx-Ax)*(Bx-Ax)+(Cy-Ay)*(By-Ay))/(Math.Pow((Bx-Ax),2)+Math.Pow((By-Ay),2));
            var Dx = Ax + t*(Bx - Ax);
            var Dy = Ay + t*(By - Ay);

            e.Graphics.DrawLine(new Pen(Color.LightGreen), (float)Dx, (float)Dy, (float)Cx, (float)Cy);
            
        }

        private Robot myBot;
        private Ball myBall;

        private Pen myPen;
        private Pen testPen;

        private float LeftValue;
        private float RightValue;

        private void Field_MouseClick(object sender, MouseEventArgs e)
        {
            myBall.setCenter(new PointF(e.X,e.Y));
            myBall.handleStop();
        }
    }
}
