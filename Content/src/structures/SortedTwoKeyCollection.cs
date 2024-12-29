using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SortedTwoKeyCollection<T> : IEnumerable<(string Key, int SortOrder, T Value)>
{
    private readonly SortedDictionary<int, List<string>> sortedData = new();
    private readonly Dictionary<string, (int, T)> keyMap = new();

    public void Add(string key, int sortOrder, T value)
    {
        // Remove existing entry if key already exists
        if (keyMap.ContainsKey(key))
        {
            Remove(key);
        }

        // Add to keyMap
        keyMap[key] = (sortOrder, value);

        // Add to sortedData
        if (!sortedData.ContainsKey(sortOrder))
        {
            sortedData[sortOrder] = new List<string>();
        }
        sortedData[sortOrder].Add(key);
    }

    public void Remove(string key)
    {
        if (keyMap.TryGetValue(key, out var entry))
        {
            int sortOrder = entry.Item1;

            // Remove from sortedData
            sortedData[sortOrder].Remove(key);
            if (sortedData[sortOrder].Count == 0)
            {
                sortedData.Remove(sortOrder);
            }

            // Remove from keyMap
            keyMap.Remove(key);
        }
    }

    public T GetValue(string key)
    {
        if (keyMap.TryGetValue(key, out var entry))
        {
            return entry.Item2;
        }
        throw new KeyNotFoundException($"Key '{key}' not found.");
    }

    public IEnumerable<(string Key, int SortOrder, T Value)> GetSortedEntries()
    {
        foreach (var kvp in sortedData)
        {
            foreach (var key in kvp.Value)
            {
                var (sortOrder, value) = keyMap[key];
                yield return (key, sortOrder, value);
            }
        }
    }
    public IEnumerator<(string Key, int SortOrder, T Value)> GetEnumerator()
    {
        return GetSortedEntries().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
