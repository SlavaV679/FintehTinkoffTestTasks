using System;

namespace Task1TariffMobile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Console.WriteLine("Введите 4 целых положительных числа A,B,C,D(1≤A,B,C,D≤100) — " +
                "\r\nА - стоимость тарифа Кости, \r\nB - размер тарифа Кости, \r\nC - стоимость каждого лишнего мегабайта, " +
                "\r\nD - размер интернет-трафика Кости в следующем месяце. \r\nЧисла должны быть разделены пробелами. ");

            var inputData = Console.ReadLine();
            var inputDataList = inputData.Split(' ');
            if (inputDataList.Length != 4)
            {
                Console.WriteLine("Необходимо ввести 4 числа!");
            }
            int aCostTariff = ParseNumber(inputDataList[0]);
            int bNumberOfMegabytesInTariff = ParseNumber(inputDataList[1]);
            int cCostOfExtraMegabyte = ParseNumber(inputDataList[2]);
            int dWastedMegabytes = ParseNumber(inputDataList[3]);

            var mBOverTarif = dWastedMegabytes - bNumberOfMegabytesInTariff;

            if (mBOverTarif <= 0)
            {
                Console.WriteLine($"Костя потратит {aCostTariff} на интернет.");
                Console.ReadKey();
                return;
            }
            else
            {
                var totalAmount = mBOverTarif * cCostOfExtraMegabyte + aCostTariff;

                Console.WriteLine($"Костя потратит {totalAmount} на интернет.");
                Console.ReadKey();
                return;
            }
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
