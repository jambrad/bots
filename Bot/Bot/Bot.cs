using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot
{
    class Bot
    {
        private const float LENGTH = 30f;
        private const float MAX_SPEED = 3f;
        private const float TURN_RATE = 10f;

        private const int Q1 = 0;
        private const int Q2 = 1;
        private const int Q3 = 2;
        private const int Q4 = 3;
        private const int PX = 4;
        private const int PY = 5;
        private const int NX = 6;
        private const int NY = 7;


        public Bot(float x, float y)
        {
            Anchor = new PointF(x - (LENGTH / 2), y - (LENGTH / 2));

            Center = new PointF(x, y);

            Size = new SizeF(LENGTH, LENGTH);

            Boundaries = new RectangleF(Anchor, Size);

            Angle = 90f;
        }

        public Bot() : this(0f, 0f) { }


        //private void MoveCenter(float speed)
        //{
        //    float deltaX = (float)(Math.Cos(RelativeRad) * speed);
        //    float deltaY = (float)(Math.Sin(RelativeRad) * speed);

        //    //Console.WriteLine("1 - a " + Angle + " - ra " + RelativeAngle + " - dX " + deltaX + " - dY " + deltaY);

        //    deltaX *= TransformX(deltaX);
        //    deltaY *= TransformY(deltaY);

        //    //Console.WriteLine("2 - a " + Angle + " - ra " + RelativeAngle + " - dX " + deltaX + " - dY " + deltaY);

        //    Anchor = new PointF(Anchor.X + deltaX, Anchor.Y - deltaY);
        //    Center = new PointF(Center.X + deltaX, Center.Y - deltaY);

        //    boundaries.Location = Anchor;
        //}

        //private void Turn(float turnAngle)
        //{
        //    Angle = Angle + turnAngle;

        //    if (Angle > 180)
        //    {
        //        var offsetAngle = Angle - 180;

        //        Angle = -180 + offsetAngle;
        //    }

        //    else if (Angle < -180)
        //    {
        //        var offsetAngle = -180 - Angle;

        //        Angle = 180 - offsetAngle;
        //    }
        //}

        private void MoveCenter(float newX, float newY)
        {

        }

        //private void Turn(float left, float right)
        //{
        //    if (Math.Abs(left) > Math.Abs(right))
        //    {
        //        Angle = Angle + (TURN_RATE * (left - right));
        //    }

        //    else
        //    {
        //        Angle = Angle = Angle - (TURN_RATE * (right - left));
        //    }
        //}

        //private void TurnLeft(float rate)
        //{
            
        //}

        

        public void Move(float left, float right)
        {
            Turn(right * TURN_RATE);
            MoveCenter(left * MAX_SPEED);
        }

        public PointF FindTurningPoint(float left, float right)
        {
            var absLeft = Math.Abs(left);
            var absRight = Math.Abs(right);

            if (absLeft == absRight)
            {
                return Center;
            }

            else if (absLeft == 0 && absRight != 0)
            {

            }
        }

        //private float TransformX(float x)
        //{
        //    if (Angle < 0 && Angle != -180)
        //    {
        //        return x * -1;
        //    }

        //    else if (Angle > 0 && Angle != 180)
        //    {
        //        return x;
        //    }

        //    else
        //    {
        //        return 0f;
        //    }
        //}

        //private float TransformY(float y)
        //{
        //    if (Angle < 90 && Angle > -90)
        //    {
        //        return y;
        //    }

        //    else if ((Angle < -90 || Angle > 90) && (Math.Abs(Angle) != 180))
        //    {
        //        return y * -1;
        //    }

        //    else
        //    {
        //        return 0f;
        //    }
        //}


        private PointF FindPointFromCenter(float degrees, float distance)
        {
            float x = (float)(Math.Cos(RelativeRad + degrees) * distance);
            float y = (float)(Math.Sin(RelativeRad + degrees) * distance);

            x += Center.X;
            y += Center.Y;

            return new PointF(x, y);
        }
        
        private int GetAngleOrientation(float degrees)
        {
            if (degrees > 0 && degrees < 90)
            {
                return Q1;
            }

            else if (degrees > 90 && degrees < 180)
            {
                return Q2;
            }

            else if (degrees > 180 && degrees < 270)
            {
                return Q3;
            }

            else if (degrees > 270 && degrees < 360)
            {
                return Q4;
            }

            else if (degrees == 0)
            {
                return PX;
            }

            else if (degrees == 90)
            {
                return PY;
            }

            else if (degrees == 180)
            {
                return NX;
            }

            else
            {
                return NY;
            }
        }

        private float SimplifyAngle(float angle)
        {
            if (angle >= 360)
            {
                return angle - 360;
            }

            else if (angle < 0)
            {
                return angle + 360;
            }

            else
            {
                return angle;
            }
        }

        public float GetRelativeAngle(float angle)
        {
            switch (GetAngleOrientation(angle))
            {
                case Q1:
                    break;
                case Q2:
                    break;
                case Q3:
                    break;
                case Q4:
                    break;
                case PX:
                    break;
                case PY:
                    break;
                case NX:
                    break;
                case NY:
                    break;
            }

            if (Angle > 0 && Angle < 90) // Q1
            {
                return 90 - Angle;
            }

            else if (Angle < 0 && Angle > -90) // Q2
            {
                return -90 - Angle;
            }

            else if (Angle < -90 && Angle > -180) // Q3
            {
                return Angle + 90;
            }

            else if (Angle > 90 && Angle < 180) // Q4
            {
                return Angle - 90;
            }

            else if (Angle == 0) // +Y axis
            {
                return 90f;
            }

            else if (Angle == 90) // +X axis
            {
                return 0f;
            }

            else if (Angle == -90) // -X axis
            {
                return 0f;
            }

            else // -Y axis
            {
                return 90f;
            }
        }

        public float RelativeRad
        {
            get
            {
                //return (float)(RelativeAngle / (Math.PI * 2));
                return DegreeToRad(GetRelativeAngle);
            }
        }


        public PointF Anchor { get; private set; }

        public PointF Center { get; private set; }

        public SizeF Size { get; private set; }

        public float Angle { get; private set; }
        

        public float Radius
        {
            get
            {
                return LENGTH / 2;
            }
        }

        public float Diameter
        {
            get
            {
                return LENGTH;
            }
        }

        private float DegreeToRad(float degree)
        {
            return degree * 0.0174533f;
        }

        public RectangleF Boundaries
        {
            get
            {
                return boundaries;
            }

            private set
            {
                boundaries = value;
            }
        }


        private RectangleF boundaries;
    }
}
