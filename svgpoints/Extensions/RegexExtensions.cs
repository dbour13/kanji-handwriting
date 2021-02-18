using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace svgpoints.Extensions
{
    public static class RegexExtensions
    {
        public static IEnumerable<Match> GetMatches(this Match match)
        {
            var matchHold = match;

            while (matchHold.Success)
            {
                yield return matchHold;
                matchHold = matchHold.NextMatch();
            }
        }
    }
}
