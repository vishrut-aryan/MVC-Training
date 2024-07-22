using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkedinPortal.Models
{
    public class UserProfile
    {
        public string FullName { get; set; }
        public string Headline { get; set; }
        public string CurrentPosition { get; set; }
        public string Location { get; set; }
        public string About { get; set; }
    }
}