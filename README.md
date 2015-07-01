# DataMap
A simple set of extension methods that allow for easy ADO.Net DataSet => POCO transformations.

### NuGet Packages

```
PM> Install-Package SimpleSpecification
```

Get away from code such as

```csharp
foreach(DataRow row in dataSet.Tables[0].Rows){
	int val;
	int.TryParse(row["columnName"].ToString(), out val);
	
	someCollection.Add(new Thing{
		Prop = val
	});
}
return someCollection;
```

And get the same result with a simple

```csharp
return dataSet.ToEnumerable<SimplePoco>();
```

Data transformations make use of Reflection to easily map properties to columns based on either a matching name or a custom attribute.

e.g.

```csharp
public class SimplePoco
{
	//Matching field name
	public int Id { get; set; }
	
	//Explicit map
	[MapTo("columnName")]
	public string Name { get; set; }
}
```

Additional extension methods:
```csharp
//DataSet
IEnumerable<T> ForEachRow<T>(this DataSet dataSet, Func<DataRow, T> function, int tableIndex = 0)

IEnumerable<T> ForEachPoco<T>(this DataSet dataSet, Func<T, T> function, int tableIndex = 0)

IEnumerable<T> Where<T>(this DataSet dataSet, Func<T, bool> function, int tableIndex = 0)

IEnumerable<T> SelectColumn<T>(this DataSet dataSet, string columnName, int tableIndex = 0)

IEnumerable<T> ToEnumerableOf<T>(this DataSet dataSet, int tableIndex = 0)

T FirstOrDefault<T>(this DataSet dataSet, int tableIndex = 0)

bool IsEmpty(this DataSet dataSet)

bool IsNotEmpty(this DataSet dataSet)

bool WithinRange(this DataSet dataSet, int tableIndex)

//DataTable
IEnumerable<T> ForEachRow<T>(this DataTable table, Func<DataRow, T> function)

IEnumerable<T> ForEachPoco<T>(this DataTable table, Func<T, T> function)

IEnumerable<T> Where<T>(this DataTable table, Func<T, bool> function)

IEnumerable<T> SelectColumn<T>(this DataTable table, string columnName)

IEnumerable<T> ToEnumerableOf<T>(this DataTable table)

T FirstOrDefault<T>(this DataTable table)

bool IsEmpty(this DataTable table)

bool IsNotEmpty(this DataTable table)

//DataRow
T To<T>(this DataRow row)
```

Project comes with full unit test coverage for types:

* int
* string
* guid
* enum
* float
* bool
* dateTime

Enjoy...


