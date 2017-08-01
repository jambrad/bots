using System;
using System.Drawing;
using System.Windows.Forms;

namespace Robot
{
    class Robot
    {

        private readonly float maxSpeed;
        private const float max_distance = 300f; 
        private const float turn_rate = 10f;
        private readonly float cornerDistance;
        public PointF[] cornerPoints;
        public readonly float len = 45f;

        private FuzzyEngine engine;
        private float leftSpeed;
        private float rightSpeed;
        private float x;
        private float y;

        
        
        
        public Robot(float x, float y, int intervals)
        {
            engine = new FuzzyEngine();
            anchor = new PointF(x - rad, y - rad);
            center = new PointF(x, y);
            angle = new Angle(90);
            front = new PointF(x + rad, y + rad);

            this.x = x;
            this.y = y;
            
            size = new SizeF(len, len);

            leftSpeed = 0;
            rightSpeed = 0;

            
            edgePen = new Pen(Color.Blue,3);
            driverPen = new Pen(Color.Black);
            turnPen = new Pen(Color.White);

            pastTurningPoint = center;

            maxSpeed = max_distance * (intervals / 1000f);
            cornerDistance = (float)Math.Sqrt((Math.Pow(size.Width / 2, 2) + Math.Pow(size.Height / 2, 2)));
        }

        
        public Robot(int interval) : this(0f, 0f, interval) { }
        

        
        public void draw(PaintEventArgs e)
        {
            drawBound(e);

            var frontPoint = pointFromCenter(angle, rad);
            var frontLine = new PointF[] { frontPoint, center };
            var turningLine = new PointF[] { pastTurningPoint, center };

            e.Graphics.DrawLines(driverPen, frontLine);
            //e.Graphics.DrawLines(turnPen, turningLine);
        }

        public void drawBound(PaintEventArgs e)
        {
            var cornerAngle = new Angle(angle.Degree + 45);

           cornerPoints = new PointF[5];

            cornerPoints[0] = pointFromCenter(cornerAngle, cornerDistance);
           

            for (int i = 1; i < 5; i++)
            {
                cornerAngle = new Angle(cornerAngle.Degree - 90);

                cornerPoints[i] = pointFromCenter(cornerAngle, cornerDistance);
                
            }
           
            e.Graphics.DrawLines(edgePen, cornerPoints);
            
        }

        public void moveRobot(double angle, double distance)
        {
            leftSpeed = engine.LeftSpeed(angle, distance);
            rightSpeed =  engine.RightSpeed(angle, distance);
            //Console.WriteLine("Left: " + left + "    Right: " + right);

            moveRobot(leftSpeed,rightSpeed);
        }

        public void moveRobotToPoint(float destX, float destY)
        {
            double angle = getFinalAngleToPoint(destX, destY);
            double distance = getDistance(destX, destY);

            moveRobot(angle, distance);
        }

        public PointF[] getFrontPoints()
        {
            return new PointF[] { cornerPoints[1], cornerPoints[4] };
        }

        public bool isFrontingBall()
        {
            return (rightSpeed == leftSpeed);
        }

        //Temporary
        public float getMaxSpeed()
        {
            return Math.Max(leftSpeed, rightSpeed);
        }

        public double getDistance(float X, float Y)
        {
            float tempX, tempY;
            double result;
            tempX = (float)Math.Pow((X - center.X), 2);
            tempY = (float)Math.Pow((Y - center.Y), 2);
            result = Math.Sqrt(tempX + tempY);

            return result;
        }

        private double getRelativeAngle(float destX, float destY)
        {
            if (center.X == destX)
            {
                if (center.Y > destY)
                {
                    return 270;
                }
                else if (center.Y < destY)
                {
                    return 90;
                }
            }

            var orientation = (double)(center.X < destX ? 0 : 180);

            var deltaX = getDeltaX(center.X, destX);
            var deltaY = getDeltaY(center.Y, destY);

            var angle = Math.Atan(deltaY / deltaX);

            var result = (angle * 180 / Math.PI);
            //Console.Write("result: {0} >>> ", result);
            result = (orientation - result);


            return result;
        }

