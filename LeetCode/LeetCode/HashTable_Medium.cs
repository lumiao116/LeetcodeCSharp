using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    class HashTable_Medium
    {
        #region 49. 字谜分组
        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            IList<IList<string>> res = new List<IList<string>>();
            Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();

            for (int i = 0; i < strs.Length; i++)
            {
                string sortedStr = StringSort(strs[i]);

                if (dic.ContainsKey(sortedStr))
                {
                    dic[sortedStr].Add(strs[i]);
                }
                else
                {
                    List<string> tmp = new List<string>();
                    tmp.Add(strs[i]);
                    dic.Add(sortedStr, tmp);
                }
            }

            foreach (var k in dic.Keys)
            {
                res.Add(dic[k]);
            }

            return res;
        }


        public static string StringSort(string str)
        {
            List<char> strList = new List<char>(str);
            strList.Sort();
            string res = "";
            foreach (char ch in strList)
            {
                res += ch;
            }
            return res;
        }
        #endregion
    }
}
