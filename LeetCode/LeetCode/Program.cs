using System;
using System.Diagnostics;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] Arr = new int[2, 3] { { 1, 2, 5 }, { 3, 2, 1 } };
            int s = LeetCode_Dynamic_Medium.MinPathSum(Arr);
            Console.WriteLine(s);
            Console.Read();
        }
    }
}