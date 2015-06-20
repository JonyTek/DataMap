using System.Linq;
using System.Reflection;

namespace DataMap.Extensions
{
    internal static class PropertyInfoExtensions
    {
        /// <summary>
        /// If map to attribute exists return value else return property name
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        internal static string GetMapToName(this PropertyInfo property)
        {
            var attribute = property.GetCustomAttributes<MapToAttribute>().FirstOrDefault();

            return attribute != null ? attribute.ColumnName : property.Name;
        }
    }
}