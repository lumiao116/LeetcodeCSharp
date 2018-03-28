using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class Leetcode_Easy
    {
        #region 
        public static int[] TwoSum(int[] nums, int target)
        {
            int[] result = new int[2];

            if (nums == null || nums.Length < 2)
                return null;

            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        result[0] = i;
                        result[1] = j;
                        break;
                    }
                }
            }
            return result;
        }
        #endregion

        #region 771 宝石与石头
        public int NumJewelsInStones(string J, string S)
        {
            char[] charJ = J.ToArray();
            char[] charS = S.ToArray();
            int count = 0;

            for (int i = 0; i < charJ.Length; i++)
            {
                for (int j = 0; j < charS.Length; j++)
                {
                    if (charS[j] == charJ[i])
                        count++;
                }
            }
            return count;
        }
        #endregion

        #region 344 翻转字符串
        public static string ReverseString(string s)
        {
            char[] chas = s.ToCharArray();
            Array.Reverse(chas);
            return new string(chas);
        }
        #endregion

        #region 728 自除数
        public static IList<int> SelfDividingNumbers(int left, int right)
        {
            IList<int> list=new List<int>();
            for(int num=left;num<=right;num++)
            {
                if (IsSelfdividingNum(num) == true)
                    list.Add(num);
            }
            return list;
        }

        public static bool IsSelfdividingNum(int num)
        {
            int tmp=num;
            int flag=0;
            while(tmp!=0)
            {
                flag=tmp%10;
                if (flag == 0 || num % flag != 0)
                    return false;
                tmp /= 10;
            }
            return true;
        }
        #endregion

        #region 744 大于目标字符的最小字符
        public char NextGreatestLetter(char[] letters, char target)
        {
            if(letters==null)
                return default(char);

            Array.Sort(letters);
            for (int i = 0; i < letters.Length; i++)
            {
                if (letters[i] > target)
                {
                    return letters[i];
                }
                if (i == letters.Length - 1 && letters[i] <= target)
                {
                    return letters[0];
                }

            }
            return default(char);
        }
        #endregion

        #region 657 回到原点
        public bool JudgeCircle(string moves)
        {
            int x = 0;
            int y = 0;
            char[] moveto = moves.ToCharArray();
            foreach(char m in moveto)
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

        #region 557 翻转句子的每个单词
        public static string ReverseWords(string s)
        {
            string[] ss = s.Split(' ');
            string result = "";
            for (int i = 0; i < ss.Length;i++ )
            {
                if (i == 0)
                {
                    result = ReverseString(ss[i]);
                }
                else
                {
                    result = result + " " + ReverseString(ss[i]);
                }
            }
            return result;
        }
        #endregion
    }
}
