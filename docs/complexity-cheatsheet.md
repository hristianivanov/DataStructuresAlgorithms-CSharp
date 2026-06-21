# Complexity Cheatsheet

This cheatsheet summarizes the expected time and space complexity for the data structures and algorithms in this repository.

## Data Structures

| Data Structure | Operation | Average Time | Worst Time | Extra Space | Notes |
| --- | --- | --- | --- | --- | --- |
| Singly Linked List | `AddFirst` | O(1) | O(1) | O(1) | Updates head |
| Singly Linked List | `AddLast` | O(1) | O(1) | O(1) | Uses tail reference |
| Singly Linked List | `Remove` | O(n) | O(n) | O(1) | Searches by value |
| Singly Linked List | `Contains` | O(n) | O(n) | O(1) | Linear scan |
| Stack | `Push` | O(1) amortized | O(n) during resize | O(1) | Array doubles when full |
| Stack | `Pop` | O(1) | O(1) | O(1) | Removes from top |
| Queue | `Enqueue` | O(1) amortized | O(n) during resize | O(1) | Circular array |
| Queue | `Dequeue` | O(1) | O(1) | O(1) | Removes from front |
| Hash Table | `Add` | O(1) | O(n) | O(1) | Separate chaining |
| Hash Table | `Remove` | O(1) | O(n) | O(1) | Worst case when many collisions occur |
| Hash Table | `ContainsKey` | O(1) | O(n) | O(1) | Uses `EqualityComparer<TKey>.Default` |
| Binary Search Tree | `Add` | O(log n) | O(n) | O(1) | Worst case when tree is skewed |
| Binary Search Tree | `Contains` | O(log n) | O(n) | O(1) | Follows tree ordering |
| Binary Search Tree | `Remove` | O(log n) | O(n) | O(h) | Recursive removal |
| Binary Search Tree | Traversal | O(n) | O(n) | O(h) | `h` is tree height |

## Searching

| Algorithm | Best Time | Average Time | Worst Time | Extra Space | Notes |
| --- | --- | --- | --- | --- | --- |
| Linear Search | O(1) | O(n) | O(n) | O(1) | Works on unsorted input |
| Binary Search | O(1) | O(log n) | O(log n) | O(1) | Requires sorted input |

## Sorting

| Algorithm | Best Time | Average Time | Worst Time | Extra Space | Notes |
| --- | --- | --- | --- | --- | --- |
| Bubble Sort | O(n) | O(n^2) | O(n^2) | O(1) | Best case with early-exit optimization |
| Selection Sort | O(n^2) | O(n^2) | O(n^2) | O(1) | Always scans remaining items |
| Insertion Sort | O(n) | O(n^2) | O(n^2) | O(1) | Good for small or nearly sorted arrays |
| Merge Sort | O(n log n) | O(n log n) | O(n log n) | O(n) | Predictable time, extra merge buffer |
| Quick Sort | O(n log n) | O(n log n) | O(n^2) | O(log n) average | Pivot choice affects worst case |

## Notes

- Best case describes the most favorable input.
- Average case describes typical expected performance.
- Worst case describes the least favorable input.
- `O(1)` means constant time or space.
- `O(log n)` often appears when each step halves the remaining work.
- `O(n)` means work grows linearly with input size.
- `O(n log n)` is common for efficient comparison-based sorting.
- `O(n^2)` usually comes from nested passes over the data.
