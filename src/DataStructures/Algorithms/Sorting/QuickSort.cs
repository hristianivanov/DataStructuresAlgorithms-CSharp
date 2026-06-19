namespace DataStructures.Algorithms.Sorting;

/// <summary>
/// Provides the quick sort algorithm.
/// </summary>
public static class QuickSort
{
    /// <summary>
    /// Sorts the array in ascending order.
    /// </summary>
    /// <exception cref="ArgumentNullException"><paramref name="items"/> is <see langword="null"/>.</exception>
    public static void Sort<T>(T[] items)
    {
        ArgumentNullException.ThrowIfNull(items);

        if (items.Length < 2)
        {
            return;
        }

        IComparer<T> comparer = Comparer<T>.Default;
        Sort(items, left: 0, right: items.Length - 1, comparer);
    }

    private static void Sort<T>(T[] items, int left, int right, IComparer<T> comparer)
    {
        if (left >= right)
        {
            return;
        }

        int partitionIndex = Partition(items, left, right, comparer);

        Sort(items, left, partitionIndex, comparer);
        Sort(items, partitionIndex + 1, right, comparer);
    }

    private static int Partition<T>(T[] items, int left, int right, IComparer<T> comparer)
    {
        T pivot = items[left + ((right - left) / 2)];
        int i = left - 1;
        int j = right + 1;

        while (true)
        {
            do
            {
                i++;
            }
            while (comparer.Compare(items[i], pivot) < 0);

            do
            {
                j--;
            }
            while (comparer.Compare(items[j], pivot) > 0);

            if (i >= j)
            {
                return j;
            }

            Swap(items, i, j);
        }
    }

    private static void Swap<T>(T[] items, int left, int right)
    {
        (items[left], items[right]) = (items[right], items[left]);
    }
}
