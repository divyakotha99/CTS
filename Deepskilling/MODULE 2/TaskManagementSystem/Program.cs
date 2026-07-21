using System;

namespace TaskManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Task Management System ===\n");

            ExplainLinkedLists();

            TestOperations();

            AnalyzeComplexity();

            Console.WriteLine("\n=== Task Management Complete ===");
        }

        static void ExplainLinkedLists()
        {
            Console.WriteLine("\n1. LINKED LISTS EXPLANATION");
            Console.WriteLine("============================");
            Console.WriteLine("");
            Console.WriteLine("What is a Linked List?");
            Console.WriteLine("  - A linear data structure where elements are stored in nodes");
            Console.WriteLine("  - Each node contains data and a reference to the next node");
            Console.WriteLine("  - Nodes are not stored contiguously in memory");
            Console.WriteLine("  - Connected using pointers/references");
            Console.WriteLine("");
            Console.WriteLine("Different Types of Linked Lists:");
            Console.WriteLine("");
            Console.WriteLine("1. SINGLY LINKED LIST");
            Console.WriteLine("   - Each node has data and pointer to NEXT node");
            Console.WriteLine("   - Can traverse only in one direction (forward)");
            Console.WriteLine("   - Memory: Node = Data + 1 pointer");
            Console.WriteLine("   - Example: A -> B -> C -> D -> null");
            Console.WriteLine("   - Advantages: Simple, less memory per node");
            Console.WriteLine("   - Disadvantages: Can only traverse forward");
            Console.WriteLine("");
            Console.WriteLine("2. DOUBLY LINKED LIST");
            Console.WriteLine("   - Each node has data + pointer to NEXT + pointer to PREVIOUS");
            Console.WriteLine("   - Can traverse in both directions (forward and backward)");
            Console.WriteLine("   - Memory: Node = Data + 2 pointers");
            Console.WriteLine("   - Example: null <- A <-> B <-> C <-> D -> null");
            Console.WriteLine("   - Advantages: Can traverse both directions");
            Console.WriteLine("   - Disadvantages: More memory per node");
            Console.WriteLine("");
            Console.WriteLine("3. CIRCULAR LINKED LIST");
            Console.WriteLine("   - Last node points back to first node (no null)");
            Console.WriteLine("   - Forms a circle/cycle");
            Console.WriteLine("   - Example: A -> B -> C -> D -> A (circle)");
            Console.WriteLine("   - Advantages: Can start from any node");
            Console.WriteLine("   - Disadvantages: Need to detect cycle");
            Console.WriteLine("");
            Console.WriteLine("4. CIRCULAR DOUBLY LINKED LIST");
            Console.WriteLine("   - Doubly linked list where last points to first");
            Console.WriteLine("   - First also points to last");
            Console.WriteLine("   - Example: A <-> B <-> C <-> D (circular)");
            Console.WriteLine("   - Advantages: Bidirectional + circular");
            Console.WriteLine("   - Disadvantages: Most memory per node");
            Console.WriteLine("");
            Console.WriteLine("Comparison Table:");
            Console.WriteLine("┌──────────────────────┬──────────┬──────────────┬──────────┐");
            Console.WriteLine("│ Type                 │ Pointers │ Traversal    │ Memory   │");
            Console.WriteLine("├──────────────────────┼──────────┼──────────────┼──────────┤");
            Console.WriteLine("│ Singly Linked        │ 1        │ Forward only │ Less     │");
            Console.WriteLine("│ Doubly Linked        │ 2        │ Both dirs    │ More     │");
            Console.WriteLine("│ Circular Linked      │ 1        │ Circular     │ Less     │");
            Console.WriteLine("│ Circular Doubly      │ 2        │ Circular     │ More     │");
            Console.WriteLine("└──────────────────────┴──────────┴──────────────┴──────────┘");
            Console.WriteLine("");
            Console.WriteLine("Memory Representation:");
            Console.WriteLine("");
            Console.WriteLine("Singly Linked List:");
            Console.WriteLine("  Node 1: [Task1 | pointer to Node 2] -> Address: 1000");
            Console.WriteLine("  Node 2: [Task2 | pointer to Node 3] -> Address: 1500");
            Console.WriteLine("  Node 3: [Task3 | null]              -> Address: 2000");
            Console.WriteLine("  Nodes are scattered in memory, connected by pointers");
            Console.WriteLine("");
            Console.WriteLine("Doubly Linked List:");
            Console.WriteLine("  Node 1: [Task1 | prev=null | next=Node2] -> Address: 1000");
            Console.WriteLine("  Node 2: [Task2 | prev=Node1| next=Node3] -> Address: 1500");
            Console.WriteLine("  Node 3: [Task3 | prev=Node2| next=null]  -> Address: 2000");
            Console.WriteLine("  Each node has 2 pointers (previous and next)");
            Console.WriteLine("");
            Console.WriteLine("WHY USE LINKED LIST FOR TASK MANAGEMENT?");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("  1. Dynamic size - tasks can be added/deleted freely");
            Console.WriteLine("  2. No fixed capacity limit");
            Console.WriteLine("  3. Efficient insertion/deletion (O(1) at beginning)");
            Console.WriteLine("  4. Memory efficient for sparse data");
            Console.WriteLine("  5. Tasks don't need to be contiguous in memory");
            Console.WriteLine("");
        }

        static void TestOperations()
        {
            Console.WriteLine("\n2. TEST OPERATIONS");
            Console.WriteLine("==================");

            TaskLinkedList taskList = new TaskLinkedList();

            Console.WriteLine("\nTest 1: Add Tasks");
            taskList.AddTask(new Task(1, "Complete Project Report", "Pending"));
            taskList.AddTask(new Task(2, "Review Code", "InProgress"));
            taskList.AddTask(new Task(3, "Update Documentation", "Pending"));
            taskList.AddTask(new Task(4, "Test Application", "Completed"));
            taskList.AddTask(new Task(5, "Fix Bugs", "InProgress"));

            Console.WriteLine($"Total Tasks: {taskList.GetCount()}");

            Console.WriteLine("\nTest 2: Add Task at Beginning");
            taskList.AddTaskAtBeginning(new Task(0, "Urgent Task", "Pending"));
            Console.WriteLine($"Total Tasks: {taskList.GetCount()}");

            Console.WriteLine("\nTest 3: Display All Tasks");
            taskList.DisplayAll();

            Console.WriteLine("\nTest 4: Search Task by ID");
            Task? found = taskList.SearchTaskById(3);
            if (found != null)
            {
                Console.WriteLine($"Found: {found.GetTaskDetails()}");
            }

            Console.WriteLine("\nTest 5: Search Task by Name");
            Task? foundByName = taskList.SearchTaskByName("Review Code");
            if (foundByName != null)
            {
                Console.WriteLine($"Found: {foundByName.GetTaskDetails()}");
            }

            Console.WriteLine("\nTest 6: Get Tasks by Status (Pending)");
            Task[] pendingTasks = taskList.GetTasksByStatus("Pending");
            Console.WriteLine($"Found {pendingTasks.Length} pending tasks:");
            foreach (Task task in pendingTasks)
            {
                Console.WriteLine($"  {task.GetTaskDetails()}");
            }

            Console.WriteLine("\nTest 7: Delete Task by ID");
            taskList.DeleteTask(2);
            Console.WriteLine($"Total After Delete: {taskList.GetCount()}");

            Console.WriteLine("\nTest 8: Display After Delete");
            taskList.DisplayAll();

            Console.WriteLine("\nTest 9: Delete Tasks by Status (Pending)");
            int deletedCount = taskList.DeleteTasksByStatus("Pending");
            Console.WriteLine($"Deleted {deletedCount} pending tasks");
            Console.WriteLine($"Total After Delete: {taskList.GetCount()}");

            Console.WriteLine("\nTest 10: Display Final State");
            taskList.DisplayAll();

            Console.WriteLine("\nTest 11: Search Non-Existent Task");
            Task? notFound = taskList.SearchTaskById(999);
            if (notFound == null)
            {
                Console.WriteLine("Task not found (as expected)");
            }
        }

        static void AnalyzeComplexity()
        {
            Console.WriteLine("\n3. TIME COMPLEXITY ANALYSIS");
            Console.WriteLine("============================");

            Console.WriteLine("\nTime Complexity of Operations (Singly Linked List):");
            Console.WriteLine("| Operation          | Time Complexity | Description                 |");
            Console.WriteLine("|--------------------|-----------------|-----------------------------|");
            Console.WriteLine("| Add at End         | O(n)            | Traverse to end             |");
            Console.WriteLine("| Add at Beginning   | O(1)            | Direct insertion            |");
            Console.WriteLine("| Search by ID       | O(n)            | Traverse and check          |");
            Console.WriteLine("| Search by Name     | O(n)            | Traverse and check          |");
            Console.WriteLine("| Traverse           | O(n)            | Visit all n nodes           |");
            Console.WriteLine("| Delete by ID       | O(n)            | Search + unlink node        |");
            Console.WriteLine("| Delete by Status   | O(n)            | Traverse all, delete matches|");
            Console.WriteLine("| Get Count          | O(1)            | Return stored count         |");
            Console.WriteLine("");

            Console.WriteLine("Detailed Analysis:");
            Console.WriteLine("");
            Console.WriteLine("Add at End: O(n)");
            Console.WriteLine("  - Must traverse from head to end");
            Console.WriteLine("  - Visit n nodes in worst case");
            Console.WriteLine("  - Then add new node at end");
            Console.WriteLine("  - Total: n traversals = O(n)");
            Console.WriteLine("");
            Console.WriteLine("Add at Beginning: O(1)");
            Console.WriteLine("  - Create new node");
            Console.WriteLine("  - Point new node to current head");
            Console.WriteLine("  - Update head to new node");
            Console.WriteLine("  - Constant time, no traversal");
            Console.WriteLine("");
            Console.WriteLine("Search by ID: O(n)");
            Console.WriteLine("  - Start from head node");
            Console.WriteLine("  - Traverse and check each node");
            Console.WriteLine("  - Worst case: task at end or not found");
            Console.WriteLine("  - Average case: n/2 comparisons");
            Console.WriteLine("  - n/2 = O(n)");
            Console.WriteLine("");
            Console.WriteLine("Search by Name: O(n)");
            Console.WriteLine("  - Same as Search by ID");
            Console.WriteLine("  - String comparison adds constant time");
            Console.WriteLine("  - Still O(n) overall");
            Console.WriteLine("");
            Console.WriteLine("Traverse: O(n)");
            Console.WriteLine("  - Start from head");
            Console.WriteLine("  - Visit each node until null");
            Console.WriteLine("  - Exactly n nodes visited");
            Console.WriteLine("  - Linear time complexity");
            Console.WriteLine("");
            Console.WriteLine("Delete by ID: O(n)");
            Console.WriteLine("  - Step 1: Search for node (O(n))");
            Console.WriteLine("  - Step 2: Unlink node (O(1))");
            Console.WriteLine("  - Total: O(n) + O(1) = O(n)");
            Console.WriteLine("  - Worst case: delete last node");
            Console.WriteLine("");
            Console.WriteLine("Delete by Status: O(n)");
            Console.WriteLine("  - Traverse all n nodes");
            Console.WriteLine("  - Check each node's status");
            Console.WriteLine("  - Delete matching nodes");
            Console.WriteLine("  - Total: O(n)");
            Console.WriteLine("");

            Console.WriteLine("\nADVANTAGES OF LINKED LISTS OVER ARRAYS:");
            Console.WriteLine("========================================");
            Console.WriteLine("");
            Console.WriteLine("1. DYNAMIC SIZE:");
            Console.WriteLine("   - Linked List: Automatically grows/shrinks");
            Console.WriteLine("   - Array: Fixed size, must know max beforehand");
            Console.WriteLine("   - Example: Task list can have any number of tasks");
            Console.WriteLine("");
            Console.WriteLine("2. EFFICIENT INSERTION/DELETION:");
            Console.WriteLine("   - Linked List: O(1) at beginning");
            Console.WriteLine("   - Array: O(n) for insertion/deletion");
            Console.WriteLine("   - Must shift all elements in array");
            Console.WriteLine("");
            Console.WriteLine("3. NO MEMORY WASTAGE:");
            Console.WriteLine("   - Linked List: Allocate only what needed");
            Console.WriteLine("   - Array: Allocate max size, may waste space");
            Console.WriteLine("   - Example: Array(1000) with 10 tasks = 99% waste");
            Console.WriteLine("");
            Console.WriteLine("4. NO RESHIFTING REQUIRED:");
            Console.WriteLine("   - Linked List: Just change pointers");
            Console.WriteLine("   - Array: Must shift n-i elements after deletion");
            Console.WriteLine("   - Deleting from array is expensive");
            Console.WriteLine("");
            Console.WriteLine("5. FLEXIBLE MEMORY ALLOCATION:");
            Console.WriteLine("   - Linked List: Nodes scattered in memory");
            Console.WriteLine("   - Array: Must have contiguous memory");
            Console.WriteLine("   - Linked list works even with fragmented memory");
            Console.WriteLine("");
            Console.WriteLine("6. NO CAPACITY LIMIT:");
            Console.WriteLine("   - Linked List: Limited only by available memory");
            Console.WriteLine("   - Array: Limited by allocated size");
            Console.WriteLine("   - Can add unlimited tasks to linked list");
            Console.WriteLine("");

            Console.WriteLine("\nDISADVANTAGES OF LINKED LISTS:");
            Console.WriteLine("===============================");
            Console.WriteLine("");
            Console.WriteLine("1. NO DIRECT INDEX ACCESS:");
            Console.WriteLine("   - Linked List: O(n) to access nth element");
            Console.WriteLine("   - Array: O(1) to access by index");
            Console.WriteLine("   - Cannot do tasks[5] in linked list");
            Console.WriteLine("");
            Console.WriteLine("2. MORE MEMORY PER ELEMENT:");
            Console.WriteLine("   - Linked List: Data + Pointer (8 bytes overhead)");
            Console.WriteLine("   - Array: Just data (no overhead)");
            Console.WriteLine("   - 8 bytes extra per node");
            Console.WriteLine("");
            Console.WriteLine("3. SLOWER TRAVERSAL:");
            Console.WriteLine("   - Linked List: Not cache-friendly");
            Console.WriteLine("   - Array: Contiguous = better caching");
            Console.WriteLine("   - Array traverses faster in practice");
            Console.WriteLine("");
            Console.WriteLine("4. NO BINARY SEARCH:");
            Console.WriteLine("   - Linked List: Cannot do binary search");
            Console.WriteLine("   - Array: Binary search O(log n) if sorted");
            Console.WriteLine("   - Must use linear search O(n)");
            Console.WriteLine("");

            Console.WriteLine("\nWHEN TO USE LINKED LIST:");
            Console.WriteLine("========================");
            Console.WriteLine("");
            Console.WriteLine("1. Dynamic data size (unknown or changing)");
            Console.WriteLine("   - Example: Task management, chat messages");
            Console.WriteLine("");
            Console.WriteLine("2. Frequent insertion/deletion at beginning");
            Console.WriteLine("   - Example: Queue, stack operations");
            Console.WriteLine("");
            Console.WriteLine("3. Memory is fragmented");
            Console.WriteLine("   - Cannot allocate large contiguous block");
            Console.WriteLine("");
            Console.WriteLine("4. Don't need index-based access");
            Console.WriteLine("   - Mostly traverse or search by value");
            Console.WriteLine("");
            Console.WriteLine("5. Real-time streaming data");
            Console.WriteLine("   - Continuous addition/deletion");
            Console.WriteLine("");

            Console.WriteLine("\nWHEN TO USE ARRAY:");
            Console.WriteLine("==================");
            Console.WriteLine("");
            Console.WriteLine("1. Fixed size data (known number of elements)");
            Console.WriteLine("   - Example: Days of week, months");
            Console.WriteLine("");
            Console.WriteLine("2. Need fast index-based access");
            Console.WriteLine("   - Example: Get tasks[5], tasks[10]");
            Console.WriteLine("");
            Console.WriteLine("3. Need binary search");
            Console.WriteLine("   - Data is sorted, need fast search");
            Console.WriteLine("");
            Console.WriteLine("4. Memory efficiency is critical");
            Console.WriteLine("   - No pointer overhead");
            Console.WriteLine("");
            Console.WriteLine("5. Small datasets with random access");
            Console.WriteLine("   - O(1) access is important");
            Console.WriteLine("");

            Console.WriteLine("\nRECOMMENDATION FOR TASK MANAGEMENT:");
            Console.WriteLine("====================================");
            Console.WriteLine("");
            Console.WriteLine("USE: Linked List (as implemented)");
            Console.WriteLine("");
            Console.WriteLine("REASONS:");
            Console.WriteLine("  1. Tasks are dynamic - added/deleted frequently");
            Console.WriteLine("  2. Unknown number of tasks (can grow indefinitely)");
            Console.WriteLine("  3. O(1) insertion at beginning (urgent tasks)");
            Console.WriteLine("  4. Don't need index-based access (search by ID/name)");
            Console.WriteLine("  5. Memory efficient for sparse task data");
            Console.WriteLine("");
            Console.WriteLine("ALTERNATIVE FOR PRODUCTION:");
            Console.WriteLine("  Use List<T> (C# built-in dynamic array):");
            Console.WriteLine("  - O(1) add at end");
            Console.WriteLine("  - O(1) index access");
            Console.WriteLine("  - Dynamic size");
            Console.WriteLine("  - Better cache performance");
            Console.WriteLine("");
            Console.WriteLine("  OR use Dictionary for O(1) search:");
            Console.WriteLine("  Dictionary<int, Task> tasks = new Dictionary<int, Task>();");
            Console.WriteLine("  - Add: tasks.Add(taskId, task) - O(1)");
            Console.WriteLine("  - Search: tasks[taskId] - O(1)");
            Console.WriteLine("  - Delete: tasks.Remove(taskId) - O(1)");
            Console.WriteLine("");
        }
    }
}