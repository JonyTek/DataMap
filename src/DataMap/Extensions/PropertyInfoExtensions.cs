using System.Linq;
using System.Reflection;

namespace DataMap.Extensions
{
    internal static class PropertyInfoExtensions
    {
        internal static string GetMapToName(this PropertyInfo property)
        {
            var attribute =  property.GetCustomAttributes<MapToAttribute>().FirstOrDefault();

            return attribute != null ? attribute.ColumnName : property.Name;
        }
    }
}