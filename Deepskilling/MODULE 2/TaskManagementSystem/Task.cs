namespace TaskManagementSystem
{
    public class Task
    {
        private int _taskId;
        private string _taskName;
        private string _status;

        public Task(int taskId, string taskName, string status)
        {
            _taskId = taskId;
            _taskName = taskName;
            _status = status;
        }

        public int TaskId
        {
            get { return _taskId; }
            set { _taskId = value; }
        }

        public string TaskName
        {
            get { return _taskName; }
            set { _taskName = value; }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public string GetTaskDetails()
        {
            return $"ID: {_taskId}, Name: {_taskName}, Status: {_status}";
        }
    }
}