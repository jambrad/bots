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
            double[] tempX;
            double[] tempY;

            this.name = name;

            
        }
        
    }
}
