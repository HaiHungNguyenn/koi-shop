namespace Services.Extension;

public static class StringExtension
{
    public static string ToCapitalize(this string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return text;
        }
        return char.ToUpper(text[0]) + text.Substring(1).ToLower();
    }
}