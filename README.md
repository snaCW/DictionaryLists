# DictionaryLists

`DictionaryLists.IDictionaryList<T>` interface and `DictiinaryLists.DictionaryList<T>` class are the base interface and class for any data types that are in the form of `List<Dictionary<string, T>>`.

The importance of defining such interface and class is to have better implementations of CSV, JSON, and Excel databases.

Look at the below examples:

- CSV:

```
Key1,Key2,Key3
Value1-1,Value1-2,Value1-3
Value2-1,Value2-2,Value2-3
```

- JSON:

```
[
    {
        "Key1": "Value1-1",
        "Key2": "Value1-2",
        "Key3": "Value1-3"
    },
    {
        "Key1": "Value2-1",
        "Key2": "Value2-2",
        "Key3": "Value2-3"
    }
]
```

- Excel:

| Key1     | Key2     | Key3     |
| -------- | -------- | -------- |
| Value1-1 | Value1-2 | Value1-3 |
| Value2-1 | Value2-2 | Value2-3 |

- C#:
```C#
List<Dictionary<string, string>> database = 
[
    new Dictionary<string, string>()
    {
        {"Key1", "Value1-1"},
        {"Key2", "Value1-2"},
        {"Key3", "Value1-3"}
    },
    new Dictionary<string, string>()
    {
        {"Key1", "Value2-1"},
        {"Key2", "Value2-2"},
        {"Key3", "Value2-3"}
    }
]
```