using System;
using Xunit;
using kanji.handwritting.common;

namespace kanji.handwritting.common.tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string s = "ç°";

            string a = ((int)s[0]).ToString("X5");

            Class1 c = new Class1();
        }
    }
}
