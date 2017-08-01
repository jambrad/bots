using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot
{
    class FuzzyEngineLeft
    {
        //constants
        private static int NUM_ANGLE_SET = 7;
        private static int NUM_DISTANCE_SET = 5;
        private static int NUM_SPEED_SET = 5;

        //Inference matrix
        public static int[][] SPEED_FAM;

        //FuzzySets
        private FuzzySet[] AngleSet;
        private FuzzySet[] DistanceSet;
        private FuzzySet[] SpeedSet;

        enum SPEED
        {
            VERY_SLOW,
            SLOW,
            AVERAGE,
            FAST,
            VERY_FAST
        }

        enum ANGLE
        {
            VERY_RIGHT,
            RIGHT,
            SLIGHTLY_RIGHT,
            FRONT,
            SLIGHTLY_LEFT,
            LEFT,
            VERY_LEFT
        }

        enum DISTANCE 
        {
            VERY_NEAR ,
            NEAR ,
            MEDIUM ,
            FAR ,
            VERY_FAR
        }

        public FuzzyEngineLeft()
        {
            Initialize();
        }

        private void Initialize()
        {
            InitializeFAM();
            InitializeFuzzySet();

            

        }

        //Initialize the fuzzy inference matrix
        private void InitializeFAM()
        {
            SPEED_FAM = new int[NUM_ANGLE_SET][];
            for (int i = 0; i < NUM_ANGLE_SET; i++ )
            {
                SPEED_FAM[i] = new int[NUM_DISTANCE_SET];
            }

            // VERY RIGHT row
            SPEED_FAM[(int)ANGLE.VERY_RIGHT][(int)DISTANCE.VERY_NEAR] = (int)SPEED.SLOW;
            SPEED_FAM[(int)ANGLE.VERY_RIGHT][(int)DISTANCE.NEAR] = (int)SPEED.AVERAGE;
            SPEED_FAM[(int)ANGLE.VERY_RIGHT][(int)DISTANCE.MEDIUM] = (int)SPEED.AVERAGE;
            SPEED_FAM[(int)ANGLE.VERY_RIGHT][(int)DISTANCE.FAR] = (int)SPEED.FAST;
            SPEED_FAM[(int)ANGLE.VERY_RIGHT][(int)DISTANCE.VERY_FAR] = (int)SPEED.VERY_FAST;

            // RIGHT row
            SPEED_FAM[(int)ANGLE.RIGHT][(int)DISTANCE.VERY_NEAR] = (int)SPEED.SLOW;
            SPEED_FAM[(int)ANGLE.RIGHT][(int)DISTANCE.NEAR] = (int)SPEED.AVERAGE;
            SPEED_FAM[(int)ANGLE.RIGHT][(int)DISTANCE.MEDIUM] = (int)SPEED.FAST;
            SPEED_FAM[(int)ANGLE.RIGHT][(int)DISTANCE.FAR] = (int)SPEED.FAST;
            SPEED_FAM[(int)ANGLE.RIGHT][(int)DISTANCE.VERY_FAR] = (int)SPEED.VERY_FAST;

            // SLIGHTLY RIGHT row
            SPEED_FAM[(int)ANGLE.SLIGHTLY_RIGHT][(int)DISTANCE.VERY_NEAR] = (int)SPEED.AVERAGE;
            SPEED_FAM[(int)ANGLE.SLIGHTLY_RIGHT][(int)DISTANCE.NEAR] = (int)SPEED.AVERAGE;
            SPEED_FAM[(int)ANGLE.SLIGHTLY_RIGHT][(int)DISTANCE.MEDIUM] = (int)SPEED.AVERAGE;
            SPEED_FAM[(int)ANGLE.SLIGHTLY_RIGHT][(int)DISTANCE.FAR] = (int)SPEED.FAST;
            SPEED_FAM[(int)ANGLE.SLIGHTLY_RIGHT][(int)DISTANCE.VERY_FAR] = (int)SPEED.VERY_FAST;

            // FRONT row
            SPEED_FAM[(int)ANGLE.FRONT][(int)DISTANCE.VERY_NEAR] = (int)SPEED.AVERAGE;
            SPEED_FAM[(int)ANGLE.FRONT][(int)DISTANCE.NEAR] = (int)SPEED.AVERAGE;
            SPEED_FAM[(int)ANGLE.FRONT][(int)DISTANCE.MEDIUM] = (int)SPEED.FAST;
            SPEED_FAM[(int)ANGLE.FRONT][(int)DISTANCE.FAR] = (int)SPEED.FAST;
            SPEED_FAM[(int)ANGLE.FRONT][(int)DISTANCE.VERY_FAR] = (int)SPEED.VERY_FAST;

            // SLIGHTLY LEFT row
            SPEED_FAM[(int)ANGLE.SLIGHTLY_LEFT][(int)DISTANCE.VERY_NEAR] = (int)SPEED.VERY_SLOW;
            SPEED_FAM[(int)ANGLE.SLIGHTLY_LEFT][(int)DISTANCE.NEAR] = (int)SPEED.SLOW;
            SPEED_FAM[(int)ANGLE.SLIGHTLY_LEFT][(int)DISTANCE.MEDIUM] = (int)SPEED.SLOW;
            SPEED_FAM[(int)ANGLE.SLIGHTLY_LEFT][(int)DISTANCE.FAR] = (int)SPEED.FAST;
            SPEED_FAM[(int)ANGLE.SLIGHTLY_LEFT][(int)DISTANCE.VERY_FAR] = (int)SPEED.FAST;

            // LEFT row
            SPEED_FAM[(int)ANGLE.LEFT][(int)DISTANCE.VERY_NEAR] = (int)SPEED.VERY_SLOW;
            SPEED_FAM[(int)ANGLE.LEFT][(int)DISTANCE.NEAR] = (int)SPEED.VERY_SLOW;
            SPEED_FAM[(int)ANGLE.LEFT][(int)DISTANCE.MEDIUM] = (int)SPEED.SLOW;
            SPEED_FAM[(int)ANGLE.LEFT][(int)DISTANCE.FAR] = (int)SPEED.FAST;
            SPEED_FAM[(int)ANGLE.LEFT][(int)DISTANCE.VERY_FAR] = (int)SPEED.AVERAGE;

            // VERY LEFT row
            SPEED_FAM[(int)ANGLE.VERY_LEFT][(int)DISTANCE.VERY_NEAR] = (int)SPEED.VERY_SLOW;
            SPEED_FAM[(int)ANGLE.VERY_LEFT][(int)DISTANCE.NEAR] = (int)SPEED.VERY_SLOW;
            SPEED_FAM[(int)ANGLE.VERY_LEFT][(int)DISTANCE.MEDIUM] = (int)SPEED.VERY_SLOW;
            SPEED_FAM[(int)ANGLE.VERY_LEFT][(int)DISTANCE.FAR] = (int)SPEED.FAST;
            SPEED_FAM[(int)ANGLE.VERY_LEFT][(int)DISTANCE.VERY_FAR] = (int)SPEED.FAST;
            
        }

        private void InitializeFuzzySet()
        {
            AngleSet = new FuzzySet[NUM_ANGLE_SET];
            DistanceSet = new FuzzySet[NUM_DISTANCE_SET];
            SpeedSet = new FuzzySet[NUM_SPEED_SET];

            for (int i = 0; i < NUM_ANGLE_SET; i++)
            {
                AngleSet[i] = new FuzzySet();
            }

            for (int i = 0; i < NUM_DISTANCE_SET; i++)
            {
                DistanceSet[i] = new FuzzySet();
            }

            for (int i = 0; i < NUM_SPEED_SET; i++)
            {
                SpeedSet[i] = new FuzzySet();
            }

            //Angle
            AngleSet[(int)ANGLE.VERY_RIGHT].Set("Very Right", 0, -180, 1, -120, 1, -120, 1, -93.5, 0);
            AngleSet[(int)ANGLE.RIGHT].Set("Right", 1, -110, 0, -90, 1, -90, 1, -70, 0);
            AngleSet[(int)ANGLE.SLIGHTLY_RIGHT].Set("Slightly Right", 2, -80.5, 0, -48.75, 1, -48.75, 1, -17, 0);
            AngleSet[(int)ANGLE.FRONT].Set("Front", 3, -20, 0, 0, 1, 0, 1, 20, 0);
            AngleSet[(int)ANGLE.SLIGHTLY_LEFT].Set("Slightly Left", 4, 16, 0, 48.75, 1, 48.75, 1, 81.2, 0);
            AngleSet[(int)ANGLE.LEFT].Set("Left", 5, 70, 0, 90, 1, 90, 1, 110, 0);
            AngleSet[(int)ANGLE.VERY_LEFT].Set("Very Left", 6, 88, 0, 130, 1, 150, 1, 180, 1);

            //Distance
            DistanceSet[(int)DISTANCE.VERY_NEAR].Set("Very Near", 0, 0, 1, 70, 1, 70, 1, 90, 0);
            DistanceSet[(int)DISTANCE.NEAR].Set("Near", 1, 80, 0, 196, 1, 196, 1, 312, 0);
            DistanceSet[(int)DISTANCE.MEDIUM].Set("Medium", 2, 240, 0, 380, 1, 380, 1, 400, 0);
            DistanceSet[(int)DISTANCE.FAR].Set("Far", 3, 390, 0, 445, 1, 445, 1, 500, 0);
            DistanceSet[(int)DISTANCE.VERY_FAR].Set("Very Far", 4, 470, 0, 624, 1, 700, 1, 780, 1);

            //Speed
            SpeedSet[(int)SPEED.VERY_SLOW].Set("Very Slow", 0, 0, 1, 0.1, 1, 0.1, 1, 0.2, 0);
            SpeedSet[(int)SPEED.SLOW].Set("Slow",1 , 0.15, 0, 0.275, 1, 0.275, 1, 0.4, 0);
            SpeedSet[(int)SPEED.AVERAGE].Set("Average", 2, 0.35, 0, 0.5, 1, 0.5, 1, 0.65, 0);
            SpeedSet[(int)SPEED.FAST].Set("Fast", 3, 0.6, 0, 0.725, 1, 0.725, 1, 0.85, 0);
            SpeedSet[(int)SPEED.VERY_FAST].Set("Very Fast", 4, 0.8, 0, 0.9, 1, 0.9, 1, 1, 1);   


        }


        public double getEngineOutput(double input_angle, double input_distance){
            int i,j;
	        double area,centroid,numerator=0,denominator=0,minimum=0.0;
            
            for(i = 0; i < NUM_ANGLE_SET; i++){
                for(j = 0; j < NUM_DISTANCE_SET; j++){
                    
                    minimum = Util.min(AngleSet[i].membership(input_angle), DistanceSet[j].membership(input_distance));

                    if (minimum != 0)
                    {
                        //Console.WriteLine("Angle: " + (ANGLE)i + "({0})" + "   Distance: " + (DISTANCE)j + "({1})", AngleSet[i].membership(input_angle), DistanceSet[j].membership(input_distance));
                        FuzzySet speed =  SpeedSet[SPEED_FAM[AngleSet[i].index][DistanceSet[j].index]];
                        
                        area = speed.Area(minimum);

                        centroid = speed.CenterOfArea(minimum);

                        numerator += (area * centroid);
                        denominator += area;
                    }
                }
            }

            if (denominator == 0.0)
                return 0.0;
            else
                return numerator / denominator;
        }
        
        
    }
}
