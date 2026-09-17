using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        if (string.IsNullOrEmpty(identifier))
        {
            return string.Empty;
        }

        var result = new StringBuilder();
        bool convertNextToUpper = false;

        foreach (char c in identifier)
        {
          
            if (char.IsControl(c))
            {
                result.Append("CTRL");
                continue;
            }

            if (c == '-')
            {
                convertNextToUpper = true;
                continue;
            }

            char processedChar = c;
            if (convertNextToUpper)
            {
                processedChar = char.ToUpper(c);
                convertNextToUpper = false;
            }

            
            if (processedChar == ' ')
            {
                result.Append('_');
                continue;
            }

        
            if (processedChar >= 'α' && processedChar <= 'ω')
            {
                continue;
            }

       
            if (!char.IsLetter(processedChar) && processedChar != '_')
            {
                continue;
            }

            result.Append(processedChar);
        }

        return result.ToString();
    }
}