using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Robot
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
        private float max_speed;
        private float max_distance;
        private float friction;
        private int status; // 0 - stationary  1 - moving
        private float timeStep;
        private Angle direction;
        public PointF center;

        public Ball(int x, int y, int width, int height, int intervals)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.radius = width / 2;
            this.speed = 0;
            this.friction = .999f;
            this.status = 0;
            this.direction = null;
            this.max_distance = 350f;
            this.max_speed = max_distance * (intervals / 1000f);

            this.timeStep = (intervals );
            setCenter(new PointF(x, y));
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
            //if not moving
            if (isStationary()) { 
                e.Graphics.FillEllipse(brush, new RectangleF(X, Y, width, height));
            }
            else //if still moving or about to move
            {
                if (speed == 0) {
                    handleStop();

                }
                else 
                { 
                    var distance = travelDistance();
                    var newPoint = pointFrom(center,direction,distance);
                    setCenter(newPoint);
                 
                    e.Graphics.FillEllipse(brush, new RectangleF(X, Y, width, height));
                }
                
                
            }
           
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
        private PointF offsetToCenter(PointF point)
        {
            return new PointF(point.X - (width / 2), point.Y - (height / 2));
        }

        public void setCenter(PointF point)
        {
            center = point;//offsetToCenter(point);
            X = (point.X - (width / 2));
            Y = (point.Y - (height / 2));

        }
        //(A,B) points of frontLine (C) point of center of ball
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
                return (getDistance((float)r.X, (float)r.Y, (float)C.X, (float)C.Y) <= (radius));
            }

            return false;
        }

        public void handleCollision(float speed, Angle direction)
        {
            //timeStep = 0;
            this.speed = speed;
            this.direction = direction;
            this.status = 1;

        }

        public void handleStop()
        {
            //timeStep = 0;
            this.speed = 0;
            this.direction = null;
            this.status = 0;
        }

        public bool isStationary(){
            return (status == 0);
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

        private float travelDistance()
        {
            speed = (float)(speed * Math.Pow(friction, timeStep));
            //speed = speed - speed * (1 - friction) * timeStep;
            return speed * max_speed;
        }

        private PointF pointFrom(PointF basePoint, Angle angle, float distance)
        {
            float x = (float)(Math.Cos(angle.Radian) * distance);
            float y = (float)(Math.Sin(angle.Radian) * distance);

            x = basePoint.X + x;
            y = basePoint.Y - y;

            return new PointF(x, y);
        }

        public float X
        {
            get;
            set;
        }
        public float Y
        {
            get;
            set;
        }

         
    }
}
