namespace MySQLCore.Models
{
    public class Task
    {
        private string _name;
        // private int _id;

        public Task(string name)
        {
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }
    }
}
