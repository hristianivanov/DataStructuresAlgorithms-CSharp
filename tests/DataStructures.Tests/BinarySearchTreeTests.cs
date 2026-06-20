using DataStructures.Trees;

namespace DataStructures.Tests;

public class BinarySearchTreeTests
{
    [Fact]
    public void NewTree_IsEmpty()
    {
        BinarySearchTree<int> tree = new();

        Assert.True(tree.IsEmpty);
        Assert.Equal(0, tree.Count);
        Assert.Empty(tree.InOrderTraversal());
    }

    [Fact]
    public void Add_IncreasesCount()
    {
        BinarySearchTree<int> tree = new();

        tree.Add(10);
        tree.Add(5);

        Assert.False(tree.IsEmpty);
        Assert.Equal(2, tree.Count);
    }

    [Fact]
    public void Add_DuplicateValue_ThrowsArgumentException()
    {
        BinarySearchTree<int> tree = new();
        tree.Add(10);

        Assert.Throws<ArgumentException>(() => tree.Add(10));
    }

    [Fact]
    public void Contains_ExistingValue_ReturnsTrue()
    {
        BinarySearchTree<int> tree = CreateTree();

        Assert.True(tree.Contains(12));
    }

    [Fact]
    public void Contains_MissingValue_ReturnsFalse()
    {
        BinarySearchTree<int> tree = CreateTree();

        Assert.False(tree.Contains(99));
    }

    [Fact]
    public void InOrderTraversal_ReturnsSortedValues()
    {
        BinarySearchTree<int> tree = CreateTree();

        Assert.Equal([3, 5, 7, 10, 12, 15, 18], tree.InOrderTraversal());
    }

    [Fact]
    public void PreOrderTraversal_ReturnsExpectedOrder()
    {
        BinarySearchTree<int> tree = CreateTree();

        Assert.Equal([10, 5, 3, 7, 15, 12, 18], tree.PreOrderTraversal());
    }

    [Fact]
    public void PostOrderTraversal_ReturnsExpectedOrder()
    {
        BinarySearchTree<int> tree = CreateTree();

        Assert.Equal([3, 7, 5, 12, 18, 15, 10], tree.PostOrderTraversal());
    }

    [Fact]
    public void Remove_LeafNode_ReturnsTrueAndRemovesValue()
    {
        BinarySearchTree<int> tree = CreateTree();

        bool wasRemoved = tree.Remove(3);

        Assert.True(wasRemoved);
        Assert.False(tree.Contains(3));
        Assert.Equal([5, 7, 10, 12, 15, 18], tree.InOrderTraversal());
        Assert.Equal(6, tree.Count);
    }

    [Fact]
    public void Remove_NodeWithOneChild_ReturnsTrueAndKeepsChild()
    {
        BinarySearchTree<int> tree = new();
        tree.Add(10);
        tree.Add(5);
        tree.Add(3);

        bool wasRemoved = tree.Remove(5);

        Assert.True(wasRemoved);
        Assert.Equal([3, 10], tree.InOrderTraversal());
        Assert.Equal(2, tree.Count);
    }

    [Fact]
    public void Remove_NodeWithTwoChildren_ReturnsTrueAndKeepsTreeSorted()
    {
        BinarySearchTree<int> tree = CreateTree();

        bool wasRemoved = tree.Remove(5);

        Assert.True(wasRemoved);
        Assert.Equal([3, 7, 10, 12, 15, 18], tree.InOrderTraversal());
        Assert.Equal(6, tree.Count);
    }

    [Fact]
    public void Remove_RootNode_ReturnsTrueAndKeepsTreeSorted()
    {
        BinarySearchTree<int> tree = CreateTree();

        bool wasRemoved = tree.Remove(10);

        Assert.True(wasRemoved);
        Assert.Equal([3, 5, 7, 12, 15, 18], tree.InOrderTraversal());
        Assert.Equal(6, tree.Count);
    }

    [Fact]
    public void Remove_OnlyRootNode_ReturnsTrueAndEmptiesTree()
    {
        BinarySearchTree<int> tree = new();
        tree.Add(10);

        bool wasRemoved = tree.Remove(10);

        Assert.True(wasRemoved);
        Assert.True(tree.IsEmpty);
        Assert.Equal(0, tree.Count);
        Assert.Empty(tree.InOrderTraversal());
    }

    [Fact]
    public void Remove_MissingValue_ReturnsFalse()
    {
        BinarySearchTree<int> tree = CreateTree();

        bool wasRemoved = tree.Remove(99);

        Assert.False(wasRemoved);
        Assert.Equal(7, tree.Count);
    }

    [Fact]
    public void Clear_RemovesAllNodes()
    {
        BinarySearchTree<int> tree = CreateTree();

        tree.Clear();

        Assert.True(tree.IsEmpty);
        Assert.Equal(0, tree.Count);
        Assert.Empty(tree.InOrderTraversal());
    }

    [Fact]
    public void NullValueOperations_ThrowArgumentNullException()
    {
        BinarySearchTree<string> tree = new();

        Assert.Throws<ArgumentNullException>(() => tree.Add(null!));
        Assert.Throws<ArgumentNullException>(() => tree.Contains(null!));
        Assert.Throws<ArgumentNullException>(() => tree.Remove(null!));
    }

    private static BinarySearchTree<int> CreateTree()
    {
        BinarySearchTree<int> tree = new();

        foreach (int value in new[] { 10, 5, 15, 3, 7, 12, 18 })
        {
            tree.Add(value);
        }

        return tree;
    }
}
