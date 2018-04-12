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
            var leet = new leetcodeFROM1TO20();
            int[] num = new int[22] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22};
            int[] num2 = new int[2] {0,6};

            //string s = "abba";
            double flowered = leetcodeFROM1TO20.FindMedianSortedArrays(num,num2);
                //stp.Start();
                //string res = LeetCode_String_Medium.StringSort(s);
                //string[] strs = new string[2] { "", ""};
                //bool bo=Array_Easy
             Console.WriteLine(flowered);
            //stp.Stop();
            //Console.WriteLine(bo);
               
            Console.ReadKey();
        }
    }
}
