using System;
using System.Collections.Generic;

namespace Task12Money
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); //ограничение на сумарную стоимость монет в кошельке (1≤N≤1018).

            var coins = new int[3]; // номиналы монет (1≤𝐴,𝐵,𝐶≤100000)

            for (int i = 0; i < 3; i++)
            {
                coins[i] = int.Parse(Console.ReadLine());
            }

            var amounts = new List<int>();

            for (int i = 0; i < n / coins[0] + 1; i++)
            {
                var sumMinusCoins1 = n - (coins[0] * i + 1);

                for (int j = 0; j < sumMinusCoins1 / coins[1] + 1; j++)
                {
                    var sumMinusCoins1and2 = sumMinusCoins1 - coins[1] * j;

                    for (int k = 0; k < sumMinusCoins1 / coins[2] + 1; k++)
                    {
                        var v1 = coins[2] * k;
                        if (sumMinusCoins1and2 - v1 < 0)
                        {
                            // amounts.Add(n - sumMinusCoins1and2);
                            break;
                        }
                        
                        var sumMinusCoins1and2And3 = sumMinusCoins1and2 - v1;

                        var v3 = n - sumMinusCoins1and2And3;
                        amounts.Add(v3);
                    }
                }
            }

            Console.WriteLine(n);

            Console.ReadKey();
        }
    }
}