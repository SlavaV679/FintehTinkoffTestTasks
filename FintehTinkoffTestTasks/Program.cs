// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Console.WriteLine("Введите 4 целых положительных числа A,B,C,D(1≤A,B,C,D≤100) — " +
    "\r\nА - стоимость тарифа Кости, \r\n B - размер тарифа Кости, \r\nC - стоимость каждого лишнего мегабайта, " +
    "\r\nD - размер интернет-трафика Кости в следующем месяце. \r\nЧисла должны быть разделены пробелами. ");

var inputData = Console.ReadLine();
var inputDataList = inputData.Split(' ');
if (inputDataList.Length != 4)
{
    Console.WriteLine("Необходимо ввести 4 числа!");
}

var helper = new Helper();
int aCostTariff = helper.ParseNumber(inputDataList[0]);
int bNumberOfMegabytesInTariff = helper.ParseNumber(inputDataList[1]);
int cCostOfExtraMegabyte = helper.ParseNumber(inputDataList[2]);
int dWastedMegabytes = helper.ParseNumber(inputDataList[3]);

var mBOverTarif = dWastedMegabytes - bNumberOfMegabytesInTariff;

if (mBOverTarif <= 0)
{
    Console.WriteLine($"Костя потратит {aCostTariff} на интернет.");
    return;
}
else
{
    var totalAmount = mBOverTarif * cCostOfExtraMegabyte + aCostTariff;

    Console.WriteLine($"Костя потратит {totalAmount} на интернет.");
    return;
}

public class Helper
{
    public int ParseNumber(string inputData)
    {
        if (!int.TryParse(inputData, out var number))
        {
            throw new Exception("Необходимо вводить только числа!");
        }
        return number;
    }
}
