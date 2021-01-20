using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimeNumber;
using System;
using System.IO;
using System.Text;
using FluentAssertions;

namespace PrimeTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IOTest()
        {
            TextWriter tmp = Console.Out;
            String readIn = "5\n7\n4\n31\n96\n-1\nFish";
            StringBuilder writeOut = new StringBuilder();
            Console.SetIn(new StringReader(readIn));
            Console.SetOut(new StringWriter(writeOut));
            Program.Main(null);
            String expected = "The number five is Prime."
                + Environment.NewLine + "The number seven is Prime."
                + Environment.NewLine+ "The number four is not Prime."
                + Environment.NewLine+ "The number thirty-one is Prime." 
                + Environment.NewLine + "The number ninety-six is not Prime."
                + Environment.NewLine + "Parameter 'num' cannot be less than 0";
            Console.SetOut(tmp);
            expected.Should().Be(writeOut.ToString().Trim());
            
        }

        [TestMethod]
        public void TestIsPrime()
        {
            Assert.IsTrue(Program.isPrime(5));
            Assert.IsFalse(Program.isPrime(1));
            Assert.IsFalse(Program.isPrime(4));
            String except = "";
            try
            {
                Program.isPrime(-1);
            }
            catch (Exception e)
            {
                except = e.Message.Trim();
            }
            Assert.AreEqual("Parameter 'num' cannot be less than 0", except);
        }
    }
}
