using System.Data;

namespace DataMap.Extensions
{
    public static class DataRowExtensions
    {
        /// <summary>
        /// Perform data row to poco conversion
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="row"></param>
        /// <returns></returns>
        public static T To<T>(this DataRow row)
            where T : class, new()
        {
            if (row == null) return null;

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
