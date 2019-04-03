using System.Collections.Generic;

namespace NET1.S._2019.Tsyvis._07.Sort
{
    /// <summary>
    /// Provide compare string by length.
    /// </summary>
    /// <seealso cref="System.Collections.Generic.IComparer{System.String}" />
    public class LengthDescendingComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x.Length > y.Length)
            {
                return 1;
            }

            if (x.Length < y.Length)
            {
                return -1;
            }

            return 0;
        }
    }
}
