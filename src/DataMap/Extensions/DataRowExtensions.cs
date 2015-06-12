using System.Data;
using DataMap.Helpers;

namespace DataMap.Extensions
{
    public static class DataRowExtensions
    {
        public static T To<T>(this DataRow row)
            where T : new()
        {
            Validation.NotNull(row);

            var poco = new T();
            var columns = row.Table.Columns;            
            var properties = poco.GetPublicProperties();

            foreach (var property in properties)
            {
                var name = property.GetMapToName();
                if (columns.Contains(name))
                {
                    var dataValue = row[name];
                    property.SetValue(poco, dataValue, null);
                }
            }

            return poco;
        }
    }
}
