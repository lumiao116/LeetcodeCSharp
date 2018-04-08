using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    class Array_Medium
    {
        #region 子集
        public static IList<IList<int>> Subsets(int[] nums)
        {
            IList<IList<int>> res = new List<IList<int>>();

            IList<int> tmp = new List<int>();
            res.Add(tmp);
            for (int i = 0; i < nums.Length; i++)
            {
                int size = res.Count;
                for (int j = 0; j < size; j++)
                {
                    IList<int> ss = DeepCopy(res[j]);
                    res.Add(ss);
                    res[res.Count - 1].Add(nums[i]);
                }
            }
            return res;
        }

        private static IList<int> DeepCopy(IList<int> origialList)
        {
            List<int> newList = null;
            if (origialList == null)
            {
                return newList;
            }

            newList = new List<int>();

            List<int> temp = origialList as List<int>;

            if (temp == null)
            {
                return newList;
            }

            temp.ForEach(item => {
                newList.Add(item);
            });
            return newList;
        }
        #endregion
    }
}
