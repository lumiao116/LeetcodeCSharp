using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    class LeetCode_String_Medium
    {
        
        #region 22. 括号生成
        public static IList<string> res = new List<string>();
        /// <summary>
        /// http://www.mamicode.com/info-detail-1064376.html
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static IList<string> GenerateParenthesis(int n)
        {
            generateLeftsAndRights("",n,n);
            return res;
        }

        private static void generateLeftsAndRights(string subList,int left, int right)
        {
            if (left > right)
                return;

            if (left > 0)
                generateLeftsAndRights(subList + "(", left - 1, right);

            if (right > 0)
                generateLeftsAndRights(subList + ")", left, right - 1);

            if (left == 0 && right == 0)
            {
                res.Add(subList);
                return;
            }
        }
        #endregion

        #region 49. 字谜分组
        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            IList<IList<string>> res = new List<IList<string>>();
            Hashtable hst = new Hashtable();
            foreach (string str in strs)
            {
                hst.Add(str, StringSort(str));
            }

            
            return res;
        }
        #endregion

        public static string StringSort(string str)
        {
            List<char> strList = new List<char>(str);
            strList.Sort();
            string res = "";
            foreach(char ch in strList)
            {
                res += ch;
            }
            return res;
        }

        #region 647. 回文子串
        public static int CountSubstrings(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;
            int count = 0;
            int[,] isPalindrome = new int[s.Length, s.Length];
            for(int i=0;i<s.Length;i++)
            {
                for(int j=0;j<s.Length;j++)
                {
                    if (i == j)
                    {
                        isPalindrome[i, j] = 1;
                        count++;
                    }                        
                    else if(i<j)
                    {
                        if(IsPalindromeString(s,i,j)==true)
                        {
                            isPalindrome[i, j] = 1;
                            count++;
                        }
                        else
                            isPalindrome[i, j] = 0;
                    }
                }
            }
            return count;
        }
        public static bool IsPalindromeString(string s, int left, int right)
        {
            int start = left;
            int end = right;
            while (start < end)
            {
                if (s[start++] != s[end--])
                    return false;
            }
            return true;
        }
        #endregion
    }
}
