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

// SELECT * FROM Cars WHERE Price > 12000
var selectAllWhere = SQLSelectBuilder.
    .SelectAllFrom("Cars")
    .Where("Price", new MajorThan(12000))
    .Build();

// SELECT * FROM Users WHERE Age > 20 AND AGE < 30
var selectAllWhereWithAnd = SQLSelectBuilder
    .SelectAllFrom("Users")
    .Where("Age", new MajorThan(20))
    .And("Age", new LesserThan(30))
    .Build();

// SELECT Price, Name FROM Products WHERE Price > 10 AND Price < 20 AND Sector_ID = 10
var selectWhereWithAnds = SQLSelectBuilder
    .Select("Price", "Name")
    .From("Products")
    .Where("Price", new MajorThan(10))
    .And("Price", new LesserThan(20))
    .And("Sector_ID", new EqualsTo(10))
    .Build();

```

## Versions

v1.0
- INSERT supported

v2.0
- SELECT supported
 - WHERE, AND clauses