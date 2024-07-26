using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestAlekseyAlgoritm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Даня в обеденный перерыв ходит в одно и то же кафе. Ему, как сотруднику банка, положено   специальное предложение: при каждой покупке больше, чем на ﻿100﻿ рублей, Даня получает купон на бесплатный обед.
            // Даня узнал стоимость своих обедов на ближайшие ﻿n﻿ дней. Ему хочется минимизировать свои затраты, грамотно используя талоны. Требуется найти минимальные суммарные затраты Дани на обеды.

            var n = int.Parse(Console.ReadLine());
            var prices = new int[n];
            var canUse = new List<int>();
            var coupons = 0;

            for (int i = 0; i < n; i++)
            { // 105 150 155
                prices[i] = int.Parse(Console.ReadLine());
                if (coupons > 0 && i != 0) canUse.Add(prices[i]);
                if (prices[i] > 100 && i != n - 1) coupons++;
            }

            var sale = 0;
            while (coupons > 0 && canUse.Count > 0)
            {
                int current = canUse.Max();
                canUse.Remove(current);
                sale += current; //155 150
                coupons--;
            }



        }
    }
}

