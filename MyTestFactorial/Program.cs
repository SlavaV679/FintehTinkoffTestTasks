using System;

namespace MyTestFactorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Factorial(5));
            Console.WriteLine(FactorialRecursion(5));

            Console.ReadKey();
        }

        static long Factorial(int number)
        {
            long result = 1;

            for (int i = 1; i < number + 1; i++)
            {
                result = result * i;
            }
            return result;
        }

        static long FactorialRecursion(int number)
        {
            if (number == 1)
                return 1;

            return FactorialRecursion(number - 1) * number;
        }
    }
}
