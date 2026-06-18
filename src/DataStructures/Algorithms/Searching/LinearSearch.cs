namespace DataStructures.Algorithms.Searching;

/// <summary>
/// Provides a linear search algorithm.
/// </summary>
public static class LinearSearch
{
    /// <summary>
    /// Searches the collection from left to right and returns the index of the first matching item.
    /// </summary>
    /// <returns>The index of the item when found; otherwise, -1.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="items"/> is <see langword="null"/>.</exception>
    public static int IndexOf<T>(IReadOnlyList<T> items, T target)
    {
        ArgumentNullException.ThrowIfNull(items);

        EqualityComparer<T> comparer = EqualityComparer<T>.Default;

        for (int i = 0; i < items.Count; i++)
        {
            if (comparer.Equals(items[i], target))
            {
                return i;
            }
        }

        return -1;
    }
}
