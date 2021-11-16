using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class DateHelpers
    {
        public static string ToDateInputValue_Mt(this DateTime d)
        {
            return d.ToString("yyyy-MM-dd");
        }
    }
}
