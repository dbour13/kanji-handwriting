using svgpoints.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace svgpoints
{
    public static class SvgPoints
    {
        public static IEnumerable<Point> GetPointsFromSVGPathsString(string svgPathsString)
        {
            List<Point> points = new List<Point>();
            var svgPaths = GetSVGCommandsFromSVGPathsString(svgPathsString);
            Point currentPoint = new Point(0, 0);

            foreach (var command in svgPaths)
            {
                switch (command.SVGCommandType)
                {
                    case SVGCommandType.M:
                        currentPoint = new Point(command.XYParams.FirstOrDefault(),
                                                 command.XYParams.Skip(1).FirstOrDefault());
                        points.Add(currentPoint);
                        break;
                    case SVGCommandType.c:
                    case SVGCommandType.C:
                        double dX = (command.SVGCommandType == SVGCommandType.c) ? currentPoint.X : 0;
                        double dY = (command.SVGCommandType == SVGCommandType.c) ? currentPoint.Y : 0;

                        Point p0 = currentPoint;
                        Point p1 = new Point(dX + command.XYParams.FirstOrDefault(),
                                             dY + command.XYParams.Skip(1).FirstOrDefault());
                        Point p2 = new Point(dX + command.XYParams.Skip(2).FirstOrDefault(),
                                             dY + command.XYParams.Skip(3).FirstOrDefault());
                        Point p3 = new Point(dX + command.XYParams.Skip(4).FirstOrDefault(),
                                             dY + command.XYParams.Skip(5).FirstOrDefault());

                        currentPoint = p3;
                        points.AddRange(SVGMath.CalculateCubicBeizer(p0, p1, p2, p3, 100));
                        break;
                }
            }

            return points;
        }

        private static IEnumerable<SVGCommand> GetSVGCommandsFromSVGPathsString(string svgPathsString)
        {
            return Regex.Match(svgPathsString, "([a-zA-Z])([0-9|\\.|\\,|\\-]+)")
                        .GetMatches()
                        .Select(m => new SVGCommand()
                        {
                            SVGCommandType = (SVGCommandType)Enum.Parse(typeof(SVGCommandType), m.Groups[1].Value),
                            XYParams = Regex.Match(m.Groups[2].Value, "\\-?[0-9\\.]+")
                                            .GetMatches()
                                            .Select(p => Double.Parse(p.Value))
                        });
        }       
    }
}
