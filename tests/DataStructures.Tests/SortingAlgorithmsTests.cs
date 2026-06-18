using DataStructures.Algorithms.Sorting;

namespace DataStructures.Tests;

public class SortingAlgorithmsTests
{
    [Fact]
    public void BubbleSort_SortsIntegers()
    {
        int[] items = [5, 1, 4, 2, 8];

        BubbleSort.Sort(items);

        Assert.Equal([1, 2, 4, 5, 8], items);
    }

    [Fact]
    public void SelectionSort_SortsIntegers()
    {
        int[] items = [64, 25, 12, 22, 11];

        SelectionSort.Sort(items);

        Assert.Equal([11, 12, 22, 25, 64], items);
    }

    [Fact]
    public void InsertionSort_SortsIntegers()
    {
        int[] items = [12, 11, 13, 5, 6];

        InsertionSort.Sort(items);

        Assert.Equal([5, 6, 11, 12, 13], items);
    }

    [Fact]
    public void SortingAlgorithms_HandleAlreadySortedArray()
    {
        AssertAllSortingAlgorithms([1, 2, 3, 4], [1, 2, 3, 4]);
    }

    [Fact]
    public void SortingAlgorithms_HandleReverseSortedArray()
    {
        AssertAllSortingAlgorithms([5, 4, 3, 2, 1], [1, 2, 3, 4, 5]);
    }

    [Fact]
    public void SortingAlgorithms_HandleDuplicates()
    {
        AssertAllSortingAlgorithms([3, 1, 2, 3, 1], [1, 1, 2, 3, 3]);
    }

    [Fact]
    public void SortingAlgorithms_HandleStrings()
    {
        AssertAllSortingAlgorithms(["pear", "apple", "orange"], ["apple", "orange", "pear"]);
    }

    [Fact]
    public void SortingAlgorithms_NullInput_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => BubbleSort.Sort<int>(null!));
        Assert.Throws<ArgumentNullException>(() => SelectionSort.Sort<int>(null!));
        Assert.Throws<ArgumentNullException>(() => InsertionSort.Sort<int>(null!));
    }

    private static void AssertAllSortingAlgorithms<T>(T[] input, T[] expected)
    {
        T[] bubbleItems = [.. input];
        T[] selectionItems = [.. input];
        T[] insertionItems = [.. input];

        BubbleSort.Sort(bubbleItems);
        SelectionSort.Sort(selectionItems);
        InsertionSort.Sort(insertionItems);

        Assert.Equal(expected, bubbleItems);
        Assert.Equal(expected, selectionItems);
        Assert.Equal(expected, insertionItems);
    }
}
