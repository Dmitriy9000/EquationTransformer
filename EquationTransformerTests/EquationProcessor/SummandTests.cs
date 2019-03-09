using EquationTransformer.EquationProcessor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EquationTransformerTests.EquationProcessor
{
    [TestClass]
    public class SummandTests
    {
        [TestMethod]
        public void SummandParse1()
        {
            var summand = new Summand("3.5(xy)^2");
            Assert.AreEqual(3.5, summand.Multiplier);
            Assert.AreEqual(true, summand.IsPositive);
            Assert.AreEqual("xy", summand.Variable);
            Assert.AreEqual(2, summand.Power);
        }

        [TestMethod]
        public void SummandParse2()
        {
            var summand = new Summand("(xy)^2");
            Assert.AreEqual(1, summand.Multiplier);
            Assert.AreEqual(true, summand.IsPositive);
            Assert.AreEqual("xy", summand.Variable);
            Assert.AreEqual(2, summand.Power);
        }

        [TestMethod]
        public void SummandParse3()
        {
            var summand = new Summand("0.5(xy)");
            Assert.AreEqual(0.5, summand.Multiplier);
            Assert.AreEqual(true, summand.IsPositive);
            Assert.AreEqual("xy", summand.Variable);
            Assert.AreEqual(1, summand.Power);
        }

        [TestMethod]
        public void SummandParse4()
        {
            var summand = new Summand("3x^2");
            Assert.AreEqual(3, summand.Multiplier);
            Assert.AreEqual(true, summand.IsPositive);
            Assert.AreEqual("x", summand.Variable);
            Assert.AreEqual(2, summand.Power);
        }

        [TestMethod]
        public void SummandParse5()
        {
            var summand = new Summand("3.5x");
            Assert.AreEqual(3.5, summand.Multiplier);
            Assert.AreEqual(true, summand.IsPositive);
            Assert.AreEqual("x", summand.Variable);
            Assert.AreEqual(1, summand.Power);
        }

        [TestMethod]
        public void SummandParse6()
        {
            var summand = new Summand("x^2");
            Assert.AreEqual(1, summand.Multiplier);
            Assert.AreEqual(true, summand.IsPositive);
            Assert.AreEqual("x", summand.Variable);
            Assert.AreEqual(2, summand.Power);
        }

        [TestMethod]
        public void SummandParse7()
        {
            var summand = new Summand("3.5xy");
            Assert.AreEqual(3.5, summand.Multiplier);
            Assert.AreEqual(true, summand.IsPositive);
            Assert.AreEqual("xy", summand.Variable);
            Assert.AreEqual(1, summand.Power);
        }

        [TestMethod]
        public void SummandParse8()
        {
            var summand = new Summand("y");
            Assert.AreEqual(1, summand.Multiplier);
            Assert.AreEqual(true, summand.IsPositive);
            Assert.AreEqual("y", summand.Variable);
            Assert.AreEqual(1, summand.Power);
        }

        [TestMethod]
        public void SummandParse9()
        {
            var summand = new Summand("-3.5xy");
            Assert.AreEqual(3.5, summand.Multiplier);
            Assert.AreEqual(false, summand.IsPositive);
            Assert.AreEqual("xy", summand.Variable);
            Assert.AreEqual(1, summand.Power);
        }

        [TestMethod]
        public void SummandParse10()
        {
            var summand = new Summand("+3.5xy");
            Assert.AreEqual(3.5, summand.Multiplier);
            Assert.AreEqual(true, summand.IsPositive);
            Assert.AreEqual("xy", summand.Variable);
            Assert.AreEqual(1, summand.Power);
        }

        [TestMethod]
        public void SummandParse11()
        {
            var summand = new Summand("-2");
            Assert.AreEqual(2, summand.Multiplier);
            Assert.AreEqual(false, summand.IsPositive);
            Assert.AreEqual(string.Empty, summand.Variable);
            Assert.AreEqual(1, summand.Power);
        }

        [TestMethod]
        public void SummandParse12()
        {
            var summand = new Summand("-y");
            Assert.AreEqual(1, summand.Multiplier);
            Assert.AreEqual(false, summand.IsPositive);
            Assert.AreEqual("y", summand.Variable);
            Assert.AreEqual(1, summand.Power);
        }
    }
}
