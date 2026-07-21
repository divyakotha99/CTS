using System;

namespace EmployeeManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Employee Management System ===\n");

            ExplainArrays();

            TestOperations();

            AnalyzeComplexity();

            Console.WriteLine("\n=== Employee Management Complete ===");
        }

        static void ExplainArrays()
        {
            Console.WriteLine("\n1. ARRAY REPRESENTATION IN MEMORY");
            Console.WriteLine("==================================");
            Console.WriteLine("Array in Memory:");
            Console.WriteLine("  - Arrays store elements in contiguous memory locations");
            Console.WriteLine("  - Each element is stored right after the previous one");
            Console.WriteLine("  - Memory address = Base Address + (Index * Element Size)");
            Console.WriteLine("");
            Console.WriteLine("Example: int array [10, 20, 30, 40]");
            Console.WriteLine("  Memory: [10][20][30][40]");
            Console.WriteLine("  Address: 1000 1004 1008 1012");
            Console.WriteLine("");
            Console.WriteLine("Advantages of Arrays:");
            Console.WriteLine("  1. Fast Access: O(1) - direct access using index");
            Console.WriteLine("  2. Memory Efficient: No extra space for pointers");
            Console.WriteLine("  3. Simple: Easy to understand and implement");
            Console.WriteLine("  4. Cache Friendly: Contiguous memory = better caching");
            Console.WriteLine("  5. Predictable: Fixed size, known memory location");
            Console.WriteLine("");
            Console.WriteLine("Memory Layout Example:");
            Console.WriteLine("  Employee Array [Emp1, Emp2, Emp3]:");
            Console.WriteLine("  Address: 5000 5048 5096");
            Console.WriteLine("  Each Employee object: 48 bytes");
            Console.WriteLine("  Stored contiguously for fast traversal");
            Console.WriteLine("");
        }

        static void TestOperations()
        {
            Console.WriteLine("\n2. TEST OPERATIONS");
            Console.WriteLine("==================");

            EmployeeArray employeeArray = new EmployeeArray(10);

            Console.WriteLine("\nTest 1: Add Employees");
            employeeArray.AddEmployee(new Employee(1, "John Doe", "Manager", 75000));
            employeeArray.AddEmployee(new Employee(2, "Jane Smith", "Developer", 65000));
            employeeArray.AddEmployee(new Employee(3, "Bob Johnson", "Analyst", 55000));
            employeeArray.AddEmployee(new Employee(4, "Alice Brown", "Developer", 70000));
            employeeArray.AddEmployee(new Employee(5, "Charlie Wilson", "HR", 50000));

            Console.WriteLine($"Total Employees: {employeeArray.GetCount()}");

            Console.WriteLine("\nTest 2: Display All");
            employeeArray.DisplayAll();

            Console.WriteLine("\nTest 3: Search by ID");
            Employee? found = employeeArray.SearchById(3);
            if (found != null)
            {
                Console.WriteLine($"Found: {found.GetEmployeeDetails()}");
            }

            Console.WriteLine("\nTest 4: Search by Name");
            Employee? foundByName = employeeArray.SearchByName("Jane Smith");
            if (foundByName != null)
            {
                Console.WriteLine($"Found: {foundByName.GetEmployeeDetails()}");
            }

            Console.WriteLine("\nTest 5: Add More Employees (to show array growing)");
            employeeArray.AddEmployee(new Employee(6, "Diana Lee", "QA", 48000));
            employeeArray.AddEmployee(new Employee(7, "Eve Davis", "Marketing", 52000));
            Console.WriteLine($"Total Employees: {employeeArray.GetCount()}");

            Console.WriteLine("\nTest 6: Delete Employee");
            employeeArray.DeleteEmployee(3);
            Console.WriteLine($"Total After Delete: {employeeArray.GetCount()}");

            Console.WriteLine("\nTest 7: Display After Delete");
            employeeArray.DisplayAll();

            Console.WriteLine("\nTest 8: Search Non-Existent Employee");
            Employee? notFound = employeeArray.SearchById(999);
            if (notFound == null)
            {
                Console.WriteLine("Employee not found (as expected)");
            }

            Console.WriteLine("\nTest 9: Try to Add Beyond Capacity");
            for (int i = 8; i <= 15; i++)
            {
                employeeArray.AddEmployee(new Employee(i, $"Employee {i}", "Staff", 40000));
            }
        }

        static void AnalyzeComplexity()
        {
            Console.WriteLine("\n3. TIME COMPLEXITY ANALYSIS");
            Console.WriteLine("============================");

            Console.WriteLine("\nTime Complexity of Operations:");
            Console.WriteLine("| Operation  | Time Complexity | Description                    |");
            Console.WriteLine("|------------|-----------------|--------------------------------|");
            Console.WriteLine("| Add        | O(1)            | Add at end, no search needed   |");
            Console.WriteLine("| Search(ID) | O(n)            | Must check each element        |");
            Console.WriteLine("| Search(Name)| O(n)           | Must check each element        |");
            Console.WriteLine("| Traverse   | O(n)            | Visit all n elements           |");
            Console.WriteLine("| Delete     | O(n)            | Search + shift elements        |");
            Console.WriteLine("");

            Console.WriteLine("Detailed Analysis:");
            Console.WriteLine("");
            Console.WriteLine("Add: O(1)");
            Console.WriteLine("  - Add at index _count (end of array)");
            Console.WriteLine("  - No loop, just one assignment");
            Console.WriteLine("  - Constant time regardless of array size");
            Console.WriteLine("");
            Console.WriteLine("Search by ID: O(n)");
            Console.WriteLine("  - Must check each element one by one");
            Console.WriteLine("  - Worst case: element at last position or not found");
            Console.WriteLine("  - Average case: n/2 comparisons");
            Console.WriteLine("  - n/2 = O(n) (ignore constants in Big O)");
            Console.WriteLine("");
            Console.WriteLine("Search by Name: O(n)");
            Console.WriteLine("  - Same as Search by ID");
            Console.WriteLine("  - Must iterate through all elements");
            Console.WriteLine("  - String comparison adds constant time");
            Console.WriteLine("");
            Console.WriteLine("Traverse: O(n)");
            Console.WriteLine("  - Loop through all n elements");
            Console.WriteLine("  - Print/display each element");
            Console.WriteLine("  - Exactly n iterations");
            Console.WriteLine("  - Linear time complexity");
            Console.WriteLine("");
            Console.WriteLine("Delete: O(n)");
            Console.WriteLine("  - Step 1: Search for element (O(n))");
            Console.WriteLine("  - Step 2: Shift remaining elements left (O(n))");
            Console.WriteLine("  - Total: O(n) + O(n) = 2n = O(n)");
            Console.WriteLine("  - Worst case: delete first element (shift all)");
            Console.WriteLine("");

            Console.WriteLine("\nLIMITATIONS OF ARRAYS:");
            Console.WriteLine("======================");
            Console.WriteLine("");
            Console.WriteLine("1. Fixed Size:");
            Console.WriteLine("   - Cannot grow or shrink after creation");
            Console.WriteLine("   - Must know maximum size beforehand");
            Console.WriteLine("   - Example: EmployeeArray(10) can only hold 10 employees");
            Console.WriteLine("   - If you try to add 11th employee, it fails");
            Console.WriteLine("");
            Console.WriteLine("2. Slow Insertion/Deletion at Middle:");
            Console.WriteLine("   - O(n) for middle insertion/deletion");
            Console.WriteLine("   - Must shift all elements after the position");
            Console.WriteLine("   - Example: Deleting employee at index 0 shifts all n-1 employees");
            Console.WriteLine("");
            Console.WriteLine("3. No Built-in Search:");
            Console.WriteLine("   - Must implement search manually (loop)");
            Console.WriteLine("   - O(n) for unsorted arrays");
            Console.WriteLine("   - No binary search unless array is sorted");
            Console.WriteLine("");
            Console.WriteLine("4. Memory Wastage:");
            Console.WriteLine("   - Allocate maximum size upfront");
            Console.WriteLine("   - May use only small portion");
            Console.WriteLine("   - Example: Allocate 1000, use only 50 = 95% waste");
            Console.WriteLine("");
            Console.WriteLine("5. No Dynamic Resizing:");
            Console.WriteLine("   - Cannot add beyond capacity");
            Console.WriteLine("   - Need to create new larger array and copy");
            Console.WriteLine("   - Resizing is expensive: O(n) copy operation");
            Console.WriteLine("");

            Console.WriteLine("\nWHEN TO USE ARRAYS:");
            Console.WriteLine("===================");
            Console.WriteLine("");
            Console.WriteLine("1. Fixed number of elements (known size)");
            Console.WriteLine("   - Example: Max 100 employees in small company");
            Console.WriteLine("");
            Console.WriteLine("2. Need fast access by index");
            Console.WriteLine("   - Example: Get employee at index 5: O(1)");
            Console.WriteLine("");
            Console.WriteLine("3. Simple storage with minimal operations");
            Console.WriteLine("   - Mostly add at end, traverse all");
            Console.WriteLine("   - Few deletions or middle insertions");
            Console.WriteLine("");
            Console.WriteLine("4. Memory efficiency is critical");
            Console.WriteLine("   - No extra space for pointers/node overhead");
            Console.WriteLine("   - Arrays use minimal memory");
            Console.WriteLine("");
            Console.WriteLine("5. Small datasets (n < 100)");
            Console.WriteLine("   - O(n) search is fast enough for small n");
            Console.WriteLine("   - No need for complex data structures");
            Console.WriteLine("");
            Console.WriteLine("6. Educational purposes");
            Console.WriteLine("   - Learning fundamental data structures");
            Console.WriteLine("   - Understanding memory representation");
            Console.WriteLine("");

            Console.WriteLine("\nWHEN NOT TO USE ARRAYS:");
            Console.WriteLine("=======================");
            Console.WriteLine("");
            Console.WriteLine("1. Frequent add/delete operations");
            Console.WriteLine("   - Use List or LinkedList instead");
            Console.WriteLine("   - Arrays have O(n) deletion");
            Console.WriteLine("");
            Console.WriteLine("2. Unknown or changing size");
            Console.WriteLine("   - Use List (dynamic array)");
            Console.WriteLine("   - Automatically grows as needed");
            Console.WriteLine("");
            Console.WriteLine("3. Need fast search (especially by key)");
            Console.WriteLine("   - Use Dictionary: O(1) search by employeeId");
            Console.WriteLine("   - Arrays have O(n) search");
            Console.WriteLine("");
            Console.WriteLine("4. Large datasets (n > 1000)");
            Console.WriteLine("   - Use Database with indexes");
            Console.WriteLine("   - Or Dictionary for O(1) lookup");
            Console.WriteLine("");
            Console.WriteLine("5. Need sorted data with fast operations");
            Console.WriteLine("   - Use SortedList: O(log n) search");
            Console.WriteLine("   - Arrays require manual sorting");
            Console.WriteLine("");

            Console.WriteLine("\nALTERNATIVES TO ARRAYS:");
            Console.WriteLine("=======================");
            Console.WriteLine("");
            Console.WriteLine("1. List (ArrayList in C#):");
            Console.WriteLine("   - Dynamic size (automatically grows)");
            Console.WriteLine("   - O(1) add at end");
            Console.WriteLine("   - O(n) search (same as array)");
            Console.WriteLine("   - Better for most use cases");
            Console.WriteLine("");
            Console.WriteLine("2. Dictionary (HashMap):");
            Console.WriteLine("   - O(1) search by key (employeeId)");
            Console.WriteLine("   - O(1) add, delete");
            Console.WriteLine("   - Best for frequent lookups");
            Console.WriteLine("   - Example: Dictionary<int, Employee>");
            Console.WriteLine("");
            Console.WriteLine("3. SortedList:");
            Console.WriteLine("   - Maintains sorted order");
            Console.WriteLine("   - O(log n) search (binary search)");
            Console.WriteLine("   - O(n) add/delete (maintain sorted)");
            Console.WriteLine("   - Good when data needs to be sorted");
            Console.WriteLine("");
            Console.WriteLine("4. Database (SQL):");
            Console.WriteLine("   - For very large datasets (millions)");
            Console.WriteLine("   - Indexed queries: O(log n) or O(1)");
            Console.WriteLine("   - Persistent storage");
            Console.WriteLine("   - Example: Employee table with PK on employeeId");
            Console.WriteLine("");
            Console.WriteLine("5. LinkedList:");
            Console.WriteLine("   - O(1) insertion/deletion at known position");
            Console.WriteLine("   - O(n) search (same as array)");
            Console.WriteLine("   - Dynamic size");
            Console.WriteLine("   - Not cache-friendly (scattered memory)");
            Console.WriteLine("");

            Console.WriteLine("\nRECOMMENDATION FOR EMPLOYEE MANAGEMENT:");
            Console.WriteLine("========================================");
            Console.WriteLine("");
            Console.WriteLine("For Small Company (< 100 employees):");
            Console.WriteLine("  USE: Array (as implemented)");
            Console.WriteLine("  - Simple and easy to understand");
            Console.WriteLine("  - O(n) search is fast enough");
            Console.WriteLine("  - Memory efficient");
            Console.WriteLine("");
            Console.WriteLine("For Medium Company (100-1000 employees):");
            Console.WriteLine("  USE: List or Dictionary");
            Console.WriteLine("  - List: Dynamic size, easy to use");
            Console.WriteLine("  - Dictionary: O(1) search by employeeId (BEST)");
            Console.WriteLine("");
            Console.WriteLine("For Large Company (> 1000 employees):");
            Console.WriteLine("  USE: Database + Dictionary cache");
            Console.WriteLine("  - Database: Persistent storage, indexed queries");
            Console.WriteLine("  - Dictionary: Fast cache for frequent access");
            Console.WriteLine("");
            Console.WriteLine("Best Practice for Production:");
            Console.WriteLine("  Dictionary<int, Employee> employees = new Dictionary<int, Employee>();");
            Console.WriteLine("  - Add: employees.Add(employeeId, employee) - O(1)");
            Console.WriteLine("  - Search: employees[employeeId] - O(1)");
            Console.WriteLine("  - Delete: employees.Remove(employeeId) - O(1)");
            Console.WriteLine("");
        }
    }
}