using System;
using System.Net;
using System.Text;

public static class Identificador
{
    public static void Main()
    {
        Console.WriteLine("la cadena sin modificar: hola-mundo");
        Console.WriteLine($"Cadena modificada: {Clean("hola-mundo")}");
    }
    public static string Clean(string Identificador)
    {

        if (string.IsNullOrEmpty(Identificador))
        {
            return string.Empty;
        }

        var result = new StringBuilder();
        bool convertNextToUpper = false;

        for (int i =0; i< Identificador.Length; i++){

           char c = Identificador[i];

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

            if (convertNextToUpper)
            {
                c = char.ToUpper(c);
                convertNextToUpper = false;
            }

            if (c == ' ')
            {
                result.Append('_');
                continue;
            }

            if (c >= 'α' && c <= 'ω')
            {
                continue;
            }

            if (!char.IsLetter(c) && c != '_')
            {
                continue;
            }
            result.Append(c);
        }
        return result.ToString();
    }
}