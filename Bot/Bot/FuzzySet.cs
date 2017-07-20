using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot
{
    //Class holding the details of a FuzzySet
    class FuzzySet
    {
        //Linguistic Name
        private String name {get; set;}
        //Linguistic Index
        public int index { get; set; }
        //Number of points in the function
        private int n { get; set; }
        //Array of the x-point values
        private double[] x;
        //Array of the degree of membership of the x-point values
        private double[] y;

        public FuzzySet(){
            n = 0;
            x = null;
            y = null;
        }

       //Sets the values to a a fuzzy set
        public void Set(String name, int index, double x0, double y0, double x1, double y1,
            double x2, double y2, double x3, double y3)
        {
            //Temporary holders
            double[] tempX = new double[4];
            double[] tempY = new double[4];
            this.index = index;
            this.name = name;
            tempX[0] = x0;
            tempY[0] = y0;
            this.n = 1;

            if ((x1 != x0) || (y1 != y0))
            {
                tempX[n] = x1;
                tempY[n] = y1;
                ++n;
            }

            if ((x2 != x1) || (y2 != y1))
            {
                tempX[n] = x2;
                tempY[n] = y2;
                ++n;
            }

            if ((x3 != x2) || (y3 != y2))
            {
                tempX[n] = x3;
                tempY[n] = y3;
                ++n;
            }
         
            x = new double[n+1];
            y = new double[n+1];

            if (x == null)
            {
                n = 0;
                return;
            }
            Console.WriteLine("X >> " + x.Length);
            tempX.CopyTo(x, 0);
            tempY.CopyTo(y, 0);
            
        }

        //gets the level of membership of a point in this FuzzySet
        public double membership(double point)
        {
            int low, mid, high;
            double tempY;

            if (n == 0)
            {
                return 0;
            }

            if (point <= x[0])
                return y[0];

            if (point >= x[n - 1])
                return y[n - 1];

            low = 0;
            high = n - 1;

            for (; ; )
            {
                mid = (low + high) / 2;
                if (mid == low)
                    break;
                if (x[mid] < point)
                    low = mid;
                else
                    high = mid;
            }

            tempY = (point - x[high - 1]) / (x[high] - x[high - 1]) * (y[high] - y[high - 1]);
            return tempY + y[high - 1];
        }

        //Computes the area in a given point
        public double Area(double mf)
        {
            if (n == 0)
                return 0.0;
            else if (n == 2 && (y[0] == 0 || y[0] == 1))
                return 0.5 * mf * (x[1] - x[0]) * (2 - mf);
            else
                return 0.5 * mf * (x[2] - x[0]) * (2 - mf);
        }

        //Computes the centroid in a given point
        public double CenterOfArea(double mf)
        {
            if (mf == 0)
                return 0.0;
            if (n == 2 && x[0] == 0)
                return ((1 - mf + mf * mf / 3) * (x[1]) / (2 - mf));
            else if (n == 2)
                return (mf * (x[0] + 2.0 / 3 * mf * (x[1] - x[0])) + 2 * (1 - mf) * (x[0] + 0.5 * (x[1] - x[0]) * (1 + mf))) / (2 - mf);
            else
                return x[1];
        }


        //returns the name of the fuzzySet
        public String GetLinguistic()
        {
            return name;
        }

        public void Print()
        {
            Console.WriteLine("Lingustic: {0} \n N: {1}", name, n);

            Console.Write("X: [");
            foreach (double xx in x)
            {
                Console.Write(xx + ", ");
            }
            Console.WriteLine("]");

            Console.Write("Y: [");
            foreach (double yy in y)
            {
                Console.Write(yy + ", ");
            }
            Console.WriteLine("]");
        }
        
    }
}
