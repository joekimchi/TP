using Utilities;

namespace Utilities
{
    public class Site
    {
        public string SiteID { get; set; }
        public string Description { get; set; }
        public string APIKey { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string SiteURL { get; set; }

        public Site()
        {

        }

        public Site(string siteid, string desc, string apikey, string email, string phonenumber, string siteURL)
        {
            SiteID = siteid;
            Description = desc;
            APIKey = apikey;
            Email = email;
            PhoneNumber = phonenumber;
            SiteURL = siteURL;
        }
    }
}