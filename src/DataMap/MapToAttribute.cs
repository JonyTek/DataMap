using System;

namespace DataMap
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class MapToAttribute : Attribute
    {
        public string ColumnName { get; set; }

        public MapToAttribute(string columnName)
        {
            ColumnName = columnName;
        }
    }
}