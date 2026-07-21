using System;

namespace SortingCustomerOrders
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sorting Customer Orders ===\n");

            ExplainSortingAlgorithms();

            TestBubbleSort();

            TestQuickSort();

            CompareAlgorithms();

            Console.WriteLine("\n=== Sorting Customer Orders Complete ===");
        }

        static void ExplainSortingAlgorithms()
        {
            Console.WriteLine("\n1. SORTING ALGORITHMS EXPLANATION");
            Console.WriteLine("==================================");
            Console.WriteLine("");
            Console.WriteLine("What is Sorting?");
            Console.WriteLine("  Sorting is arranging data in a particular order (ascending or descending).");
            Console.WriteLine("  In e-commerce, sorting orders by price helps prioritize high-value orders.");
            Console.WriteLine("");
            Console.WriteLine("Different Sorting Algorithms:");
            Console.WriteLine("");
            Console.WriteLine("1. BUBBLE SORT");
            Console.WriteLine("   - Compares adjacent elements and swaps if they're in wrong order");
            Console.WriteLine("   - Repeats until no swaps needed (array is sorted)");
            Console.WriteLine("   - Time Complexity: O(n²) worst/average, O(n) best");
            Console.WriteLine("   - Space Complexity: O(1)");
            Console.WriteLine("   - Simple but inefficient for large datasets");
            Console.WriteLine("   - Example: [5,3,8,1] → [3,5,8,1] → [3,5,1,8] → ...");
            Console.WriteLine("");
            Console.WriteLine("2. INSERTION SORT");
            Console.WriteLine("   - Builds sorted array one element at a time");
            Console.WriteLine("   - Inserts each element into its correct position");
            Console.WriteLine("   - Time Complexity: O(n²) worst/average, O(n) best");
            Console.WriteLine("   - Space Complexity: O(1)");
            Console.WriteLine("   - Efficient for small or nearly sorted datasets");
            Console.WriteLine("   - Example: [5,3,8,1] → [3,5,8,1] → [3,5,8,1] → [1,3,5,8]");
            Console.WriteLine("");
            Console.WriteLine("3. QUICK SORT");
            Console.WriteLine("   - Divides array into smaller sub-arrays (divide and conquer)");
            Console.WriteLine("   - Picks a pivot and partitions elements around it");
            Console.WriteLine("   - Recursively sorts sub-arrays");
            Console.WriteLine("   - Time Complexity: O(n log n) average, O(n²) worst");
            Console.WriteLine("   - Space Complexity: O(log n)");
            Console.WriteLine("   - Fastest general-purpose sorting algorithm");
            Console.WriteLine("   - Example: [5,3,8,1,9] → pivot=5 → [3,1],[5],[8,9] → [1,3,5,8,9]");
            Console.WriteLine("");
            Console.WriteLine("4. MERGE SORT");
            Console.WriteLine("   - Divides array into halves recursively");
            Console.WriteLine("   - Sorts each half and merges them back");
            Console.WriteLine("   - Time Complexity: O(n log n) for all cases");
            Console.WriteLine("   - Space Complexity: O(n)");
            Console.WriteLine("   - Stable sort (preserves order of equal elements)");
            Console.WriteLine("   - Good for large datasets and external sorting");
            Console.WriteLine("   - Example: [5,3,8,1] → [5,3],[8,1] → [3,5],[1,8] → [1,3,5,8]");
            Console.WriteLine("");
            Console.WriteLine("Comparison Table:");
            Console.WriteLine("┌──────────────┬─────────────┬────────────┬──────────┐");
            Console.WriteLine("│ Algorithm    │ Time(Avg)   │ Time(Worst)│ Space    │");
            Console.WriteLine("├──────────────┼─────────────┼────────────┼──────────┤");
            Console.WriteLine("│ Bubble Sort  │ O(n²)       │ O(n²)      │ O(1)     │");
            Console.WriteLine("│ Insertion    │ O(n²)       │ O(n²)      │ O(1)     │");
            Console.WriteLine("│ Quick Sort   │ O(n log n)  │ O(n²)      │ O(log n) │");
            Console.WriteLine("│ Merge Sort   │ O(n log n)  │ O(n log n) │ O(n)     │");
            Console.WriteLine("└──────────────┴─────────────┴────────────┴──────────┘");
            Console.WriteLine("");
        }

        static void TestBubbleSort()
        {
            Console.WriteLine("\n2. BUBBLE SORT TESTS");
            Console.WriteLine("====================");

            Order[] orders = new Order[8];
            orders[0] = new Order(1, "John Doe", 150.00);
            orders[1] = new Order(2, "Jane Smith", 450.00);
            orders[2] = new Order(3, "Bob Johnson", 75.00);
            orders[3] = new Order(4, "Alice Brown", 320.00);
            orders[4] = new Order(5, "Charlie Wilson", 890.00);
            orders[5] = new Order(6, "Diana Lee", 210.00);
            orders[6] = new Order(7, "Eve Davis", 55.00);
            orders[7] = new Order(8, "Frank Miller", 670.00);

            SortingAlgorithms.DisplayOrders(orders);

            (Order[] sortedOrders, int comparisons, int swaps) bubbleResult = SortingAlgorithms.BubbleSortWithCount(orders);

            SortingAlgorithms.DisplaySortedOrders(bubbleResult.sortedOrders, "Bubble Sort");

            Console.WriteLine($"Bubble Sort Statistics:");
            Console.WriteLine($"  Comparisons: {bubbleResult.comparisons}");
            Console.WriteLine($"  Swaps: {bubbleResult.swaps}");
            Console.WriteLine($"  Time Complexity: O(n²)");
            Console.WriteLine("");
        }

        static void TestQuickSort()
        {
            Console.WriteLine("\n3. QUICK SORT TESTS");
            Console.WriteLine("===================");

            Order[] orders = new Order[8];
            orders[0] = new Order(1, "John Doe", 150.00);
            orders[1] = new Order(2, "Jane Smith", 450.00);
            orders[2] = new Order(3, "Bob Johnson", 75.00);
            orders[3] = new Order(4, "Alice Brown", 320.00);
            orders[4] = new Order(5, "Charlie Wilson", 890.00);
            orders[5] = new Order(6, "Diana Lee", 210.00);
            orders[6] = new Order(7, "Eve Davis", 55.00);
            orders[7] = new Order(8, "Frank Miller", 670.00);

            SortingAlgorithms.DisplayOrders(orders);

            SortingAlgorithms.QuickSort(orders);

            SortingAlgorithms.DisplaySortedOrders(orders, "Quick Sort");

            Console.WriteLine($"Quick Sort Statistics:");
            Console.WriteLine($"  Time Complexity: O(n log n) average");
            Console.WriteLine($"  Space Complexity: O(log n)");
            Console.WriteLine("");
        }

        static void CompareAlgorithms()
        {
            Console.WriteLine("\n4. ALGORITHM COMPARISON ANALYSIS");
            Console.WriteLine("=================================");

            Console.WriteLine("\nTIME COMPLEXITY COMPARISON:");
            Console.WriteLine("---------------------------");
            Console.WriteLine("| Algorithm   | Best Case | Average Case | Worst Case |");
            Console.WriteLine("|-------------|-----------|--------------|------------|");
            Console.WriteLine("| Bubble Sort | O(n)      | O(n²)        | O(n²)      |");
            Console.WriteLine("| Quick Sort  | O(n log n)| O(n log n)   | O(n²)      |");
            Console.WriteLine("");

            Console.WriteLine("\nPRACTICAL PERFORMANCE COMPARISON:");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("For n = 1,000 orders:");
            Console.WriteLine("  Bubble Sort: ~1,000,000 comparisons");
            Console.WriteLine("  Quick Sort: ~10,000 comparisons");
            Console.WriteLine("  Quick Sort is 100x faster!");
            Console.WriteLine("");
            Console.WriteLine("For n = 10,000 orders:");
            Console.WriteLine("  Bubble Sort: ~100,000,000 comparisons");
            Console.WriteLine("  Quick Sort: ~130,000 comparisons");
            Console.WriteLine("  Quick Sort is 770x faster!");
            Console.WriteLine("");

            Console.WriteLine("\nWHY QUICK SORT IS PREFERRED OVER BUBBLE SORT:");
            Console.WriteLine("=============================================");
            Console.WriteLine("");
            Console.WriteLine("1. BETTER TIME COMPLEXITY:");
            Console.WriteLine("   - Quick Sort: O(n log n) average");
            Console.WriteLine("   - Bubble Sort: O(n²) average");
            Console.WriteLine("   - For large n, n log n << n²");
            Console.WriteLine("");
            Console.WriteLine("2. FEWER OPERATIONS:");
            Console.WriteLine("   - Quick Sort: Divides and conquers efficiently");
            Console.WriteLine("   - Bubble Sort: Compares every adjacent pair repeatedly");
            Console.WriteLine("   - Quick Sort does significantly fewer comparisons");
            Console.WriteLine("");
            Console.WriteLine("3. BETTER FOR LARGE DATASETS:");
            Console.WriteLine("   - Quick Sort: Scales well (n log n growth)");
            Console.WriteLine("   - Bubble Sort: Performance degrades rapidly (n² growth)");
            Console.WriteLine("   - E-commerce platforms have thousands/millions of orders");
            Console.WriteLine("");
            Console.WriteLine("4. DIVIDE AND CONQUER APPROACH:");
            Console.WriteLine("   - Quick Sort: Breaks problem into smaller sub-problems");
            Console.WriteLine("   - Bubble Sort: Linear approach, no optimization");
            Console.WriteLine("   - Divide and conquer is more efficient");
            Console.WriteLine("");
            Console.WriteLine("5. REAL-WORLD USAGE:");
            Console.WriteLine("   - Quick Sort: Used in C# Array.Sort(), Java Arrays.sort()");
            Console.WriteLine("   - Bubble Sort: Educational purposes only");
            Console.WriteLine("   - Industry standard for general-purpose sorting");
            Console.WriteLine("");
            Console.WriteLine("6. CACHE EFFICIENCY:");
            Console.WriteLine("   - Quick Sort: Better memory access patterns");
            Console.WriteLine("   - Bubble Sort: Poor cache utilization");
            Console.WriteLine("   - Quick Sort is faster on modern hardware");
            Console.WriteLine("");

            Console.WriteLine("\nWHEN TO USE BUBBLE SORT:");
            Console.WriteLine("------------------------");
            Console.WriteLine("  1. Educational purposes (learning sorting concepts)");
            Console.WriteLine("  2. Very small datasets (n < 10)");
            Console.WriteLine("  3. Nearly sorted data (with optimization)");
            Console.WriteLine("  4. When code simplicity is more important than performance");
            Console.WriteLine("");

            Console.WriteLine("\nWHEN TO USE QUICK SORT:");
            Console.WriteLine("-----------------------");
            Console.WriteLine("  1. General-purpose sorting (most common case)");
            Console.WriteLine("  2. Large datasets (n > 100)");
            Console.WriteLine("  3. E-commerce order sorting (your scenario)");
            Console.WriteLine("  4. When performance is critical");
            Console.WriteLine("  5. In-memory sorting");
            Console.WriteLine("");

            Console.WriteLine("\nRECOMMENDATION FOR E-COMMERCE PLATFORM:");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("  USE: Quick Sort (or built-in Array.Sort())");
            Console.WriteLine("");
            Console.WriteLine("  REASONS:");
            Console.WriteLine("  1. E-commerce platforms handle thousands of orders");
            Console.WriteLine("  2. Need fast sorting for real-time dashboards");
            Console.WriteLine("  3. Quick Sort is O(n log n) - much faster than O(n²)");
            Console.WriteLine("  4. Industry standard, well-tested algorithm");
            Console.WriteLine("  5. C# provides built-in Quick Sort via Array.Sort()");
            Console.WriteLine("");
            Console.WriteLine("  ALTERNATIVE: Use built-in Array.Sort() with custom comparator:");
            Console.WriteLine("    Array.Sort(orders, (a, b) => a.TotalPrice.CompareTo(b.TotalPrice));");
            Console.WriteLine("");

            Console.WriteLine("\nCOMPLETE COMPARISON TABLE:");
            Console.WriteLine("--------------------------");
            Console.WriteLine("┌──────────────┬─────────────┬────────────┬──────────┬────────┐");
            Console.WriteLine("│ Algorithm    │ Time(Avg)   │ Time(Worst)│ Space    │ Usage  │");
            Console.WriteLine("├──────────────┼─────────────┼────────────┼──────────┼────────┤");
            Console.WriteLine("│ Bubble Sort  │ O(n²)       │ O(n²)      │ O(1)     │ Learn  │");
            Console.WriteLine("│ Quick Sort   │ O(n log n)  │ O(n²)      │ O(log n) │ BEST   │");
            Console.WriteLine("│ Merge Sort   │ O(n log n)  │ O(n log n) │ O(n)     │ Stable │");
            Console.WriteLine("│ Array.Sort   │ O(n log n)  │ O(n log n) │ O(log n) │ REAL   │");
            Console.WriteLine("└──────────────┴─────────────┴────────────┴──────────┴────────┘");
            Console.WriteLine("");
        }
    }
}