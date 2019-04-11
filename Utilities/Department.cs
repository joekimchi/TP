namespace Utilities
{
    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Department()
        {

        }

        public Department(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}