# Data Structures and Algorithms in C#

## Overview

This repository contains clean, tested implementations of common data structures and algorithms in C#. Day 1 introduced a generic singly linked list, Day 2 added array-backed stack and queue implementations, Day 3 added a hash table using separate chaining, and Day 4 adds searching and basic sorting algorithms.

## Purpose

The project is designed for:

- Practicing data structures and algorithms
- Preparing for technical interviews
- Demonstrating clean, beginner-friendly C# implementations
- Documenting time and space complexity

## Tech Stack

- .NET 8
- C# with nullable reference types enabled
- xUnit
- Visual Studio, Visual Studio Code, or the .NET CLI

## Project Structure

```text
DataStructuresAlgorithms-CSharp/
|-- DataStructuresAlgorithms.sln
|-- src/
|   `-- DataStructures/
|       |-- Algorithms/
|       |   |-- Searching/
|       |   |   |-- BinarySearch.cs
|       |   |   `-- LinearSearch.cs
|       |   `-- Sorting/
|       |       |-- BubbleSort.cs
|       |       |-- InsertionSort.cs
|       |       `-- SelectionSort.cs
|       |-- DataStructures.csproj
|       |-- ArrayStack.cs
|       |-- CircularQueue.cs
|       |-- SeparateChainingHashTable.cs
|       `-- SinglyLinkedList.cs
|-- tests/
|   `-- DataStructures.Tests/
|       |-- DataStructures.Tests.csproj
|       |-- ArrayStackTests.cs
|       |-- CircularQueueTests.cs
|       |-- SeparateChainingHashTableTests.cs
|       |-- SearchingAlgorithmsTests.cs
|       |-- SortingAlgorithmsTests.cs
|       `-- SinglyLinkedListTests.cs
`-- README.md
```

### File Explanations

- `DataStructuresAlgorithms.sln`: Groups the source and test projects for building and testing together.
- `src/DataStructures/DataStructures.csproj`: Defines the .NET 8 class library with nullable reference types enabled.
- `src/DataStructures/Algorithms/Searching/LinearSearch.cs`: Contains a generic linear search implementation.
- `src/DataStructures/Algorithms/Searching/BinarySearch.cs`: Contains a generic binary search implementation for sorted input.
- `src/DataStructures/Algorithms/Sorting/BubbleSort.cs`: Contains a generic in-place bubble sort implementation.
- `src/DataStructures/Algorithms/Sorting/SelectionSort.cs`: Contains a generic in-place selection sort implementation.
- `src/DataStructures/Algorithms/Sorting/InsertionSort.cs`: Contains a generic in-place insertion sort implementation.
- `src/DataStructures/ArrayStack.cs`: Contains the generic array-backed stack implementation.
- `src/DataStructures/CircularQueue.cs`: Contains the generic circular-array queue implementation.
- `src/DataStructures/SeparateChainingHashTable.cs`: Contains the generic hash table implementation using separate chaining.
- `src/DataStructures/SinglyLinkedList.cs`: Contains the generic singly linked list implementation and its private node type.
- `tests/DataStructures.Tests/DataStructures.Tests.csproj`: Defines the .NET 8 xUnit test project and references the class library.
- `tests/DataStructures.Tests/ArrayStackTests.cs`: Verifies stack behavior, resizing, exceptions, and clearing.
- `tests/DataStructures.Tests/CircularQueueTests.cs`: Verifies queue behavior, circular wrapping, resizing, exceptions, and clearing.
- `tests/DataStructures.Tests/SeparateChainingHashTableTests.cs`: Verifies hash table behavior, duplicate keys, null keys, resizing, and collisions.
- `tests/DataStructures.Tests/SearchingAlgorithmsTests.cs`: Verifies linear and binary search behavior.
- `tests/DataStructures.Tests/SortingAlgorithmsTests.cs`: Verifies bubble, selection, and insertion sort behavior.
- `tests/DataStructures.Tests/SinglyLinkedListTests.cs`: Verifies empty-list behavior, additions, removals, searches, nullable values, custom equality, enumeration, and count updates.
- `README.md`: Documents the repository, implementation, commands, learning notes, roadmap, and commit plan.

## Current Progress

| Day | Topic | Status |
| --- | --- | --- |
| Day 1 | Singly Linked List | Done |
| Day 2 | Stack and Queue | Done |
| Day 3 | Hash Table basics | Done |
| Day 4 | Searching and Basic Sorting | Done |
| Day 5 | Merge Sort and Quick Sort | Next |

## Singly Linked List Explanation

A singly linked list stores values in nodes. Each node contains a value and a reference to the next node. The list keeps references to its first node (`head`) and last node (`tail`).

