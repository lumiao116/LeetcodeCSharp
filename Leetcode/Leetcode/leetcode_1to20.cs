using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    class leetcode_1to20
    {
        #region 1.两数之和manx
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
            if(nums.Length<2)
            {
                return nums;
            }
            int[] res = new int[2];
            Dictionary<int, int> dic = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length;i++)
            {
                if(dic.ContainsKey(target-nums[i]))
                {
                    res[1] = i;
                    res[0] = dic[target - nums[i]];
                    break;
                }
                if(!dic.ContainsKey(nums[i]))
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

            for(int i=1;i<s.Length;i++)
            {
                if(!dic.ContainsKey(s[i]))
                {
                    dic.Add(s[i], i);
                    res[i] = res[i - 1] + 1;
                }
                else
                {
                    int pre = Math.Max(i-1-res[i-1], dic[s[i]]);
                    res[i] = i - pre;
                    dic[s[i]] = i;
                }
            }
            int maxLen = res[0];
            for(int i=0;i<res.Length;i++)
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
    }
}
