using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
            //Stopwatch gettime = new Stopwatch();
            //gettime.Start();
            //for (int i = 1; i <= 50;i++ )
            //{
            //    Console.WriteLine(LeetCode_String_Easy.CountAndSay(i));
            //}
            //gettime.Stop();
            //Console.WriteLine(gettime.ElapsedMilliseconds.ToString());
            int[] num = new int[0] { };
            int[] num2 = new int[1] { 1 };
            LeetCode_HashTable_Easy.Intersection(num,num2);
               
            Console.ReadKey();
        }
    }
}
