using System;

namespace Services
{
    public interface ICalculator
    {
        /// <summary>
        /// Takes all the numbers in the input and returns the sum of the numbers.
        /// </summary>
        /// <param name="numbers">The numbers to sum</param>
        /// <exception cref="ArgumentOutOfRangeException">Is thrown if zero numbers are given in the parameters.</exception>
        /// <returns>A sum of all numbers in the input</returns>
        double Add(params double[] numbers);
        
        /// <summary>
        /// Takes all numbers in the input and return the subtracted number. That is: numbers[0] - numbers[1] - ... - numbers[n]
        /// </summary>
        /// <param name="numbers">The numbers to subtract</param>
        /// <exception cref="ArgumentOutOfRangeException">Is thrown if zero numbers are given in the parameters.</exception>
        /// <returns>The result when all numbers are subtracted</returns>
        double Subtract(params double[] numbers);
        
        /// <summary>
        /// Takes all numbers in the input and multiply them together.
        /// </summary>
        /// <param name="numbers">The numbers to multiply</param>
        /// <exception cref="ArgumentOutOfRangeException">Is thrown if zero numbers are given in the parameters.</exception>
        /// <returns>The result when all numbers are multiplied</returns>
        double Multiply(params double[] numbers);
        
        /// <summary>
        /// Takes all numbers in the input and divide them. That is: numbers[0] / numbers[1] / ... / numbers[n]
        /// </summary>
        /// <param name="numbers">The numbers to divide</param>
        /// <exception cref="ArgumentOutOfRangeException">Is thrown if zero numbers are given in the parameters.</exception>
        /// <returns>The result when all numbers have are divided</returns>
        double Divide(params double[] numbers);
        
        /// <summary>
        /// Finds the factorial of the given number. The factorial of a number means that the number is multiplied with all integers between 1 and itself.
        /// For instance the factorial number of 5 = 5*4*3*2*1 = 120.
        /// The factorial number of 0 = 1.
        /// </summary>
        /// <param name="number">The number to find the factorial of</param>
        /// <exception cref="ArgumentOutOfRangeException">Is thrown if a negative number is provided.</exception>
        /// <returns>The factorial of the given number</returns>
        double Factorial(double number);

    }
}