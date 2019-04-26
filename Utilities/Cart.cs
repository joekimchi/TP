using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    [Serializable]
    public class Cart
    {
        //internal list of items and constructor which instantiates it
        public List<CartItem> cartItems;
        public Cart()
        {
            cartItems = new List<CartItem>();
        }

        //readonly property that returns the number of items in internal list
        public int Count
        {
            get { return cartItems.Count; }
        }

        //indexers - locate items in internal list by index or product id
        public CartItem this[int index]
        {
            get { return cartItems[index]; }
            set { cartItems[index] = value; }
        }
        public CartItem this[string id]
        {
            get
            {
                return cartItems.FirstOrDefault(c => c.Product.ProductID.ToString() == id.ToString());
            }
        }

        public void AddItem(CartItem Item)
        {
            cartItems.Add(Item);

        }

        public void RemoveItem(CartItem Item)
        {
            cartItems.Remove(Item);
        }

        public void ClearCart()
        {
            cartItems = new List<CartItem>();
        }

        public int TotalQuantity
        {
            get
            {
                int total = 0;
                for (int i = 0; i < cartItems.Count; i++)
                {
                    total += cartItems[i].Quantity;
                }
                return total;
            }
        }
    }
}

