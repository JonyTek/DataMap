using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DataMap.Helpers;

namespace DataMap.Extensions
{
    public static class DataTableExtensions
    {
        public static IEnumerable<T> ForEachRow<T>(this DataTable table, Func<DataRow, T> function)
        {
            Validation.NotNull(function);

            if (table.IsEmpty()) return null;

            return from DataRow row in table.Rows select function(row);
        }

        public static IEnumerable<T> ToEnumerableOf<T>(this DataTable table)
            where T : new()
        {
            return table.IsEmpty() ? null : table.ForEachRow(row => row.To<T>());
        }

        public static T ToFirsRow<T>(this DataTable table)
            where T : class, new()
        {
            return table.IsEmpty() ? null : table.Rows[0].To<T>();
        }

        public static bool IsEmpty(this DataTable table)
        {
            return table == null || table.Rows.Count == 0;
        }

        public static bool IsNotEmpty(this DataTable table)
        {
            return !IsEmpty(table);
        }
    }
}
