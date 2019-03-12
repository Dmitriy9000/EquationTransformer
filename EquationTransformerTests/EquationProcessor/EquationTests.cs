using EquationTransformer.EquationProcessor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EquationTransformerTests.EquationProcessor
{
    [TestClass]
    public class EquationTests
    {
        [TestMethod]
        public void Equation_ToString_1()
        {
            var equation = new Equation("x^2 + 3.5xy + y = y^2 - xy + y");
            Assert.AreEqual("x^2 + 3.5xy + y = y^2 - xy + y", equation.ToString());
        }

        [TestMethod]
        public void Equation_ToString_2()
        {
            var equation = new Equation("- y = + xy - 2");
            Assert.AreEqual(" -y = xy - 2", equation.ToString());
        }

        [TestMethod]
        public void Equation_ToString_3()
        {
            var equation = new Equation("x^20 + 3.5(xy)^54 + 1 = y^2 - xy + (y)^-1");
            Assert.AreEqual("3.5(xy)^54 + x^20 + 1 = y^2 - xy + y^-1", equation.ToString());
        }
    }
}
