using System;

namespace Task5CountUnicalNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число n (2<=n<=1000) — количество учеников в шеренге.");

            var amountHeights = ParseNumber(Console.ReadLine());

            Console.WriteLine("Введите n чисел ai — рост учеников (1<=ai<=109)");

            var stringSecond = Console.ReadLine().Split(' ');

            var heights = new long[stringSecond.Length];

            for (int i = 0; i < stringSecond.Length; i++)
            {
                heights[i] = ParseNumber(stringSecond[i]);
            }

            var indexes = GetTwoIndexestoSwap(heights);

            Console.WriteLine($"Номера учеников, которых нужно поменять местами: {indexes[0]}, {indexes[1]}");
            Console.ReadKey();
        }

        private static int[] GetTwoIndexestoSwap(long[] heights)
        {
            int index1 = 0, index2 = 0;

            for (int i = 1; i < heights.Length + 1; i++)
            {
                if (i % 2 == 0 && heights[i - 1] % 2 == 0)
                    continue;

                if (i % 2 == 1 && heights[i - 1] % 2 == 1)
                    continue;

                if (index1 == 0)
                {
                    index1 = i;
                    continue;
                }

                if (index2 == 0)
                {
                    index2 = i;
                    continue;
                }

                index1 = -1;
                index2 = -1;
                break;
            }

            if (index2 == 0)
            {
                index1 = -1;
                index2 = -1;
            }

            var indexes = new int[] { index1, index2 };

            return indexes;
        }

        private static long ParseNumber(string inputData1)
        {
            if (!long.TryParse(inputData1, out var number))
            {
                throw new Exception("Необходимо вводить только числа!");
            }
            return number;
        }
    }
}
