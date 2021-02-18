using System;
using System.Collections.Generic;
using System.Text;

namespace svgpoints
{
    internal enum SVGCommandType { M, m, L, l, C, c, Q, q, Z, z };
    internal class SVGCommand
    {
        internal SVGCommandType SVGCommandType { get; set; }
        internal IEnumerable<double> XYParams { get; set; }
    }
}
