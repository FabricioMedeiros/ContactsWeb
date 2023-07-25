using System;
using Microsoft.AspNetCore.Mvc.Razor;

namespace ContactsWeb.Extensions
{
    public static class RazorExtensions
    {
        public static string FormatPhone(this RazorPage page, string phone)
        {
             return phone.Length > 10 ? string.Format("{0:(##) #####-####}", Int64.Parse(phone)) : string.Format("{0:(##) ####-####}", Int64.Parse(phone));
        }
    }
}