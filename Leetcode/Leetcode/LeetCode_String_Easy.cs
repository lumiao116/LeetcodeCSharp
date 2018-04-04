using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Leetcode
{
    class LeetCode_String_Easy
    {
        #region 38. 数数并说
        public static string CountAndSay(int n)
        {
            if (n <= 0) return "";
            StringBuilder res = new StringBuilder("1");
            int count = 1;

            for(int num=2;num<=n;num++)
            {
                StringBuilder cur = new StringBuilder("");
                for(int i=0;i<res.Length;i++)
                {
                    for(int j=i+1;j<res.Length;j++)
                    {
                        if(res[j]==res[i])
                        {
                            count++;
                        }                           
                        else
                        {
                            break;
                        }                                                 
                    }
                    cur.Append(count.ToString());
                    cur.Append(res[i].ToString());
                    i +=  count-1;
                    count = 1;                
                }
                res = cur;
            }
            return res.ToString();
        }

        public static string CountAndSay1(int n)
        {
            StringBuilder strResult = new StringBuilder();
            if (n <= 0)
            {
                return strResult.ToString();
            }
            strResult.Append("1");
            int strCount;
            for (int num = 2; num <= n; num++)
            {
                StringBuilder strPre = new StringBuilder(strResult.ToString());
                strResult.Clear();
                strCount = 0;
                for (int i = 0; i < strPre.Length; i++)
                {
                    strCount = 0;
                    for (int j = i; j < strPre.Length; j++)
                    {
                        if (strPre[i].Equals(strPre[j]))
                        {
                            strCount++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    i += (strCount - 1);
                    strResult.Append(strCount.ToString());
                    strResult.Append(strPre[i]);
                }
            }
            return strResult.ToString();
        }
        #endregion

        #region 344. 反转字符串
        public  static string ReverseString(string s)
        {
            StringBuilder strB = new StringBuilder();
            char[] chars = s.ToCharArray();
            if (chars == null || chars.Length == 0)
            {
                return s;
            }
            for (int i = chars.Length - 1; i >= 0; i--)
            {
                strB.Append(chars[i]);
            }
            return strB.ToString();
        }
        #endregion

        #region 383. 赎金信
        public static bool CanConstruct(string ransomNote, string magazine)
        {
            if (ransomNote.Length > magazine.Length)
                return false;

            Dictionary<char, int> magDic = new Dictionary<char, int>();
            char[] mags = magazine.ToCharArray();
            char[] rans = ransomNote.ToCharArray();
            for(int i=0;i<mags.Length;i++)
            {
                if(magDic.ContainsKey(mags[i]))
                {
                    magDic[mags[i]]++;
                }
                else
                {
                    magDic.Add(mags[i], 1);
                }
            }

            for(int j=0;j<rans.Length;j++)
            {
                if (!magDic.ContainsKey(rans[j]))
                    return false;
                else
                {
                    if(magDic[rans[j]]<1)
                        return false;
                    else
                        magDic[rans[j]]--;
                }
            }
            return true;
        }
        #endregion

        #region 520. 检测大写字母
        public bool DetectCapitalUse(string word)
        {
            int count = 0;
            for(int i=0;i<word.Length;i++)
            {
                if (word[i] <= 'Z')
                    count++;
            }
            return count == 0 || count == word.Length || (count == 1 && word[0] <= 'Z');
        }
        #endregion

        #region 521. 最长特殊序列 Ⅰ
        public int FindLUSlength(string a, string b)
        {
            return a == b ? -1 : Math.Max(a.Length, b.Length);
        }
        #endregion

        #region 541. 翻转字符串2
        public  static string ReverseStr(string s, int k)
        {
            StringBuilder res = new StringBuilder("");
            string cur;
            for(int i=0;i<s.Length;i=i+2*k)
            {
                if(i+2*k<=s.Length-1)
                {
                    cur = ReverseString1(s.Substring(i, 2*k),0,k-1);
                    res.Append(cur);
                }
                else
                {
                    if(i+k-1<=s.Length-1)
                    {
                        cur = ReverseString1(s.Substring(i), 0, k-1);
                        res.Append(cur);
                        break;
                    }
                    else
                    {
                        cur = ReverseString1(s.Substring(i), 0, s.Substring(i).Length-1);
                        res.Append(cur);
                        break;
                    }
                }
            }
            return res.ToString();
        }

        public static string ReverseString1(string s,int left,int right)
        {
            char[] chars = s.ToCharArray();

            int i = left;
            char temp;
            int j = right;
            while(i<j)
            {
                temp = chars[i];
                chars[i] = chars[j];
                chars[j] = temp;
                i++;
                j--;
            }
            return new string(chars);
        }
        #endregion

        #region 557. 反转字符串中的单词 III
        public string ReverseWords(string s)
        {
            if (s == null || s.Length <= 1)
                return s;

            int left = 0;
            int right = 0;
            int len = s.Length;
            string res = s;

            while(left<len&&right<len)
            {
                while (right < len && res[right] != ' ')
                    ++right;

                for(int i=left,j=right-1;i<j;i++,j--)
                {
                    ReverseString(res.Substring(i, j - 1 + 1));
                }
                left = right + 1;
            }
            return res;
        } 

        public static void swap(char a,char b)
        {
            char c = a;
            a = b;
            b = c;
        }
        #endregion

        #region 657. 判断路线成圈
        public bool JudgeCircle(string moves)
        {
            int x = 0;
            int y = 0;
            char[] moveto = moves.ToCharArray();
            foreach (char m in moveto)
            {
                if (m == 'L')
                    x--;
                else if (m == 'R')
                    x++;
                else if (m == 'U')
                    y++;
                else if (m == 'D')
                    y--;
            }
            if (x == 0 && y == 0)
                return true;
            else
                return false;
        }
        #endregion



        public static object Dictionary { get; set; }
    }
}
