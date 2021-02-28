using System;
using System.IO;
using NUnit.Framework;
using Services;

namespace Tests
{
    public class SubtractTests
    {
        private ICalculator _calc;

        [SetUp]
        public void Setup()
        {
            _calc = new Calculator();
        }


        [Test]
        public void SubtractNumbersWithNoInput()
        {
            var array = Array.Empty<double>();
            var ex = Assert.Throws<InvalidDataException>(() => _calc.Add(array));
            Assert.That(ex.Message, Is.EqualTo("Values required for Add method"));
        }

        [Test]
        public void SubtractTwoPositiveNumbers()
        {
            var actual = _calc.Subtract(10, 5);
            const double expected = 5;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SubtractTwoNegativeNumbers()
        {
            var actual = _calc.Subtract(-10, -5);
            const double expected = -5;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SubtractThreePositiveNumbers()
        {
            var actual = _calc.Subtract(10, 5, 2);
            const double expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SubtractThreeNegativeNumbers()
        {
            var actual = _calc.Subtract(-10, -5, -5);
            const double expected = 0;
            Assert.AreEqual(expected, actual);
        }
        
        
        [Test]
        public void Subtract_ZerosInParams_ShouldThrowException()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(()
                => _calc.Subtract(0, 0, 0, 0, 0));
            Assert.That(ex.Message, Is.EqualTo("Only zero values not allowed. (Parameter 'numbers')"));
        }
    }
}