namespace DataStructures.Tests;

public class SinglyLinkedListTests
{
    [Fact]
    public void NewList_IsEmpty()
    {
        SinglyLinkedList<int> list = new();

        Assert.True(list.IsEmpty);
        Assert.Equal(0, list.Count);
        Assert.Empty(list.ToEnumerable());
    }

    [Fact]
    public void AddFirst_AddsValueToBeginning()
    {
        SinglyLinkedList<int> list = new();

        list.AddFirst(2);
        list.AddFirst(1);

        Assert.Equal([1, 2], list.ToEnumerable());
    }

    [Fact]
    public void AddLast_AddsValueToEnd()
    {
        SinglyLinkedList<int> list = new();

        list.AddLast(1);
        list.AddLast(2);

        Assert.Equal([1, 2], list.ToEnumerable());
    }

    [Fact]
    public void Remove_Head_RemovesFirstValue()
    {
        SinglyLinkedList<int> list = CreateList(1, 2, 3);

        bool wasRemoved = list.Remove(1);

        Assert.True(wasRemoved);
        Assert.Equal([2, 3], list.ToEnumerable());
    }

    [Fact]
    public void Remove_MiddleElement_RemovesMatchingValue()
    {
        SinglyLinkedList<int> list = CreateList(1, 2, 3);

        bool wasRemoved = list.Remove(2);

        Assert.True(wasRemoved);
        Assert.Equal([1, 3], list.ToEnumerable());
    }

    [Fact]
    public void Remove_MissingElement_ReturnsFalseAndLeavesListUnchanged()
    {
        SinglyLinkedList<int> list = CreateList(1, 2, 3);

        bool wasRemoved = list.Remove(4);

        Assert.False(wasRemoved);
        Assert.Equal([1, 2, 3], list.ToEnumerable());
    }

    [Fact]
    public void Remove_EmptyList_ReturnsFalse()
    {
        SinglyLinkedList<int> list = new();

        bool wasRemoved = list.Remove(1);

        Assert.False(wasRemoved);
        Assert.True(list.IsEmpty);
    }

    [Fact]
    public void Remove_Tail_AllowsValueToBeAddedAtEnd()
    {
        SinglyLinkedList<int> list = CreateList(1, 2, 3);

        bool wasRemoved = list.Remove(3);
        list.AddLast(4);

        Assert.True(wasRemoved);
        Assert.Equal([1, 2, 4], list.ToEnumerable());
    }

    [Fact]
    public void Remove_DuplicateValues_RemovesOnlyFirstOccurrence()
    {
        SinglyLinkedList<int> list = CreateList(1, 2, 2, 3);

        bool wasRemoved = list.Remove(2);

        Assert.True(wasRemoved);
        Assert.Equal([1, 2, 3], list.ToEnumerable());
        Assert.Equal(3, list.Count);
    }

    [Fact]
    public void Contains_ExistingElement_ReturnsTrue()
    {
        SinglyLinkedList<int> list = CreateList(1, 2, 3);

        Assert.True(list.Contains(2));
    }

    [Fact]
    public void Contains_MissingElement_ReturnsFalse()
    {
        SinglyLinkedList<int> list = CreateList(1, 2, 3);

        Assert.False(list.Contains(4));
    }

    [Fact]
    public void Count_UpdatesAfterAddsAndRemoves()
    {
        SinglyLinkedList<int> list = new();

        list.AddFirst(2);
        list.AddFirst(1);
        list.AddLast(3);
        bool wasRemoved = list.Remove(2);

        Assert.True(wasRemoved);
        Assert.Equal(2, list.Count);
        Assert.False(list.IsEmpty);
    }

    [Fact]
    public void AddLast_AfterRemovingOnlyValue_AddsToEmptyList()
    {
        SinglyLinkedList<int> list = new();
        list.AddLast(1);
        list.Remove(1);

        list.AddLast(2);

        Assert.Equal([2], list.ToEnumerable());
        Assert.Equal(1, list.Count);
    }

    [Fact]
    public void NullableValues_CanBeAddedFoundAndRemoved()
    {
        SinglyLinkedList<string?> list = new();
        list.AddLast("value");
        list.AddLast(null);

        bool containsNull = list.Contains(null);
        bool wasRemoved = list.Remove(null);

        Assert.True(containsNull);
        Assert.True(wasRemoved);
        Assert.Equal(["value"], list.ToEnumerable());
    }

    [Fact]
    public void CustomComparer_IsUsedByContainsAndRemove()
    {
        SinglyLinkedList<string> list = new(StringComparer.OrdinalIgnoreCase);
        list.AddLast("VALUE");

        bool containsValue = list.Contains("value");
        bool wasRemoved = list.Remove("value");

        Assert.True(containsValue);
        Assert.True(wasRemoved);
        Assert.True(list.IsEmpty);
    }

    [Fact]
    public void Constructor_NullComparer_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new SinglyLinkedList<int>(null!));
    }

    [Fact]
    public void ToEnumerable_WhenListChangesDuringEnumeration_ThrowsInvalidOperationException()
    {
        SinglyLinkedList<int> list = CreateList(1);
        using IEnumerator<int> enumerator = list.ToEnumerable().GetEnumerator();
        Assert.True(enumerator.MoveNext());

        list.AddLast(2);

        Assert.Throws<InvalidOperationException>(() => enumerator.MoveNext());
    }

    private static SinglyLinkedList<int> CreateList(params int[] values)
    {
        SinglyLinkedList<int> list = new();

        foreach (int value in values)
        {
            list.AddLast(value);
        }

        return list;
    }
}
