namespace DataStructures.Tests;

public class SeparateChainingHashTableTests
{
    [Fact]
    public void NewHashTable_IsEmpty()
    {
        SeparateChainingHashTable<string, int> table = new();

        Assert.True(table.IsEmpty);
        Assert.Equal(0, table.Count);
        Assert.Empty(table.ToEnumerable());
    }

    [Fact]
    public void Add_IncreasesCount()
    {
        SeparateChainingHashTable<string, int> table = new();

        table.Add("one", 1);

        Assert.False(table.IsEmpty);
        Assert.Equal(1, table.Count);
    }

    [Fact]
    public void Add_DuplicateKey_ThrowsArgumentException()
    {
        SeparateChainingHashTable<string, int> table = new();
        table.Add("one", 1);

        Assert.Throws<ArgumentException>(() => table.Add("one", 10));
    }

    [Fact]
    public void Add_NullKey_ThrowsArgumentNullException()
    {
        SeparateChainingHashTable<string, int> table = new();

        Assert.Throws<ArgumentNullException>(() => table.Add(null!, 1));
    }

    [Fact]
    public void NullKeyOperations_ThrowArgumentNullException()
    {
        SeparateChainingHashTable<string, int> table = new();

        Assert.Throws<ArgumentNullException>(() => table.ContainsKey(null!));
        Assert.Throws<ArgumentNullException>(() => table.TryGetValue(null!, out _));
        Assert.Throws<ArgumentNullException>(() => table.Remove(null!));
    }

    [Fact]
    public void ContainsKey_ExistingKey_ReturnsTrue()
    {
        SeparateChainingHashTable<string, int> table = new();
        table.Add("one", 1);

        Assert.True(table.ContainsKey("one"));
    }

    [Fact]
    public void ContainsKey_MissingKey_ReturnsFalse()
    {
        SeparateChainingHashTable<string, int> table = new();
        table.Add("one", 1);

        Assert.False(table.ContainsKey("two"));
    }

    [Fact]
    public void TryGetValue_ExistingKey_ReturnsValue()
    {
        SeparateChainingHashTable<string, int> table = new();
        table.Add("one", 1);

        bool wasFound = table.TryGetValue("one", out int value);

        Assert.True(wasFound);
        Assert.Equal(1, value);
    }

    [Fact]
    public void TryGetValue_MissingKey_ReturnsFalseAndDefaultValue()
    {
        SeparateChainingHashTable<string, int> table = new();
        table.Add("one", 1);

        bool wasFound = table.TryGetValue("two", out int value);

        Assert.False(wasFound);
        Assert.Equal(default, value);
    }

    [Fact]
    public void Remove_ExistingKey_ReturnsTrueAndDecreasesCount()
    {
        SeparateChainingHashTable<string, int> table = new();
        table.Add("one", 1);
        table.Add("two", 2);

        bool wasRemoved = table.Remove("one");

        Assert.True(wasRemoved);
        Assert.Equal(1, table.Count);
        Assert.False(table.ContainsKey("one"));
    }

    [Fact]
    public void Remove_MissingKey_ReturnsFalse()
    {
        SeparateChainingHashTable<string, int> table = new();
        table.Add("one", 1);

        bool wasRemoved = table.Remove("two");

        Assert.False(wasRemoved);
        Assert.Equal(1, table.Count);
    }

    [Fact]
    public void Clear_RemovesAllEntries()
    {
        SeparateChainingHashTable<string, int> table = new();
        table.Add("one", 1);
        table.Add("two", 2);

        table.Clear();

        Assert.True(table.IsEmpty);
        Assert.Equal(0, table.Count);
        Assert.Empty(table.ToEnumerable());
    }

    [Fact]
    public void ToEnumerable_ReturnsAllEntries()
    {
        SeparateChainingHashTable<string, int> table = new();
        table.Add("one", 1);
        table.Add("two", 2);

        Dictionary<string, int> entries = table.ToEnumerable().ToDictionary(pair => pair.Key, pair => pair.Value);

        Assert.Equal(2, entries.Count);
        Assert.Equal(1, entries["one"]);
        Assert.Equal(2, entries["two"]);
    }

    [Fact]
    public void Resize_KeepsAllExistingValuesAccessible()
    {
        SeparateChainingHashTable<int, string> table = new(initialCapacity: 2);

        for (int i = 0; i < 10; i++)
        {
            table.Add(i, $"value-{i}");
        }

        for (int i = 0; i < 10; i++)
        {
            Assert.True(table.TryGetValue(i, out string? value));
            Assert.Equal($"value-{i}", value);
        }
    }

    [Fact]
    public void CollisionHandling_WorksForDifferentKeysWithSameHashCode()
    {
        SeparateChainingHashTable<CollisionKey, string> table = new(initialCapacity: 2);
        CollisionKey first = new("first");
        CollisionKey second = new("second");

        table.Add(first, "value-1");
        table.Add(second, "value-2");

        Assert.True(table.TryGetValue(first, out string? firstValue));
        Assert.True(table.TryGetValue(second, out string? secondValue));
        Assert.Equal("value-1", firstValue);
        Assert.Equal("value-2", secondValue);
        Assert.Equal(2, table.Count);
    }

    [Fact]
    public void Remove_CollidingKey_RemovesOnlyMatchingEntry()
    {
        SeparateChainingHashTable<CollisionKey, string> table = new(initialCapacity: 4);
        CollisionKey first = new("first");
        CollisionKey second = new("second");
        table.Add(first, "value-1");
        table.Add(second, "value-2");

        bool wasRemoved = table.Remove(first);

        Assert.True(wasRemoved);
        Assert.False(table.ContainsKey(first));
        Assert.True(table.TryGetValue(second, out string? secondValue));
        Assert.Equal("value-2", secondValue);
        Assert.Equal(1, table.Count);
    }

    private sealed class CollisionKey(string value)
    {
        public string Value { get; } = value;

        public override bool Equals(object? obj)
        {
            return obj is CollisionKey other && Value == other.Value;
        }

        public override int GetHashCode()
        {
            return 1;
        }
    }
}
