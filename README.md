# Data Structures and Algorithms in C#

## Overview

This repository contains clean, tested implementations of common data structures and algorithms in C#. Day 1 introduced a generic singly linked list, and Day 2 adds array-backed stack and queue implementations.

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
|       |-- DataStructures.csproj
|       |-- ArrayStack.cs
|       |-- CircularQueue.cs
|       `-- SinglyLinkedList.cs
|-- tests/
|   `-- DataStructures.Tests/
|       |-- DataStructures.Tests.csproj
|       |-- ArrayStackTests.cs
|       |-- CircularQueueTests.cs
|       `-- SinglyLinkedListTests.cs
`-- README.md
```

### File Explanations

- `DataStructuresAlgorithms.sln`: Groups the source and test projects for building and testing together.
- `src/DataStructures/DataStructures.csproj`: Defines the .NET 8 class library with nullable reference types enabled.
- `src/DataStructures/ArrayStack.cs`: Contains the generic array-backed stack implementation.
- `src/DataStructures/CircularQueue.cs`: Contains the generic circular-array queue implementation.
- `src/DataStructures/SinglyLinkedList.cs`: Contains the generic singly linked list implementation and its private node type.
- `tests/DataStructures.Tests/DataStructures.Tests.csproj`: Defines the .NET 8 xUnit test project and references the class library.
- `tests/DataStructures.Tests/ArrayStackTests.cs`: Verifies stack behavior, resizing, exceptions, and clearing.
- `tests/DataStructures.Tests/CircularQueueTests.cs`: Verifies queue behavior, circular wrapping, resizing, exceptions, and clearing.
- `tests/DataStructures.Tests/SinglyLinkedListTests.cs`: Verifies empty-list behavior, additions, removals, searches, nullable values, custom equality, enumeration, and count updates.
- `README.md`: Documents the repository, implementation, commands, learning notes, roadmap, and commit plan.

## Current Progress

| Day | Topic | Status |
| --- | --- | --- |
| Day 1 | Singly Linked List | Done |
| Day 2 | Stack and Queue | Done |
| Day 3 | Hash Table basics | Next |

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

## Roadmap for Days 3-7

| Day | Topic |
| --- | --- |
| Day 3 | Hash Table basics |
| Day 4 | Searching and Basic Sorting |
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