Unlike an array, linked-list nodes do not need to occupy adjacent memory locations. Adding at the beginning is constant time, and tracking the tail also makes adding at the end constant time. Searching and removing by value require walking through the list.

The `SinglyLinkedList<T>` supports:

- `AddFirst(T value)`: Adds a value at the beginning.
- `AddLast(T value)`: Adds a value at the end.
- `Remove(T value)`: Removes the first matching value and reports whether it was found.
- `Contains(T value)`: Reports whether a matching value exists.
- `Count`: Returns the number of values.
- `IsEmpty`: Reports whether the list has no values.
- `ToEnumerable()`: Enumerates values from first to last.

By default, values are matched using `EqualityComparer<T>.Default`. A custom `IEqualityComparer<T>` can be supplied to the constructor when different equality behavior is needed. Enumeration fails fast with an `InvalidOperationException` if the list changes while it is being enumerated.

## Stack

A stack stores items in last-in, first-out order. The last item pushed onto the stack is the first item returned by `Pop`.

The `ArrayStack<T>` uses an internal array and resizes when the array becomes full. This keeps the implementation simple while still providing efficient push and pop operations.

The `ArrayStack<T>` supports:

- `Push(T item)`: Adds an item to the top.
- `Pop()`: Removes and returns the top item.
- `Peek()`: Returns the top item without removing it.
- `Count`: Returns the number of items.
- `IsEmpty`: Reports whether the stack has no items.
- `Clear()`: Removes all items.
- `ToEnumerable()`: Enumerates items from top to bottom.

## Queue

A queue stores items in first-in, first-out order. The first item enqueued is the first item returned by `Dequeue`.

The `CircularQueue<T>` uses an internal circular array. When items are dequeued, the front index moves forward instead of shifting every item. When the array becomes full, the queue resizes and keeps the same front-to-back order.

The `CircularQueue<T>` supports:

- `Enqueue(T item)`: Adds an item to the back.
- `Dequeue()`: Removes and returns the front item.
- `Peek()`: Returns the front item without removing it.
- `Count`: Returns the number of items.
- `IsEmpty`: Reports whether the queue has no items.
- `Clear()`: Removes all items.
- `ToEnumerable()`: Enumerates items from front to back.

## Hash Table

A hash table stores key-value pairs and uses a hash code to decide where each key should live in an internal bucket array. A good hash function spreads keys across buckets so lookup, insertion, and removal are usually very fast.

The `SeparateChainingHashTable<TKey, TValue>` uses `EqualityComparer<TKey>.Default` to compare keys. Null keys are rejected with `ArgumentNullException`, and adding the same key twice throws `ArgumentException`.

### Hashing

Hashing converts a key into an integer hash code. The hash table maps that hash code to a bucket index with modulo arithmetic. For example, a hash code can be mapped into an array index from `0` to `bucketCount - 1`.

### Collisions

A collision happens when two different keys map to the same bucket. Collisions are normal and must be handled correctly.

### Separate Chaining

Separate chaining handles collisions by storing a linked chain of entries inside each bucket. If multiple keys map to the same bucket, the hash table walks that bucket's chain to find the matching key.

The hash table resizes when adding an entry would push the load factor above `0.75`. Resizing creates a larger bucket array and reassigns existing entries to their new buckets.

The `SeparateChainingHashTable<TKey, TValue>` supports:

- `Add(TKey key, TValue value)`: Adds a new key-value pair.
- `Remove(TKey key)`: Removes a key-value pair by key.
- `ContainsKey(TKey key)`: Reports whether a key exists.
- `TryGetValue(TKey key, out TValue value)`: Gets a value when the key exists.
- `Count`: Returns the number of key-value pairs.
- `IsEmpty`: Reports whether the hash table has no entries.
- `Clear()`: Removes all entries.
- `ToEnumerable()`: Enumerates all key-value pairs.

## Searching

Searching algorithms locate a target value inside a collection and return its index when found.

### Linear Search

Linear search checks each item from left to right until it finds the target. It works on unsorted input, handles empty input by returning `-1`, and uses `EqualityComparer<T>.Default` for comparisons.

Linear search is simple and reliable, but it may need to inspect every item.

### Binary Search

Binary search works on sorted input. It repeatedly compares the target with the middle item and discards half of the remaining search range.

Binary search uses `Comparer<T>.Default`, returns the matching index when found, and returns `-1` when the target is missing or the input is empty.

## Sorting

Sorting algorithms reorder values into ascending order. Day 4 includes simple in-place sorting algorithms that use `Comparer<T>.Default` and are useful for learning comparisons, swaps, and nested loops.

### Bubble Sort

Bubble sort repeatedly compares adjacent items and swaps them when they are out of order. After each pass, the largest remaining item moves toward the end of the array.

