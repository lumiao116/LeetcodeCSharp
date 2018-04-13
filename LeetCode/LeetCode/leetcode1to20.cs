using System;
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
        /*tags*/
        //字符串，动态规划
        /// <summary>
        /// 思路：动态规划法，用dp[i][j]存放i-j区间是否为回文序列(回文序列的次子序列肯定也是回文序列)
        /// dp[i][j]=s[i]==s[j]&&(j-i<2||dp[dp[start + 1, end - 1]])
        /// </summary>
        /// <returns>The palindrome.</returns>
        /// <param name="s">S.</param>
        public static string LongestPalindrome(string s)
        {
            bool[,] dp = new bool[s.Length,s.Length];
            int left=0;
            int right=0;
            int len=0;
            
            for(int end=0;end<s.Length;end++)
            {
                for(int start=0;start<end;start++)
                {
                    dp[start, end] = s[start] == s[end] && (end - start < 2 || dp[start + 1, end - 1]);
                    if(dp[start,end]&&end-start+1>len)
                    {
                        left=start;
                        right=end;
                        len=right-left+1;
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
          Y   I   R*/
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
            
        }
        #endregion
    }
}
