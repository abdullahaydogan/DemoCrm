namespace DemoCRM.Core.Extensions
{
    public static class SearchStringExtensions
    {
                /// <summary>
        /// Normalizes Turkish characters and converts string to upper-case
        /// for search and comparison purposes.
        /// </summary>
        public static string NormalizeForSearch(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return string.Empty;
            }
            return value
                .Replace("ç", "Ç")
                .Replace("i", "İ")
                .Replace("ş", "Ş")
                .Replace("ğ", "Ğ")
                .Replace("ü", "Ü")
                .Replace("ö", "Ö")
                .Replace("ı","I")
                .Trim()
                .ToUpper();
        }
    }
}
