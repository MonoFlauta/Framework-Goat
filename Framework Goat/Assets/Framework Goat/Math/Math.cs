namespace FrameworkGoat
{

    public class Math
    {
        /// <summary>
        /// Gets the factorial of a number
        /// </summary>
        /// <param name="value">Number</param>
        /// <returns>The factorial</returns>
        public static int GetFactorial(int value)
        {
            if (value <= 1) return 1;
            return value * GetFactorial(value - 1);
        }

        /// <summary>
        /// Gets the factorial of a number
        /// </summary>
        /// <param name="value">Number</param>
        /// <returns>The factorial</returns>
        public static int GetFactorial(float value)
        {
            return GetFactorial((int)value);
        }

        /// <summary>
        /// Gets the Fibonacci number of a number
        /// </summary>
        /// <param name="value">Number</param>
        /// <returns>The Fibonacci number</returns>
        public static int GetFibonacci(int value)
        {
            if (value == 0) return 0;
            if (value <= 2) return 1;
            return GetFibonacci(value - 1) + GetFibonacci(value - 2);
        }

        /// <summary>
        /// Gets the Fibonacci number of a number
        /// </summary>
        /// <param name="value">Number</param>
        /// <returns>The Fibonacci number</returns>
        public static int GetFibonacci(float value)
        {
            return GetFactorial((int)value);
        }

        /// <summary>
        /// Gets the binomial coefficient from two numbers
        /// </summary>
        /// <param name="firstValue">First number</param>
        /// <param name="secondValue">Second number</param>
        /// <returns>The binomial coefficient of two numbers</returns>
        public static int GetBinomialCoefficient(int firstValue, int secondValue)
        {
            if (firstValue == secondValue || secondValue == 0) return 1;
            return GetFactorial(firstValue) / (GetFactorial(secondValue) * GetFactorial(firstValue - secondValue));
        }

        /// <summary>
        /// Gets the binomial coefficient from two numbers
        /// </summary>
        /// <param name="firstValue">First number</param>
        /// <param name="secondValue">Second number</param>
        /// <returns>The binomial coefficient of two numbers</returns>
        public static int GetBinomialCoefficient(float firstValue, float secondValue)
        {
            return GetBinomialCoefficient((int)firstValue, (int)secondValue);
        }
    }
}