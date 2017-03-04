using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inevitable
{
    public static class StringExtensions
    {
        /// <summary>
        /// Compares two strings together without considering their case
        /// That is. StRinG is equal to strinG
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public static bool EqualsCaseless(this string t1, string t2)
        {
            if (t1.ToUpper().Equals(t2.ToUpper()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
