using System;
using System.Diagnostics;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] coins = new int[1] { 2 };
            int amount = 3;
            Stopwatch watch = new Stopwatch();
            watch.Start();
            int solution = LeetCode_Dynamic_Easy.CoinChange(coins, amount);
            watch.Stop();
            Console.WriteLine(solution);
            Console.WriteLine("time: " + (watch.ElapsedMilliseconds));
            Console.ReadKey();
        }
    }
}