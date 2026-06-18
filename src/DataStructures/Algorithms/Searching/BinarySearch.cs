namespace DataStructures.Algorithms.Searching;

/// <summary>
/// Provides a binary search algorithm for sorted collections.
/// </summary>
public static class BinarySearch
{
    /// <summary>
    /// Searches a sorted collection and returns the index of the matching item.
    /// </summary>
    /// <returns>The index of the item when found; otherwise, -1.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="items"/> is <see langword="null"/>.</exception>
    public static int IndexOf<T>(IReadOnlyList<T> items, T target)
    {
        ArgumentNullException.ThrowIfNull(items);

        IComparer<T> comparer = Comparer<T>.Default;
        int left = 0;
        int right = items.Count - 1;

        while (left <= right)
        {
            int middle = left + ((right - left) / 2);
            int comparison = comparer.Compare(items[middle], target);

            if (comparison == 0)
            {
                return middle;
            }

            if (comparison < 0)
            {
                left = middle + 1;
            }
            else
            {
                right = middle - 1;
            }
        }

        return -1;
    }
}
