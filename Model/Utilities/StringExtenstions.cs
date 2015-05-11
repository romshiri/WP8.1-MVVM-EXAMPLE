using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Romfix.Model.Utilities
{
    public static class StringExtenstions
    {
        public static T ToEnum<T>(this string value, bool ignoreCase = false)
        {
            return (T)Enum.Parse(typeof(T), value, ignoreCase);
        }
    }
}
