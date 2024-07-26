using System;

namespace Task4ChangeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите два целых числа n,k — количество чисел на бумажке и " +
                "ограничение на число операций. (1≤n≤1000, 1≤k≤104).");

            var stringFirst = Console.ReadLine().Split(' ');

            var AmountOfNumbers = ParseNumber(stringFirst[0]);

            var numberOfOperations = ParseNumber(stringFirst[1]);

            Console.WriteLine("Введите n чисел ai — числа на бумажке(1≤ai≤109)");

            var stringSecond = Console.ReadLine().Split(' ');

            var numbers = new long[stringSecond.Length];

            for (int i = 0; i < stringSecond.Length; i++)
            {
                numbers[i] = ParseNumber(stringSecond[i]);
            }

            var initSum = GetSum(numbers);
            for (int i = 0; i < numberOfOperations; i++)
            {
                int index = GetIndexOfValuableNumber(numbers);
                ReplaceDigitInNumber(index, numbers);
            }

            var endSum = GetSum(numbers);

            var result = endSum - initSum;

            Console.WriteLine($"Максимальная разность между конечной и начальной суммой: {result}");
            Console.ReadKey();
        }

        private static long GetSum(long[] numbers)
        {
            long sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }

            return sum;
        }

        /// <summary>
        /// Заменить цифру в числе на 9 в максимально возможном разряде, там где не 9ка.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="v"></param>
        /// <exception cref="NotImplementedException"></exception>
        private static void ReplaceDigitInNumber(int index, long[] numbers)
        {
            var digitOfNumber = GetDigitOfNumber(numbers[index]);

            for (int i = 1; i < digitOfNumber + 1; i++)
            {
                var number = numbers[index];
                var digitesInit = (long)Math.Pow(10, digitOfNumber - i);
                if (number / digitesInit != 9)
                {
                    var numberArray = new long[digitOfNumber];
                    for (int j = 0; j < digitOfNumber; j++)
                    {
                        numberArray[j] = number % 10;
                        number = number / 10;
                    }

                    numberArray[digitOfNumber - i] = 9;

                    long endNumber = 0;
                    for (int j = 0; j < digitOfNumber; j++)
                    {
                        var digites = (long)Math.Pow(10, j);
                        endNumber += numberArray[j] * digites;
                    }
                    numbers[index] = endNumber;

                    return;
                }
            }
        }

        /// <summary>
        /// Получить индекс значимого числа. Значимое число - первый претендент на изменения цифры в этом числе из всего массива чисел.
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        private static int GetIndexOfValuableNumber(long[] numbers)
        {
            long specificValueOfNumberMax = 0;
            var index = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                var digitOfNumber = GetDigitOfNumber(numbers[i]);

                long nines = 0;

                for (int j = digitOfNumber; j != 0; j--)
                {
                    nines = nines * 10 + 9;
                }

                var specificValueOfNumber = nines - numbers[i];

                if (specificValueOfNumber > specificValueOfNumberMax)
                {
                    specificValueOfNumberMax = specificValueOfNumber;
                    index = i;
                }
            }

            return index;
        }

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

        private static int ParseNumber(string inputData1)
        {
            if (!int.TryParse(inputData1, out var number))
            {
                throw new Exception("Необходимо вводить только числа!");
            }
            return number;
        }
    }
}

