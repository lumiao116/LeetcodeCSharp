using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    class String_Medium
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

        #region 392. 判断子序列
        public bool IsSubsequence(string s, string t)
        {
            if (t.Length < s.Length)
                return false;

            int len = s.Length;
            int prev = 0;

            for (int i = 0; i < len; i++)
            {
                char tmpchar = s[i];
                prev = t.IndexOf(tmpchar,prev);
                if (prev == -1)
                    return false;

                prev++;
            }
            return true;
        }
        #endregion

        #region 551. 学生出勤纪录 I
        public static bool CheckRecord(string s)
        {
            if (string.IsNullOrEmpty(s))
                return false;

            int countA = 0;
            int countB = 0;

            for(int i=0;i<s.Length;i++)
            {
                if(s[i]=='A')
                {
                    countB = 0;
                    countA++;
                    {
                        if (countA > 1)
                            return false;
                    }
                }
                else if(s[i]=='L')
                {
                    countB++;
                    if (countB > 2)
                        return false;
                }
                else
                {
                    countB = 0;
                }
            }
            return true;
            
        }
        #endregion

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
