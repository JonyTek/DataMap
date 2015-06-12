using System.Collections.Generic;
using System.Data;
using DataMap.Helpers;

namespace DataMap.Extensions
{
    public static class DataSetExtensions
    {
        public static IEnumerable<T> ToEnumerable<T>(this DataSet dataSet, int tableIndex = 0)
            where  T : new()
        {
            Validation.NotNull(dataSet);
            Validation.IsTrue(dataSet.OutOfRange(tableIndex), "Out of range");

            return dataSet.Tables[tableIndex].ToEnumerableOf<T>();
        }

        public static bool OutOfRange(this DataSet dataSet, int tableIndex)
        {
            return tableIndex >= 0 && dataSet.Tables.Count >= tableIndex + 1;
        }
    }
}