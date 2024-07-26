using System;

namespace Task5CountUnicalNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Введите число n (2<=n<=10^5) — количество учеников.");

            var numberOfStudents = ParseNumber(Console.ReadLine());

            //Console.WriteLine("Введите n чисел ai — ученик, который достался Тайному Санте с номером i (1<=ai<=n)");

            var stringSecond = Console.ReadLine().Split(' ');

            var numbers = new long[stringSecond.Length];

            for (int i = 0; i < stringSecond.Length; i++)
            {
                numbers[i] = ParseNumber(stringSecond[i]);
            }

            var indexeAndNumber = GetIndexesAndNumberToReplace(numbers);

            Console.WriteLine($"{indexeAndNumber[0]}, {indexeAndNumber[1]}");
            Console.ReadKey();
        }

        private static int[] GetIndexesAndNumberToReplace(long[] numbers)
        {
            int index = 0, number = 0;

            for (int i = 1; i < numbers.Length + 1; i++)
            {
                int numberOfCoincidences = 0;

                for (int j = 1; j < numbers.Length + 1; j++)
                {
                    if (numbers[j - 1] == i)
                    {
                        numberOfCoincidences++;
                    }

                    if (numberOfCoincidences == 2)
                    {
                        if (index != 0)
                        {
                            return new int[] { -1, -1 };
                        }
                        index = j;
                    }

                    if (numberOfCoincidences > 2)
                    {
                        return new int[] { -1, -1 };
                    }
                }

                if (numberOfCoincidences == 0)
                {
                    if (number != 0)
                    {
                        return new int[] { -1, -1 };
                    }
                    number = i;
                }
            }

            if (number == 0)
            {
                index = -1;
                number = -1;
            }

            var indexes = new int[] { index, number };

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
