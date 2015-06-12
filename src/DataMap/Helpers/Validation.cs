using System;
using System.Linq;

namespace DataMap.Helpers
{
    internal static class Validation
    {
        internal static void NotNull(params object[] objects)
        {
            foreach (var o in objects.Where(o => o == null))
            {
                throw new ArgumentException(o.GetType().FullName);
            }
        }

        internal static void IsTrue(bool isTrue, string message)
        {
            if (!isTrue) throw new ArgumentException(message);
        }
    }
}