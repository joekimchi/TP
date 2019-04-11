namespace Utilities
{
    public class Product
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string ImageURL { get; set; }
        public int DepartmentID { get; set; }

        public Product()
        {

        }

        public Product(int id, string desc, float price, string imgURL, int deptID)
        {
            ID = id;
            Description = desc;
            Price = price;
            ImageURL = imgURL;
            DepartmentID = deptID;
        }

        public Product(int id, string desc, float price, string imgURL)
        {
            ID = id;
            Description = desc;
            Price = price;
            ImageURL = imgURL;
        }
    }
}