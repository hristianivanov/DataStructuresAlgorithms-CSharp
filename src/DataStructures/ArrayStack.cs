namespace DataStructures;

/// <summary>
/// Represents a generic stack backed by a resizable array.
/// </summary>
/// <typeparam name="T">The type of items stored in the stack.</typeparam>
public sealed class ArrayStack<T>
{
    private const int DefaultCapacity = 4;

    private T[] _items;

    /// <summary>
    /// Initializes a new instance of the <see cref="ArrayStack{T}"/> class
    /// using a small default capacity.
    /// </summary>
    public ArrayStack()
        : this(DefaultCapacity)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArrayStack{T}"/> class
    /// using the specified initial capacity.
    /// </summary>
    /// <param name="initialCapacity">The number of items the stack can hold before resizing.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="initialCapacity"/> is less than 1.</exception>
    public ArrayStack(int initialCapacity)
    {
        if (initialCapacity < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(initialCapacity), "Initial capacity must be greater than zero.");
        }

        _items = new T[initialCapacity];
    }

    /// <summary>
    /// Gets the number of items in the stack.
    /// </summary>
    public int Count { get; private set; }

    /// <summary>
    /// Gets a value indicating whether the stack contains no items.
    /// </summary>
    public bool IsEmpty => Count == 0;

    /// <summary>
    /// Adds an item to the top of the stack.
    /// </summary>
    public void Push(T item)
    {
        if (Count == _items.Length)
        {
            Resize();
        }

        _items[Count] = item;
        Count++;
    }

    /// <summary>
    /// Removes and returns the item at the top of the stack.
    /// </summary>
    /// <exception cref="InvalidOperationException">The stack is empty.</exception>
    public T Pop()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("Cannot pop from an empty stack.");
        }

        Count--;
        T item = _items[Count];
        _items[Count] = default!;
        return item;
    }

    /// <summary>
    /// Returns the item at the top of the stack without removing it.
    /// </summary>
    /// <exception cref="InvalidOperationException">The stack is empty.</exception>
    public T Peek()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("Cannot peek an empty stack.");
        }

        return _items[Count - 1];
    }

    /// <summary>
    /// Removes all items from the stack.
    /// </summary>
    public void Clear()
    {
        Array.Clear(_items, 0, Count);
        Count = 0;
    }

    /// <summary>
    /// Returns the stack items from top to bottom.
    /// </summary>
    public IEnumerable<T> ToEnumerable()
    {
        for (int i = Count - 1; i >= 0; i--)
        {
            yield return _items[i];
        }
    }

    private void Resize()
    {
        int newCapacity = _items.Length * 2;
        Array.Resize(ref _items, newCapacity);
    }
}
