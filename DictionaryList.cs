using System.Collections;
namespace DictionaryLists;

public class DictionaryList<T> : IDictionaryList<T>
{
    public List<Dictionary<string, T>> Database { get; set; } = new List<Dictionary<string, T>>();
    public int Count { get; private set; } = 0;
    public bool IsReadOnly { get; private set; } = false;
    public DictionaryList()
    {

    }
    public DictionaryList(DictionaryList<T> dictionaryList)
    {
        Database = dictionaryList.Database;
        Count = dictionaryList.Count;
    }
    public void Add(Dictionary<string, T> dictionary)
    {
        Database.Add(dictionary);
        Count++;
    }
    public void AddTo(int index, KeyValuePair<string, T> pair)
    {
        AddTo(index, pair.Key, pair.Value);
    }
    public void AddTo(int index, string key, T value)
    {
        Database[index].Add(key, value);
    }
    public void AddToAll(KeyValuePair<string, T> pair)
    {
        AddToRange(0, Count, pair);
    }
    public void AddToAll(string key, T value)
    {
        AddToRange(0, Count, key, value);
    }
    public void AddToRange(int start, KeyValuePair<string, T> pair)
    {
        AddToRange(start, Count, pair);
    }
    public void AddToRange(int start, string key, T value)
    {
        AddToRange(start, Count, key, value);
    }
    public void AddToRange(int start, int count, KeyValuePair<string, T> pair)
    {
        AddToRange(start, count, pair.Key, pair.Value);
    }
    public void AddToRange(int start, int count, string key, T value)
    {
        for (int i = 0; i < count; i++)
        {
            AddTo(start + i, key, value);
        }
    }
    public void Clear()
    {
        Database.Clear();
    }
    public void ClearAt(int index)
    {
        Database[index].Clear();
    }
    public bool Contains(Dictionary<string, T> dictionary)
    {
        return Database.Contains(dictionary);
    }
    public bool ContainsKey(string key)
    {
        for (int i = 0; i < Count; i++)
        {
            if (ContainsKeyAt(i, key))
            {
                return true;
            }
        }
        return false;
    }
    public bool ContainsKeyAt(int index, string key)
    {
        return Database[index].ContainsKey(key);
    }
    public bool ContainsPair(KeyValuePair<string, T> pair)
    {
        return ContainsPair(pair.Key, pair.Value);
    }
    public bool ContainsPair(string key, T value)
    {
        for (int i = 0; i < Count; i++)
        {
            if (ContainsPairAt(i, key, value))
            {
                return true;
            }
        }
        return false;
    }
    public bool ContainsPairAt(int index, KeyValuePair<string, T> pair)
    {
        return ContainsPairAt(index, pair.Key, pair.Value);
    }
    public bool ContainsPairAt(int index, string key, T value)
    {
        return Database[index].TryGetValue(key, out T? _value) && EqualityComparer<T>.Default.Equals(_value, value);
    }
    public bool ContainsValue(T value)
    {
        for (int i = 0; i < Count; i++)
        {
            if (ContainsValueAt(i, value))
            {
                return true;
            }
        }
        return false;
    }
    public bool ContainsValueAt(int index, T value)
    {
        return Database[index].ContainsValue(value);
    }
    public void CopyTo(Dictionary<string, T>[] array, int index)
    {
        Database.CopyTo(array, index);
    }
    public int CountOf(int index)
    {
        return Database[index].Count;
    }
    public Dictionary<string, T> DictionaryAt(int index)
    {
        return Database[index];
    }
    public bool EqualsAt(int index, object? obj)
    {
        return Database[index].Equals(obj);
    }
    public int GetHashCodeAt(int index)
    {
        return Database[index].GetHashCode();
    }
    public IEnumerator<Dictionary<string, T>> GetEnumerator()
    {
        return Database.GetEnumerator();
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    public int IndexOf(Dictionary<string, T> dictionary)
    {
        return Database.IndexOf(dictionary);
    }
    public void Insert(int index, Dictionary<string, T> dictionary)
    {
        Database.Insert(index, dictionary);
    }
    public void Merge(IDictionaryList<T> dictionaryList)
    {
        for (int i = 0; i < Count; i++)
        {
            if (i == dictionaryList.Count)
            {
                break;
            }
            foreach (var pair in dictionaryList[i])
            {
                AddTo(i, pair);
            }
        }
    }
    public T ValueAt(int index, string key)
    {
        return Database[index][key];
    }
    public Dictionary<string, T> this[int index]
    {
        get { return Database[index]; }
        set { Database[index] = value; }
    }
    public T this[int index, string key]
    {
        get { return Database[index][key]; }
        set { Database[index][key] = value; }
    }
    public bool TryAddTo(int index, KeyValuePair<string, T> pair)
    {
        return TryAddTo(index, pair.Key, pair.Value);
    }
    public bool TryAddTo(int index, string key, T value)
    {
        if (index < 0 || index >= Database.Count)
        {
            return false;
        }
        if (!ContainsKeyAt(index, key))
        {
            AddTo(index, key, value);
            return true;
        }
        return false;
    }
    public bool TryGetValueAt(int index, string key, out T? _object)
    {
        if (index >= 0 && index < Database.Count)
        {
            return Database[index].TryGetValue(key, out _object);
        }
        _object = default;
        return false;
    }
    public bool Remove(Dictionary<string, T> dictionary)
    {
        if (Database.Remove(dictionary))
        {
            Count--;
            return true;
        }
        return false;
    }
    public void RemoveAt(int index)
    {
        Database.RemoveAt(index);
        if (Database.Count != Count)
        {
            Count--;
        }
    }
}