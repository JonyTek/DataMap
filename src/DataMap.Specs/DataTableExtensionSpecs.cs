using System.Data;
using System.Linq;
using DataMap.Extensions;
using DataMap.Specs.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataMap.Specs
{
    [TestClass]
    public class DataTableExtensionSpecs
    {
        static DataTable Table
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
        public void ShouldRunForEachRow()
        {
            var enumerable = Table.ForEachRow(row => row.To<SimplePoco>()).ToList();

            Assert.AreEqual(2, enumerable.Count());
            Assert.AreEqual("Jony", enumerable.First().Name);
        }

        [TestMethod]
        public void ShouldRunForEachPoco()
        {
            var enumerable = Table.ForEachPoco<SimplePoco>(poco => poco.SetName("NAME"));

            Assert.AreEqual("NAME", enumerable.First().Name);
        }

        [TestMethod]
        public void ShouldRunAWhere()
        {
            var enumerable = Table.Where<SimplePoco>(poco => poco.Id == 1).ToList();

            Assert.AreEqual(1, enumerable.Count());
            Assert.AreEqual("Jony", enumerable.First().Name);
        }

        [TestMethod]
        public void ShouldSelectAColumnByName()
        {
            var enumerable = Table.SelectColumn<int>("Id").ToList();

            Assert.AreEqual(1, enumerable.First());
            Assert.AreEqual(2, enumerable.Skip(1).First());
        }

        [TestMethod]
        public void ShouldTransformToEnumerable()
        {
            var enumerable = Table.ToEnumerableOf<SimplePoco>().ToList();

            Assert.AreEqual(2, enumerable.Count());
            Assert.AreEqual("Jony", enumerable.First().Name);
        }

        [TestMethod]
        public void ShouldReturnTrueIfEmptyDataTable()
        {
            Assert.IsTrue(((DataTable)null).IsEmpty());
            Assert.IsTrue(new DataTable().IsEmpty());

            Assert.IsFalse(((DataTable)null).IsNotEmpty());
            Assert.IsFalse(new DataTable().IsNotEmpty());

        }
    }
}
