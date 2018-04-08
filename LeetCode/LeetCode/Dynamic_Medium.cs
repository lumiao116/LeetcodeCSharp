using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class LeetCode_Dynamic_Medium
    {
        #region 5. 最长回文子串
        public static string LongestPalindrome(string s)
        {
            return null;
        }

        public static bool isPalindrome(string s,int i,int j)
        {
            string subs = s.Substring(i, j-i+1);
            char[] chas = subs.ToCharArray();

            while(i<j)
            {
                if (chas[i++] != chas[j--])
                    return false;
            }
            return true;
        }
        #endregion

        #region 64. 最小路径和
        public static int MinPathSum(int[,] grid)
        {
            int row = grid.GetLength(0);
            int col = grid.GetLength(1);
            int[,] minsum = new int[row, col];

            minsum[0, 0] = grid[0, 0];

            for (int i = 1; i < row; i++)
                minsum[i, 0] = minsum[i - 1, 0] + grid[i, 0];

            for (int i = 1; i < col; i++)
                minsum[0, i] = minsum[0, i - 1] + grid[0, i];


            for (int i = 1; i < row; i++)
            {
                for (int j = 1; j < col; j++)
                    minsum[i, j] = Math.Min(minsum[i - 1, j], minsum[i, j - 1]) + grid[i, j];
            }

            return minsum[row - 1, col - 1];
        }
        #endregion

        #region 322.零钱兑换
        public static int CoinChange(int[] coins, int amount)
        {
            if (coins.Length < 1 || amount < 0) return -1;

            int[] solution = new int[amount + 1];
            solution[0] = 0;
            Array.Sort(coins);

            for (int money = 1; money <= amount; money++)
            {
                solution[money] = amount + 1;
                for (int index = 0; index < coins.Length; index++)
                {
                    if (money >= coins[index])
                    {
                        solution[money] = Math.Min(solution[money], solution[money - coins[index]] + 1);
                    }
                }
            }
            return solution[amount] > amount ? -1 : solution[amount];
        }
        #endregion

       
    }
}
