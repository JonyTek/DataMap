using System;

namespace DataMap.Specs.Model
{
    public class SimplePoco
    {
        [MapTo("Id")]
        public int Id { get; set; }

        [MapTo("Name")]
        public string Name { get; set; }

        [MapTo("Name")]
        public string OtherField { get; set; }

        [MapTo("SomeGuid")]
        public Guid SomeGuid { get; set; }

        [MapTo("Enum")]
        public AEnum Enum { get; set; }

        [MapTo("Float")]
        public float Float { get; set; }

        [MapTo("Bool")]
        public bool Bool { get; set; }

        [MapTo("DateTime")]
        public DateTime DateTime { get; set; }

        public SimplePoco SetName(string name)
        {
            Name = name;

            return this;
        }
    }

    public enum AEnum
    {
        Test
    }
}
