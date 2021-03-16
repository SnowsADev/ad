using System;
using System.Collections.Generic;
using System.Text;

namespace AD
{
    public static class MyExtensions
    {
        /// <summary>
        /// This function creates a string from the list and returns it. example: [1,2,3]
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string ToStringCustom(this List<int> list)
        {
            if (list.Count <= 0) return "[]";

            string result = "[";
            for(int i = 0; i < list.Count; i++)
            {
                result += list[i].ToString();
                if (i != list.Count - 1) result += ",";
            }
            return result + "]";
        }
    }
}
