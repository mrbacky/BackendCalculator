using System;
using System.IO;
using NUnit.Framework;
using Services;

namespace Tests
{
    public class AddTests
    {
        private ICalculator _calc;

        [SetUp]
        public void Setup()
        {
            _calc = new Calculator();
        }


        [Test]
        public void AddNumbersWithNoInput()
        {
            var array = Array.Empty<double>();
            var ex = Assert.Throws<InvalidDataException>(() => _calc.Add(array));
            Assert.That(ex.Message, Is.EqualTo("Values required for Add method"));
        }

        [Test]
        public void AddTwoPositiveNumbers()
        {
            var actual = _calc.Add(1.2, 7.4);
            const double expected = 8.6;
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void AddTwoNegativeNumbers()
        {
            var actual = _calc.Add(-1.2, -3);
            const double expected = -4.2;
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void AddThreePositiveNumbers()
        {
            var actual = _calc.Add(3.5, 3, 7.9);
            const double expected = 14.4;
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void AddThreeNegativeNumbers()
        {
            var actual = _calc.Add(-3.5, -3, -7.9);
            const double expected = -14.4;
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Add_ZerosInParams_ShouldThrowException()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(()
                => _calc.Add(0, 0, 0, 0, 0));
            Assert.That(ex.Message, Is.EqualTo("Only zero values not allowed. (Parameter 'numbers')"));
        }
    }
}