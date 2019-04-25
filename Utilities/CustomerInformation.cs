namespace Utilities
{
    public class CustomerInformation
    {
        //Personal Customer Variables 
        public int ID { get; set; }
        public string LoginID { get; set; }
        public string Password { get; set; }

        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        //Shipping Addresss Variables
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        //Security Codes
        public string SecurityQuestion1 { get; set; }
        public string SecurityAnswer1 { get; set; }
        public string SecurityQuestion2 { get; set; }
        public string SecurityAnswer2 { get; set; }

        public CustomerInformation()
        {

        }
    }
}