### Selection Sort

Selection sort finds the smallest item in the unsorted part of the array and moves it into the next sorted position.

### Insertion Sort

Insertion sort builds the sorted part of the array one item at a time. Each new item is shifted left until it reaches its correct position.

## Big O Complexity

### Singly Linked List

| Operation | Time Complexity | Extra Space |
| --- | --- | --- |
| `AddFirst` | O(1) | O(1) |
| `AddLast` | O(1) | O(1) |
| `Remove` | O(n) | O(1) |
| `Contains` | O(n) | O(1) |
| `Count` | O(1) | O(1) |
| `IsEmpty` | O(1) | O(1) |
| `ToEnumerable` | O(n) | O(1) |

### Stack

| Operation | Time Complexity | Extra Space |
| --- | --- | --- |
| `Push` | O(1) amortized | O(1) |
| `Pop` | O(1) | O(1) |
| `Peek` | O(1) | O(1) |
| `Count` | O(1) | O(1) |
| `IsEmpty` | O(1) | O(1) |
| `Clear` | O(n) | O(1) |
| `ToEnumerable` | O(n) | O(1) |

### Queue

| Operation | Time Complexity | Extra Space |
| --- | --- | --- |
| `Enqueue` | O(1) amortized | O(1) |
| `Dequeue` | O(1) | O(1) |
| `Peek` | O(1) | O(1) |
| `Count` | O(1) | O(1) |
| `IsEmpty` | O(1) | O(1) |
| `Clear` | O(n) | O(1) |
| `ToEnumerable` | O(n) | O(1) |

### Hash Table

| Operation | Average Time Complexity | Worst Time Complexity | Extra Space |
| --- | --- | --- | --- |
| `Add` | O(1) amortized | O(n) | O(1) |
| `Remove` | O(1) | O(n) | O(1) |
| `ContainsKey` | O(1) | O(n) | O(1) |
| `TryGetValue` | O(1) | O(n) | O(1) |
| `Count` | O(1) | O(1) | O(1) |
| `IsEmpty` | O(1) | O(1) | O(1) |
| `Clear` | O(n) | O(n) | O(1) |
| `ToEnumerable` | O(n) | O(n) | O(1) |

### Searching and Sorting

| Algorithm | Best Time | Average Time | Worst Time | Extra Space |
| --- | --- | --- | --- | --- |
| Linear Search | O(1) | O(n) | O(n) | O(1) |
| Binary Search | O(1) | O(log n) | O(log n) | O(1) |
| Bubble Sort | O(n) | O(n^2) | O(n^2) | O(1) |
| Selection Sort | O(n^2) | O(n^2) | O(n^2) | O(1) |
| Insertion Sort | O(n) | O(n^2) | O(n^2) | O(1) |

## How to Run

Build the complete solution from the repository root:

```bash
dotnet build DataStructuresAlgorithms.sln
```

This repository currently contains a class library rather than an executable application. Use the tests to exercise the implementation.

## Running Tests

Run all tests from the repository root:

```bash
dotnet test DataStructuresAlgorithms.sln
```

## Learning Notes

- A linked list trades direct indexed access for efficient insertion at known ends.
- A private nested node keeps implementation details hidden from consumers.
- `EqualityComparer<T>.Default` compares generic values correctly without restricting `T`.
- Accepting an `IEqualityComparer<T>` allows callers to define equality without changing the data structure.
- Updating both head and tail references is important when removing the only node.
- Maintaining `Count` makes size checks constant time.
- Iterator methods using `yield return` expose values without exposing internal nodes.
- Detecting modifications during enumeration avoids silently returning inconsistent results.
- A stack is useful when the most recent item must be processed first.
- A queue is useful when items must be processed in arrival order.
- Circular arrays avoid shifting queue items after every dequeue.
- Hash tables trade ordering for fast key-based access.
- Collisions are expected, so collision handling is part of the data structure design.
- Separate chaining keeps collision logic readable by linking entries in the same bucket.
- Linear search works without sorted data.
- Binary search is fast, but only when the input is sorted.
- Basic sorting algorithms are not the fastest for large inputs, but they are excellent for learning comparison-based sorting.

## Roadmap for Days 5-7

| Day | Topic |
| --- | --- |
| Day 5 | Merge Sort and Quick Sort |
| Day 6 | Binary Search Tree |
| Day 7 | Final Review and Improvements |

## GitHub-Friendly Commit Plan

1. **Initialize solution structure**
   - Add the .NET 8 solution, class library, and xUnit test project.
2. **Add singly linked list implementation**
   - Add the generic linked list and its required operations.
3. **Add linked list tests and README documentation**
   - Add xUnit coverage and complete Day 1 documentation.
