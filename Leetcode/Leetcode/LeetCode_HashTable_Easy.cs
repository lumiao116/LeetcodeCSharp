using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    class LeetCode_HashTable_Easy
    {
        #region 217. 存在重复
        public static bool ContainsDuplicate(int[] nums)
        {
            if(nums.Length<=1 || nums==null)
                return false;

            Dictionary<int, int> numDic = new Dictionary<int, int>();

            foreach(int item in nums)
            {
                if (numDic.ContainsKey(item))
                    return true;
                else
                    numDic.Add(item, 1);
            }

            return false;
        }
        #endregion

        #region 349. 两个数组的交集
        public static int[] Intersection(int[] nums1, int[] nums2)
        {
            if (nums1 == null || nums2 == null)
                return null;
            if(nums1.Length<1||nums2.Length<1)
                return new int[0];

            HashSet<int> hst1 = new HashSet<int>(nums1);
            HashSet<int> hst2 = new HashSet<int>(nums2);
            int[] res = new int[Math.Max(nums1.Length, nums2.Length)];

            foreach(int item in hst1)
            {
                if(hst2.Contains(item))
                {

                }
            }
        }
        #endregion
    }
}
