namespace DataStructures;

/// <summary>
/// Represents a generic queue backed by a resizable circular array.
/// </summary>
/// <typeparam name="T">The type of items stored in the queue.</typeparam>
public sealed class CircularQueue<T>
{
    private const int DefaultCapacity = 4;

    private T[] _items;
    private int _front;

    /// <summary>
    /// Initializes a new instance of the <see cref="CircularQueue{T}"/> class
    /// using a small default capacity.
    /// </summary>
    public CircularQueue()
        : this(DefaultCapacity)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CircularQueue{T}"/> class
    /// using the specified initial capacity.
    /// </summary>
    /// <param name="initialCapacity">The number of items the queue can hold before resizing.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="initialCapacity"/> is less than 1.</exception>
    public CircularQueue(int initialCapacity)
    {
        if (initialCapacity < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(initialCapacity), "Initial capacity must be greater than zero.");
        }

        _items = new T[initialCapacity];
    }

    /// <summary>
    /// Gets the number of items in the queue.
    /// </summary>
    public int Count { get; private set; }

    /// <summary>
    /// Gets a value indicating whether the queue contains no items.
    /// </summary>
    public bool IsEmpty => Count == 0;

    /// <summary>
    /// Adds an item to the back of the queue.
    /// </summary>
    public void Enqueue(T item)
    {
        if (Count == _items.Length)
        {
            Resize();
        }

        int back = (_front + Count) % _items.Length;
        _items[back] = item;
        Count++;
    }

    /// <summary>
    /// Removes and returns the item at the front of the queue.
    /// </summary>
    /// <exception cref="InvalidOperationException">The queue is empty.</exception>
    public T Dequeue()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("Cannot dequeue from an empty queue.");
        }

        T item = _items[_front];
        _items[_front] = default!;
        _front = (_front + 1) % _items.Length;
        Count--;

        if (IsEmpty)
        {
            _front = 0;
        }

        return item;
    }

    /// <summary>
    /// Returns the item at the front of the queue without removing it.
    /// </summary>
    /// <exception cref="InvalidOperationException">The queue is empty.</exception>
    public T Peek()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("Cannot peek an empty queue.");
        }

        return _items[_front];
    }

    /// <summary>
    /// Removes all items from the queue.
    /// </summary>
    public void Clear()
    {
        Array.Clear(_items, 0, _items.Length);
        Count = 0;
        _front = 0;
    }

    /// <summary>
    /// Returns the queue items from front to back.
    /// </summary>
    public IEnumerable<T> ToEnumerable()
    {
        for (int i = 0; i < Count; i++)
        {
            int index = (_front + i) % _items.Length;
            yield return _items[index];
        }
    }

    private void Resize()
    {
        T[] resizedItems = new T[_items.Length * 2];

        for (int i = 0; i < Count; i++)
        {
            int index = (_front + i) % _items.Length;
            resizedItems[i] = _items[index];
        }

        _items = resizedItems;
        _front = 0;
    }
}
