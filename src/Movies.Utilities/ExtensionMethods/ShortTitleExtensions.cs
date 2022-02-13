using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    public static class ShortTitleExtensions
    {
        public static string GetShortTitle(this string title)
        => string.Concat(title.Replace(" ", "").Where(x => char.IsUpper(x)));
    }
}
