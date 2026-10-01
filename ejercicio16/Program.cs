using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

public static class DialingCodes
{
    public static Dictionary<int, string> GetEmptyDictionary()
    {
        return new Dictionary<int, string>();
    }

    public static Dictionary<int, string> GetExistingDictionary()
    {
       return new Dictionary<int, string>
       {
            {1, "United State of America"},
            {55, "Brazil"},
            {91, "India"}  
       };
    }

    public static Dictionary<int, string> AddCountryToEmptyDictionary(int countryCode, string countryName)
    {
        var dictionary = new Dictionary<int, string>(); 
        dictionary.Add(countryCode, countryName);
        return dictionary;
    }

    public static Dictionary<int, string> AddCountryToExistingDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
       existingDictionary.Add(countryCode, countryName);
       return existingDictionary;
    }

    public static string GetCountryNameFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode)
    {
        if(existingDictionary.TryGetValue(countryCode, out string countryName))
        {
            return countryName;
        }
        return string.Empty;
    }

    public static bool CheckCodeExists(Dictionary<int, string> existingDictionary, int countryCode)
    {
       return existingDictionary.ContainsKey(countryCode);
    }

    public static Dictionary<int, string> UpdateDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        if (existingDictionary.ContainsKey(countryCode))
        {
            existingDictionary[countryCode] = countryName;
        }
        return existingDictionary;
    }

    public static Dictionary<int, string> RemoveCountryFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode)
    {
        existingDictionary.Remove(countryCode);
        return existingDictionary;
    }

    public static string FindLongestCountryName(Dictionary<int, string> existingDictionary)
    {
        string longestName = string.Empty;
        
        foreach(string name in existingDictionary.Values)
        {
            if(name.Length > longestName.Length)
            {
                longestName = name;
            }
        }
        return longestName;
    }
}

class Program
{
    public static void Main()
    {
       Imprimir("1. Vacío", DialingCodes.GetEmptyDictionary());

        Imprimir("2. Prepoblado", DialingCodes.GetExistingDictionary());

        
        Imprimir("3. Agregar a vacío",
            DialingCodes.AddCountryToEmptyDictionary(44, "United Kingdom"));

        
        Imprimir("4. Agregar a existente",
            DialingCodes.AddCountryToExistingDictionary(
                DialingCodes.GetExistingDictionary(), 44, "United Kingdom"));

        
        Console.WriteLine("5. Código 55: " +
            DialingCodes.GetCountryNameFromDictionary(DialingCodes.GetExistingDictionary(), 55));
        Console.WriteLine("5. Código 999: \"" +
            DialingCodes.GetCountryNameFromDictionary(DialingCodes.GetExistingDictionary(), 999) + "\"");

        
        Console.WriteLine("6. ¿Existe el 55? " +
            DialingCodes.CheckCodeExists(DialingCodes.GetExistingDictionary(), 55));

        
        Imprimir("7. Actualizar código 1",
            DialingCodes.UpdateDictionary(DialingCodes.GetExistingDictionary(), 1, "Les États-Unis"));
        Imprimir("7. Actualizar código 999 (sin cambios)",
            DialingCodes.UpdateDictionary(DialingCodes.GetExistingDictionary(), 999, "Newlands"));

       
        Imprimir("8. Eliminar código 91",
            DialingCodes.RemoveCountryFromDictionary(DialingCodes.GetExistingDictionary(), 91));


        Console.WriteLine("9. Nombre más largo: " +
            DialingCodes.FindLongestCountryName(DialingCodes.GetExistingDictionary()));
    }

    private static void Imprimir(string titulo, Dictionary<int, string> diccionario)
    {
        Console.WriteLine(titulo);

        foreach (KeyValuePair<int, string> par in diccionario)
        {
            Console.WriteLine($"   {par.Key} => \"{par.Value}\"");
        }
    }
    
}