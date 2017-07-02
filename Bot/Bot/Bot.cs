using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bot
{
    class Bot
    {
        private const float LENGTH = 30f;
        private const float MAX_DISTANCE_PER_SECOND = 100f; 
        private const float TURN_RATE = 10f;

        private readonly float maxSpeed;


        // primary constructor
        public Bot(float x, float y, int interval)
        {
            // bot location and orientation
            Anchor = new PointF(x - (LENGTH / 2), y - (LENGTH / 2));
            Center = new PointF(x, y);
            Angle = new Angle(90);

            // bot dimensions
            Size = new SizeF(LENGTH, LENGTH);
            Boundaries = new RectangleF(Anchor, Size);

            // bot pen
            boundaryPen = new Pen(Color.Black);
            frontPen = new Pen(Color.Red);

            maxSpeed = MAX_DISTANCE_PER_SECOND * (interval / 1000f);
        }

        // default constructor
        public Bot(int interval) : this(0f, 0f, interval) { }
        

        // draw the object
        public void Draw(PaintEventArgs e)
        {
            e.Graphics.DrawEllipse(boundaryPen, Boundaries);
            var frontPoint = FindPointFromCenter(Angle, Radius);
            var points = new PointF[] { frontPoint, frontPoint };
            e.Graphics.DrawLines(frontPen, points);
        }

        // update location and direction of the bot
        public void Move(float left, float right)
        {
            if (left == right)
            {
                // passing left or right doesn't matter
                // they're both equal in speed
                StraightMove(left); 
            }

            else
            {
                var turningAngle = TurningPointAngle(left, right);
                var turningRadius = TurningPointDistance(left, right);
                var turningPoint = FindPointFromCenter(turningAngle, turningRadius);

                if (turningPoint.Equals(Center))
                {
                    StraightMove(left);
                }

                else
                {
                    CurvedMove(turningPoint, turningAngle, turningRadius, left, right);
                }
            }
        }


        private PointF FindPointFromCenter(Angle angle, float distance)
        {
            return FindPointFrom(Center, angle, distance);
        }

        private PointF FindPointFrom(PointF basePoint, Angle angle, float distance)
        {
            float x = (float)(Math.Cos(angle.Radian) * distance);
            float y = (float)(Math.Sin(angle.Radian) * distance);

            x = basePoint.X + x;
            y = basePoint.Y - y;

            return new PointF(x, y);
        }

        private Angle TurningPointAngle(float left, float right)
        {
            return new Angle(Angle.Degree + (Math.Abs(left) < Math.Abs(right) ? 90 : -90));
        }

        private float TurningPointDistance(float left, float right)
        {
            var faster = (left > right ? left : right);
            var slower = (left < right ? left : right);

            return Math.Abs(Radius * (faster / (faster - slower)));
        }

        private void StraightMove(float speed)
        {
            var distance = GetTravelDistance(speed);

            var newCenter = FindPointFromCenter(Angle, distance);

            MoveCenter(newCenter);
        }

        private void CurvedMove(PointF turningPoint, Angle turningAngle, float turningRadius, float left, float right)
        {
            turningAngle.Reverse();

            OuterCurvedMove(turningPoint, turningAngle, turningRadius, left, right);

            //// turning point is outside the bot
            //if (turningRadius > Radius) 
            //{
            //    OuterCurvedMove(turningPoint, turningAngle, turningRadius, left, right);
            //}

            //// turning point is within the bot
            //else if (turningRadius < Radius)
            //{
            //    InnerCurvedMove(turningPoint, left, right);
            //}

            //// turning point is either on the left or right wheel
            //else
            //{
            //    Pivot(turningPoint, left, right);
            //}
        }

        private void OuterCurvedMove(PointF turningPoint, Angle turningAngle, float turningRadius, float left, float right)
        {
            var rotationFactor = GetRotationFactor(left, right);
            var greaterSpeed = (left > right ? left : right);

            // difference between turn base angle and turn end angle
            var curveAngle = GetAngleOfCurve(turningPoint, turningAngle, turningRadius + Radius, GetTravelDistance(greaterSpeed));
            
            var endAngle = new Angle(turningAngle.Degree + (curveAngle.Degree * rotationFactor));

            var endPoint = FindPointFrom(turningPoint, endAngle, turningRadius);

            Console.WriteLine("Ac -> " + curveAngle.Degree + " Ae -> " + endAngle.Degree);

            Angle.Degree = endAngle.Degree + (90 * rotationFactor);
            MoveCenter(endPoint);
        }

        private void InnerCurvedMove(PointF turningPoint, float left, float right)
        {

        }

        private void Pivot(PointF turningPointf, float left, float right)
        {

        }

        private int GetRotationFactor(float left, float right)
        {
            var absLeft = Math.Abs(left);
            var absRight = Math.Abs(right);

            if (absLeft < absRight)
            {
                if (left < right)
                {
                    return 1;
                }

                else
                {
                    return -1;
                }
            }

            else if (absLeft > absRight)
            {
                if (left < right)
                {
                    return 1;
                }

                else
                {
                    return -1;
                }
            }

            else
            {
                return 0;
            }
        }

        private float GetTravelDistance(float wheelSpeed)
        {
            return wheelSpeed * maxSpeed;
        }

        private Angle GetAngleOfCurve(PointF turningPoint, Angle turningBaseAngle, float turningRadius, float targetDistance)
        {
            var turningDiameter = turningRadius * 2;

            return new Angle((360 * targetDistance) / ((float)Math.PI * turningDiameter));
        }


        private void MoveCenter(PointF newCenter)
        {
            Anchor = new PointF(newCenter.X - Radius, newCenter.Y - Radius);

            Center = newCenter;

            boundaries.X = Anchor.X;
            boundaries.Y = Anchor.Y;
        }

        private void MoveCenter(float newX, float newY)
        {

        }


        public PointF Anchor { get; private set; }

        public PointF Center { get; private set; }

        public SizeF Size { get; private set; }

        public Angle Angle { get; private set; }
        

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


        private Pen boundaryPen;
        private Pen frontPen;

        private RectangleF boundaries;
    }
}
