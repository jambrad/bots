using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot
{
    //Class holding the details of a FuzzySet
    class FuzzySet
    {
        //Linguistic Name
        private String name {get; set;}
        //Linguistic Index
        private int index { get; set; }
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

            x = new double[n];
            y = new double[n];

            if (x == null)
            {
                n = 0;
                return;
            }

            tempX.CopyTo(x, 0);
            tempY.CopyTo(y, 0);
            
        }

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
    }
}
