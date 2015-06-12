using System;
using System.Data;
using System.Linq;
using DataMap.Extensions;
using DataMap.Specs.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataMap.Specs
{
    [TestClass]
    public class DataRowExtensionSpecs
    {
        private static DataTable Table
        {
            get
            {
                var table = new DataTable();

                table.Columns.Add("Id", typeof(int));
                table.Columns.Add("Name", typeof(string));

                table.Rows.Add(1, "Jony");
                table.Rows.Add(2, "Gregory");

                return table;
            }
        }

        [TestMethod]
        public void ShouldTransformToObject()
        {
            var single = Table.Rows[0].To<SimplePoco>();

            Assert.AreEqual("Jony", single.Name);
        }

        [TestMethod]
        public void ShouldGetColumnGyMapToAttribute()
        {
            var single = Table.Rows[0].To<SimplePoco>();

            Assert.AreEqual("Jony", single.OtherField);
        }

        [TestMethod]
        public void ShouldParseAGuid()
        {
            var guid = Guid.NewGuid();
            var table = new DataTable();
            table.Columns.Add("SomeGuid", typeof(Guid));
            table.Rows.Add(guid);

            var single = table.ToEnumerableOf<SimplePoco>().First();

            Assert.AreEqual(guid, single.SomeGuid);
        }

        [TestMethod]
        public void ShouldParseAEnum()
        {
            var table = new DataTable();
            table.Columns.Add("Enum", typeof(AEnum));
            table.Rows.Add(AEnum.Test);

            var single = table.ToEnumerableOf<SimplePoco>().First();

            Assert.AreEqual(AEnum.Test, single.Enum);
        }

        [TestMethod]
        public void ShouldParseAFloat()
        {
            var table = new DataTable();
            table.Columns.Add("Float", typeof(float));
            table.Rows.Add(1.1f);

            var single = table.ToEnumerableOf<SimplePoco>().First();

            Assert.AreEqual(1.1f, single.Float);
        }

        [TestMethod]
        public void ShouldParseABool()
        {
            var table = new DataTable();
            table.Columns.Add("Bool", typeof(bool));
            table.Rows.Add(1);

            var single = table.ToEnumerableOf<SimplePoco>().First();
            Assert.AreEqual(true, single.Bool);

            table = new DataTable();
            table.Columns.Add("Bool", typeof(bool));
            table.Rows.Add(true);

            single = table.ToEnumerableOf<SimplePoco>().First();
            Assert.AreEqual(true, single.Bool);
        }

        [TestMethod]
        public void ShouldParseADateTime()
        {
            var date = new DateTime(2000, 1, 1);
            var table = new DataTable();
            table.Columns.Add("DateTime", typeof(DateTime));
            table.Rows.Add(date);

            var single = table.ToFirsRow<SimplePoco>();

            Assert.AreEqual(date, single.DateTime);
        }
    }
}
