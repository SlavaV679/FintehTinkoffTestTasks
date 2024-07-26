using System;

namespace Task2CuttingRoll
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество гостей:");
            var numberGuests = Console.ReadLine();

            if (!decimal.TryParse(numberGuests, out var guests))
            {
                Console.WriteLine("Введите число!");
                return;
            }

            var numberCuts = 0;
            while (guests != 1)
            {
                numberCuts ++;

                guests = Math.Round(guests/2, MidpointRounding.AwayFromZero);
            }
            Console.WriteLine($"Минимальное количество резов: '{numberCuts}'");
            Console.ReadKey();
        }
    }
}
