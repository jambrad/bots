using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot
{
    class FuzzyEngine
    {
        private FuzzyEngineLeft leftEngine;
        private FuzzyEngineRight rightEngine;

        public FuzzyEngine()
        {
            leftEngine = new FuzzyEngineLeft();
            rightEngine = new FuzzyEngineRight();
        }

        public float LeftSpeed(double angle, double distance)
        {
            return ((float)leftEngine.getEngineOutput(angle, distance));
        }

        public float RightSpeed(double angle, double distance)
        {
            return ((float)rightEngine.getEngineOutput(angle,distance));
        }
    }
}
