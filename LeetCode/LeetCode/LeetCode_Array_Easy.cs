using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class LeetCode_Array_Easy
    {
        #region 119.帕斯卡三角形II
        //public IList<int> GetRow(int rowIndex)
        //{

        //}
        #endregion

        #region 283.移动0
        public void MoveZeroes(int[] nums)
        {
            int pos = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                    nums[pos++] = nums[i];
            }
            for (; pos < nums.Length; pos++)
            {
                nums[pos] = 0;
            }
        }
        #endregion

        #region 532.K-diff Pairs in an Array
        public int FindPairs(int[] nums, int k)
        {
            if (nums == null || nums.Length < 2 || k<0)
                return 0;

            HashSet<int> hst = new HashSet<int>();
            for(int i=0;i<nums.Length;i++)
            {
                for(int j=i+1;j< nums.Length; j++)
                {
                    if (nums[i] - nums[j] == k)
                        hst.Add(nums[j]);
                    else if (nums[j] - nums[i] == k)
                        hst.Add(nums[i]);
                }
            }
            return hst.Count;
        }
        #endregion

        #region 561.数组拆分
        public int ArrayPairSum(int[] nums)
        {
            if (nums == null || nums.Length % 2 != 0)
                return 0;

            Array.Sort(nums);
            int result = 0;
            for (int i = 0; i < nums.Length; i = i + 2)
            {
                result += nums[i];
            }
            return result;
        }
        #endregion

        #region 747.至少是其他数字两倍的最大数
        public int DominantIndex(int[] nums)
        {
            if (nums == null || nums.Length < 2)
                return 0;

            int maxIndex = 0;
            for(int i=0;i<nums.Length;i++)
            {
                maxIndex = nums[i] > nums[maxIndex] ? i : maxIndex;
            }
            for(int i=0;i<nums.Length;i++)
            {
                if (i == maxIndex)
                    continue;
                else if (nums[i] * 2 > nums[maxIndex])
                    return -1;
            }
            return maxIndex;

        }
        #endregion

        #region 766.托普利茨矩阵
        public static bool IsToeplitzMatrix(int[,] matrix)
        {
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);

            for(int i=0;i<row-1;i++)
            {
                for(int j=0;j<col-1;j++)
                {
                    if (matrix[i,j] != matrix[i + 1,j + 1])
                        return false;
                }
            }
            return true;
        }
        #endregion

        





    }
} 
