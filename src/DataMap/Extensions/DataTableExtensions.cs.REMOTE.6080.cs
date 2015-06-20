using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;

namespace DataMap.Extensions
{
    public static class DataTableExtensions
    {
        /// <summary>
        /// Run a function over each element in a data table
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <param name="function"></param>
        /// <returns></returns>
        public static IEnumerable<T> ForEachRow<T>(this DataTable table, Func<DataRow, T> function)
            where T : class, new()
        {
            if (table.IsEmpty()) return null;

            return from DataRow row in table.Rows select function(row);
        }

        /// <summary>
        /// Run a function over each poco contained in a data table
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <param name="function"></param>
        /// <returns></returns>
        public static IEnumerable<T> ForEachPoco<T>(this DataTable table, Func<T, T> function)
            where T : class, new()
        {
            if (table.IsEmpty()) return null;

            var updated = new Collection<T>();
            foreach (var poco in from DataRow row in table.Rows select row.To<T>())
            {
                updated.Add(function(poco));
            }

            return updated;
        }

        /// <summary>
        /// Filter a collection by boolean function
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <param name="function"></param>
        /// <returns></returns>
        public static IEnumerable<T> Where<T>(this DataTable table, Func<T, bool> function)
           where T : class, new()
        {
            if (table.IsEmpty()) return null;

            var pocos = new Collection<T>();
            foreach (var poco in table.Rows
                .Cast<DataRow>()
                .Select(row => row.To<T>())
                .Where(function))
            {
                pocos.Add(poco);
            }

            return pocos;
        }

        /// <summary>
        /// Select a single column for each element in a table
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static IEnumerable<T> SelectColumn<T>(this DataTable table, string columnName)
        {
            if (table.IsEmpty()) return null;

            var values = new Collection<T>();

            foreach (DataRow row in table.Rows) values.Add((T)row[columnName]);

            return values;
        }

        /// <summary>
        /// Simple data table to poco enumerable 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <returns></returns>
        public static IEnumerable<T> ToEnumerableOf<T>(this DataTable table)
            where T : class, new()
        {
            return table.IsEmpty() ? null : table.ForEachRow(row => row.To<T>());
        }

        /// <summary>
        /// Get first row as poco
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <returns></returns>
        public static T FirstOrDefault<T>(this DataTable table)
            where T : class, new()
        {
            return table.IsEmpty() ? null : table.Rows[0].To<T>();
        }

        /// <summary>
        /// Is data table empty
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static bool IsEmpty(this DataTable table)
        {
            return table == null || table.Rows.Count == 0;
        }

        /// <summary>
        /// Is data table not empty
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static bool IsNotEmpty(this DataTable table)
        {
            return !IsEmpty(table);
        }
    }
}
