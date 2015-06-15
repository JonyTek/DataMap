# DataMap
A simple set of extension methods that allow for easy ADO.Net DataSet => POCO transformations.

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
retun dataSet.ToEnumerable<Thing>();
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
IEnumerable<T> ToEnumerable<T>(this DataSet dataSet, int tableIndex = 0)

//DataTable
IEnumerable<T> ForEachRow<T>(this DataTable table, Func<DataRow, T> function)

IEnumerable<T> ToEnumerableOf<T>(this DataTable table)

T ToFirstRow<T>(this DataTable table)

bool IsEmpty(this DataTable table)

bool IsNotEmpty(this DataTable table)

//DataRow
T To<T>(this DataRow row)
```

Project comes with full unit test coverage for types:

int
string
guid
enum
float
bool
dateTime

Enjoy...


