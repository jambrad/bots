using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bot
{
    class Ball
    {
        private int x;
        private int y;
        private int width;
        private int height;
        public Brush brush;
        private float radius;
        private float speed;

        public Ball(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.radius = width / 2;
            this.speed = 0;
            brush = new SolidBrush(Color.DarkRed);
        }

        public Ball()
        {
            this.x = 0;
            this.y = 0;
            this.width = 0;
            this.height = 0;
            brush = new SolidBrush(Color.DarkRed);
        }

        public void draw(PaintEventArgs e)
        {
            e.Graphics.FillEllipse(brush, new Rectangle(x, y, width, height));
           
        }
        /*
        public bool isCollideWithBot(PointF[] frontPoints)
        {
            var Ax = frontPoints[0].X;
            var Ay = frontPoints[0].Y;
            var Bx = frontPoints[1].X;
            var By = frontPoints[1].Y;
            var Cx = X;
            var Cy = Y;
            var t = ((Cx - Ax) * (Bx - Ax) + (Cy - Ay) * (By - Ay)) / (Math.Pow((Bx - Ax), 2) + Math.Pow((By - Ay), 2));
            var Dx = Ax + t * (Bx - Ax);
            var Dy = Ay + t * (By - Ay);

            return (getDistance((float)Cx, (float)Cy, (float)Dx, (float)Dy) <= radius);
        }
        */

        public bool isCollideWithBot(PointF A, PointF B, PointF C)
        {
            var isValid = false;
            var r = new PointF();

            var U = ((C.X - A.X) * (B.X - A.X)) + ((C.Y - A.Y) * (B.Y - A.Y));

            var Udenom = Math.Pow(B.X - A.X, 2) + Math.Pow(B.Y - A.Y, 2);

            U /= (float)Udenom;

            r.X = A.X + (U * (B.X - A.X));
            r.Y = A.Y + (U * (B.Y - A.Y));

           

            var minx = Math.Min(A.X, B.X);
            var maxx = Math.Max(A.X, B.X);

            var miny = Math.Min(A.Y, B.Y);
            var maxy = Math.Max(A.Y, B.Y);

            isValid = (r.X >= minx && r.X <= maxx) && (r.Y >= miny && r.Y <= maxy);

            if (isValid)
            {
                return (getDistance((float)r.X, (float)r.Y, (float)C.X, (float)C.Y) <= radius);
            }

            return false;
        }

        public float getDistance(float Ax, float Ay, float Bx, float By)
        {
            float tempX, tempY;
            float result;
            tempX = (float)Math.Pow((Ax - Bx), 2);
            tempY = (float)Math.Pow((Ay - By), 2);
            result = (float)Math.Sqrt(tempX + tempY);

            return result; 
        }

        public int X
        {
            get { return x + (width / 2); }
            set { x = value; }
        }
        public int Y
        {
            get { return y + (height / 2); }
            set { y = value; }
        }

         
    }
}
