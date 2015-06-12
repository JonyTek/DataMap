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
        public void ShouldRunForEach()
        {
            var enumerable = Table.ForEachRow(row => row.To<SimplePoco>());
            
            Assert.AreEqual(2, enumerable.Count());
            Assert.AreEqual("Jony", enumerable.First().Name);
        }

        [TestMethod]
        public void ShouldTransformToEnumerable()
        {
            var enumerable = Table.ToEnumerableOf<SimplePoco>();

            Assert.AreEqual(2, enumerable.Count());
            Assert.AreEqual("Jony", enumerable.First().Name);
        }

        [TestMethod]
        public void ShouldReturnTruIdEmpltyDataTable()
        {
            Assert.IsTrue(((DataTable)null).IsEmpty());
            Assert.IsTrue(new DataTable().IsEmpty());

            Assert.IsFalse(((DataTable)null).IsNotEmpty());
            Assert.IsFalse(new DataTable().IsNotEmpty());
            
        }
    }
}
