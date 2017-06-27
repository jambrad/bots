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
        private const float TURN_RATE = 1f;
        

        public Bot(float x, float y)
        {
            Anchor = new PointF(x - (LENGTH / 2), y - (LENGTH / 2));

            Center = new PointF(x, y);

            Size = new SizeF(LENGTH, LENGTH);

            Boundaries = new RectangleF(Anchor, Size);

            Angle = 0f;
        }

        public Bot() : this(0f, 0f) { }


        private void MoveCenter(float speed)
        {
            float deltaX = (float)(Math.Cos(RelativeRad) * speed);
            float deltaY = (float)(Math.Sin(RelativeRad) * speed);

            //Console.WriteLine("1 - a " + Angle + " - ra " + RelativeAngle + " - dX " + deltaX + " - dY " + deltaY);

            deltaX *= TransformX(deltaX);
            deltaY *= TransformY(deltaY);

            //Console.WriteLine("2 - a " + Angle + " - ra " + RelativeAngle + " - dX " + deltaX + " - dY " + deltaY);

            Anchor = new PointF(Anchor.X + deltaX, Anchor.Y - deltaY);
            Center = new PointF(Center.X + deltaX, Center.Y - deltaY);

            boundaries.Location = Anchor;
        }

        private void Turn(float turnAngle)
        {
            Angle = Angle + turnAngle;

            if (Angle > 180)
            {
                var offsetAngle = Angle - 180;

                Angle = -180 + offsetAngle;
            }

            else if (Angle < -180)
            {
                var offsetAngle = -180 - Angle;

                Angle = 180 - offsetAngle;
            }
        }

        public void Move(float speedFactor, float turnFactor)
        {
            Turn(turnFactor * TURN_RATE);
            MoveCenter(speedFactor * MAX_SPEED);
        }


        private float TransformX(float x)
        {
            if (Angle < 0 && Angle != -180)
            {
                return x * -1;
            }

            else if (Angle > 0 && Angle != 180)
            {
                return x;
            }

            else
            {
                return 0f;
            }
        }

        private float TransformY(float y)
        {
            if (Angle < 90 && Angle > -90)
            {
                return y;
            }

            else if ((Angle < -90 || Angle > 90) && (Math.Abs(Angle) != 180))
            {
                return y * -1;
            }

            else
            {
                return 0f;
            }
        }


        public PointF Anchor { get; private set; }

        public PointF Center { get; private set; }

        public SizeF Size { get; private set; }

        public float Angle { get; private set; }

        public float RelativeAngle
        {
            get
            {
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
        }

        public float RelativeRad
        {
            get
            {
                //return (float)(RelativeAngle / (Math.PI * 2));
                return RelativeAngle * 0.0174533f;
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


        private RectangleF boundaries;
    }
}
