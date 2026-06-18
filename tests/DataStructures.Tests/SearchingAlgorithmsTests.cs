using DataStructures.Algorithms.Searching;

namespace DataStructures.Tests;

public class SearchingAlgorithmsTests
{
    [Fact]
    public void LinearSearch_FindsItem()
    {
        int[] items = [4, 8, 15, 16, 23, 42];

        int index = LinearSearch.IndexOf(items, 16);

        Assert.Equal(3, index);
    }

    [Fact]
    public void LinearSearch_MissingItem_ReturnsMinusOne()
    {
        int[] items = [4, 8, 15, 16, 23, 42];

        int index = LinearSearch.IndexOf(items, 99);

        Assert.Equal(-1, index);
    }

    [Fact]
    public void LinearSearch_WorksWithStrings()
    {
        string[] items = ["alpha", "beta", "gamma"];

        int index = LinearSearch.IndexOf(items, "gamma");

        Assert.Equal(2, index);
    }

    [Fact]
    public void BinarySearch_FindsItem()
    {
        int[] items = [4, 8, 15, 16, 23, 42];

        int index = BinarySearch.IndexOf(items, 23);

        Assert.Equal(4, index);
    }

    [Fact]
    public void BinarySearch_MissingItem_ReturnsMinusOne()
    {
        int[] items = [4, 8, 15, 16, 23, 42];

        int index = BinarySearch.IndexOf(items, 99);

        Assert.Equal(-1, index);
    }

    [Fact]
    public void BinarySearch_EmptyInput_ReturnsMinusOne()
    {
        int[] items = [];

        int index = BinarySearch.IndexOf(items, 10);

        Assert.Equal(-1, index);
    }

    [Fact]
    public void SearchingAlgorithms_NullInput_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => LinearSearch.IndexOf<int>(null!, 10));
        Assert.Throws<ArgumentNullException>(() => BinarySearch.IndexOf<int>(null!, 10));
    }
}
