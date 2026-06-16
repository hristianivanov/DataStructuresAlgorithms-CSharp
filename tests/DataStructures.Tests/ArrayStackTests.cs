namespace DataStructures.Tests;

public class ArrayStackTests
{
    [Fact]
    public void NewStack_IsEmpty()
    {
        ArrayStack<int> stack = new();

        Assert.True(stack.IsEmpty);
        Assert.Equal(0, stack.Count);
        Assert.Empty(stack.ToEnumerable());
    }

    [Fact]
    public void Push_AddsItemAndClearRemovesAllItems()
    {
        ArrayStack<int> stack = new();

        stack.Push(10);
        stack.Clear();

        Assert.True(stack.IsEmpty);
        Assert.Equal(0, stack.Count);
        Assert.Empty(stack.ToEnumerable());
    }

    [Fact]
    public void Pop_ReturnsItemsInLifoOrder()
    {
        ArrayStack<int> stack = new();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        Assert.Equal(3, stack.Pop());
        Assert.Equal(2, stack.Pop());
        Assert.Equal(1, stack.Pop());
        Assert.True(stack.IsEmpty);
    }

    [Fact]
    public void Peek_ReturnsTopItemWithoutRemovingIt()
    {
        ArrayStack<int> stack = new();
        stack.Push(1);
        stack.Push(2);

        int item = stack.Peek();

        Assert.Equal(2, item);
        Assert.Equal(2, stack.Count);
    }

    [Fact]
    public void Pop_EmptyStack_ThrowsInvalidOperationException()
    {
        ArrayStack<int> stack = new();

        Assert.Throws<InvalidOperationException>(() => stack.Pop());
    }

    [Fact]
    public void Peek_EmptyStack_ThrowsInvalidOperationException()
    {
        ArrayStack<int> stack = new();

        Assert.Throws<InvalidOperationException>(() => stack.Peek());
    }

    [Fact]
    public void Resize_KeepsItemsInLifoOrder()
    {
        ArrayStack<int> stack = new(initialCapacity: 2);

        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        Assert.Equal([3, 2, 1], stack.ToEnumerable());
        Assert.Equal(3, stack.Pop());
        Assert.Equal(2, stack.Pop());
        Assert.Equal(1, stack.Pop());
    }

    [Fact]
    public void Constructor_InvalidInitialCapacity_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new ArrayStack<int>(0));
    }
}
