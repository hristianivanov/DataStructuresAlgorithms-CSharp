namespace DataStructures;

/// <summary>
/// Represents a generic hash table that resolves collisions with separate chaining.
/// </summary>
/// <typeparam name="TKey">The type of keys stored in the hash table.</typeparam>
/// <typeparam name="TValue">The type of values stored in the hash table.</typeparam>
public sealed class SeparateChainingHashTable<TKey, TValue>
    where TKey : notnull
{
    private const int DefaultCapacity = 4;
    private const double MaxLoadFactor = 0.75;

    private Entry?[] _buckets;
    private readonly EqualityComparer<TKey> _comparer = EqualityComparer<TKey>.Default;

    /// <summary>
    /// Initializes a new instance of the <see cref="SeparateChainingHashTable{TKey, TValue}"/> class
    /// using a small default capacity.
    /// </summary>
    public SeparateChainingHashTable()
        : this(DefaultCapacity)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SeparateChainingHashTable{TKey, TValue}"/> class
    /// using the specified initial capacity.
    /// </summary>
    /// <param name="initialCapacity">The initial number of buckets.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="initialCapacity"/> is less than 1.</exception>
    public SeparateChainingHashTable(int initialCapacity)
    {
        if (initialCapacity < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(initialCapacity), "Initial capacity must be greater than zero.");
        }

        _buckets = new Entry[initialCapacity];
    }

    /// <summary>
    /// Gets the number of key-value pairs in the hash table.
    /// </summary>
    public int Count { get; private set; }

    /// <summary>
    /// Gets a value indicating whether the hash table contains no key-value pairs.
    /// </summary>
    public bool IsEmpty => Count == 0;

    /// <summary>
    /// Adds a key-value pair to the hash table.
    /// </summary>
    /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">The key already exists in the hash table.</exception>
    public void Add(TKey key, TValue value)
    {
        ValidateKey(key);
        EnsureCapacityForNextEntry();

        int bucketIndex = GetBucketIndex(key);
        Entry? current = _buckets[bucketIndex];

        while (current is not null)
        {
            if (_comparer.Equals(current.Key, key))
            {
                throw new ArgumentException("An entry with the same key already exists.", nameof(key));
            }

            current = current.Next;
        }

        _buckets[bucketIndex] = new Entry(key, value, _buckets[bucketIndex]);
        Count++;
    }

    /// <summary>
    /// Removes the key-value pair with the specified key.
    /// </summary>
    /// <returns><see langword="true"/> if the key was removed; otherwise, <see langword="false"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
    public bool Remove(TKey key)
    {
        ValidateKey(key);

        int bucketIndex = GetBucketIndex(key);
        Entry? previous = null;
        Entry? current = _buckets[bucketIndex];

        while (current is not null)
        {
            if (_comparer.Equals(current.Key, key))
            {
                if (previous is null)
                {
                    _buckets[bucketIndex] = current.Next;
                }
                else
                {
                    previous.Next = current.Next;
                }

                Count--;
                return true;
            }

            previous = current;
            current = current.Next;
        }

        return false;
    }

    /// <summary>
    /// Determines whether the hash table contains the specified key.
    /// </summary>
    /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
    public bool ContainsKey(TKey key)
    {
        return TryGetEntry(key, out _);
    }

    /// <summary>
    /// Gets the value associated with the specified key.
    /// </summary>
    /// <returns><see langword="true"/> if the key was found; otherwise, <see langword="false"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
    public bool TryGetValue(TKey key, out TValue value)
    {
        if (TryGetEntry(key, out Entry? entry))
        {
            value = entry.Value;
            return true;
        }

        value = default!;
        return false;
    }

    /// <summary>
    /// Removes all key-value pairs from the hash table.
    /// </summary>
    public void Clear()
    {
        Array.Clear(_buckets, 0, _buckets.Length);
        Count = 0;
    }

    /// <summary>
    /// Returns all key-value pairs stored in the hash table.
    /// </summary>
    public IEnumerable<KeyValuePair<TKey, TValue>> ToEnumerable()
    {
        foreach (Entry? bucket in _buckets)
        {
            Entry? current = bucket;

            while (current is not null)
            {
                yield return new KeyValuePair<TKey, TValue>(current.Key, current.Value);
                current = current.Next;
            }
        }
    }

    private bool TryGetEntry(TKey key, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Entry? entry)
    {
        ValidateKey(key);

        int bucketIndex = GetBucketIndex(key);
        Entry? current = _buckets[bucketIndex];

        while (current is not null)
        {
            if (_comparer.Equals(current.Key, key))
            {
                entry = current;
                return true;
            }

            current = current.Next;
        }

        entry = null;
        return false;
    }

    private void EnsureCapacityForNextEntry()
    {
        double nextLoadFactor = (Count + 1.0) / _buckets.Length;

        if (nextLoadFactor > MaxLoadFactor)
        {
            Resize();
        }
    }

    private void Resize()
    {
        Entry?[] oldBuckets = _buckets;
        _buckets = new Entry[oldBuckets.Length * 2];

        foreach (Entry? bucket in oldBuckets)
        {
            Entry? current = bucket;

            while (current is not null)
            {
                Entry? next = current.Next;
                int bucketIndex = GetBucketIndex(current.Key);
                current.Next = _buckets[bucketIndex];
                _buckets[bucketIndex] = current;
                current = next;
            }
        }
    }

    private int GetBucketIndex(TKey key)
    {
        int hashCode = _comparer.GetHashCode(key) & int.MaxValue;
        return hashCode % _buckets.Length;
    }

    private static void ValidateKey(TKey key)
    {
        if (key is null)
        {
            throw new ArgumentNullException(nameof(key));
        }
    }

    private sealed class Entry(TKey key, TValue value, Entry? next)
    {
        public TKey Key { get; } = key;

        public TValue Value { get; } = value;

        public Entry? Next { get; set; } = next;
    }
}
