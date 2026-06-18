namespace DataStructures.Algorithms.Sorting;

/// <summary>
/// Provides the insertion sort algorithm.
/// </summary>
public static class InsertionSort
{
    /// <summary>
    /// Sorts the array in ascending order.
    /// </summary>
    /// <exception cref="ArgumentNullException"><paramref name="items"/> is <see langword="null"/>.</exception>
    public static void Sort<T>(T[] items)
    {
        ArgumentNullException.ThrowIfNull(items);

        IComparer<T> comparer = Comparer<T>.Default;

        for (int i = 1; i < items.Length; i++)
        {
            T current = items[i];
            int j = i - 1;

            while (j >= 0 && comparer.Compare(items[j], current) > 0)
            {
                items[j + 1] = items[j];
                j--;
            }

            items[j + 1] = current;
        }
    }
}
