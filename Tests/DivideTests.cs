using System;
using System.IO;
using NUnit.Framework;
using Services;

namespace Tests
{
    public class DivideTests
    {
        private ICalculator _calc;

        [SetUp]
        public void Setup()
        {
            _calc = new Calculator();
        }


        [Test]
        public void DivideNumbersWithNoInput()
        {
            var array = Array.Empty<double>();
            var ex = Assert.Throws<InvalidDataException>(() => _calc.Divide(array));
            Assert.That(ex.Message, Is.EqualTo("you need to input at least 2 numbers"));
        }

        [Test]
        public void DivideTwoPositiveNumbers()
        {
            var arr = new double[2] {10, 5};
            var actual = _calc.Divide(arr);
            Assert.AreEqual(actual, 2);
        }

        [Test]
        public void DivideTwoNegativeNumbers()
        {
            var arr = new double[2] {-10, -5};
            var actual = _calc.Divide(arr);
            Assert.AreEqual(actual, 2);
        }

        [Test]
        public void DivideTwoNumbersWithZero()
        {
            var array = new double[2] {10, 0};
            var ex = Assert.Throws<InvalidDataException>(() => _calc.Divide(array));
            Assert.That(ex.Message, Is.EqualTo("cannot divide with zero"));
        }

        [Test]
        public void DivideThreeNumbersWithZero()
        {
            var array = new double[3] {10, 6, 0};
            var ex = Assert.Throws<InvalidDataException>(() => _calc.Divide(array));
            Assert.That(ex.Message, Is.EqualTo("cannot divide with zero"));
        }

        [Test]
        public void Divide_ZerosInParams_ShouldThrowExeption()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(()
                => _calc.Divide(0, 0, 0, 0, 0));
            Assert.That(ex.Message, Is.EqualTo("Only zero values not allowed. (Parameter 'numbers')"));
        }
    }
}