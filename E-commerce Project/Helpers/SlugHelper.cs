using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace E_commerce_Project.Helpers;

public class SlugHelper
{
    public static string GenerateSlug(string phrase)
    {
        string str = phrase.ToLowerInvariant();

        str = RemoveDiacritics(str);
        str = Regex.Replace(str, @"[^a-z0-9\s-]", ""); 
        str = Regex.Replace(str, @"\s+", " ").Trim();  
        str = Regex.Replace(str, @"\s", "-");          

        return str;
    }

    private static string RemoveDiacritics(string text)
    {
        var normalized = text.Normalize(NormalizationForm.FormD);
        var chars = normalized.Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark);
        return new string(chars.ToArray()).Normalize(NormalizationForm.FormC);
    }

}