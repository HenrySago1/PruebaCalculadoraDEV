using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppCalculadora;
using System;

namespace AppCalculadora.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        private Calculator _calculator = null!;

        [TestInitialize]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        [TestMethod]
        public void TestAdd()
        {
            double result = _calculator.Add(10.5, 4.5);
            Assert.AreEqual(15.0, result, 0.0001);
        }

        [TestMethod]
        public void TestSubtract()
        {
            double result = _calculator.Subtract(10.5, 4.5);
            Assert.AreEqual(6.0, result, 0.0001);
        }

        [TestMethod]
        public void TestMultiply()
        {
            double result = _calculator.Multiply(4.0, 2.5);
            Assert.AreEqual(10.0, result, 0.0001);
        }

        [TestMethod]
        public void TestDivide()
        {
            double result = _calculator.Divide(10.0, 4.0);
            Assert.AreEqual(2.5, result, 0.0001);
        }

        [TestMethod]
        public void TestDivideByZeroThrowsException()
        {
            bool exceptionThrown = false;
            try
            {
                _calculator.Divide(5.0, 0);
            }
            catch (DivideByZeroException)
            {
                exceptionThrown = true;
            }
            Assert.IsTrue(exceptionThrown, "Se esperaba DivideByZeroException pero no se lanzó.");
        }
    }
}
