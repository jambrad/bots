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
            Anchor = new PointF(x - Radius, y - Radius);
            Center = new PointF(x, y);
            Angle = new Angle(90);

            // bot dimensions
            Size = new SizeF(LENGTH, LENGTH);
            Boundaries = new RectangleF(Anchor, Size);

            // bot pen
            boundaryPen = new Pen(Color.Black);
            frontPen = new Pen(Color.Red);
            turningPen = new Pen(Color.Blue);

            maxSpeed = MAX_DISTANCE_PER_SECOND * (interval / 1000f);
        }

        // default constructor
        public Bot(int interval) : this(0f, 0f, interval) { }
        

        // draw the object
        public void Draw(PaintEventArgs e)
        {
            e.Graphics.DrawEllipse(boundaryPen, Boundaries);

            var frontPoint = FindPointFromCenter(Angle, Radius);
            var frontLine = new PointF[] { frontPoint, Center };
            var turningLine = new PointF[] { recentTurningPoint, Center };

            e.Graphics.DrawLines(frontPen, frontLine);
            e.Graphics.DrawLines(turningPen, turningLine);
        }

        // update location and direction of the bot
        public void Move(float left, float right)
        {
            if (Math.Abs(left) == Math.Abs(right))
            {
                if (left == right)
                {
                    // passing left or right doesn't matter
                    // they're both equal in speed
                    StraightMove(left);
                }

                else
                {
                    var rotationFactor = GetPrimaryRotationFactor(left, right);

                    // passing left or right doesn't matter
                    // they're both equal in speed
                    TwistMove(Math.Abs(left), rotationFactor);
                }
            }

            else
            {
                var turningAngle = TurningPointAngle(left, right);
                var turningRadius = TurningPointDistance(left, right);
                var turningPoint = FindPointFromCenter(turningAngle, turningRadius);

                recentTurningPoint = turningPoint;

                CurvedMove(turningPoint, turningAngle, turningRadius, left, right);
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
            var absLeft = Math.Abs(left);
            var absRight = Math.Abs(right);

            var faster = (absLeft > absRight ? left : right);
            var slower = (absLeft < absRight ? left : right);

            return Math.Abs(Radius * (faster / (faster - slower)));
        }

        private void StraightMove(float speed)
        {
            var distance = GetTravelDistance(speed);

            var newCenter = FindPointFromCenter(Angle, distance);

            MoveCenter(newCenter);
        }

        private void TwistMove(float speed, int rotationFactor)
        {
            var curveAngle = GetAngleOfCurve(Center, Angle, Radius, GetTravelDistance(speed));

            var endAngle = new Angle(Angle.Degree + (curveAngle.Degree * rotationFactor));

            Angle = endAngle;
        }

        private void CurvedMove(PointF turningPoint, Angle turningAngle, float turningRadius, float left, float right)
        {
            //if (!GetTertiaryRotationFactor(left, right))
                turningAngle.Reverse();

            var absLeft = Math.Abs(left);
            var absRight = Math.Abs(right);

            var primaryRotationFactor = GetPrimaryRotationFactor(left, right);
            var secondaryRotationFactor = GetSecondaryRotationFactor(left, right);
            var greaterSpeed = (absLeft > absRight ? absLeft : absRight);

            // difference between turn base angle and turn end angle
            var curveAngle = GetAngleOfCurve(turningPoint, turningAngle, turningRadius + Radius, GetTravelDistance(greaterSpeed));

            var endAngle = new Angle(turningAngle.Degree + (curveAngle.Degree * primaryRotationFactor));

            var endPoint = FindPointFrom(turningPoint, endAngle, turningRadius);

            Angle.Degree = endAngle.Degree + (90 * primaryRotationFactor * secondaryRotationFactor);
            MoveCenter(endPoint);
        }

        private int GetPrimaryRotationFactor(float left, float right)
        {
            if (left == right)
            {
                return 0;
            }

            else
            {
                return (left < right ? 1 : -1);
            }
        }

        private int GetSecondaryRotationFactor(float left, float right)
        {
            if (left < 0 || right < 0)
            {
                return -1;
            }

            else
            {
                return 1;
            }
        }

        //private bool GetTertiaryRotationFactor(float left, float right)
        //{
        //    if (Math.Sign(left) != Math.Sign(right) && left != 0 && right != 0)
        //    {
        //        var absLeft = Math.Abs(left);
        //        var absRight = Math.Abs(right);

        //        var greater = (absLeft > absRight ? left : right);
        //        var lesser = (absLeft < absRight ? left : right);
        //    }

        //    else
        //    {
        //        return false;
        //    }
        //}

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
        private Pen turningPen;

        private RectangleF boundaries;
        private PointF recentTurningPoint;
    }
}
