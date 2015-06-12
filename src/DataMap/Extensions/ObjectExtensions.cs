using System.Reflection;

namespace DataMap.Extensions
{
    internal static class ObjectExtensions
    {
        internal static PropertyInfo[] GetPublicProperties(this object obj)
        {
            return obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }
    }
}
