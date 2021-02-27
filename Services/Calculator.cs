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


            double sum = 0;
            foreach (double num in numbers)
            {
                sum += num;
            }

            return sum;
        }

        //Armand
        public double Subtract(params double[] numbers)
        {
            if (numbers.Length < 1) throw new InvalidDataException("Values required for Multiply method");
            double result = numbers[0];

            // double result = Subtract(numbers);
            for (int i = 1; i < numbers.Length; i++)
            {
                result = result - numbers[i];
            }

            return result;
        }

        //Rado
        public double Multiply(params double[] numbers)
        {
            if (numbers.Length < 1) throw new InvalidDataException("Values required for Multiply method");
            var isAllZero = numbers.All(value => value == 0);
            if (isAllZero)
                throw new ArgumentOutOfRangeException(nameof(numbers), "Only zeros values not allowed.");

            return numbers.Aggregate<double, double>(1, (current, num) => current * num);
        }

        public double Divide(params double[] numbers)
        {
            if (numbers.Length < 2) throw new InvalidDataException("you need to input at least 2 numbers");

            double res = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] == 0) throw new InvalidDataException("cannot divide with zero");
                res /= numbers[i];
            }

            return res;
        }

        public double Factorial(double number)
        {
            if (number < 0) throw new InvalidDataException("cannot do factorial on numbers smaller than 0");
            if (number > 60) throw new InvalidDataException("highest factorial for this calculator is 60");

            double factorial = 1;

            for (int i = 1; i <= number; i++)
            {
                factorial = factorial * i;
            }

            return factorial;
        }
    }
}