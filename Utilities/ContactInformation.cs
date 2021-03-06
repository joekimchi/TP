﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    [Serializable()]
    public class ContactInformation
    {
        private int id;
        private String name;
        private String address;
        private String city;
        private String state;
        private int zipCode;
        private String email;
        private String phoneNumber;
        private String password;
        private String securityAnswer1;
        private String securityAnswer2;

        public ContactInformation()
        {

        }
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public String Address
        {
            get { return address; }
            set { address = value; }
        }

        public String City
        {
            get { return city; }
            set { city = value; }
        }

        public String State
        {
            get { return state; }
            set { state = value; }
        }

        public int ZipCode
        {
            get { return zipCode; }
            set { zipCode = value; }
        }

        public String Email
        {
            get { return email; }
            set { email = value; }
        }

        public String Phone
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public String Password
        {
            get { return password; }
            set { password = value; }
        }

        public String SecurityAnswer1
        {
            get { return securityAnswer1; }
            set { securityAnswer1 = value; }
        }

        public String SecurityAnswer2
        {
            get { return securityAnswer2; }
            set { securityAnswer2 = value; }
        }
    }
}
