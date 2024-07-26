using System;

class TinkoffNine
{
    private static int[][] memo;
    private static int[] cost;

    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        cost = new int[n];
        memo = new int[n + 1][];
        for (int i = 0; i <= n; i++)
        {
            memo[i] = new int[n + 1];
            for (int j = 0; j < memo[i].Length; j++)
            {
                memo[i][j] = -1;
            }
        }
        for (int i = n - 1; i >= 0; i--)
        {
            cost[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine(Traverse(n, 0));

        Console.ReadKey();
    }

    private static int Traverse(int day, int coupons)
    {
        if (day == 0) return 0;
        if (memo[day][coupons] != -1) return memo[day][coupons];

        int payment = int.MaxValue;

        // не используем купон
        if (cost[day - 1] > 100)
        {
            payment = Math.Min(payment, cost[day - 1] + Traverse(day - 1, coupons + 1));
        }
        else
        {
            payment = Math.Min(payment, cost[day - 1] + Traverse(day - 1, coupons));
        }

        // используем купон
        if (coupons > 0)
        {
            payment = Math.Min(payment, Traverse(day - 1, coupons - 1));
        }

        memo[day][coupons] = payment;
        return payment;
    }
}