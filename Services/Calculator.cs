using System;
using System.IO;
using System.Linq;

namespace Services
{
    public class Calculator : ICalculator
    {
        public double Add(params double[] numbers)
        {
            if (numbers.Length < 1) throw new InvalidDataException("Values required for Add method");
            var isAllZero = numbers.All(value => value == 0);
            if (isAllZero)
                throw new ArgumentOutOfRangeException(nameof(numbers), "Only zero values not allowed.");
            return numbers.Sum();
        }

        //Armand
        public double Subtract(params double[] numbers)
        {
            if (numbers.Length < 1) throw new InvalidDataException("Values required for Multiply method");
            var isAllZero = numbers.All(value => value == 0);
            if (isAllZero)
                throw new ArgumentOutOfRangeException(nameof(numbers), "Only zero values not allowed.");
            var result = numbers[0];
            for (var i = 1; i < numbers.Length; i++)
            {
                result -= numbers[i];
            }

            return result;
        }

        //Rado
        public double Multiply(params double[] numbers)
        {
            if (numbers.Length < 1) throw new InvalidDataException("Values required for Multiply method");
            var isAllZero = numbers.All(value => value == 0);
            if (isAllZero)
                throw new ArgumentOutOfRangeException(nameof(numbers), "Only zero values not allowed.");

            return numbers.Aggregate<double, double>(1, (current, num) => current * num);
        }

        public double Divide(params double[] numbers)
        {
            if (numbers.Length < 2) throw new InvalidDataException("you need to input at least 2 numbers");
            var isAllZero = numbers.All(value => value == 0);
            if (isAllZero)
                throw new ArgumentOutOfRangeException(nameof(numbers), "Only zero values not allowed.");
            var res = numbers[0];
            for (var i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] == 0) throw new InvalidDataException("cannot divide with zero");
                res /= numbers[i];
            }

            return res;
        }

        public double Factorial(double number)
        {
            switch (number)
            {
                case < 0:
                    throw new ArgumentOutOfRangeException(nameof(number),
                        "Cannot do factorial on numbers smaller than 0.");
                case > 60:
                    throw new InvalidDataException("highest factorial for this calculator is 60");
            }

            double factorial = 1;

            for (var i = 1; i <= number; i++)
            {
                factorial *= i;
            }

            return factorial;
        }

        public double Power(double[] numbers)
        {
            if (numbers.Length != 2)
            {
                throw new ArgumentOutOfRangeException(nameof(numbers), "Exactly two numbers are required.");
            }

            var isAllZero = numbers.All(value => value == 0);
            if (isAllZero)
                throw new ArgumentOutOfRangeException(nameof(numbers), "Only zero values not allowed.");


            return Math.Pow(numbers[0], numbers[1]);
        }
    }
}