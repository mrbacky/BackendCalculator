using System;
using System.IO;
using NUnit.Framework;
using Services;

namespace Tests
{
    public class MultiplyTests
    {
        private ICalculator _calc;

        [SetUp]
        public void Setup()
        {
            _calc = new Calculator();
        }


        [Test]
        public void MultiplyNumbersWithNoInput()
        {
            var array = Array.Empty<double>();
            var ex = Assert.Throws<InvalidDataException>(() => _calc.Multiply(array));
            Assert.That(ex.Message, Is.EqualTo("Values required for Multiply method"));
        }

        [Test]
        public void Multiply_ZerosInParams_ShouldThrowExeption()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(()
                => _calc.Multiply(0, 0, 0, 0, 0));
            Assert.That(ex.Message, Is.EqualTo("Only zero values not allowed. (Parameter 'numbers')"));
        }

        [Test]
        public void MultiplyTwoPositiveNumbers()
        {
            var actual = _calc.Multiply(4, 3);
            const double expected = 12;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MultiplyTwoNegativeNumbers()
        {
            var actual = _calc.Multiply(-2, -3);
            const double expected = 6;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MultiplyThreePositiveNumbers()
        {
            var actual = _calc.Multiply(2, 3, 5);
            const double expected = 30;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MultiplyThreeNegativeNumbers()
        {
            var actual = _calc.Multiply(-2, -3, -5);
            const double expected = -30;
            Assert.AreEqual(expected, actual);
        }
    }
}