        private double getFinalAngleToPoint(float destX, float destY)
        {
            var ra = getRelativeAngle(destX,destY);
            //Console.Write("Relative: {0}   Bot:  {1}  ", ra, myBot.angle.Degree);

            var fa = -(angle.Degree - ra);
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

        private float getDeltaY(float p, float Y)
        {
            return p - Y;
        }

        private float getDeltaX(float p, float X)
        {
            return p - X;
        }

      

        public void moveRobot(float left, float right)
        {
            if (Math.Abs(left) == Math.Abs(right))
            {
                if (left == right)
                {
                    pastTurningPoint = center;

                    
                    moveStraight(left);
                }

                else
                {
                    var rotationFactor = primaryRotation(left, right);

                    pastTurningPoint = center;

                    
                    moveAround(Math.Abs(left), rotationFactor);
                }
            }

            else
            {
                var turningAngle = turningPAngle(left, right);
                var turningRadius = turningPDistance(left, right);
                var turningPoint = pointFromCenter(turningAngle, turningRadius);

                pastTurningPoint = turningPoint;

                moveTurn(turningPoint, turningAngle, turningRadius, left, right);
            }
        }


        private PointF pointFromCenter(Angle angle, float distance)
        {
            return pointFrom(center, angle, distance);
        }

        private PointF pointFrom(PointF basePoint, Angle angle, float distance)
        {
            float x = (float)(Math.Cos(angle.Radian) * distance);
            float y = (float)(Math.Sin(angle.Radian) * distance);

            x = basePoint.X + x;
            y = basePoint.Y - y;

            return new PointF(x, y);
        }

        private Angle turningPAngle(float left, float right)
        {
            return new Angle(angle.Degree + (Math.Abs(left) < Math.Abs(right) ? 90 : -90));
        }

        private float turningPDistance(float left, float right)
        {
            var absLeft = Math.Abs(left);
            var absRight = Math.Abs(right);

            if (Math.Sign(left) == Math.Sign(right) || left == 0 || right == 0)
            {
                var faster = (absLeft > absRight ? left : right);
                var slower = (absLeft < absRight ? left : right);

                return Math.Abs(rad * (faster / (faster - slower)));
            }

            else
            {
                var faster = (absLeft > absRight ? absLeft : absRight);
                var slower = (absLeft < absRight ? absLeft : absRight);

                return Math.Abs(rad * ((faster - slower) / faster));
            }
        }

        private void moveStraight(float speed)
        {
            var distance = travelDistance(speed);

            var newCenter = pointFromCenter(angle, distance);

            moveCenter(newCenter);
        }

        private void moveAround(float speed, int rotationFactor)
        {
            var curveAngle2 = curveAngle(center, angle, rad, travelDistance(speed));

            var endAngle = new Angle(angle.Degree + (curveAngle2.Degree * rotationFactor));

            angle = endAngle;
        }

        private void moveTurn(PointF turningPoint, Angle turningAngle, float turningRadius, float left, float right)
        {
            turningAngle.Reverse();

            var absLeft = Math.Abs(left);
            var absRight = Math.Abs(right);

            var primaryRotationFactor = primaryRotation(left, right);
            var secondaryRotationFactor = secondaryRotation(left, right);
            var tertiaryRotationFactor = tertiaryRotation(left, right);
            var greaterSpeed = (absLeft > absRight ? absLeft : absRight);

            
            var curveAngle2 = curveAngle(turningPoint, turningAngle, turningRadius + rad, travelDistance(greaterSpeed));

            var endAngle = new Angle(turningAngle.Degree + (curveAngle2.Degree * primaryRotationFactor));

            var endPoint = pointFrom(turningPoint, endAngle, turningRadius);

            angle.Degree = endAngle.Degree + (90 * primaryRotationFactor * secondaryRotationFactor) + tertiaryRotationFactor;
            moveCenter(endPoint);
        }

        private int primaryRotation(float left, float right)
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

        private int secondaryRotation(float left, float right)
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

        private int tertiaryRotation(float left, float right)
        {
            if (Math.Sign(left) != Math.Sign(right) && left != 0 && right != 0)
            {
                var absLeft = Math.Abs(left);
                var absRight = Math.Abs(right);

                var greater = (absLeft > absRight ? left : right);
                var lesser = (absLeft < absRight ? left : right);

                if (greater > 0)
                {
                    return 180;
                }

                else
                {
                    return 0;
                }
            }

            else
            {
                return 0;
            }
        }

        private float travelDistance(float wheelSpeed)
        {
            return wheelSpeed * maxSpeed;
        }

        private Angle curveAngle(PointF turningPoint, Angle turningBaseAngle, float turningRadius, float targetDistance)
        {
            var turningDiameter = turningRadius * 2;

            return new Angle((360 * targetDistance) / ((float)Math.PI * turningDiameter));
        }


        private void moveCenter(PointF newCenter)
        {
            anchor = new PointF(newCenter.X - rad, newCenter.Y - rad);
            front = pointFromCenter(angle, rad);
            center = newCenter;
        }


        public PointF anchor { get; private set; }

        public PointF center { get; private set; }

        public PointF front { get; private set; }

        public SizeF size { get; private set; }

        public Angle angle { get; private set; }
        

        public float rad
        {
            get
            {
                return len / 2;
            }
        }

        public float diameter
        {
            get
            {
                return len;
            }
        }

        public float Y
        {
            get { return y; }
            set { y = value; }
        }
        public float X
        {
            get { return x; }
            set { x = value; }
        }

        private Pen edgePen;
        private Pen driverPen;
        private Pen turnPen;
        
        private PointF pastTurningPoint;
    }
}
