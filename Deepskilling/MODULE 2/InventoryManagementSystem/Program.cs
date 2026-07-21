using System;
using System.Linq;

namespace InventoryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Inventory Management System ===\n");

            ExplainDataStructures();

            TestInventoryOperations();

            CompareDataStructures();

            AnalyzeTimeComplexity();

            Console.WriteLine("\n=== Inventory Management Complete ===");
        }

        static void ExplainDataStructures()
        {
            Console.WriteLine("\n1. DATA STRUCTURES AND ALGORITHMS EXPLANATION");
            Console.WriteLine("==============================================");
            Console.WriteLine("Why Data Structures and Algorithms are Essential:");
            Console.WriteLine("  - Large inventories contain thousands to millions of products");
            Console.WriteLine("  - Efficient storage enables fast retrieval (search operations)");
            Console.WriteLine("  - Proper algorithms reduce computation time");
            Console.WriteLine("  - Good data structures minimize memory usage");
            Console.WriteLine("  - Critical for real-time warehouse operations");
            Console.WriteLine("");
            Console.WriteLine("Business Impact:");
            Console.WriteLine("  - Faster order processing = better customer service");
            Console.WriteLine("  - Reduced computation = lower server costs");
            Console.WriteLine("  - Real-time updates = accurate inventory tracking");
            Console.WriteLine("  - Scalability = handle growing inventory");
            Console.WriteLine("");
            Console.WriteLine("Types of Data Structures Suitable:");
            Console.WriteLine("");
            Console.WriteLine("  1. DICTIONARY (HashMap) - RECOMMENDED");
            Console.WriteLine("     - O(1) average for add, update, delete, search");
            Console.WriteLine("     - Key-based lookup by productId");
            Console.WriteLine("     - Best for frequent search operations");
            Console.WriteLine("");
            Console.WriteLine("  2. LIST (ArrayList)");
            Console.WriteLine("     - O(n) for search, update, delete");
            Console.WriteLine("     - O(1) for add (at end)");
            Console.WriteLine("     - Good for iteration, bad for search");
            Console.WriteLine("");
            Console.WriteLine("  3. SORTED LIST");
            Console.WriteLine("     - O(log n) search (binary search)");
            Console.WriteLine("     - O(n) add/delete (maintain sorted order)");
            Console.WriteLine("     - Good when products need sorted display");
            Console.WriteLine("");
            Console.WriteLine("  4. COMBINED APPROACH (BEST)");
            Console.WriteLine("     - Dictionary for O(1) lookup by ID");
            Console.WriteLine("     - Secondary Dictionary for name-based search");
            Console.WriteLine("     - List for iteration and display");
            Console.WriteLine("");
        }

        static void TestInventoryOperations()
        {
            Console.WriteLine("\n2. INVENTORY OPERATIONS TESTS");
            Console.WriteLine("==============================");

            InventoryManager inventory = new InventoryManager();

            // Test 1: Add products
            Console.WriteLine("\nTest 1: Adding Products");
            Product product1 = new Product(1, "Laptop", 50, 999.99);
            Product product2 = new Product(2, "Headphones", 100, 149.99);
            Product product3 = new Product(3, "Mouse", 200, 29.99);
            Product product4 = new Product(4, "Keyboard", 150, 79.99);
            Product product5 = new Product(5, "Monitor", 75, 349.99);

            inventory.AddProduct(product1);
            inventory.AddProduct(product2);
            inventory.AddProduct(product3);
            inventory.AddProduct(product4);
            inventory.AddProduct(product5);

            Console.WriteLine($"Total Products: {inventory.GetInventoryCount()}");

            // Test 2: Try adding duplicate
            Console.WriteLine("\nTest 2: Adding Duplicate Product");
            Product duplicate = new Product(1, "Laptop Pro", 30, 1299.99);
            inventory.AddProduct(duplicate);

            // Test 3: Search by ID
            Console.WriteLine("\nTest 3: Search Product by ID");
            Product? found = inventory.SearchProductById(3);
            if (found != null)
            {
                Console.WriteLine($"Found: {found.GetProductDetails()}");
            }

            // Test 4: Search by name
            Console.WriteLine("\nTest 4: Search Products by Name");
            var headphones = inventory.SearchProductByName("Headphones");
            Console.WriteLine($"Found {headphones.Count} product(s):");
            foreach (var p in headphones)
            {
                Console.WriteLine($"  {p.GetProductDetails()}");
            }

            // Test 5: Update product
            Console.WriteLine("\nTest 5: Update Product");
            inventory.UpdateProduct(3, "Wireless Mouse", 180, 34.99);

            // Test 6: Get total inventory value
            Console.WriteLine("\nTest 6: Total Inventory Value");
            double totalValue = inventory.GetTotalInventoryValue();
            Console.WriteLine($"Total Inventory Value: ${totalValue:F2}");

            // Test 7: Get low stock products
            Console.WriteLine("\nTest 7: Low Stock Products (quantity < 100)");
            var lowStock = inventory.GetLowStockProducts(100);
            Console.WriteLine($"Found {lowStock.Count} low stock product(s):");
            foreach (var p in lowStock)
            {
                Console.WriteLine($"  {p.GetProductDetails()}");
            }

            // Test 8: Display all products
            Console.WriteLine("\nTest 8: Display All Products");
            inventory.DisplayAllProducts();

            // Test 9: Delete product
            Console.WriteLine("\nTest 9: Delete Product");
            inventory.DeleteProduct(5);
            Console.WriteLine($"Total Products After Delete: {inventory.GetInventoryCount()}");

            // Test 10: Delete non-existent
            Console.WriteLine("\nTest 10: Delete Non-Existent Product");
            inventory.DeleteProduct(999);
        }

        static void CompareDataStructures()
        {
            Console.WriteLine("\n3. DATA STRUCTURE COMPARISON");
            Console.WriteLine("=============================");

            // Compare Dictionary vs List
            InventoryManager.DictionaryInventory dictInventory = new InventoryManager.DictionaryInventory();
            InventoryManager.InventoryWithList listInventory = new InventoryManager.InventoryWithList();

            Console.WriteLine("\nCreating 1000 test products...");
            for (int i = 1; i <= 1000; i++)
            {
                Product p = new Product(i, $"Product {i}", 100, 50.00);
                dictInventory.AddProduct(p);
                listInventory.AddProduct(p);
            }

            Console.WriteLine("\nPerformance Comparison (n = 1000):");
            Console.WriteLine("-----------------------------------");

            // Test search performance
            Console.WriteLine("\nSearch Operation (finding product ID 500):");
            
            DateTime startDict = DateTime.Now;
            Product? dictResult = dictInventory.SearchProductById(500);
            TimeSpan dictTime = DateTime.Now - startDict;
            Console.WriteLine($"Dictionary: {dictTime.TotalMilliseconds}ms - Found: {dictResult != null}");

            DateTime startList = DateTime.Now;
            Product? listResult = listInventory.SearchProductById(500);
            TimeSpan listTime = DateTime.Now - startList;
            Console.WriteLine($"List: {listTime.TotalMilliseconds}ms - Found: {listResult != null}");

            // Test update performance
            Console.WriteLine("\nUpdate Operation (updating product ID 500):");
            
            startDict = DateTime.Now;
            dictInventory.UpdateProduct(500, "Updated Product", 150, 60.00);
            dictTime = DateTime.Now - startDict;
            Console.WriteLine($"Dictionary: {dictTime.TotalMilliseconds}ms");

            startList = DateTime.Now;
            listInventory.UpdateProduct(500, "Updated Product", 150, 60.00);
            listTime = DateTime.Now - startList;
            Console.WriteLine($"List: {listTime.TotalMilliseconds}ms");

            // Test delete performance
            Console.WriteLine("\nDelete Operation (deleting product ID 500):");
            
            startDict = DateTime.Now;
            dictInventory.DeleteProduct(500);
            dictTime = DateTime.Now - startDict;
            Console.WriteLine($"Dictionary: {dictTime.TotalMilliseconds}ms");

            startList = DateTime.Now;
            listInventory.DeleteProduct(500);
            listTime = DateTime.Now - startList;
            Console.WriteLine($"List: {listTime.TotalMilliseconds}ms");
        }

        static void AnalyzeTimeComplexity()
        {
            Console.WriteLine("\n4. TIME COMPLEXITY ANALYSIS");
            Console.WriteLine("============================");

            Console.WriteLine("\nDictionary-Based Inventory (RECOMMENDED):");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("| Operation | Time Complexity | Space Complexity |");
            Console.WriteLine("|-----------|-----------------|------------------|");
            Console.WriteLine("| Add       | O(1) average    | O(n)             |");
            Console.WriteLine("| Update    | O(1) average    | O(n)             |");
            Console.WriteLine("| Delete    | O(1) average    | O(n)             |");
            Console.WriteLine("| Search(ID)| O(1) average    | O(n)             |");
            Console.WriteLine("| Search(Name)| O(1) avg + O(k)| O(n)            |");
            Console.WriteLine("| GetAll    | O(n)            | O(n)             |");
            Console.WriteLine("");
            Console.WriteLine("Notes:");
            Console.WriteLine("  - O(1) average means constant time regardless of inventory size");
            Console.WriteLine("  - Worst case for Dictionary is O(n) (hash collisions)");
            Console.WriteLine("  - Space O(n) because we store n products");
            Console.WriteLine("  - Name search: O(1) to find list + O(k) to return k matches");
            Console.WriteLine("");

            Console.WriteLine("\nList-Based Inventory (FOR COMPARISON):");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("| Operation | Time Complexity | Space Complexity |");
            Console.WriteLine("|-----------|-----------------|------------------|");
            Console.WriteLine("| Add       | O(n)            | O(n)             |");
            Console.WriteLine("| Update    | O(n)            | O(n)             |");
            Console.WriteLine("| Delete    | O(n)            | O(n)             |");
            Console.WriteLine("| Search    | O(n)            | O(n)             |");
            Console.WriteLine("| GetAll    | O(n)            | O(n)             |");
            Console.WriteLine("");
            Console.WriteLine("Notes:");
            Console.WriteLine("  - O(n) means time grows linearly with inventory size");
            Console.WriteLine("  - Must iterate through all products to find one");
            Console.WriteLine("  - Add is O(n) because we check for duplicates");
            Console.WriteLine("");

            Console.WriteLine("\nOPTIMIZATION STRATEGIES:");
            Console.WriteLine("========================");
            Console.WriteLine("");
            Console.WriteLine("1. Use Dictionary (HashMap) - ALREADY IMPLEMENTED");
            Console.WriteLine("   - O(1) average for all operations");
            Console.WriteLine("   - Best for frequent search/update/delete");
            Console.WriteLine("");
            Console.WriteLine("2. Add Secondary Indexes");
            Console.WriteLine("   - Dictionary for name-based search");
            Console.WriteLine("   - Dictionary for category-based search");
            Console.WriteLine("   - Increases space but improves search speed");
            Console.WriteLine("");
            Console.WriteLine("3. Use Sorted Dictionary");
            Console.WriteLine("   - O(log n) search with binary search");
            Console.WriteLine("   - Products automatically sorted");
            Console.WriteLine("   - Good for range queries");
            Console.WriteLine("");
            Console.WriteLine("4. Implement Caching");
            Console.WriteLine("   - Cache frequently accessed products");
            Console.WriteLine("   - Reduces database queries");
            Console.WriteLine("   - Use LRU cache for memory efficiency");
            Console.WriteLine("");
            Console.WriteLine("5. Database Indexing (for large scale)");
            Console.WriteLine("   - Add indexes on productId, productName");
            Console.WriteLine("   - Use B-tree indexes for range queries");
            Console.WriteLine("   - Partition table by category");
            Console.WriteLine("");
            Console.WriteLine("6. Parallel Processing");
            Console.WriteLine("   - Use parallel queries for large inventories");
            Console.WriteLine("   - Split inventory across multiple processors");
            Console.WriteLine("   - Good for GetAll and aggregate operations");
            Console.WriteLine("");

            Console.WriteLine("\nWHICH DATA STRUCTURE TO USE?");
            Console.WriteLine("=============================");
            Console.WriteLine("");
            Console.WriteLine("For Warehouse Inventory System:");
            Console.WriteLine("  RECOMMENDATION: Dictionary (HashMap)");
            Console.WriteLine("  - Fastest for add, update, delete, search");
            Console.WriteLine("  - O(1) average time complexity");
            Console.WriteLine("  - Handles millions of products efficiently");
            Console.WriteLine("");
            Console.WriteLine("When to Use List:");
            Console.WriteLine("  - Small inventory (< 100 products)");
            Console.WriteLine("  - Simple iteration needed");
            Console.WriteLine("  - Minimal memory usage required");
            Console.WriteLine("");
            Console.WriteLine("When to Use Combined Approach:");
            Console.WriteLine("  - Large enterprise warehouse");
            Console.WriteLine("  - Multiple search criteria (ID, name, category)");
            Console.WriteLine("  - Need both fast lookup and iteration");
            Console.WriteLine("");
        }
    }
}