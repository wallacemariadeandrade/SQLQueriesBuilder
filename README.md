# SQLQueriesHelper
A fluent way to write out your SQL statements.

## Inserts Examples

```c#

// INSERT INTO TABLE VALUES ('fOO1', FOO2, FOO3)
var insertExample1 = SQLQueriesBuilder
  .InsertAt("TABLE")
  .WithValues("fOO1", "FOO2", "FOO3")
  .As(ColumnTypes.Text, ColumnTypes.NonText, ColumnTypes.NonText)
  .Builder()
  .Build();

// INSERT INTO TABLE (COLUMN1, COLUMN2, COLUMN3) VALUES (fOO1, FOO2, FOO3)
var insertExample2 = SQLQueriesBuilder
  .InsertAt("TABLE")
  .AtColumns("COLUMN1", "COLUMN2", "COLUMN3")
  .WithValues("fOO1", "FOO2", "FOO3")
  .As(ColumnTypes.NonText, ColumnTypes.NonText, ColumnTypes.NonText)
  .Builder()
  .Build();
  
```

## Versions

v1.0
- Simple inserts queries suppported
