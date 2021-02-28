using System;
using NUnit.Framework;
using Services;

namespace Tests
{
    public class PowerTests
    {
        private ICalculator _calc;

        [SetUp]
        public void Setup()
        {
            _calc = new Calculator();
        }

        [Test]
        public void Power1()
        {
            var numbers = new double[2] {5, 2};
            var product = _calc.Power(numbers);
            const int expected = 25;
            Assert.AreEqual(expected, product);
        }

        [Test]
        public void Power_WithNotExactlyTwoNumbers_ShouldThrowException()
        {
            var numbers = new double[4] {5, 2, 84, 2};
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => _calc.Power(numbers));
            Assert.That(ex.Message, Is.EqualTo("Exactly two numbers are required. (Parameter 'numbers')"));
        }

        [Test]
        public void Power_ZerosInParams_ShouldThrowException()
        {
            var numbers = new double[2] {0, 0};
            var ex = Assert.Throws<ArgumentOutOfRangeException>(()
                => _calc.Power(numbers));
            Assert.That(ex.Message, Is.EqualTo("Only zero values not allowed. (Parameter 'numbers')"));
        }


        // [Test]
        // public void Power2()
        // {
        //     var product = _calc.Power(7, 14);
        //     const long expected = 678223072849;
        //     Assert.AreEqual(expected, product);
        // }
    }
}