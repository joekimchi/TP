using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    [Serializable]
    public class CartItem
    {
        //create empty object or add values on creation
        public CartItem() { }
        public CartItem(Product product, int quantity)
        {
            this.Product = product;
            this.Quantity = quantity;
        }

        //public properties
        public Product Product { get; set; }
        public int Quantity { get; set; }

        //add to quantity
        public void AddQuantity(int quantity)
        {
            this.Quantity += quantity;
        }

        //display item's property values
        public string Display()
        {
            string display = string.Format("{0} ({1} at {2} each)",
                Product.Description, Quantity.ToString(),
                Product.Price.ToString("c"));
            return display;
        }

        public String ProductName
        {
            get
            {
                return this.Product.Description;
            }
        }

        public double Price
        {
            get
            {
                return this.Product.Price;
            }
        }

        public float Subtotal
        {
            get
            {
                return (float)this.Product.Price * this.Quantity;
            }
        }

        public string URL
        {
            get
            {
                return this.Product.ImageUrl;
            }
        }

    }
}
