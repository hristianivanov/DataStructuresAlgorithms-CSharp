namespace DataStructures.Algorithms.Sorting;

/// <summary>
/// Provides the selection sort algorithm.
/// </summary>
public static class SelectionSort
{
    /// <summary>
    /// Sorts the array in ascending order.
    /// </summary>
    /// <exception cref="ArgumentNullException"><paramref name="items"/> is <see langword="null"/>.</exception>
    public static void Sort<T>(T[] items)
    {
        ArgumentNullException.ThrowIfNull(items);

        IComparer<T> comparer = Comparer<T>.Default;

        for (int i = 0; i < items.Length - 1; i++)
        {
            int smallestIndex = i;

            for (int j = i + 1; j < items.Length; j++)
            {
                if (comparer.Compare(items[j], items[smallestIndex]) < 0)
                {
                    smallestIndex = j;
                }
            }

            if (smallestIndex != i)
            {
                Swap(items, i, smallestIndex);
            }
        }
    }

    private static void Swap<T>(T[] items, int left, int right)
    {
        (items[left], items[right]) = (items[right], items[left]);
    }
}
