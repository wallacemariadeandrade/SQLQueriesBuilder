# SQLQueriesHelper
A fluent way to write out your SQL statements.

## Examples

### How to insert

```c#

// INSERT INTO TABLE VALUES ('fOO1', FOO2, FOO3)
var insertExample1 = SQLQueriesBuilder
  .InsertAt("TABLE")
  .WithValues("fOO1", "FOO2", "FOO3")
  .As(ColumnTypes.Text, ColumnTypes.NonText, ColumnTypes.NonText)
  .Builder()
  .Build();

// INSERT INTO TABLE (COLUMN1, COLUMN2, COLUMN3) VALUES (fOO1, FOO2, 'FOO3')
var insertExample2 = SQLQueriesBuilder
  .InsertAt("TABLE")
  .AtColumns("COLUMN1", "COLUMN2", "COLUMN3")
  .WithValues("fOO1", "FOO2", "FOO3")
  .As(ColumnTypes.NonText, ColumnTypes.NonText, ColumnTypes.Text)
  .Builder()
  .Build();
  
```

### How to select

```c#

// SELECT * FROM FOO
var selectExample1 = SQLQueriesBuilder
  .SelectAllFrom("FOO")
  .Builder()
  .Build();


// SELECT Id, Name, Price FROM Products 
var selectExample2 = SQLQueriesBuilder
  .SelectFrom("Products")
  .Columns("Id", "Name", "Price")
  .Builder()
  .Build();

```

## Versions

v1.0
- Simple inserts queries suppported
