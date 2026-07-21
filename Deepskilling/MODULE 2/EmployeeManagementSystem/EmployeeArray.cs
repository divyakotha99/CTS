using System;

namespace EmployeeManagementSystem
{
    public class EmployeeArray
    {
        private Employee[] _employees;
        private int _count;

        public EmployeeArray(int size)
        {
            _employees = new Employee[size];
            _count = 0;
        }

        public bool AddEmployee(Employee employee)
        {
            if (_count >= _employees.Length)
            {
                Console.WriteLine($"Cannot add: Array is full (max {_employees.Length} employees)");
                return false;
            }
            _employees[_count] = employee;
            _count++;
            Console.WriteLine($"Employee added: {employee.GetEmployeeDetails()}");
            return true;
        }

        public Employee? SearchById(int employeeId)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_employees[i].EmployeeId == employeeId)
                {
                    return _employees[i];
                }
            }
            Console.WriteLine($"Employee with ID {employeeId} not found");
            return null;
        }

        public Employee? SearchByName(string name)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_employees[i].Name == name)
                {
                    return _employees[i];
                }
            }
            Console.WriteLine($"Employee with name {name} not found");
            return null;
        }

        public void Traverse()
        {
            if (_count == 0)
            {
                Console.WriteLine("No employees in the array");
                return;
            }
            for (int i = 0; i < _count; i++)
            {
                Console.WriteLine(_employees[i].GetEmployeeDetails());
            }
        }

        public bool DeleteEmployee(int employeeId)
        {
            int index = -1;
            for (int i = 0; i < _count; i++)
            {
                if (_employees[i].EmployeeId == employeeId)
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                Console.WriteLine($"Employee with ID {employeeId} not found");
                return false;
            }

            Employee deletedEmployee = _employees[index];
            for (int i = index; i < _count - 1; i++)
            {
                _employees[i] = _employees[i + 1];
            }
            _count--;
            Console.WriteLine($"Employee deleted: {deletedEmployee.GetEmployeeDetails()}");
            return true;
        }

        public int GetCount()
        {
            return _count;
        }

        public void DisplayAll()
        {
            Console.WriteLine("\n=== All Employees ===");
            Console.WriteLine($"Total: {_count}");
            Console.WriteLine("---------------------");
            Traverse();
            Console.WriteLine("---------------------\n");
        }
    }
}