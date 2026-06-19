namespace DataStructures.Algorithms.Sorting;

/// <summary>
/// Provides the merge sort algorithm.
/// </summary>
public static class MergeSort
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

        T[] temporaryItems = new T[items.Length];
        IComparer<T> comparer = Comparer<T>.Default;

        Sort(items, temporaryItems, left: 0, right: items.Length - 1, comparer);
    }

    private static void Sort<T>(T[] items, T[] temporaryItems, int left, int right, IComparer<T> comparer)
    {
        if (left >= right)
        {
            return;
        }

        int middle = left + ((right - left) / 2);

        Sort(items, temporaryItems, left, middle, comparer);
        Sort(items, temporaryItems, middle + 1, right, comparer);
        Merge(items, temporaryItems, left, middle, right, comparer);
    }

    private static void Merge<T>(
        T[] items,
        T[] temporaryItems,
        int left,
        int middle,
        int right,
        IComparer<T> comparer)
    {
        int leftIndex = left;
        int rightIndex = middle + 1;
        int temporaryIndex = left;

        while (leftIndex <= middle && rightIndex <= right)
        {
            if (comparer.Compare(items[leftIndex], items[rightIndex]) <= 0)
            {
                temporaryItems[temporaryIndex] = items[leftIndex];
                leftIndex++;
            }
            else
            {
                temporaryItems[temporaryIndex] = items[rightIndex];
                rightIndex++;
            }

            temporaryIndex++;
        }

        while (leftIndex <= middle)
        {
            temporaryItems[temporaryIndex] = items[leftIndex];
            leftIndex++;
            temporaryIndex++;
        }

        while (rightIndex <= right)
        {
            temporaryItems[temporaryIndex] = items[rightIndex];
            rightIndex++;
            temporaryIndex++;
        }

        for (int i = left; i <= right; i++)
        {
            items[i] = temporaryItems[i];
        }
    }
}
