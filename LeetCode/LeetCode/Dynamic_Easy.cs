using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCode
{
    class LeetCode_Dynamic_Easy
    {
        #region 53. 最大子序和
        public int MaxSubArray(int[] nums)
        {
            if (nums.Length < 1 || nums == null)
                return 0;

            int[] path = new int[nums.Length];
            if (nums.Length == 1)
                return nums[0];

            path[0] = nums[0];
            int max = path[0];

            for (int i = 1; i < nums.Length; i++)
            {
                if (path[i - 1] < 0)
                    path[i] = nums[i];
                else
                    path[i] = path[i - 1] + nums[i];

                max = Math.Max(max, path[i]);
            }
            return max;
        }
        #endregion

        #region 70.爬楼梯
        public int ClimbStairs(int n)
        {
            if (n == 0 || n == 1 || n == 2)
                return n;

            int[] upSolutions = new int[n + 1];
            upSolutions[1] = 1;
            upSolutions[2] = 2;

            for (int i = 3; i <= n; i++)
            {
                upSolutions[i] = upSolutions[i - 1] + upSolutions[i - 2];
            }

            return upSolutions[n];
        }
        #endregion

        #region 121. 买卖股票的最佳时机
        public int MaxProfit(int[] prices)
        {
            int max = 0;
            if (prices.Length <= 1 || prices == null)
                return 0;

            int minPrice = prices[0];
            for (int i = 1; i < prices.Length; i++)
            {
                max = Math.Max(max, prices[i] - minPrice);
                minPrice = Math.Min(minPrice, prices[i]);
            }
            return max;
        }
        #endregion

        #region 198. 打家劫舍
        public int Rob(int[] nums)
        {
            int len = nums.Length;
            if (len < 1 || nums == null)
                return 0;
            if (len == 1)
                return nums[0];

            if (len == 2)
                return Math.Max(nums[0], nums[1]);

            int[] solution = new int[nums.Length];
            solution[0] = nums[0];
            solution[1] = Math.Max(nums[0], nums[1]);

            for (int i = 2; i < nums.Length; i++)
            {
                solution[i] = Math.Max(solution[i - 1], solution[i - 2] + nums[i]);
            }
            return Math.Max(solution[nums.Length - 1], solution[nums.Length - 2]);
        }
        #endregion        

        #region 746. 使用最小花费爬楼梯
        public int MinCostClimbingStairs(int[] cost)
        {
            int stairsNum = cost.Length + 1;
            if (cost.Length < 1 || cost == null)
                return 0;
            if (stairsNum == 1)
                return 0;
            if (stairsNum == 2)
                return 0;

            int[] mincost = new int[stairsNum];
            mincost[0] = 0;
            mincost[1] = 0;

            for (int i = 2; i < stairsNum; i++)
            {
                mincost[i] = Math.Min(mincost[i - 2] + cost[i - 2], mincost[i - 1] + cost[i - 1]);
            }
            return mincost[stairsNum - 1];
        }
        #endregion
    }
}