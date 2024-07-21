namespace DictionaryLists;

public interface IDictionaryList<T> : IList<Dictionary<string, T>>
{
    public List<Dictionary<string, T>> Database { get; set; }
    //public void AddTo(int index, KeyValuePair<string, T> pair);
    public void AddTo(int index, string key, T value);
    //public void AddToAll(KeyValuePair<string, T> pair);
    public void AddToAll(string key, T value);
    //public void AddToRange(int start, KeyValuePair<string, T> pair);
    public void AddToRange(int start, string key, T value);
    //public void AddToRange(int start, int count, KeyValuePair<string, T> pair);
    public void AddToRange(int start, int count, string key, T value);
    public void ClearAt(int index);
    public bool ContainsKey(string key);
    public bool ContainsKeyAt(int index, string key);
    //public bool ContainsPair(KeyValuePair<string, T> pair);
    public bool ContainsPair(string key, T value);
    //public bool ContainsPairAt(int index, KeyValuePair<string, T> pair);
    public bool ContainsPairAt(int index, string key, T value);
    public bool ContainsValue(T value);
    public bool ContainsValueAt(int index, T value);
    public Dictionary<string, T> DictionaryAt(int index);
    public bool EqualsAt(int index, object? obj);
    public int GetHashCodeAt(int index);
    public void Merge(IDictionaryList<T> dictionaryList);
    public bool TryAddTo(int index, KeyValuePair<string, T> pair);
    public bool TryAddTo(int index, string key, T value);
    public bool TryGetValueAt(int index, string key, out T? _object);
    public T ValueAt(int index, string key);
}