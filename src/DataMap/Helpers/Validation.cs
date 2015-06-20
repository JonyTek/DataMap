using System;
using System.Data;

namespace DataMap.Helpers
{
    internal static class Validation
    {
        /// <summary>
        /// Throw exception if table index is out of range
        /// </summary>
        /// <param name="dataSet"></param>
        /// <param name="tableIndex"></param>
        internal static void TableWithinRange(DataSet dataSet, int tableIndex)
        {
            if (tableIndex > dataSet.Tables.Count)
            {
                throw new ArgumentOutOfRangeException("tableIndex");
            }
        }
    }
}