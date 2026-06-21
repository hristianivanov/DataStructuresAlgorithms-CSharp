# Data Structures and Algorithms in C#

A 7-day C# practice repository implementing foundational data structures and algorithms with clean code, nullable reference types, and xUnit coverage.

## Overview

This repository is a focused learning project for implementing common data structures and algorithms from scratch in C#.

It favors readable, interview-ready implementations over clever abstractions. The code intentionally avoids built-in collection shortcuts such as `Dictionary<TKey, TValue>` for the custom hash table, built-in sort helpers for sorting algorithms, and built-in tree structures for the binary search tree.

## Why This Repo Exists

This project exists to:

- Practice data structures and algorithms in modern C#
- Build a clean GitHub portfolio repository
- Prepare for technical interviews
- Document Big O complexity in a practical way
- Show steady progress across a 7-day learning plan

## Tech Stack

| Tool | Purpose |
| --- | --- |
| .NET 8 | Target framework |
| C# | Implementation language |
| xUnit | Unit testing |
| Nullable reference types | Safer null handling |
| .NET CLI | Build, test, and format verification |

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
|       |       |-- MergeSort.cs
|       |       |-- QuickSort.cs
|       |       `-- SelectionSort.cs
|       |-- Trees/
|       |   `-- BinarySearchTree.cs
|       |-- ArrayStack.cs
|       |-- CircularQueue.cs
|       |-- SeparateChainingHashTable.cs
|       `-- SinglyLinkedList.cs
|-- tests/
|   `-- DataStructures.Tests/
|       |-- AdvancedSortingAlgorithmsTests.cs
|       |-- ArrayStackTests.cs
|       |-- BinarySearchTreeTests.cs
|       |-- CircularQueueTests.cs
|       |-- SearchingAlgorithmsTests.cs
|       |-- SeparateChainingHashTableTests.cs
|       |-- SinglyLinkedListTests.cs
|       `-- SortingAlgorithmsTests.cs
|-- docs/
|   `-- complexity-cheatsheet.md
`-- README.md
```

## Current Implementation

| Category | Implementation | Main Concepts |
| --- | --- | --- |
| Data Structure | Singly Linked List | Nodes, head/tail references, traversal |
| Data Structure | Array Stack | LIFO, array resizing |
| Data Structure | Circular Queue | FIFO, circular array, wraparound |
| Data Structure | Separate Chaining Hash Table | Hashing, collisions, load factor |
| Data Structure | Binary Search Tree | Root, child nodes, traversal, removal cases |
| Searching | Linear Search | Sequential scan |
| Searching | Binary Search | Sorted input, divide search range |
| Sorting | Bubble Sort | Adjacent swaps |
| Sorting | Selection Sort | Repeated minimum selection |
| Sorting | Insertion Sort | Incremental sorted prefix |
| Sorting | Merge Sort | Divide and conquer, merging |
| Sorting | Quick Sort | Partitioning, recursion |

## Data Structures

| Structure | Description | Key Operations |
| --- | --- | --- |
| `SinglyLinkedList<T>` | Linked nodes with head and tail references | `AddFirst`, `AddLast`, `Remove`, `Contains` |
| `ArrayStack<T>` | Resizable array-backed stack | `Push`, `Pop`, `Peek`, `Clear` |
| `CircularQueue<T>` | Resizable circular array queue | `Enqueue`, `Dequeue`, `Peek`, `Clear` |
| `SeparateChainingHashTable<TKey, TValue>` | Hash table using bucket chains | `Add`, `Remove`, `ContainsKey`, `TryGetValue` |
| `BinarySearchTree<T>` | Ordered binary tree using `Comparer<T>.Default` | `Add`, `Remove`, `Contains`, traversals |

## Algorithms

| Algorithm | Type | Notes |
| --- | --- | --- |
| Linear Search | Searching | Works on unsorted input |
| Binary Search | Searching | Requires sorted input |
| Bubble Sort | Sorting | Simple adjacent-swap algorithm |
| Selection Sort | Sorting | Finds the next smallest item |
| Insertion Sort | Sorting | Efficient for small or nearly sorted input |
| Merge Sort | Sorting | Stable divide-and-conquer sort with `O(n)` extra space |
| Quick Sort | Sorting | In-place partitioning sort with fast average performance |

## Big O Complexity Summary

| Implementation | Average Time | Worst Time | Extra Space |
| --- | --- | --- | --- |
| Singly Linked List search/remove | O(n) | O(n) | O(1) |
| Stack push/pop/peek | O(1) | O(1) | O(1) |
| Queue enqueue/dequeue/peek | O(1) | O(1) | O(1) |
| Hash Table add/search/remove | O(1) | O(n) | O(1) |
| Binary Search Tree add/search/remove | O(log n) | O(n) | O(1) to O(h) |
| Linear Search | O(n) | O(n) | O(1) |
| Binary Search | O(log n) | O(log n) | O(1) |
| Bubble Sort | O(n^2) | O(n^2) | O(1) |
| Selection Sort | O(n^2) | O(n^2) | O(1) |
| Insertion Sort | O(n^2) | O(n^2) | O(1) |
| Merge Sort | O(n log n) | O(n log n) | O(n) |
| Quick Sort | O(n log n) | O(n^2) | O(log n) average |

For a more detailed reference, see [Complexity Cheatsheet](docs/complexity-cheatsheet.md).

## How To Run Locally

Clone the repository and build the solution:

```bash
git clone https://github.com/hristianivanov/DataStructuresAlgorithms-CSharp.git
cd DataStructuresAlgorithms-CSharp
dotnet build DataStructuresAlgorithms.sln
```

## How To Run Tests

Run the full xUnit test suite:

```bash
dotnet test DataStructuresAlgorithms.sln
```

Run Release build verification:

```bash
dotnet build DataStructuresAlgorithms.sln -c Release
```

Run formatting verification:

```bash
dotnet format --verify-no-changes
```

## 7-Day Progress Log

| Day | Focus | Status |
| --- | --- | --- |
| Day 1 | Singly Linked List | Done |
| Day 2 | Stack and Queue | Done |
| Day 3 | Hash Table | Done |
| Day 4 | Searching and Basic Sorting | Done |
| Day 5 | Merge Sort and Quick Sort | Done |
| Day 6 | Binary Search Tree | Done |
| Day 7 | Final Review and Documentation | Done |

## Commit History

The commit history is organized by day and by topic. Each implementation was committed separately from its tests and documentation, making the progression easy to review.

## What I Learned

- How to model data structures with small, focused public APIs
- How to use generic types and default comparers effectively
- How to reason about edge cases such as empty input, duplicates, null values, resizing, collisions, and removal cases
- How traversal order changes the output of tree algorithms
- How algorithm choice changes time and space complexity
- How to keep tests focused without overbuilding the repository
- How to present a learning project professionally on GitHub

## Future Improvements

- Add diagrams for linked lists, queues, hash tables, and trees
- Add benchmark projects later, separate from the beginner-friendly implementations
- Add more advanced data structures such as heaps, tries, and graphs
- Add balanced trees such as AVL or red-black trees
- Add graph traversal algorithms such as BFS and DFS
- Add GitHub Actions CI for automated build and test verification

## Repository Status

- 7-day implementation plan complete
- 98 passing tests at final verification
- Clean Release build
- Format verification included in final polish
