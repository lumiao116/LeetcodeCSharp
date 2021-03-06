﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    class leetcode1to20
    {
        #region 1.两数之和
        /// <summary>
        /// 给定一个整数数列，找出其中和为特定值的那两个数。你可以假设每个输入都只会有一种答案，同样的元素不能被重用。
        /// tags:Array,HashTable
        /// 思路1：暴力查找，时间复杂度O(n*n)
        /// 思路2：利用哈希表（字典），存放数组的值和下标(key-value)，每次循环检查目标是否存在，然后构建哈希表
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoSum(int[] nums, int target)
        {
            if (nums.Length < 2)
            {
                return nums;
            }
            int[] res = new int[2];
            Dictionary<int, int> dic = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (dic.ContainsKey(target - nums[i]))
                {
                    res[1] = i;
                    res[0] = dic[target - nums[i]];
                    break;
                }
                if (!dic.ContainsKey(nums[i]))
                {
                    dic.Add(nums[i], i);
                }
            }
            return res;
        }
        #endregion

        #region 3. 无重复字符的最长子串
        /*题目描述*/
        /// 给定一个字符串，找出不含有重复字符的 最长子串 的长度
        /// 给定 "abcabcbb" ，没有重复字符的最长子串是 "abc" ，那么长度就是3。
        /// 给定 "bbbbb" ，最长的子串就是 "b" ，长度是1。
        /// 给定 "pwwkew" ，最长子串是 "wke" ，长度是3。请注意答案必须是一个子串，"pwke" 是 子序列 而不是子串。
        /*tags*/
        /// HashTable,String,DoublePointer  

        /// <summary>
        /// 思路1:哈希表+动态规划：用哈希表存放当前字符前一次出现的索引
        /// 状态转移：
        /// 当前字符从未出现过，则res[i]=res[i-1]+1
        /// 当前字符出现过，找到该字符前次出现的位置，并比较s[i]与s[i-1]的前索引pre
        /// //如果pre>dic[s[i]],则res[i]=res[i-1]+1
        /// //如果pre>dic[s[i]],则res[i]=i-dic[s[i]]
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int LengthOfLongestSubstring1(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }
            var dic = new Dictionary<char, int>();
            dic.Add(s[0], 0);
            int[] res = new int[s.Length];
            res[0] = 1;

            for (int i = 1; i < s.Length; i++)
            {
                if (!dic.ContainsKey(s[i]))
                {
                    dic.Add(s[i], i);
                    res[i] = res[i - 1] + 1;
                }
                else
                {
                    int pre = Math.Max(i - 1 - res[i - 1], dic[s[i]]);
                    res[i] = i - pre;
                    dic[s[i]] = i;
                }
            }
            int maxLen = res[0];
            for (int i = 0; i < res.Length; i++)
            {
                maxLen = Math.Max(maxLen, res[i]);
            }
            return maxLen;
        }

        /// <summary>
        /// 思路2
        /// 哈希表存放s中每种字符的索引值，并在出现重复时更新索引,pre记录s[i-1]的前索引和s[i]的前索引中较大值，max存放当前最大子串长度
        /// Tip1：重复使用前次记录的变量
        /// Tip2：直接存入哈希表会自动去重
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int LengthOfLongestSubstring2(string s)
        {
            Dictionary<char, int> hash = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
                hash[s[i]] = -1;
            int max = 0, pre = -1;
            for (int i = 0; i < s.Length; i++)
            {
                pre = Math.Max(pre, hash[s[i]]);
                max = Math.Max(max, i - pre);
                hash[s[i]] = i;
            }
            return max;
        }
        #endregion

        #region 4.两个排序数组的中位数
        /*题目描述*/
        //有两个大小为 m 和 n 的排序数组 nums1 和 nums2，请找出两个排序数组的中位数并且总的运行时间复杂度为 O(log (m+n)) 。
        /*tags*/
        //数组，二分查找，分治算法
        /// <summary>
        /// 思路1
        /// 遍历合并数组，两个指针跟踪两个数组
        /// left指向第一个数组，right指向第二个数组
        /// 遍历两个数组，先放小，后放大，相等同时存入list
        /// list个数为奇数，取中间值
        /// list个数为偶数，取中间两数的平均值
        /// </summary>
        /// <returns>The median sorted arrays.</returns>
        /// <param name="nums1">Nums1.</param>
        /// <param name="nums2">Nums2.</param>
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            List<int> help = new List<int>();
            int left = 0;
            int right = 0;
            while (left < nums1.Length && right < nums2.Length)
            {
                if (left < nums1.Length && right < nums2.Length)
                {
                    if (nums1[left] < nums2[right])
                    {
                        help.Add(nums1[left++]);
                    }
                    else if (nums1[left] > nums2[right])
                    {
                        help.Add(nums2[right++]);
                    }
                    else
                    {
                        help.Add(nums1[left++]);
                        help.Add(nums2[right++]);
                    }
                }
            }

            while (left < nums1.Length)
            {
                help.Add(nums1[left++]);
            }

            while (right < nums2.Length)
            {
                help.Add(nums2[right++]);
            }
            int len = help.Count() - 1;
            if ((len + 1) % 2 != 0)
            {
                return (double)help[len / 2];
            }
            else
            {
                return (double)(help[len / 2] + help[len / 2 + 1]) / 2;
            }
        }
        #endregion

        #region 5.最长回文子串
        /*问题描述*/
        //给定一个字符串 s，找到 s 中最长的回文子串。你可以假设 s 长度最长为1000。
        //输入babad，输出bab或aba
        //输入cbbd，输出bb
        //tags:字符串，动态规划
        /// <summary>
        /// 思路：动态规划法，用dp[i][j]存放i-j区间是否为回文序列(回文序列的次子序列肯定也是回文序列)
        /// dp[i][j]=s[i]==s[j]&&(j-i<2||dp[dp[start + 1, end - 1]])
        /// </summary>
        /// <returns>The palindrome.</returns>
        /// <param name="s">S.</param>
        public static string LongestPalindrome(string s)
        {
            bool[,] dp = new bool[s.Length, s.Length];
            int left = 0;
            int right = 0;
            int len = 0;

            for (int end = 0; end < s.Length; end++)
            {
                for (int start = 0; start < end; start++)
                {
                    dp[start, end] = s[start] == s[end] && (end - start < 2 || dp[start + 1, end - 1]);
                    if (dp[start, end] && end - start + 1 > len)
                    {
                        left = start;
                        right = end;
                        len = right - left + 1;
                    }
                }
                dp[end, end] = true;
            }
            return s.Substring(left, right - left + 1);
        }
        #endregion

        #region 6. Z字形变换
        /*问题描述*/
        //将字符串 "PAYPALISHIRING" 以Z字形排列成给定的行数
        /*P   A   H   N
          A P L S I I G
          Y   I   R
        //之后从左往右，逐行读取字符："PAHNAPLSIIGYIR"
        /*tags*/
        //字符串
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public static string Convert(string s, int numRows)
        {
            if (numRows <= 1)
                return s;

            StringBuilder res = new StringBuilder();
            int size = 2 * numRows - 2;
            for (int i = 0; i < numRows; i++)
            {
                for (int j = i; j < s.Length; j += size)
                {
                    res.Append(s[j]);
                    int tmp = j + size - 2 * i;
                    if (i != 0 && i != numRows - 1 && tmp < s.Length)
                    {
                        res.Append(s[tmp]);
                    }
                }
            }

            return res.ToString();
        }
        #endregion

        #region 9. 回文数
        /*问题描述*/
        //判断一个整数是否是回文数。回文数是指正序（从左向右）和倒序（从右向左）读都是一样的整数。
        //tags：数学
        /// <summary>
        /// -121不是回文数,将数字转换为字符串，通过对称性判断
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public bool IsPalindrome(int x)
        {
            string tmp = x.ToString();
            int left = 0;
            int right = tmp.Length - 1;

            while (left < right)
            {
                if (tmp[left++] != tmp[right--])
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region 10. 正则表达式匹配
        /// <summary>
        /// 给定一个字符串 (s) 和一个字符模式 (p)。实现支持 '.' 和 '*' 的正则表达式匹配。'.' 匹配任意单个字符，'*' 匹配零个或多个前面的元素。
        /// s="aa",p="a",输出false
        /// s = "aa",p = "a*",输出true
        /// s = "ab",p = ".*",输出true
        /// s = "aab",p = "c*a*b",输出true
        /// s = "mississippi",p = "mis*is*p*.",输出false
        /// tags:字符串、动态规划、回溯算法
        /// </summary>
        /// <param name="s"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool IsMatch(string s, string p)
        {
            return false;
        }
        #endregion

        #region 11. 盛最多水的容器
        /// <summary>
        /// 给定 n 个非负整数 a1，a2，...，an，每个数代表坐标中的一个点 (i, ai) 。画 n 条垂直线，使得垂直线 i 的两个端点分别为 (i, ai) 和 (i, 0)。找出其中的两条线，使得它们与 x 轴共同构成的容器可以容纳最多的水。
        /// 双指针，如果左>右，则右指针左移，否则左指针右移
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int MaxArea(int[] height)
        {
            int left = 0, right = height.Length - 1;
            int maxArea = Math.Min(height[left], height[right]) * Math.Abs(left - right);

            while (left < right)
            {
                maxArea = Math.Max(maxArea, Math.Min(height[left], height[right]) * Math.Abs(left - right));
                if (height[left] > height[right])
                    right--;
                else
                    left++;
            }
            return maxArea;
        }
        #endregion

        #region 14. 最长公共前缀
        /// <summary>
        /// 横向比较，每次比较两个字符串的，获得当前最长公共前缀，后面以此前缀为基准，比较并更新结果集
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public static string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0)
            {
                return "";
            }
            string maxCommonPrefix = strs[0];
            for (int i = 1; i < strs.Length; i++)
            {
                maxCommonPrefix = CommPrefix(maxCommonPrefix, strs[i]);
            }
            return maxCommonPrefix;
        }

        private static string CommPrefix(string a, string b)
        {
            int indexA = 0, indexB = 0;
            StringBuilder tmp = new StringBuilder();
            while (indexA < a.Length && indexB < b.Length)
            {
                if (a[indexA] == b[indexB])
                {
                    tmp.Append(a[indexA]);
                    indexA++;
                    indexB++;
                }
                else
                {
                    break;
                }
            }
            return tmp.ToString();
        }

        /// <summary>
        /// 纵向比较，每次比较每个字符串的第i位，当存在不相等的字符时，返回结果，否则结果集写入一个字符
        /// </summary>
        /// <returns>The common prefix.</returns>
        /// <param name="strs">Strs.</param>
        public static string LongestCommonPrefix2(string[] strs)
        {
            if (strs == null || strs.Length == 0)
            {
                return "";
            }

            StringBuilder maxCommonPrefix = new StringBuilder();
            char ch;
            for (int i = 0; i < strs[0].Length; i++)
            {
                ch = strs[0][i];
                for (int j = 1; j < strs.Length; j++)
                {
                    if (strs[j].Length - 1 < i || strs[j][i] != ch)
                        return maxCommonPrefix.ToString();
                }
                maxCommonPrefix.Append(ch);
            }
            return maxCommonPrefix.ToString();
        }
        #endregion

        #region 15.三数之和
        /// <summary>
        /// Threes the sum.给定一个包含 n 个整数的数组 nums，判断 nums 中是否存在三个元素 a，b，c ，使得 a + b + c = 0 ？找出所有满足条件且不重复的三元组。
        /// tags:数组，双指针
        ///  </summary>
        /// <returns>The sum.</returns>
        /// <param name="nums">Nums.</param>
        public  static IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> res = new List<IList<int>>();
            if (nums.Length < 3)
            {
                return res;
            }
            Array.Sort(nums);
            for (int i = 0; i < nums.Length-1;i++)
            {
                int low = i + 1;
                int high = nums.Length - 1;
                IList<int> tmp = new List<int>();
                while(low<high)
                {
                    int sum = nums[i] + nums[low] + nums[high];
                    if(sum==0)
                    {
                        tmp.Add(nums[i]);
                        tmp.Add(nums[low]);
                        tmp.Add(nums[high]);
                        break;
                    }
                    else if(sum>0)
                    {
                        high--;
                    }
                    else
                    {
                        low++;
                    }
                }
                if(tmp.Count()>0)
                {
                    res.Add(tmp);
                }
            }
            return res;
        }
        #endregion
    }
}
