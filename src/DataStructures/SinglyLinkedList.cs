namespace DataStructures;

/// <summary>
/// Represents a generic singly linked list.
/// </summary>
/// <typeparam name="T">The type of values stored in the list.</typeparam>
public sealed class SinglyLinkedList<T>
{
    private readonly IEqualityComparer<T> _comparer;
    private Node? _head;
    private Node? _tail;
    private int _version;

    /// <summary>
    /// Initializes a new instance of the <see cref="SinglyLinkedList{T}"/> class
    /// using the default equality comparer for <typeparamref name="T"/>.
    /// </summary>
    public SinglyLinkedList()
        : this(EqualityComparer<T>.Default)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SinglyLinkedList{T}"/> class
    /// using the specified equality comparer.
    /// </summary>
    /// <param name="comparer">The comparer used by <see cref="Contains"/> and <see cref="Remove"/>.</param>
    /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null"/>.</exception>
    public SinglyLinkedList(IEqualityComparer<T> comparer)
    {
        ArgumentNullException.ThrowIfNull(comparer);
        _comparer = comparer;
    }

    /// <summary>
    /// Gets the number of values in the list.
    /// </summary>
    public int Count { get; private set; }

    /// <summary>
    /// Gets a value indicating whether the list contains no values.
    /// </summary>
    public bool IsEmpty => Count == 0;

    /// <summary>
    /// Adds a value to the beginning of the list.
    /// </summary>
    public void AddFirst(T value)
    {
        Node newNode = new(value)
        {
            Next = _head
        };

        _head = newNode;
        _tail ??= newNode;
        Count++;
        _version++;
    }

    /// <summary>
    /// Adds a value to the end of the list.
    /// </summary>
    public void AddLast(T value)
    {
        Node newNode = new(value);

        if (_tail is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            _tail.Next = newNode;
            _tail = newNode;
        }

        Count++;
        _version++;
    }

    /// <summary>
    /// Removes the first occurrence of the specified value.
    /// </summary>
    /// <returns><see langword="true"/> when a value was removed; otherwise, <see langword="false"/>.</returns>
    public bool Remove(T value)
    {
        Node? previous = null;
        Node? current = _head;

        while (current is not null)
        {
            if (_comparer.Equals(current.Value, value))
            {
                if (previous is null)
                {
                    _head = current.Next;
                }
                else
                {
                    previous.Next = current.Next;
                }

                if (current.Next is null)
                {
                    _tail = previous;
                }

                Count--;
                _version++;
                return true;
            }

            previous = current;
            current = current.Next;
        }

        return false;
    }

    /// <summary>
    /// Determines whether the list contains the specified value.
    /// </summary>
    public bool Contains(T value)
    {
        Node? current = _head;

        while (current is not null)
        {
            if (_comparer.Equals(current.Value, value))
            {
                return true;
            }

            current = current.Next;
        }

        return false;
    }

    /// <summary>
    /// Returns the values in the list from first to last.
    /// </summary>
    public IEnumerable<T> ToEnumerable()
    {
        int version = _version;
        Node? current = _head;

        while (current is not null)
        {
            EnsureUnmodified(version);
            yield return current.Value;
            current = current.Next;
        }

        EnsureUnmodified(version);
    }

    private void EnsureUnmodified(int version)
    {
        if (version != _version)
        {
            throw new InvalidOperationException("The list was modified during enumeration.");
        }
    }

    private sealed class Node(T value)
    {
        public T Value { get; } = value;

        public Node? Next { get; set; }
    }
}
