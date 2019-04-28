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
        public int User { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public String Image { get; set; }

        public Cart()
        {

        }
    }
}

