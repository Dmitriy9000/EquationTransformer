using EquationTransformer.EquationProcessor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EquationTransformerTests.EquationProcessor
{
    [TestClass]
    public class SummandTests
    {
        [TestMethod]
        public void Summand_Ctor_1()
        {
            var summand = new Summand("3.5(xy)^2");
            Assert.AreEqual(3.5m, summand.Multiplier);
            Assert.AreEqual(true, summand.IsPositive);
            Assert.AreEqual("xy", summand.Variable);
            Assert.AreEqual(2, summand.Power);
        }

        [TestMethod]
        public void Summand_Ctor_2()
        {
            var summand = new Summand("(xy)^2");
            Assert.AreEqual(1, summand.Multiplier);
            Assert.AreEqual(true, summand.IsPositive);
            Assert.AreEqual("xy", summand.Variable);
            Assert.AreEqual(2, summand.Power);
        }

        [TestMethod]
        public void Summand_Ctor_3()
        {
            var summand = new Summand("0.5(xy)");
            Assert.AreEqual(0.5m, summand.Multiplier);
            Assert.AreEqual(true, summand.IsPositive);
            Assert.AreEqual("xy", summand.Variable);
            Assert.AreEqual(1, summand.Power);
        }

        [TestMethod]
        public void Summand_Ctor_4()
        {
            var summand = new Summand("3x^2");
            Assert.AreEqual(3, summand.Multiplier);
            Assert.AreEqual(true, summand.IsPositive);
            Assert.AreEqual("x", summand.Variable);
            Assert.AreEqual(2, summand.Power);
        }

        [TestMethod]
        public void Summand_Ctor_5()
        {
            var summand = new Summand("3.5x");
            Assert.AreEqual(3.5m, summand.Multiplier);
            Assert.AreEqual(true, summand.IsPositive);
            Assert.AreEqual("x", summand.Variable);
            Assert.AreEqual(1, summand.Power);
        }

        [TestMethod]
        public void Summand_Ctor_6()
        {
            var summand = new Summand("x^2");
            Assert.AreEqual(1, summand.Multiplier);
            Assert.AreEqual(true, summand.IsPositive);
            Assert.AreEqual("x", summand.Variable);
            Assert.AreEqual(2, summand.Power);
        }

        [TestMethod]
        public void Summand_Ctor_7()
        {
            var summand = new Summand("3.5xy");
            Assert.AreEqual(3.5m, summand.Multiplier);
            Assert.AreEqual(true, summand.IsPositive);
            Assert.AreEqual("xy", summand.Variable);
            Assert.AreEqual(1, summand.Power);
        }

        [TestMethod]
        public void Summand_Ctor_8()
        {
            var summand = new Summand("y");
            Assert.AreEqual(1, summand.Multiplier);
            Assert.AreEqual(true, summand.IsPositive);
            Assert.AreEqual("y", summand.Variable);
            Assert.AreEqual(1, summand.Power);
        }

        [TestMethod]
        public void Summand_Ctor_9()
        {
            var summand = new Summand("-3.5xy");
            Assert.AreEqual(3.5m, summand.Multiplier);
            Assert.AreEqual(false, summand.IsPositive);
            Assert.AreEqual("xy", summand.Variable);
            Assert.AreEqual(1, summand.Power);
        }

        [TestMethod]
        public void Summand_Ctor_10()
        {
            var summand = new Summand("+3.5xy");
            Assert.AreEqual(3.5m, summand.Multiplier);
            Assert.AreEqual(true, summand.IsPositive);
            Assert.AreEqual("xy", summand.Variable);
            Assert.AreEqual(1, summand.Power);
        }

        [TestMethod]
        public void Summand_Ctor_11()
        {
            var summand = new Summand("-2");
            Assert.AreEqual(2, summand.Multiplier);
            Assert.AreEqual(false, summand.IsPositive);
            Assert.AreEqual(string.Empty, summand.Variable);
            Assert.AreEqual(1, summand.Power);
        }

        [TestMethod]
        public void Summand_Ctor_12()
        {
            var summand = new Summand("-y");
            Assert.AreEqual(1, summand.Multiplier);
            Assert.AreEqual(false, summand.IsPositive);
            Assert.AreEqual("y", summand.Variable);
            Assert.AreEqual(1, summand.Power);
        }

        [TestMethod]
        public void Summand_Ctor_13()
        {
            var summand = new Summand("1.6123x");
            Assert.AreEqual(1.6123m, summand.Multiplier);
            Assert.AreEqual(true, summand.IsPositive);
            Assert.AreEqual("x", summand.Variable);
            Assert.AreEqual(1, summand.Power);
        }
    }
}
