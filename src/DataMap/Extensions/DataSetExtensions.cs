using DataMap.Helpers;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataMap.Extensions
{
    public static class DataSetExtensions
    {
        /// <summary>
        /// Run a function over each element in a data table accessed by index
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataSet"></param>
        /// <param name="function"></param>
        /// <param name="tableIndex"></param>
        /// <returns></returns>
        public static IEnumerable<T> ForEachRow<T>(this DataSet dataSet, Func<DataRow, T> function, int tableIndex = 0)
            where T : class, new()
        {
            if (dataSet.IsEmpty()) return null;

            Validation.TableWithinRange(dataSet, tableIndex);

            return dataSet.Tables[tableIndex].ForEachRow(function);
        }

        /// <summary>
        /// Run a function over each poco contained in a data table accessed by index
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataSet"></param>
        /// <param name="function"></param>
        /// <param name="tableIndex"></param>
        /// <returns></returns>
        public static IEnumerable<T> ForEachPoco<T>(this DataSet dataSet, Func<T, T> function, int tableIndex = 0)
            where T : class, new()
        {
            if (dataSet.IsEmpty()) return null;

            Validation.TableWithinRange(dataSet, tableIndex);

            return dataSet.Tables[tableIndex].ForEachPoco(function);
        }

        /// <summary>
        /// Filter a collection by boolean function accessed by table index
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataSet"></param>
        /// <param name="function"></param>
        /// <param name="tableIndex"></param>
        /// <returns></returns>
        public static IEnumerable<T> Where<T>(this DataSet dataSet, Func<T, bool> function, int tableIndex = 0)
           where T : class, new()
        {
            if (dataSet.IsEmpty()) return null;

            Validation.TableWithinRange(dataSet, tableIndex);

            return dataSet.Tables[tableIndex].Where(function);
        }

        /// <summary>
        /// Select a single column for each element in a table
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataSet"></param>
        /// <param name="columnName"></param>
        /// <param name="tableIndex"></param>
        /// <returns></returns>
        public static IEnumerable<T> SelectColumn<T>(this DataSet dataSet, string columnName, int tableIndex = 0)
        {
            if (dataSet.IsEmpty()) return null;

            Validation.TableWithinRange(dataSet, tableIndex);

            return dataSet.Tables[tableIndex].SelectColumn<T>(columnName);
        }

        /// <summary>
        /// Simple data table to poco enumerable accessed by table index
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataSet"></param>
        /// <param name="tableIndex"></param>
        /// <returns></returns>
        public static IEnumerable<T> ToEnumerableOf<T>(this DataSet dataSet, int tableIndex = 0)
            where T : class, new()
        {
            if (dataSet.IsEmpty()) return null;

            Validation.TableWithinRange(dataSet, tableIndex);

            return dataSet.Tables[tableIndex].ToEnumerableOf<T>();
        }

        /// <summary>
        /// First row or default accessed by table index
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataSet"></param>
        /// <param name="tableIndex"></param>
        /// <returns></returns>
        public static T FirstOrDefault<T>(this DataSet dataSet, int tableIndex = 0)
            where T : class, new()
        {
            if (dataSet.IsEmpty()) return null;

            Validation.TableWithinRange(dataSet, tableIndex);

            return dataSet.Tables[tableIndex].FirstOrDefault<T>();
        }

        /// <summary>
        /// Is data set empty 
        /// </summary>
        /// <param name="dataSet"></param>
        /// <returns></returns>
        public static bool IsEmpty(this DataSet dataSet)
        {
            return dataSet.WithinRange(0) && dataSet.Tables[0] == null || dataSet.Tables[0].Rows.Count == 0;
        }

        /// <summary>
        /// Is data set not empty
        /// </summary>
        /// <param name="dataSet"></param>
        /// <returns></returns>
        public static bool IsNotEmpty(this DataSet dataSet)
        {
            return !IsEmpty(dataSet);
        }

        /// <summary>
        /// Is table index within set range
        /// </summary>
        /// <param name="dataSet"></param>
        /// <param name="tableIndex"></param>
        /// <returns></returns>
        public static bool WithinRange(this DataSet dataSet, int tableIndex)
        {
            return tableIndex >= 0 && dataSet.Tables.Count >= tableIndex + 1;
        }
    }
}