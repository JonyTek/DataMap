using System.Data;
using System.Linq;
using DataMap.Extensions;
using DataMap.Specs.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataMap.Specs
{
    [TestClass]
    public class DataSetExtensionsSpecs
    {
        private static DataTable Table
        {
            get
            {
                var table = new DataTable();

                table.Columns.Add("Id", typeof (int));
                table.Columns.Add("Name", typeof (string));

                table.Rows.Add(1, "Jony");
                table.Rows.Add(2, "Gregory");

                return table;
            }
        }

        [TestMethod]
        public void ShouldTranformADataTable()
        {
            var ds = new DataSet();
            ds.Tables.Add(Table);

            var enumerable = ds.ToEnumerable<SimplePoco>();

            Assert.AreEqual(2, enumerable.Count());
            Assert.AreEqual("Jony", enumerable.First().Name);
        }

        [TestMethod]
        public void ShouldTranformADataTable1()
        {
            var ds = new DataSet();
            ds.Tables.Add(Table);
            ds.Tables.Add(Table);

            var enumerable = ds.ToEnumerable<SimplePoco>(1);

            Assert.AreEqual(2, enumerable.Count());
            Assert.AreEqual("Jony", enumerable.First().Name);
        }

        [TestMethod]
        public void ShouldCheckIfOutOfRange()
        {
            var ds = new DataSet();
            ds.Tables.Add(Table);

            Assert.IsTrue(ds.OutOfRange(0));
            ds.Tables.Add(Table);
            Assert.IsTrue(ds.OutOfRange(0));

            Assert.IsFalse(ds.OutOfRange(2));
            Assert.IsFalse(ds.OutOfRange(-1));
        }
    }
}