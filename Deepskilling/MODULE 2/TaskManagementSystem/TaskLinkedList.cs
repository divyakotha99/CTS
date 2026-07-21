using System;

namespace TaskManagementSystem
{
    // Node class for linked list
    public class TaskNode
    {
        public Task Task { get; set; }
        public TaskNode? Next { get; set; }

        public TaskNode(Task task)
        {
            Task = task;
            Next = null;
        }
    }

    public class TaskLinkedList
    {
        private TaskNode? _head;
        private int _count;

        public TaskLinkedList()
        {
            _head = null;
            _count = 0;
        }

        // ADD at end - O(n)
        public void AddTask(Task task)
        {
            TaskNode newNode = new TaskNode(task);

            if (_head == null)
            {
                _head = newNode;
            }
            else
            {
                TaskNode? current = _head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
            _count++;
            Console.WriteLine($"Task added: {task.GetTaskDetails()}");
        }

        // ADD at beginning - O(1)
        public void AddTaskAtBeginning(Task task)
        {
            TaskNode newNode = new TaskNode(task);
            newNode.Next = _head;
            _head = newNode;
            _count++;
            Console.WriteLine($"Task added at beginning: {task.GetTaskDetails()}");
        }

        // SEARCH by ID - O(n)
        public Task? SearchTaskById(int taskId)
        {
            TaskNode? current = _head;
            while (current != null)
            {
                if (current.Task.TaskId == taskId)
                {
                    return current.Task;
                }
                current = current.Next;
            }
            Console.WriteLine($"Task with ID {taskId} not found");
            return null;
        }

        // SEARCH by name - O(n)
        public Task? SearchTaskByName(string taskName)
        {
            TaskNode? current = _head;
            while (current != null)
            {
                if (current.Task.TaskName == taskName)
                {
                    return current.Task;
                }
                current = current.Next;
            }
            Console.WriteLine($"Task with name {taskName} not found");
            return null;
        }

        // TRAVERSE - O(n)
        public void Traverse()
        {
            if (_head == null)
            {
                Console.WriteLine("No tasks in the list");
                return;
            }
            TaskNode? current = _head;
            while (current != null)
            {
                Console.WriteLine(current.Task.GetTaskDetails());
                current = current.Next;
            }
        }

        // DELETE by ID - O(n)
        public bool DeleteTask(int taskId)
        {
            if (_head == null)
            {
                Console.WriteLine("List is empty");
                return false;
            }

            // use a single nullable local to avoid duplicate declarations
            Task? deletedTask = null;

            if (_head.Task.TaskId == taskId)
            {
                deletedTask = _head.Task;
                _head = _head.Next;
                _count--;
                Console.WriteLine($"Task deleted: {deletedTask.GetTaskDetails()}");
                return true;
            }

            TaskNode current = _head;
            while (current.Next != null && current.Next.Task.TaskId != taskId)
            {
                current = current.Next;
            }

            if (current.Next == null)
            {
                Console.WriteLine($"Task with ID {taskId} not found");
                return false;
            }

            deletedTask = current.Next.Task;
            current.Next = current.Next.Next;
            _count--;
            Console.WriteLine($"Task deleted: {deletedTask.GetTaskDetails()}");
            return true;
        }

        // DELETE by status - O(n)
        public int DeleteTasksByStatus(string status)
        {
            int deletedCount = 0;

            while (_head != null && _head.Task.Status == status)
            {
                Task deletedTask = _head.Task;
                _head = _head.Next;
                _count--;
                deletedCount++;
                Console.WriteLine($"Task deleted: {deletedTask.GetTaskDetails()}");
            }

            TaskNode? current = _head;
            while (current != null && current.Next != null)
            {
                if (current.Next.Task.Status == status)
                {
                    Task deletedTask = current.Next.Task;
                    current.Next = current.Next.Next;
                    _count--;
                    deletedCount++;
                    Console.WriteLine($"Task deleted: {deletedTask.GetTaskDetails()}");
                }
                else
                {
                    current = current.Next;
                }
            }

            return deletedCount;
        }

        // GET COUNT - O(1)
        public int GetCount()
        {
            return _count;
        }

        // DISPLAY ALL - O(n)
        public void DisplayAll()
        {
            Console.WriteLine("\n=== All Tasks ===");
            Console.WriteLine($"Total: {_count}");
            Console.WriteLine("-----------------");
            Traverse();
            Console.WriteLine("-----------------\n");
        }

        // GET TASKS BY STATUS - O(n)
        public Task[] GetTasksByStatus(string status)
        {
            Task[] tasks = new Task[_count];
            int index = 0;
            TaskNode? current = _head;

            while (current != null)
            {
                if (current.Task.Status == status)
                {
                    tasks[index] = current.Task;
                    index++;
                }
                current = current.Next;
            }

            Task[] result = new Task[index];
            for (int i = 0; i < index; i++)
            {
                result[i] = tasks[i];
            }

            return result;
        }
    }
}