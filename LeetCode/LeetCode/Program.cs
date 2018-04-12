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
            int[] num = new int[1] { 1};
            int[] num2 = new int[8] { 3, 3, 4 ,5,6,7,8,9};

            string s = "abba";
            int flowered = leetcode_1to20.LengthOfLongestSubstring2(s);
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
