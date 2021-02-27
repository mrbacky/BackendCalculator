using System;
using System.IO;
using NUnit.Framework;
using Services;

namespace Tests
{
    public class Tests
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
            double[] array = new double[0];
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

        //Armand
        [Test]
        public void SubtractNumbersWithNoInput()
        {
            double[] array = new double[0];
            var ex = Assert.Throws<InvalidDataException>(() => _calc.Add(array));
            Assert.That(ex.Message, Is.EqualTo("Values required for Add method"));
        }

        [Test]
        public void SubtractTwoPositiveNumbers()
        {
            var actual = _calc.Subtract(10,5);
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
            // a - b - c
            // (-10) - (-5) - (-5) = 
            var actual = _calc.Subtract(-10, -5, -5);
            const double expected = 0;
            Assert.AreEqual(expected, actual);
        }

        //Rado
        [Test]
        public void MultiplyNumbersWithNoInput()
        {
            double[] array = new double[0];
            var ex = Assert.Throws<InvalidDataException>(() => _calc.Multiply(array));
            Assert.That(ex.Message, Is.EqualTo("Values required for Multiply method"));
        }

        [Test]
        public void Multiply_ZerosInParams_ShouldThrowExeption()
        {
            var ex = Assert.Throws<InvalidDataException>(()
                => _calc.Multiply(0, 0, 0, 0, 0));
            Assert.That(ex.Message, Is.EqualTo("Only zeros values not alowed."));
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

        //Dominik
        [Test]
        public void DivideNumbersWithNoInput()
        {
            double[] array = new double[0];
            var ex = Assert.Throws<InvalidDataException>(() => _calc.Divide(array));
            Assert.That(ex.Message, Is.EqualTo("you need to input at least 2 numbers"));
        }

        [Test]
        public void DivideTwoPositiveNumbers()
        {
            double[] arr = new double[2] {10, 5};
            var actual = _calc.Divide(arr);
            Assert.AreEqual(actual, 2);
        }

        [Test]
        public void DivideTwoNegativeNumbers()
        {
            double[] arr = new double[2] {-10, -5};
            var actual = _calc.Divide(arr);
            Assert.AreEqual(actual, 2);
        }

        [Test]
        public void DivideTwoNumbersWithZero()
        {
            double[] array = new double[2] {10, 0};
            var ex = Assert.Throws<InvalidDataException>(() => _calc.Divide(array));
            Assert.That(ex.Message, Is.EqualTo("cannot divide with zero"));
        }

        [Test]
        public void DivideThreeNumbersWithZero()
        {
            double[] array = new double[3] {10, 6, 0};
            var ex = Assert.Throws<InvalidDataException>(() => _calc.Divide(array));
            Assert.That(ex.Message, Is.EqualTo("cannot divide with zero"));
        }

        //Dominik
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
            var ex = Assert.Throws<InvalidDataException>(() => _calc.Factorial(-5));
            Assert.That(ex.Message, Is.EqualTo("cannot do factorial on numbers smaller than 0"));
        }
    }
}