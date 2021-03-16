using System;
using System.Collections.Generic;
using System.Text;

namespace AD
{
    public static class MyExtensions
    {
        public static string ToStringCustom(this List<int> list)
        {

            string MyString = "[";
            for (int i = 0; i < list.Count; i++)
            {
                MyString += $" {list[i]}";
                if (i != list.Count - 1)
                {
                    MyString += ",";
                }
            }

            return MyString + "]";
        }
    }
}
