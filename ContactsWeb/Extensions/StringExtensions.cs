namespace ContactsWeb.Models
{
    public static class StringExtensions
    {
        public static string RemoveMask(this string value)
        {
            return value.Replace(" ", string.Empty).Replace(".", string.Empty).Replace("-", string.Empty).Replace("/", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty);
        }
    }
}
