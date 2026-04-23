namespace DoubleList.Core;

public class DoublyLinkedList<T>
{
    private DoubleNode<T>? _head;
    private DoubleNode<T>? _tail;

    public DoublyLinkedList()
    {
        _head = null;
        _tail = null;
    }

    public void Add(T data)
    {
        var newNode = new DoubleNode<T>(data);
        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            if (Comparer<T>.Default.Compare(data, _head.Data!) < 0)
            {
                newNode.Next = _head;
                _head.Prev = newNode;
                _head = newNode;
            }
            else if (Comparer<T>.Default.Compare(data, _tail!.Data!) >= 0)
            {
                newNode.Prev = _tail;
                _tail.Next = newNode;
                _tail = newNode;
            }
            else
            {
                var current = _head;
                while (current != null)
                {
                    if (Comparer<T>.Default.Compare(data, current.Data!) < 0)
                    {
                        newNode.Next = current;
                        newNode.Prev = current.Prev;
                        current.Prev!.Next = newNode;
                        current.Prev = newNode;
                        break;
                    }
                    current = current.Next;
                }
            }
        }
    }

    public string GetForward()
    {
        var output = string.Empty;
        var current = _head;
        while (current != null)
        {
            output += $"{current.Data} <=> ";
            current = current.Next;
        }
        return output.Substring(0, output.Length - 5);
    }

    public string GetBackward()
    {
        var output = string.Empty;
        var current = _tail;
        while (current != null)
        {
            output += $"{current.Data} <=> ";
            current = current.Prev;
        }
        return output.Substring(0, output.Length - 5);
    }

    public void SortDescending()
    {
        if (_head == null)
        {
            return;
        }
        var swapped = true;
        while (swapped)
        {
            swapped = false;
            var current = _head;
            while (current!.Next != null)
            {
                if (Comparer<T>.Default.Compare(current.Data!, current.Next!.Data!) < 0)
                {
                    var temp = current.Data;
                    current.Data = current.Next.Data;
                    current.Next.Data = temp;
                    swapped = true;
                }
                current = current.Next;
            }
        }
    }

    public List<string> GetFashions()
    {
        var frequencies = new Dictionary<T, int>();
        var current = _head;
        while (current != null)
        {
            var key = current.Data!;
            if (frequencies.ContainsKey(key))
            {
                frequencies[key]++;
            }
            else
            {
                frequencies[key] = 1;
            }
            current = current.Next;
        }

        var result = new List<string>();

        if (frequencies.Count == 0)
        {
            return result;
        }

        var maxFrequency = 0;
        foreach (var kv in frequencies)
        {
            if (kv.Value > maxFrequency)
            {
                maxFrequency = kv.Value;
            }
        }

        foreach (var kv in frequencies)
        {
            if (kv.Value == maxFrequency)
            {
                result.Add(kv.Key?.ToString() ?? "null");
            }
        }
        return result;
    }

    public List<string> GetFashionGraph()
    {
        var frequencies = new Dictionary<T, int>();
        var current = _head;
        while (current != null)
        {
            var key = current.Data!;
            frequencies.TryGetValue(key, out var count);
            frequencies[key] = count + 1;
            current = current.Next;
        }

        var graphLines = new List<string>();
        if (frequencies.Count == 0)
            return graphLines;

        // sort by frequency descending, then by key ascending
        var entries = new List<KeyValuePair<T, int>>(frequencies);
        entries.Sort((a, b) =>
        {
            var compare = b.Value.CompareTo(a.Value);
            if (compare != 0) return compare;
            var sa = a.Key?.ToString() ?? string.Empty;
            var sb = b.Key?.ToString() ?? string.Empty;
            return Comparer<string>.Default.Compare(sa, sb);
        });

        foreach (var kv in entries)
        {
            var keyStr = kv.Key?.ToString() ?? "null";
            var stars = new string('*', kv.Value);
            graphLines.Add($"{keyStr}: {stars}");
        }
        return graphLines;
    }

    // Remove the first occurrence of the data. Returns true if removed, false otherwise.
    public bool Remove(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Data, data))
            {
                if (current.Prev != null)
                    current.Prev.Next = current.Next;
                else
                    _head = current.Next;

                if (current.Next != null)
                    current.Next.Prev = current.Prev;
                else
                    _tail = current.Prev;

                current.Next = null;
                current.Prev = null;
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    // Remove all occurrences of the data. Returns the number of removed nodes.
    public int RemoveAll(T data)
    {
        int removed = 0;
        var current = _head;
        while (current != null)
        {
            var next = current.Next;
            if (EqualityComparer<T>.Default.Equals(current.Data, data))
            {
                if (current.Prev != null)
                    current.Prev.Next = current.Next;
                else
                    _head = current.Next;

                if (current.Next != null)
                    current.Next.Prev = current.Prev;
                else
                    _tail = current.Prev;

                current.Next = null;
                current.Prev = null;
                removed++;
            }
            current = next;
        }
        return removed;
    }

    public bool Exist(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }
}
