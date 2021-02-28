using System;
using System.IO;
using NUnit.Framework;
using Services;

namespace Tests
{
    public class FactorialTests
    {
        private ICalculator _calc;

        [SetUp]
        public void Setup()
        {
            _calc = new Calculator();
        }


        [Test]
        public void FactorialOfFive()
        {
            var actual = _calc.Factorial(5);
            Assert.AreEqual(actual, 120);
        }

        [Test]
        public void FactorialOf200()
        {
            var ex = Assert.Throws<InvalidDataException>(() => _calc.Factorial(200));
            Assert.That(ex.Message, Is.EqualTo("highest factorial for this calculator is 60"));
        }

        [Test]
        public void FactorialOfZero()
        {
            var actual = _calc.Factorial(0);
            Assert.AreEqual(actual, 1);
        }

        [Test]
        public void FactorialOfNegativeNumber()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => _calc.Factorial(-5));
            Assert.That(ex.Message, Is.EqualTo("Cannot do factorial on numbers smaller than 0. (Parameter 'number')"));
        }
    }
}