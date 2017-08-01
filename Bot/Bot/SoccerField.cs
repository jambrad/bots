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

            myPoint = new PointF(0, 0);
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
            var C = myBall.center;

            return myBall.isCollideWithBot(A, B, C);
            
        }
        private void Refresher_Tick(object sender, EventArgs e)
        {
            
            myBot.moveRobotToPoint(myPoint.X, myPoint.Y);
            if (isCollide())
            {
                myBall.brush = new SolidBrush(Color.LightGreen);
                myBall.handleCollision(myBot.getMaxSpeed(), myBot.angle);
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
            e.Graphics.DrawEllipse(new Pen(Color.Violet), myPoint.X, myPoint.Y, 3, 3);
            /*if(myBot.isFrontingBall())
                projectBallToFront(e);
             * */
        }

        private Robot myBot;
        private Ball myBall;
        private PointF myPoint;

        private Pen myPen;
        private Pen testPen;

        private float LeftValue;
        private float RightValue;

        private void Field_MouseClick(object sender, MouseEventArgs e)
        {
            //myBall.setCenter(new PointF(e.X,e.Y));
            //myBall.handleStop();
            myPoint.X = e.X;
            myPoint.Y = e.Y;
            
        }
    }
}
