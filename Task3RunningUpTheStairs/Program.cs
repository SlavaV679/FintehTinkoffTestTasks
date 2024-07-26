using System;

namespace Task3RunningUpTheStairs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите 2 целых положительных числа " +
                "\r\nn и t (2<=n,t<=100) — количество сотрудников и время, " +
                "когда один из сотрудников покинет офис (в минутах). ");

            var stringFirst = Console.ReadLine().Split(' ');

            var numberEmployees = ParseNumber(stringFirst[0]);

            var timeLeavingFirstEmployee = ParseNumber(stringFirst[1]);

            Console.WriteLine("Введите n чисел в порядке возрастания — номера этажей, на которых находятся сотрудники. " +
                "Все числа должны быть различны и по абсолютной величине не превосходят 100. ");

            var stringSecond = Console.ReadLine().Split(' ');

            var floors = new int[stringSecond.Length];

            for (int i = 0; i < stringSecond.Length; i++)
            {
                floors[i] = ParseNumber(stringSecond[i]);
            }
            Console.WriteLine("Введите порядковый номер числа из второй строки, " +
                "который будет указывать на этаж, на котором сотрудник уйдет через t минут.");

            var index = ParseNumber(Console.ReadLine());

            var t1 = floors[index-1] - floors[0];// время за которое можно дойти с нижнего этажа до сотрудника

            var t2 = floors[stringSecond.Length - 1] - floors[index-1];// время за которое можно дойти с верхнего этажа до сотрудника

            var tMin = Math.Min(t1, t2);// минимальное время из t1 и t2.

            var timeFromFirstToLastFloor = floors[stringSecond.Length - 1] - floors[0];

            int totalTime;
            
            if (timeLeavingFirstEmployee - tMin > 0)
            {
                totalTime = timeFromFirstToLastFloor;
            }
            else
            {
                if (t1 < t2)
                {
                    totalTime = floors[index - 1] - floors[0] + timeFromFirstToLastFloor;
                }
                else
                {
                    totalTime = floors[stringSecond.Length - 1] - floors[index - 1] + timeFromFirstToLastFloor;
                }
            }
            Console.WriteLine($"Минимально число лестничных пролетов: {totalTime}");
            Console.ReadKey();
        }

        static int ParseNumber(string inputData1)
        {
            if (!int.TryParse(inputData1, out var number))
            {
                throw new Exception("Необходимо вводить только числа!");
            }
            return number;
        }
    }
}
