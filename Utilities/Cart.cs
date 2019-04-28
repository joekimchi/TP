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
        private int User { get; set; }
        private String Title { get; set; }
        private String Description { get; set; }
        private double Price { get; set; }
        private int Quantity { get; set; }
        private String Image { get; set; }

        public Cart()
        {

        }
    }
}

