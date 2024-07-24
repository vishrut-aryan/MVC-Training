using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Authorise_Authenticate.Models
{
    public static class ControlClass
    {
        public static IHtmlString Welcome(this HtmlHelper h, string username)
        {
            return new HtmlString("Welcome to Holtec, " + username + "!");
        }
    }

    public static class HoltecClass
    {
        public static IHtmlString Welcome(string username)
        {
            return new HtmlString("Welcome to Holtec, " + username + "!");
        }
    }
}