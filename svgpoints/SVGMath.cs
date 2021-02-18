using System;
using System.Collections.Generic;
using System.Text;

namespace svgpoints
{
    internal static class SVGMath
    {
        internal static double CalculateCubicBeizerSinglePoint(double xy0, double xy1, double xy2, double xy3, double t)
        {
            return Math.Pow(1 - t, 3) * xy0
                   + 3 * Math.Pow(1 - t, 2) * t * xy1
                   + 3 * (1 - t) * Math.Pow(t, 2) * xy2
                   + Math.Pow(t, 3) * xy3;
        }

        internal static IEnumerable<Point> CalculateCubicBeizer(Point p0, Point p1, Point p2, Point p3, int numPoints)
        {
            for (int i = 1; i < numPoints; i++)
            {
                double t = (double)i / (double)numPoints;
                yield return new Point(CalculateCubicBeizerSinglePoint(p0.X, p1.X, p2.X, p3.X, t),
                                       CalculateCubicBeizerSinglePoint(p0.Y, p1.Y, p2.Y, p3.Y, t));
            }
        }
    }
}
