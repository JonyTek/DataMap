using System.Reflection;

namespace DataMap.Extensions
{
    internal static class ObjectExtensions
    {
        /// <summary>
        /// Get properties per object extension
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal static PropertyInfo[] GetPublicProperties(this object obj)
        {
            return obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }
    }
}
