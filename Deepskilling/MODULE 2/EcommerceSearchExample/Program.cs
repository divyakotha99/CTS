using System;

namespace EcommerceSearchExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== E-commerce Platform Search Function ===\n");

            ExplainBigONotation();

            CreateTestProducts();

            TestLinearSearch();

            TestBinarySearch();

            CompareAlgorithms();

            Console.WriteLine("\n=== Search Function Analysis Complete ===");
        }

        static void ExplainBigONotation()
        {
            Console.WriteLine("\n1. BIG O NOTATION EXPLANATION");
            Console.WriteLine("================================");
            Console.WriteLine("What is Big O Notation?");
            Console.WriteLine("  Big O notation is a mathematical notation that describes the limiting behavior");
            Console.WriteLine("  of a function when the argument tends towards a particular value or infinity.");
            Console.WriteLine("  In computer science, it describes the performance or complexity of an algorithm.");
            Console.WriteLine("");
            Console.WriteLine("How it helps in analyzing algorithms:");
            Console.WriteLine("  - Measures time complexity (how runtime grows with input size)");
            Console.WriteLine("  - Measures space complexity (how memory usage grows with input size)");
            Console.WriteLine("  - Provides upper bound on growth rate (worst-case scenario)");
            Console.WriteLine("  - Allows comparison of different algorithms");
            Console.WriteLine("  - Helps predict performance for large input sizes");
            Console.WriteLine("");
            Console.WriteLine("Common Big O complexities:");
            Console.WriteLine("  O(1)    - Constant time (best)");
            Console.WriteLine("  O(log n) - Logarithmic time (very good)");
            Console.WriteLine("  O(n)    - Linear time (good)");
            Console.WriteLine("  O(n log n) - Linearithmic time (fair)");
            Console.WriteLine("  O(n^2)  - Quadratic time (poor)");
            Console.WriteLine("  O(2^n)  - Exponential time (very poor)");
            Console.WriteLine("");
            Console.WriteLine("Best, Average, and Worst-case scenarios for search:");
            Console.WriteLine("  BEST CASE:");
            Console.WriteLine("    - Element found at first position");
            Console.WriteLine("    - Time complexity: O(1)");
            Console.WriteLine("    - Example: Searching for product at index 0");
            Console.WriteLine("");
            Console.WriteLine("  AVERAGE CASE:");
            Console.WriteLine("    - Element found somewhere in middle");
            Console.WriteLine("    - Linear Search: O(n/2) = O(n)");
            Console.WriteLine("    - Binary Search: O(log n)");
            Console.WriteLine("");
            Console.WriteLine("  WORST CASE:");
            Console.WriteLine("    - Element not found or at last position");
            Console.WriteLine("    - Linear Search: O(n) - must check all elements");
            Console.WriteLine("    - Binary Search: O(log n) - must divide until found");
            Console.WriteLine("");
        }

        static Product[] CreateTestProducts()
        {
            Console.WriteLine("\n2. TEST PRODUCTS SETUP");
            Console.WriteLine("======================");
            
            Product[] products = new Product[10];
            products[0] = new Product(101, "Laptop", "Electronics", 999.99);
            products[1] = new Product(102, "Headphones", "Electronics", 149.99);
            products[2] = new Product(103, "T-Shirt", "Clothing", 29.99);
            products[3] = new Product(104, "Coffee Mug", "Kitchen", 12.99);
            products[4] = new Product(105, "Smartphone", "Electronics", 799.99);
            products[5] = new Product(106, "Jeans", "Clothing", 59.99);
            products[6] = new Product(107, "Blender", "Kitchen", 49.99);
            products[7] = new Product(108, "Watch", "Electronics", 249.99);
            products[8] = new Product(109, "Sneakers", "Clothing", 89.99);
            products[9] = new Product(110, "Pen Set", "Office", 15.99);

            Console.WriteLine("Created 10 products:");
            for (int i = 0; i < products.Length; i++)
            {
                Console.WriteLine($"  [{i}] {products[i].GetProductDetails()}");
            }

            Product[] sortedById = SearchAlgorithms.SortProductsById(products);
            Console.WriteLine("\nProducts sorted by ID:");
            for (int i = 0; i < sortedById.Length; i++)
            {
                Console.WriteLine($"  [{i}] {sortedById[i].GetProductDetails()}");
            }

            Product[] sortedByName = SearchAlgorithms.SortProductsByName(products);
            Console.WriteLine("\nProducts sorted by Name:");
            for (int i = 0; i < sortedByName.Length; i++)
            {
                Console.WriteLine($"  [{i}] {sortedByName[i].GetProductDetails()}");
            }

            return products;
        }

        static void TestLinearSearch()
        {
            Console.WriteLine("\n3. LINEAR SEARCH TESTS");
            Console.WriteLine("======================");

            Product[] products = new Product[10];
            products[0] = new Product(101, "Laptop", "Electronics", 999.99);
            products[1] = new Product(102, "Headphones", "Electronics", 149.99);
            products[2] = new Product(103, "T-Shirt", "Clothing", 29.99);
            products[3] = new Product(104, "Coffee Mug", "Kitchen", 12.99);
            products[4] = new Product(105, "Smartphone", "Electronics", 799.99);
            products[5] = new Product(106, "Jeans", "Clothing", 59.99);
            products[6] = new Product(107, "Blender", "Kitchen", 49.99);
            products[7] = new Product(108, "Watch", "Electronics", 249.99);
            products[8] = new Product(109, "Sneakers", "Clothing", 89.99);
            products[9] = new Product(110, "Pen Set", "Office", 15.99);

            Console.WriteLine("\nTest A: Search for existing product (ID: 105)");
            int index1 = SearchAlgorithms.LinearSearchById(products, 105);
            if (index1 != -1)
            {
                Console.WriteLine($"Found at index {index1}: {products[index1].GetProductDetails()}");
            }
            else
            {
                Console.WriteLine("Product not found");
            }

            Console.WriteLine("\nTest B: Search for existing product (Name: 'Jeans')");
            int index2 = SearchAlgorithms.LinearSearchByName(products, "Jeans");
            if (index2 != -1)
            {
                Console.WriteLine($"Found at index {index2}: {products[index2].GetProductDetails()}");
            }
            else
            {
                Console.WriteLine("Product not found");
            }

            Console.WriteLine("\nTest C: Search for product in specific category (Electronics)");
            int index3 = SearchAlgorithms.LinearSearchByCategory(products, "Electronics");
            if (index3 != -1)
            {
                Console.WriteLine($"Found at index {index3}: {products[index3].GetProductDetails()}");
            }
            else
            {
                Console.WriteLine("No product found in category");
            }

            Console.WriteLine("\nTest D: Search for non-existing product (ID: 999)");
            int index4 = SearchAlgorithms.LinearSearchById(products, 999);
            if (index4 != -1)
            {
                Console.WriteLine($"Found at index {index4}: {products[index4].GetProductDetails()}");
            }
            else
            {
                Console.WriteLine("Product not found (returned -1)");
            }

            Console.WriteLine("\nLinear Search Time Complexity: O(n)");
            Console.WriteLine("  - Must check each element one by one");
            Console.WriteLine("  - In worst case, checks all n elements");
            Console.WriteLine("  - Does not require sorted array");
        }

        static void TestBinarySearch()
        {
            Console.WriteLine("\n4. BINARY SEARCH TESTS");
            Console.WriteLine("======================");

            Product[] products = new Product[10];
            products[0] = new Product(101, "Laptop", "Electronics", 999.99);
            products[1] = new Product(102, "Headphones", "Electronics", 149.99);
            products[2] = new Product(103, "T-Shirt", "Clothing", 29.99);
            products[3] = new Product(104, "Coffee Mug", "Kitchen", 12.99);
            products[4] = new Product(105, "Smartphone", "Electronics", 799.99);
            products[5] = new Product(106, "Jeans", "Clothing", 59.99);
            products[6] = new Product(107, "Blender", "Kitchen", 49.99);
            products[7] = new Product(108, "Watch", "Electronics", 249.99);
            products[8] = new Product(109, "Sneakers", "Clothing", 89.99);
            products[9] = new Product(110, "Pen Set", "Office", 15.99);

            Product[] sortedById = SearchAlgorithms.SortProductsById(products);

            Console.WriteLine("\nTest A: Search for existing product (ID: 105)");
            int index1 = SearchAlgorithms.BinarySearchById(sortedById, 105);
            if (index1 != -1)
            {
                Console.WriteLine($"Found at index {index1}: {sortedById[index1].GetProductDetails()}");
            }
            else
            {
                Console.WriteLine("Product not found");
            }

            Console.WriteLine("\nTest B: Search for existing product (ID: 101 - first element)");
            int index2 = SearchAlgorithms.BinarySearchById(sortedById, 101);
            if (index2 != -1)
            {
                Console.WriteLine($"Found at index {index2}: {sortedById[index2].GetProductDetails()}");
            }
            else
            {
                Console.WriteLine("Product not found");
            }

            Console.WriteLine("\nTest C: Search for existing product (ID: 110 - last element)");
            int index3 = SearchAlgorithms.BinarySearchById(sortedById, 110);
            if (index3 != -1)
            {
                Console.WriteLine($"Found at index {index3}: {sortedById[index3].GetProductDetails()}");
            }
            else
            {
                Console.WriteLine("Product not found");
            }

            Console.WriteLine("\nTest D: Search for non-existing product (ID: 999)");
            int index4 = SearchAlgorithms.BinarySearchById(sortedById, 999);
            if (index4 != -1)
            {
                Console.WriteLine($"Found at index {index4}: {sortedById[index4].GetProductDetails()}");
            }
            else
            {
                Console.WriteLine("Product not found (returned -1)");
            }

            Console.WriteLine("\nTest E: Search by name (Name: 'Smartphone')");
            Product[] sortedByName = SearchAlgorithms.SortProductsByName(products);
            int index5 = SearchAlgorithms.BinarySearchByName(sortedByName, "Smartphone");
            if (index5 != -1)
            {
                Console.WriteLine($"Found at index {index5}: {sortedByName[index5].GetProductDetails()}");
            }
            else
            {
                Console.WriteLine("Product not found");
            }

            Console.WriteLine("\nBinary Search Time Complexity: O(log n)");
            Console.WriteLine("  - Divides search space by half each iteration");
            Console.WriteLine("  - In worst case, divides until space is 1 element");
            Console.WriteLine("  - REQUIRES sorted array");
            Console.WriteLine("  - Much faster than linear search for large datasets");
        }

        static void CompareAlgorithms()
        {
            Console.WriteLine("\n5. ALGORITHM COMPARISON ANALYSIS");
            Console.WriteLine("==================================");

            Console.WriteLine("\nTIME COMPLEXITY COMPARISON:");
            Console.WriteLine("----------------------------");
            Console.WriteLine("| Algorithm   | Best Case | Average Case | Worst Case |");
            Console.WriteLine("|-------------|-----------|--------------|------------|");
            Console.WriteLine("| Linear Search | O(1)      | O(n)         | O(n)       |");
            Console.WriteLine("| Binary Search | O(1)      | O(log n)     | O(log n)   |");
            Console.WriteLine("");

            Console.WriteLine("\nPRACTICAL PERFORMANCE COMPARISON (for n = 1,000,000):");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Linear Search:");
            Console.WriteLine("  - Best case: 1 comparison");
            Console.WriteLine("  - Average case: 500,000 comparisons");
            Console.WriteLine("  - Worst case: 1,000,000 comparisons");
            Console.WriteLine("");
            Console.WriteLine("Binary Search:");
            Console.WriteLine("  - Best case: 1 comparison");
            Console.WriteLine("  - Average case: ~10 comparisons (log2(1,000,000) = 20)");
            Console.WriteLine("  - Worst case: ~20 comparisons");
            Console.WriteLine("");

            Console.WriteLine("\nSPACE COMPLEXITY:");
            Console.WriteLine("------------------");
            Console.WriteLine("Linear Search: O(1) - no extra space needed");
            Console.WriteLine("Binary Search: O(1) - no extra space needed (iterative)");
            Console.WriteLine("");

            Console.WriteLine("\nREQUIREMENTS:");
            Console.WriteLine("--------------");
            Console.WriteLine("Linear Search:");
            Console.WriteLine("  - Does NOT require sorted array");
            Console.WriteLine("  - Works on any data structure (array, list, linked list)");
            Console.WriteLine("");
            Console.WriteLine("Binary Search:");
            Console.WriteLine("  - REQUIRES sorted array");
            Console.WriteLine("  - Only works on array-like structures with index access");
            Console.WriteLine("");

            Console.WriteLine("\nWHICH ALGORITHM IS MORE SUITABLE FOR E-COMMERCE PLATFORM?");
            Console.WriteLine("==========================================================");
            Console.WriteLine("");
            Console.WriteLine("RECOMMENDATION: Use BOTH algorithms based on context");
            Console.WriteLine("");
            Console.WriteLine("Use LINEAR SEARCH when:");
            Console.WriteLine("  1. Small dataset (n < 50)");
            Console.WriteLine("     - Sorting overhead outweighs search benefit");
            Console.WriteLine("  2. Data is frequently changing (add/delete)");
            Console.WriteLine("     - Maintaining sorted order is expensive");
            Console.WriteLine("  3. First search on unsorted data");
            Console.WriteLine("     - No need to sort if searching only once");
            Console.WriteLine("");
            Console.WriteLine("Use BINARY SEARCH when:");
            Console.WriteLine("  1. Large dataset (n > 1000)");
            Console.WriteLine("     - O(log n) is significantly faster than O(n)");
            Console.WriteLine("  2. Data is static or rarely changes");
            Console.WriteLine("     - Sorting once, searching many times");
            Console.WriteLine("  3. Multiple searches on same dataset");
            Console.WriteLine("     - Sorting overhead amortized over many searches");
            Console.WriteLine("  4. Product catalog (relatively stable)");
            Console.WriteLine("     - Products added occasionally, searched frequently");
            Console.WriteLine("");

            Console.WriteLine("\nBEST PRACTICE FOR E-COMMERCE PLATFORM:");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("1. Store products in sorted array (by ID or name)");
            Console.WriteLine("2. Use binary search for product lookups");
            Console.WriteLine("3. Use linear search for:");
            Console.WriteLine("   - Category filtering (unsorted data)");
            Console.WriteLine("   - Temporary/uncached data");
            Console.WriteLine("   - Very small result sets");
            Console.WriteLine("");
            Console.WriteLine("4. Consider hybrid approach:");
            Console.WriteLine("   - Sort data once at startup");
            Console.WriteLine("   - Use binary search for 99% of queries");
            Console.WriteLine("   - Use linear search for edge cases");
            Console.WriteLine("");
            Console.WriteLine("5. For production: Consider even faster options:");
            Console.WriteLine("   - Hash tables: O(1) average for exact ID lookup");
            Console.WriteLine("   - Database indexes: Optimized B-tree searches");
            Console.WriteLine("   - Search engines (Elasticsearch): For complex queries");
            Console.WriteLine("");
        }
    }
}