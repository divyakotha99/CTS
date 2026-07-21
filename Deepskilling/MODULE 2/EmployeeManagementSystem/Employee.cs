namespace EmployeeManagementSystem
{
    public class Employee
    {
        private int _employeeId;
        private string _name;
        private string _position;
        private double _salary;

        public Employee(int employeeId, string name, string position, double salary)
        {
            _employeeId = employeeId;
            _name = name;
            _position = position;
            _salary = salary;
        }

        public int EmployeeId
        {
            get { return _employeeId; }
            set { _employeeId = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public double Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }

        public string GetEmployeeDetails()
        {
            return $"ID: {_employeeId}, Name: {_name}, Position: {_position}, Salary: ${_salary}";
        }
    }
}