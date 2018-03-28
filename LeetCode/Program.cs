using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "Let's take LeetCode contest";
            string result=Leetcode_Easy.ReverseWords(s);
            Console.WriteLine(result);
            Console.Read();
        }
    }
}
