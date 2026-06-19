using DataStructures.Algorithms.Sorting;

namespace DataStructures.Tests;

public class AdvancedSortingAlgorithmsTests
{
    [Fact]
    public void MergeSort_SortsIntegers()
    {
        int[] items = [8, 3, 5, 4, 7, 6, 1, 2];

        MergeSort.Sort(items);

        Assert.Equal([1, 2, 3, 4, 5, 6, 7, 8], items);
    }

    [Fact]
    public void MergeSort_HandlesEmptyArray()
    {
        int[] items = [];

        MergeSort.Sort(items);

        Assert.Empty(items);
    }

    [Fact]
    public void MergeSort_HandlesOneItemArray()
    {
        int[] items = [42];

        MergeSort.Sort(items);

        Assert.Equal([42], items);
    }

    [Fact]
    public void MergeSort_HandlesDuplicates()
    {
        int[] items = [4, 2, 4, 1, 2];

        MergeSort.Sort(items);

        Assert.Equal([1, 2, 2, 4, 4], items);
    }

    [Fact]
    public void MergeSort_HandlesReverseSortedArray()
    {
        int[] items = [5, 4, 3, 2, 1];

        MergeSort.Sort(items);

        Assert.Equal([1, 2, 3, 4, 5], items);
    }

    [Fact]
    public void MergeSort_HandlesStrings()
    {
        string[] items = ["delta", "alpha", "charlie", "bravo"];

        MergeSort.Sort(items);

        Assert.Equal(["alpha", "bravo", "charlie", "delta"], items);
    }

    [Fact]
    public void QuickSort_SortsIntegers()
    {
        int[] items = [8, 3, 5, 4, 7, 6, 1, 2];

        QuickSort.Sort(items);

        Assert.Equal([1, 2, 3, 4, 5, 6, 7, 8], items);
    }

    [Fact]
    public void QuickSort_HandlesEmptyArray()
    {
        int[] items = [];

        QuickSort.Sort(items);

        Assert.Empty(items);
    }

    [Fact]
    public void QuickSort_HandlesOneItemArray()
    {
        int[] items = [42];

        QuickSort.Sort(items);

        Assert.Equal([42], items);
    }

    [Fact]
    public void QuickSort_HandlesDuplicates()
    {
        int[] items = [4, 2, 4, 1, 2];

        QuickSort.Sort(items);

        Assert.Equal([1, 2, 2, 4, 4], items);
    }

    [Fact]
    public void QuickSort_HandlesReverseSortedArray()
    {
        int[] items = [5, 4, 3, 2, 1];

        QuickSort.Sort(items);

        Assert.Equal([1, 2, 3, 4, 5], items);
    }

    [Fact]
    public void QuickSort_HandlesStrings()
    {
        string[] items = ["delta", "alpha", "charlie", "bravo"];

        QuickSort.Sort(items);

        Assert.Equal(["alpha", "bravo", "charlie", "delta"], items);
    }

    [Fact]
    public void AdvancedSortingAlgorithms_NullInput_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => MergeSort.Sort<int>(null!));
        Assert.Throws<ArgumentNullException>(() => QuickSort.Sort<int>(null!));
    }
}
