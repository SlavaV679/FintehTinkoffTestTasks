using System;

namespace Task5CountUnicalNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите два целых числа l и r - диапазон чисел, внутри которого нужно найти" +
                "максимальное число чисел, состоящих из одинаковых цифр (1<=l,r<=10^18).");

            var stringFirst = Console.ReadLine().Split(' ');

            var minNumber = ParseNumber(stringFirst[0]);

            var maxNumber = ParseNumber(stringFirst[1]);

            long amountFromMinNumber = 0;

            var amountFromMaxNumber = GetAmountOfUnicNumbers(maxNumber);

            if (minNumber > 1)
                amountFromMinNumber = GetAmountOfUnicNumbers(minNumber - 1);

            var result = amountFromMaxNumber - amountFromMinNumber;

            Console.WriteLine($"Максимальное число 'уникальных' чисел: {result}");
            Console.ReadKey();
        }

        private static long GetAmountOfUnicNumbers(long number)
        {
            var digitOfNumber = GetDigitOfNumber(number);

            var arrayDigites = GetArrayDigites(number, digitOfNumber);

            var maxNumberOfUnicsInMaxPlaceNumber = GetMaxNumberOfUnicsInMaxPlaceNumber(arrayDigites);

            var amountOfUnicNumbers = (digitOfNumber - 1) * 9 + maxNumberOfUnicsInMaxPlaceNumber;

            return amountOfUnicNumbers;
        }

        /// <summary>
        /// Получить максимальное число уникальных цифр в максимальном разряде входящего числа
        /// </summary>
        /// <param name="arrayDigites"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private static long GetMaxNumberOfUnicsInMaxPlaceNumber(long[] arrayDigites)
        {
            long maxNumber = 0;
            if (arrayDigites.Length == 1)
            {
                return arrayDigites[0];
            }
            for (int i = 1; i < arrayDigites.Length; i++)
            {
                if (arrayDigites[arrayDigites.Length - i] > arrayDigites[arrayDigites.Length - i - 1])
                {
                    maxNumber = arrayDigites[arrayDigites.Length - i] - 1;
                }
                else
                {
                    maxNumber = arrayDigites[arrayDigites.Length - i];
                }
            }
            return maxNumber;
        }

        /// <summary>
        /// Получить массив цифр составляющих число 
        /// </summary>
        /// <param name="number"></param>
        /// <param name="digitOfNumber"></param>
        /// <returns></returns>
        private static long[] GetArrayDigites(long number, int digitOfNumber)
        {
            if (digitOfNumber == 0)
                return new long[] { 0 };

            var numberArray = new long[digitOfNumber];
            for (int j = 0; j < digitOfNumber; j++)
            {
                numberArray[j] = number % 10;
                number = number / 10;
            }

            return numberArray;
        }

        /// <summary>
        /// Получить разрядность числа (количество цифр)
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static int GetDigitOfNumber(long number)
        {
            //long tempValue = -1;
            var digitOfNumber = 0;

            while (number != 0)
            {
                number = number / 10;
                digitOfNumber++;
            }

            return digitOfNumber;
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
