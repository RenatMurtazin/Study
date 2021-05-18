using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWork2Task2
{
    class Line
    {
        public double x1;
        public double x2;
        public double y1;
        public double y2;
        public Line(double x1, double y1, double x2, double y2)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.y1 = y1;
            this.y2 = y2;
        }
    }
    class Program
    {
        static bool IntersectionOfPoints(Line line1, Line line2)
        {
            double A1 = (line1.y1 - line1.y2) / (line1.x1 - line1.x2);
            double A2 = (line2.y1 - line2.y2) / (line2.x1 - line2.x2);
            double b1 = line1.y1 - A1 * line1.x1;
            double b2 = line2.y1 - A2 * line2.x1;

            if (A1 == A2)
            {
                return false;
            }

            double Xa = (b2 - b1) / (A1 - A2);

            if ((Xa < Math.Max(line1.x1, line2.x1)) || (Xa > Math.Min(line1.x2, line2.x2)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        static bool IntersectionOfPoints1(Line line1, Line line2)
        {
            if (line1.x1 - line1.x2 == 0)
            {

                double Xa = line1.x1;
                double A2 = (line2.y1 - line2.y2) / (line2.x1 - line2.x2);
                double b2 = line2.y1 - A2 * line2.x1;
                double Ya = A2 * Xa + b2;

                if (line2.x1 <= Xa && line2.x2 >= Xa && Math.Min(line1.y1, line1.y2) <= Ya &&
                    Math.Max(line1.y1, line1.y2) >= Ya)
                {

                    return true;
                }

                return false;
            }
        }
        static bool IntersectionOfPoints2(Line line1, Line line2) 
        { 
        if (line2.x1 - line2.x2 == 0) 
        {
        double Xa = line2.x1;
        double A1 = (line1.y1 - line1.y2) / (line1.x1 - line1.x2);
        double b1 = line1.y1 - A1 * line1.x1;
        double Ya = A1 * Xa + b1;
        if (line1.x1 <= Xa && line1.x2 >= Xa && Math.Min(line2.y1, line2.y2) <= Ya &&
            Math.Max(line2.y1, line2.y2) >= Ya) 
        {
        return true;
        }
        return false;
        }
        }
        static void Main(string[] args)
        {
            Line line1 = new Line(5, 2, 3, 4);
            Line line2 = new Line(2, 4, 5, 6);
            IntersectionOfPoints(line1, line2);
            IntersectionOfPoints1(line1, line2);
            IntersectionOfPoints2(line1, line2);
            Console.ReadKey();
        }
    }
}
