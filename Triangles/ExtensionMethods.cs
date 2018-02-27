using System;
using System.Collections.Generic;
using System.Text;

namespace Triangles
{
   internal static class ExtensionMethods
    {
        internal static bool IsOdd(this int value)
        {
            return value % 2 != 0;
        }

    }
}
