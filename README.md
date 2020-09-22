# SQLQueriesBuilder
A fluent way to write out your SQL statements.

## Examples

### How to insert

```c#

// INSERT INTO Products VALUES ('Pen', 'Pencil', 'Eraser')
var query1 = SQLInsertQueriesBuilder
  .InsertAt("Products")
  .Values("Pen", "Pencil", "Eraser")
  .As(ColumnTypes.Text, ColumnTypes.Text, ColumnTypes.Text)
  .Build();

// INSERT INTO Employees (Id, Name, Age) VALUES (1, 'Wallace', 26)
var query2 = SQLInsertQueriesBuilder
  .InsertAt("Employees")
  .Values("1", "Wallace", "26")
  .AtColumns("Id", "Name", "Age")
  .As(ColumnTypes.NonText, ColumnTypes.Text, ColumnTypes.NonText)
  .Build();
  
```
### How to select

```c#

// SELECT ID, Name, Price FROM Products
var selectQuery = SQLSelectBuilder
    .Select("ID", "Name", "Price")
    .From("Products")
    .Build();

```

## Versions

v1.0
- Simple inserts queries suppported
