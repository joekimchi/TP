using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class Customer : ContactInformation
    {
        private int customerID;
        
        public int CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }
    }
}
