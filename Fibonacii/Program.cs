using System;

namespace Fibonacii
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetNumberFibonacciOn(5));
            Console.WriteLine(GetNumberFibonacciO1(5));
            Console.WriteLine(GetNumberFibonacciRecursion(5));
            Console.ReadKey();
        }

        private static int GetNumberFibonacciOn(int number)
        {
            var fibonacci = new int[number + 1];

            fibonacci[0] = 0;
            fibonacci[1] = 1;

            for (int i = 2; i < number + 1; i++)
            {
                fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
            }
            return fibonacci[number];
        }

        private static int GetNumberFibonacciO1(int number)
        {
            int result = 1;
            int resultPrevious1 = 1;
            int resultPrevious2 = 0;

            for (int i = 2; i < number + 1; i++)
            {
                result = resultPrevious1 + resultPrevious2;
                resultPrevious2 = resultPrevious1;
                resultPrevious1 = result;
            }

            return result;
        }

        private static int GetNumberFibonacciRecursion(int number)
        {
            if (number < 2)
            {
                return number;
            }
            else
            {
                return GetNumberFibonacciRecursion(number - 1) + GetNumberFibonacciRecursion(number - 2);
            }
        }
    }
}
