using System;
using System.Collections.Generic;
using System.Text;

namespace LinearRegression
{
    class Point
    {
        public static List<Point> pointList = new List<Point>();

        public string Name { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        // Calculation methods for single sumation variables.
        public static double sumX()
        {
            double sum = 0.0;
            foreach(Point item in pointList)
            {
                sum += item.X;
            }
            return sum;
        }
        public static double sumXSqr()
        {
            double sum = 0.0;
            foreach (Point item in pointList)
            {
                sum += (item.X * item.X);
            }
            return sum;
        }

        public static double sumY()
        {
            double sum = 0.0;
            foreach (Point item in pointList)
            {
                sum += item.Y;
            }
            return sum;
        }
        public static double sumXY()
        {
            double sum = 0.0;
            foreach (Point item in pointList)
            {
                sum += (item.X * item.Y);
            }
            return sum;
        }

        public static int getN()
        {
            int N = pointList.Count;
            return N;
        }

        // Torn between this format and the one used in getBeta, this is easier to read so some
        // but getBeta is more efficient.
        public static double getAlpha()
        {
            double alpha = 0.0;
            double sX = sumX();
            double sXS = sumXSqr();
            double sY = sumY();
            double sXY = sumXY();
            double N = getN();

            alpha = (sY * sXS - sX * sXY) / (N * sXS - Math.Pow(sX,2));

            return alpha;
        }

        public static double getBeta()
        {
            double beta = 0.0;
            beta = (getN() * sumXY() - sumX() * sumY()) 
                 / (getN() * sumXSqr() - (Math.Pow(sumX(), 2)));
            return beta;
        }

        public static void getFormula()
        {
            double A = getAlpha();
            double B = getBeta();
            Console.WriteLine($"Y = {A} + {B} * X");
        }

        // The calling method. Starts the calling of the all the other functions needed to perform linear regression.
        
        public static void doFormula()
        {
            Console.WriteLine("The forumula for the inputed data is:");
            getFormula();
            Console.WriteLine("Please enter a value for X as a predictor:");
            double pred = double.Parse(Console.ReadLine());
            double A = getAlpha();
            double B = getBeta();
            double result = pred * B + A;
            result = Math.Round(result, 2);
            Console.WriteLine($"For X of {pred} Y is {result}.");
        }

        // Any points the user creates are added to the list for use in the calculation methods.
        public Point() 
        {
            this.Name = "Unknown";
            this.X = 0.0;
            this.Y = 0.0;
            pointList.Add(this);
        }
        public Point(string inName = "Unknown", double inX = 0, double inY = 0) 
        {
            this.Name = inName;
            this.X = inX;
            this.Y = inY;
            pointList.Add(this);
        }
        public Point(string inName = "Unknown", int inX = 0, int inY = 0) 
        {
            this.Name = inName;
            this.X = inX;
            this.Y = inY;
            pointList.Add(this);
        }
    }
}
