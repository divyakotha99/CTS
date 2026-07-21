using System;

namespace LibraryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Library Management System ===\n");

            ExplainSearchAlgorithms();

            TestLinearSearch();

            TestBinarySearch();

            CompareAlgorithms();

            Console.WriteLine("\n=== Library Management Complete ===");
        }

        static void ExplainSearchAlgorithms()
        {
            Console.WriteLine("\n1. SEARCH ALGORITHMS EXPLANATION");
            Console.WriteLine("==================================");
            Console.WriteLine("");
            Console.WriteLine("What is Search Algorithm?");
            Console.WriteLine("  - A search algorithm finds a specific item in a data structure");
            Console.WriteLine("  - Returns the item if found, or indicates not found");
            Console.WriteLine("  - Critical for library systems to find books quickly");
            Console.WriteLine("");
            Console.WriteLine("Different Search Algorithms:");
            Console.WriteLine("");
            Console.WriteLine("1. LINEAR SEARCH");
            Console.WriteLine("   - Checks each element one by one from start to end");
            Console.WriteLine("   - Stops when item is found or end is reached");
            Console.WriteLine("   - Time Complexity: O(n)");
            Console.WriteLine("   - Works on unsorted and sorted data");
            Console.WriteLine("   - Simple to implement");
            Console.WriteLine("   - Example: [5,3,8,1,9] search for 8");
            Console.WriteLine("     Check 5 (no), Check 3 (no), Check 8 (yes!)");
            Console.WriteLine("");
            Console.WriteLine("2. BINARY SEARCH");
            Console.WriteLine("   - Divides sorted array into halves repeatedly");
            Console.WriteLine("   - Compares middle element with target");
            Console.WriteLine("   - Discards half where target cannot be");
            Console.WriteLine("   - Time Complexity: O(log n)");
            Console.WriteLine("   - ONLY works on SORTED data");
            Console.WriteLine("   - Much faster than linear search for large data");
            Console.WriteLine("   - Example: [1,3,5,8,9] search for 8");
            Console.WriteLine("     Mid=5 (5<8), search right half [8,9]");
            Console.WriteLine("     Mid=8 (8==8), found!");
            Console.WriteLine("");
            Console.WriteLine("Comparison Table:");
            Console.WriteLine("┌──────────────┬─────────────┬────────────┬───────────┐");
            Console.WriteLine("│ Algorithm    │ Time(Avg)   │ Sorted Req │ Simple    │");
            Console.WriteLine("├──────────────┼─────────────┼────────────┼───────────┤");
            Console.WriteLine("│ Linear Search│ O(n)        │ No         │ Very Easy │");
            Console.WriteLine("│ Binary Search│ O(log n)    │ Yes        │ Moderate  │");
            Console.WriteLine("└──────────────┴─────────────┴────────────┴───────────┘");
            Console.WriteLine("");
            Console.WriteLine("How Linear Search Works:");
            Console.WriteLine("  1. Start at first element (index 0)");
            Console.WriteLine("  2. Compare current element with target");
            Console.WriteLine("  3. If match, return the element");
            Console.WriteLine("  4. If no match, move to next element");
            Console.WriteLine("  5. Repeat until found or end reached");
            Console.WriteLine("  6. If not found, return null");
            Console.WriteLine("");
            Console.WriteLine("How Binary Search Works:");
            Console.WriteLine("  1. Ensure array is sorted");
            Console.WriteLine("  2. Set left = 0, right = n-1");
            Console.WriteLine("  3. Calculate mid = (left + right) / 2");
            Console.WriteLine("  4. Compare middle element with target");
            Console.WriteLine("  5. If match, return the element");
            Console.WriteLine("  6. If target > mid, search right half (left = mid + 1)");
            Console.WriteLine("  7. If target < mid, search left half (right = mid - 1)");
            Console.WriteLine("  8. Repeat until found or left > right");
            Console.WriteLine("");
            Console.WriteLine("Visual Example:");
            Console.WriteLine("");
            Console.WriteLine("Linear Search: [5,3,8,1,9] search for 8");
            Console.WriteLine("  [5,3,8,1,9]  Compare 5 != 8");
            Console.WriteLine("  [5,3,8,1,9]  Compare 3 != 8");
            Console.WriteLine("  [5,3,8,1,9]  Compare 8 == 8 ✓ FOUND!");
            Console.WriteLine("  Comparisons: 3");
            Console.WriteLine("");
            Console.WriteLine("Binary Search: [1,3,5,8,9] search for 8");
            Console.WriteLine("  [1,3,5,8,9]  left=0, right=4, mid=2, value=5");
            Console.WriteLine("  5 < 8, search right half");
            Console.WriteLine("  [1,3,5,8,9]  left=3, right=4, mid=3, value=8");
            Console.WriteLine("  8 == 8 ✓ FOUND!");
            Console.WriteLine("  Comparisons: 2");
            Console.WriteLine("");
        }

        static void TestLinearSearch()
        {
            Console.WriteLine("\n2. LINEAR SEARCH TESTS");
            Console.WriteLine("======================");

            Book[] books = new Book[8];
            books[0] = new Book(1, "The Great Gatsby", "F. Scott Fitzgerald");
            books[1] = new Book(2, "To Kill a Mockingbird", "Harper Lee");
            books[2] = new Book(3, "1984", "George Orwell");
            books[3] = new Book(4, "Pride and Prejudice", "Jane Austen");
            books[4] = new Book(5, "The Catcher in the Rye", "J.D. Salinger");
            books[5] = new Book(6, "Animal Farm", "George Orwell");
            books[6] = new Book(7, "Brave New World", "Aldous Huxley");
            books[7] = new Book(8, "The Hobbit", "J.R.R. Tolkien");

            LibrarySearch.DisplayBooks(books);

            Console.WriteLine("\nTest 1: Search by Title (Exact Match)");
            Book? found = LibrarySearch.LinearSearchByTitle(books, "1984");
            if (found != null)
            {
                Console.WriteLine($"Found: {found.GetBookDetails()}");
            }

            Console.WriteLine("\nTest 2: Search by Title (Partial Match)");
            var partialResults = LibrarySearch.LinearSearchByTitlePartial(books, "Animal");
            LibrarySearch.DisplayResults(partialResults);

            Console.WriteLine("\nTest 3: Search by Author");
            Book? byAuthor = LibrarySearch.LinearSearchByAuthor(books, "George Orwell");
            if (byAuthor != null)
            {
                Console.WriteLine($"Found: {byAuthor.GetBookDetails()}");
            }

            Console.WriteLine("\nTest 4: Search by Author (Partial Match)");
            var authorResults = LibrarySearch.LinearSearchByAuthorPartial(books, "Orwell");
            LibrarySearch.DisplayResults(authorResults);

            Console.WriteLine("\nTest 5: Search Non-Existent Book");
            Book? notFound = LibrarySearch.LinearSearchByTitle(books, "Harry Potter");
            if (notFound == null)
            {
                Console.WriteLine("Book not found (as expected)");
            }

            (Book? foundBook, int comparisons) linearResult = LibrarySearch.LinearSearchWithCount(books, "1984");
            if (linearResult.foundBook != null)
            {
                Console.WriteLine($"Found '1984' with {linearResult.comparisons} comparison(s)");
            }

            Console.WriteLine("\nTest 6: Worst Case (search last element)");
            (Book? foundLast, int lastComparisons) = LibrarySearch.LinearSearchWithCount(books, "The Hobbit");
            if (foundLast != null)
            {
                Console.WriteLine($"Found 'The Hobbit' (last element) with {lastComparisons} comparison(s)");
            }
        }

        static void TestBinarySearch()
        {
            Console.WriteLine("\n3. BINARY SEARCH TESTS");
            Console.WriteLine("======================");

            Book[] books = new Book[8];
            books[0] = new Book(1, "The Great Gatsby", "F. Scott Fitzgerald");
            books[1] = new Book(2, "To Kill a Mockingbird", "Harper Lee");
            books[2] = new Book(3, "1984", "George Orwell");
            books[3] = new Book(4, "Pride and Prejudice", "Jane Austen");
            books[4] = new Book(5, "The Catcher in the Rye", "J.D. Salinger");
            books[5] = new Book(6, "Animal Farm", "George Orwell");
            books[6] = new Book(7, "Brave New World", "Aldous Huxley");
            books[7] = new Book(8, "The Hobbit", "J.R.R. Tolkien");

            LibrarySearch.DisplayBooks(books);

            Book[] sortedBooks = LibrarySearch.SortBooksByTitle(books);
            LibrarySearch.DisplaySortedBooks(sortedBooks);

            Console.WriteLine("\nTest 1: Binary Search (Middle Element)");
            Book? foundMiddle = LibrarySearch.BinarySearchByTitle(sortedBooks, "Pride and Prejudice");
            if (foundMiddle != null)
            {
                Console.WriteLine($"Found: {foundMiddle.GetBookDetails()}");
            }

            Console.WriteLine("\nTest 2: Binary Search (First Element)");
            Book? foundFirst = LibrarySearch.BinarySearchByTitle(sortedBooks, "1984");
            if (foundFirst != null)
            {
                Console.WriteLine($"Found: {foundFirst.GetBookDetails()}");
            }

            Console.WriteLine("\nTest 3: Binary Search (Last Element)");
            Book? foundLast = LibrarySearch.BinarySearchByTitle(sortedBooks, "The Hobbit");
            if (foundLast != null)
            {
                Console.WriteLine($"Found: {foundLast.GetBookDetails()}");
            }

            Console.WriteLine("\nTest 4: Binary Search (Non-Existent)");
            Book? notFound = LibrarySearch.BinarySearchByTitle(sortedBooks, "Harry Potter");
            if (notFound == null)
            {
                Console.WriteLine("Book not found (as expected)");
            }

            (Book? foundBook, int comparisons) binaryResult = LibrarySearch.BinarySearchWithCount(sortedBooks, "1984");
            if (binaryResult.foundBook != null)
            {
                Console.WriteLine($"Found '1984' (first element) with {binaryResult.comparisons} comparison(s)");
            }

            (Book? foundMiddle2, int middleComparisons) = LibrarySearch.BinarySearchWithCount(sortedBooks, "Pride and Prejudice");
            if (foundMiddle2 != null)
            {
                Console.WriteLine($"Found 'Pride and Prejudice' (middle) with {middleComparisons} comparison(s)");
            }

            (Book? foundLast2, int lastComparisons) = LibrarySearch.BinarySearchWithCount(sortedBooks, "The Hobbit");
            if (foundLast2 != null)
            {
                Console.WriteLine($"Found 'The Hobbit' (last element) with {lastComparisons} comparison(s)");
            }
        }

        static void CompareAlgorithms()
        {
            Console.WriteLine("\n4. ALGORITHM COMPARISON ANALYSIS");
            Console.WriteLine("=================================");

            Console.WriteLine("\nTIME COMPLEXITY COMPARISON:");
            Console.WriteLine("---------------------------");
            Console.WriteLine("| Algorithm    | Best Case | Average Case | Worst Case |");
            Console.WriteLine("|--------------|-----------|--------------|------------|");
            Console.WriteLine("| Linear Search| O(1)      | O(n)         | O(n)       |");
            Console.WriteLine("| Binary Search| O(1)      | O(log n)     | O(log n)   |");
            Console.WriteLine("");

            Console.WriteLine("\nPRACTICAL PERFORMANCE COMPARISON:");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("For n = 100 books:");
            Console.WriteLine("  Linear Search: ~50 comparisons (average)");
            Console.WriteLine("  Binary Search: ~7 comparisons");
            Console.WriteLine("  Binary Search is 7x faster!");
            Console.WriteLine("");
            Console.WriteLine("For n = 1,000 books:");
            Console.WriteLine("  Linear Search: ~500 comparisons (average)");
            Console.WriteLine("  Binary Search: ~10 comparisons");
            Console.WriteLine("  Binary Search is 50x faster!");
            Console.WriteLine("");
            Console.WriteLine("For n = 1,000,000 books:");
            Console.WriteLine("  Linear Search: ~500,000 comparisons (average)");
            Console.WriteLine("  Binary Search: ~20 comparisons");
            Console.WriteLine("  Binary Search is 25,000x faster!");
            Console.WriteLine("");

            Console.WriteLine("\nWHEN TO USE LINEAR SEARCH:");
            Console.WriteLine("--------------------------");
            Console.WriteLine("1. SMALL DATA SETS (n < 50)");
            Console.WriteLine("   - Difference is negligible");
            Console.WriteLine("   - Linear search is simpler to implement");
            Console.WriteLine("");
            Console.WriteLine("2. UNSORTED DATA:");
            Console.WriteLine("   - Binary search requires sorted data");
            Console.WriteLine("   - Sorting takes O(n log n) time");
            Console.WriteLine("   - If searching once, linear is better");
            Console.WriteLine("");
            Console.WriteLine("3. SINGLE SEARCH OPERATION:");
            Console.WriteLine("   - Don't sort if searching only once");
            Console.WriteLine("   - Sorting overhead > linear search cost");
            Console.WriteLine("");
            Console.WriteLine("4. PARTIAL MATCH SEARCH:");
            Console.WriteLine("   - Searching for 'Animal' in titles");
            Console.WriteLine("   - Binary search needs exact match");
            Console.WriteLine("   - Linear search can check Contains()");
            Console.WriteLine("");
            Console.WriteLine("5. SIMPLE IMPLEMENTATION PREFERRED:");
            Console.WriteLine("   - Linear search is easier to understand");
            Console.WriteLine("   - Less code, fewer bugs");
            Console.WriteLine("");

            Console.WriteLine("\nWHEN TO USE BINARY SEARCH:");
            Console.WriteLine("--------------------------");
            Console.WriteLine("1. LARGE DATA SETS (n > 1000)");
            Console.WriteLine("   - O(log n) >> O(n) for large n");
            Console.WriteLine("   - Significant performance gain");
            Console.WriteLine("");
            Console.WriteLine("2. SORTED DATA ALREADY:");
            Console.WriteLine("   - Data is pre-sorted");
            Console.WriteLine("   - No sorting overhead");
            Console.WriteLine("");
            Console.WriteLine("3. MULTIPLE SEARCH OPERATIONS:");
            Console.WriteLine("   - Sort once, search many times");
            Console.WriteLine("   - Sorting cost amortized over searches");
            Console.WriteLine("   - Example: Library catalog, search daily");
            Console.WriteLine("");
            Console.WriteLine("4. EXACT MATCH SEARCH:");
            Console.WriteLine("   - Searching for exact title");
            Console.WriteLine("   - Binary search works perfectly");
            Console.WriteLine("");
            Console.WriteLine("5. PERFORMANCE IS CRITICAL:");
            Console.WriteLine("   - Real-time systems");
            Console.WriteLine("   - High-frequency searches");
            Console.WriteLine("");

            Console.WriteLine("\nLIBRARY MANAGEMENT SYSTEM RECOMMENDATION:");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("For Small Library (< 500 books):");
            Console.WriteLine("  USE: Linear Search");
            Console.WriteLine("  - Books are likely unsorted");
            Console.WriteLine("  - Performance difference is small");
            Console.WriteLine("  - Can search by partial title/author");
            Console.WriteLine("");
            Console.WriteLine("For Medium Library (500-10,000 books):");
            Console.WriteLine("  USE: Binary Search (if sorted) or Linear (if not)");
            Console.WriteLine("  - Sort books by title once");
            Console.WriteLine("  - Use binary search for fast lookups");
            Console.WriteLine("  - Or use linear for partial matches");
            Console.WriteLine("");
            Console.WriteLine("For Large Library (> 10,000 books):");
            Console.WriteLine("  USE: Binary Search + Sorted Index");
            Console.WriteLine("  - Maintain sorted book list");
            Console.WriteLine("  - Binary search for O(log n) lookups");
            Console.WriteLine("  - Or use Dictionary for O(1) lookups");
            Console.WriteLine("");
            Console.WriteLine("BEST PRACTICE FOR PRODUCTION:");
            Console.WriteLine("  Use Dictionary (HashMap):");
            Console.WriteLine("  Dictionary<int, Book> booksById = new Dictionary<int, Book>();");
            Console.WriteLine("  Dictionary<string, Book> booksByTitle = new Dictionary<string, Book>();");
            Console.WriteLine("  - Add: booksByTitle.Add(title, book) - O(1)");
            Console.WriteLine("  - Search: booksByTitle[title] - O(1)");
            Console.WriteLine("  - Best for all sizes!");
            Console.WriteLine("");

            Console.WriteLine("\nCOMPLETE COMPARISON TABLE:");
            Console.WriteLine("--------------------------");
            Console.WriteLine("┌──────────────┬─────────────┬────────────┬──────────┬──────────┐");
            Console.WriteLine("│ Algorithm    │ Time(Avg)   │ Time(Worst)│ Sorted   │ Use Case │");
            Console.WriteLine("├──────────────┼─────────────┼────────────┼──────────┼──────────┤");
            Console.WriteLine("│ Linear       │ O(n)        │ O(n)       │ No       │ Small    │");
            Console.WriteLine("│ Binary       │ O(log n)    │ O(log n)   │ Yes      │ Large    │");
            Console.WriteLine("│ Dictionary   │ O(1)        │ O(1)       │ No       │ BEST     │");
            Console.WriteLine("└──────────────┴─────────────┴────────────┴──────────┴──────────┘");
            Console.WriteLine("");
        }
    }
}