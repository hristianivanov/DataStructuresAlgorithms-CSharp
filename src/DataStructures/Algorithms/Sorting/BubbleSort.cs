namespace DataStructures.Algorithms.Sorting;

/// <summary>
/// Provides the bubble sort algorithm.
/// </summary>
public static class BubbleSort
{
    /// <summary>
    /// Sorts the array in ascending order.
    /// </summary>
    /// <exception cref="ArgumentNullException"><paramref name="items"/> is <see langword="null"/>.</exception>
    public static void Sort<T>(T[] items)
    {
        ArgumentNullException.ThrowIfNull(items);

        IComparer<T> comparer = Comparer<T>.Default;

        for (int pass = 0; pass < items.Length - 1; pass++)
        {
            bool swapped = false;

            for (int i = 0; i < items.Length - pass - 1; i++)
            {
                if (comparer.Compare(items[i], items[i + 1]) > 0)
                {
                    Swap(items, i, i + 1);
                    swapped = true;
                }
            }

            if (!swapped)
            {
                break;
            }
        }
    }

    private static void Swap<T>(T[] items, int left, int right)
    {
        (items[left], items[right]) = (items[right], items[left]);
    }
}
