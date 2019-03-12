using EquationTransformer.EquationProcessor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EquationTransformerTests.EquationProcessor
{
    [TestClass]
    public class EquationTransformerTests
    {
        EquationTransformer.EquationProcessor.EquationTransformer _sut;

        [TestInitialize]
        public void Init()
        {
            _sut = new EquationTransformer.EquationProcessor.EquationTransformer();
        }

        [TestMethod]
        public void EquationTransformer_Transform_1()
        {
            var equation = new Equation("x^2 + 3.5xy + y = y^2 - xy + y");
            var result = _sut.Tranform(equation);
            Assert.AreEqual("x^2 - y^2 + 4.5xy = 0", result.ToString());
        }

        [TestMethod]
        public void EquationTransformer_Transform_2()
        {
            var equation = new Equation(" + 3.5xy + y = y^2 - xy + y - x^2");
            var result = _sut.Tranform(equation);
            Assert.AreEqual(" -y^2 + x^2 + 4.5xy = 0", result.ToString());
        }

        [TestMethod]
        public void EquationTransformer_Transform_3()
        {
            var equation = new Equation("0 = y^2 - xy + y - y - 3.5xy - x^2");
            var result = _sut.Tranform(equation);
            Assert.AreEqual(" -y^2 + x^2 + 4.5xy = 0", result.ToString());
        }

        [TestMethod]
        public void EquationTransformer_Transform_4()
        {
            var equation = new Equation("y = y");
            var result = _sut.Tranform(equation);
            Assert.AreEqual("0 = 0", result.ToString());
        }

        [TestMethod]
        public void EquationTransformer_Transform_5()
        {
            var equation = new Equation("0 = x^3 + x^2 + y^654 + y^654 + 2(xyz)^3 - 2(xyz)^3");
            var result = _sut.Tranform(equation);
            Assert.AreEqual(" -2y^654 - x^3 - x^2 = 0", result.ToString());
        }

        [TestMethod]
        public void EquationTransformer_Transform_6()
        {
            var equation = new Equation("x^2 + 4x + 5 = 0");
            var result = _sut.Tranform(equation);
            Assert.AreEqual("x^2 + 4x + 5 = 0", result.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(EquationException))]
        public void EquationTransformer_Transform_PoorFormat_1()
        {
            var equation = new Equation("++x = 1");
        }

        [TestMethod]
        [ExpectedException(typeof(EquationException))]
        public void EquationTransformer_Transform_PoorFormat_2()
        {
            var equation = new Equation("0 = x^3yz - 5");
        }

        [TestMethod]
        public void EquationTransformer_Transform_9()
        {
            var equation = new Equation("1.6123x = 0.1x + 0.4x + 0.1123x");
            var result = _sut.Tranform(equation);
            Assert.AreEqual("x = 0", result.ToString());
        }
    }
}
