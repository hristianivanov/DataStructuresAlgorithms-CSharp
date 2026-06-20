namespace DataStructures.Trees;

/// <summary>
/// Represents a generic binary search tree.
/// </summary>
/// <typeparam name="T">The type of values stored in the tree.</typeparam>
public sealed class BinarySearchTree<T>
{
    private readonly IComparer<T> _comparer = Comparer<T>.Default;
    private Node? _root;

    /// <summary>
    /// Gets the number of values in the tree.
    /// </summary>
    public int Count { get; private set; }

    /// <summary>
    /// Gets a value indicating whether the tree contains no values.
    /// </summary>
    public bool IsEmpty => Count == 0;

    /// <summary>
    /// Adds a value to the tree.
    /// </summary>
    /// <exception cref="ArgumentNullException"><paramref name="value"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">The value already exists in the tree.</exception>
    public void Add(T value)
    {
        ValidateValue(value);

        if (_root is null)
        {
            _root = new Node(value);
            Count++;
            return;
        }

        Node current = _root;

        while (true)
        {
            int comparison = _comparer.Compare(value, current.Value);

            if (comparison == 0)
            {
                throw new ArgumentException("The value already exists in the tree.", nameof(value));
            }

            if (comparison < 0)
            {
                if (current.Left is null)
                {
                    current.Left = new Node(value);
                    Count++;
                    return;
                }

                current = current.Left;
            }
            else
            {
                if (current.Right is null)
                {
                    current.Right = new Node(value);
                    Count++;
                    return;
                }

                current = current.Right;
            }
        }
    }

    /// <summary>
    /// Determines whether the tree contains the specified value.
    /// </summary>
    /// <exception cref="ArgumentNullException"><paramref name="value"/> is <see langword="null"/>.</exception>
    public bool Contains(T value)
    {
        ValidateValue(value);
        return FindNode(value) is not null;
    }

    /// <summary>
    /// Removes the specified value from the tree.
    /// </summary>
    /// <returns><see langword="true"/> if the value was removed; otherwise, <see langword="false"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="value"/> is <see langword="null"/>.</exception>
    public bool Remove(T value)
    {
        ValidateValue(value);

        bool wasRemoved = false;
        _root = Remove(_root, value, ref wasRemoved);

        if (wasRemoved)
        {
            Count--;
        }

        return wasRemoved;
    }

    /// <summary>
    /// Removes all values from the tree.
    /// </summary>
    public void Clear()
    {
        _root = null;
        Count = 0;
    }

    /// <summary>
    /// Returns the values in sorted order.
    /// </summary>
    public IEnumerable<T> InOrderTraversal()
    {
        return InOrderTraversal(_root);
    }

    /// <summary>
    /// Returns the values in root-left-right order.
    /// </summary>
    public IEnumerable<T> PreOrderTraversal()
    {
        return PreOrderTraversal(_root);
    }

    /// <summary>
    /// Returns the values in left-right-root order.
    /// </summary>
    public IEnumerable<T> PostOrderTraversal()
    {
        return PostOrderTraversal(_root);
    }

    private Node? FindNode(T value)
    {
        Node? current = _root;

        while (current is not null)
        {
            int comparison = _comparer.Compare(value, current.Value);

            if (comparison == 0)
            {
                return current;
            }

            current = comparison < 0 ? current.Left : current.Right;
        }

        return null;
    }

    private Node? Remove(Node? current, T value, ref bool wasRemoved)
    {
        if (current is null)
        {
            return null;
        }

        int comparison = _comparer.Compare(value, current.Value);

        if (comparison < 0)
        {
            current.Left = Remove(current.Left, value, ref wasRemoved);
            return current;
        }

        if (comparison > 0)
        {
            current.Right = Remove(current.Right, value, ref wasRemoved);
            return current;
        }

        wasRemoved = true;

        if (current.Left is null)
        {
            return current.Right;
        }

        if (current.Right is null)
        {
            return current.Left;
        }

        Node successor = FindMinimum(current.Right);
        current.Value = successor.Value;
        current.Right = RemoveMinimum(current.Right);
        return current;
    }

    private static Node FindMinimum(Node current)
    {
        while (current.Left is not null)
        {
            current = current.Left;
        }

        return current;
    }

    private static Node? RemoveMinimum(Node current)
    {
        if (current.Left is null)
        {
            return current.Right;
        }

        current.Left = RemoveMinimum(current.Left);
        return current;
    }

    private static IEnumerable<T> InOrderTraversal(Node? current)
    {
        if (current is null)
        {
            yield break;
        }

        foreach (T value in InOrderTraversal(current.Left))
        {
            yield return value;
        }

        yield return current.Value;

        foreach (T value in InOrderTraversal(current.Right))
        {
            yield return value;
        }
    }

    private static IEnumerable<T> PreOrderTraversal(Node? current)
    {
        if (current is null)
        {
            yield break;
        }

        yield return current.Value;

        foreach (T value in PreOrderTraversal(current.Left))
        {
            yield return value;
        }

        foreach (T value in PreOrderTraversal(current.Right))
        {
            yield return value;
        }
    }

    private static IEnumerable<T> PostOrderTraversal(Node? current)
    {
        if (current is null)
        {
            yield break;
        }

        foreach (T value in PostOrderTraversal(current.Left))
        {
            yield return value;
        }

        foreach (T value in PostOrderTraversal(current.Right))
        {
            yield return value;
        }

        yield return current.Value;
    }

    private static void ValidateValue(T value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }
    }

    private sealed class Node(T value)
    {
        public T Value { get; set; } = value;

        public Node? Left { get; set; }

        public Node? Right { get; set; }
    }
}
