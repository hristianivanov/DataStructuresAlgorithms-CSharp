namespace DataStructures.Tests;

public class CircularQueueTests
{
    [Fact]
    public void NewQueue_IsEmpty()
    {
        CircularQueue<int> queue = new();

        Assert.True(queue.IsEmpty);
        Assert.Equal(0, queue.Count);
        Assert.Empty(queue.ToEnumerable());
    }

    [Fact]
    public void Enqueue_AddsItemAndClearRemovesAllItems()
    {
        CircularQueue<int> queue = new();

        queue.Enqueue(10);
        queue.Clear();

        Assert.True(queue.IsEmpty);
        Assert.Equal(0, queue.Count);
        Assert.Empty(queue.ToEnumerable());
    }

    [Fact]
    public void Dequeue_ReturnsItemsInFifoOrder()
    {
        CircularQueue<int> queue = new();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);

        Assert.Equal(1, queue.Dequeue());
        Assert.Equal(2, queue.Dequeue());
        Assert.Equal(3, queue.Dequeue());
        Assert.True(queue.IsEmpty);
    }

    [Fact]
    public void Peek_ReturnsFrontItemWithoutRemovingIt()
    {
        CircularQueue<int> queue = new();
        queue.Enqueue(1);
        queue.Enqueue(2);

        int item = queue.Peek();

        Assert.Equal(1, item);
        Assert.Equal(2, queue.Count);
    }

    [Fact]
    public void Dequeue_EmptyQueue_ThrowsInvalidOperationException()
    {
        CircularQueue<int> queue = new();

        Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
    }

    [Fact]
    public void Peek_EmptyQueue_ThrowsInvalidOperationException()
    {
        CircularQueue<int> queue = new();

        Assert.Throws<InvalidOperationException>(() => queue.Peek());
    }

    [Fact]
    public void CircularBehavior_KeepsItemsInFifoOrderAfterWrapping()
    {
        CircularQueue<int> queue = new(initialCapacity: 3);
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        Assert.Equal(1, queue.Dequeue());
        Assert.Equal(2, queue.Dequeue());

        queue.Enqueue(4);
        queue.Enqueue(5);

        Assert.Equal([3, 4, 5], queue.ToEnumerable());
        Assert.Equal(3, queue.Dequeue());
        Assert.Equal(4, queue.Dequeue());
        Assert.Equal(5, queue.Dequeue());
    }

    [Fact]
    public void Resize_KeepsItemsInFifoOrder()
    {
        CircularQueue<int> queue = new(initialCapacity: 2);

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);

        Assert.Equal([1, 2, 3], queue.ToEnumerable());
        Assert.Equal(1, queue.Dequeue());
        Assert.Equal(2, queue.Dequeue());
        Assert.Equal(3, queue.Dequeue());
    }

    [Fact]
    public void Resize_AfterWrapping_KeepsItemsInFifoOrder()
    {
        CircularQueue<int> queue = new(initialCapacity: 3);
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        Assert.Equal(1, queue.Dequeue());
        Assert.Equal(2, queue.Dequeue());
        queue.Enqueue(4);
        queue.Enqueue(5);

        queue.Enqueue(6);

        Assert.Equal([3, 4, 5, 6], queue.ToEnumerable());
    }

    [Fact]
    public void Constructor_InvalidInitialCapacity_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new CircularQueue<int>(0));
    }
}
