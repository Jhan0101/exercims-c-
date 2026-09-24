using System;
using System.Runtime.CompilerServices;

public static class Languages
{
    public static void Main()
    {
        
        List<string> languages = Languages.NewList();
        Console.WriteLine("\nLista nueva");
        Console.WriteLine(string.Join(", ", languages));

       
        languages = Languages.GetExistingLanguages();
        Console.WriteLine("\nLenguajes existentes en la lista");
        Console.WriteLine(string.Join(", ", languages));

        
        Languages.AddLanguage(languages, "c++");
        Console.WriteLine("\nAgregar lenguaje(\"c++\"):");
        Console.WriteLine(string.Join(", ", languages));

        
        int count = Languages.CountLanguages(languages);
        Console.WriteLine("\nContar lenguajes():");
        Console.WriteLine(count);

        
        bool hasLanguage = Languages.HasLanguage(languages, "c++");
        Console.WriteLine("\nEsta el lenguaje?(\"c++\"):");
        Console.WriteLine(hasLanguage);

        
        Languages.ReverseList(languages);
        Console.WriteLine("Poner la lista al reves");
        Console.WriteLine(string.Join(", ", languages));

       
        bool exciting = Languages.IsExciting(languages);
        Console.WriteLine("\nEs emocionante?");
        Console.WriteLine(exciting);

        
        Languages.RemoveLanguage(languages, "c++");
        Console.WriteLine("\nRemover lenguaje(\"c++\"):");
        Console.WriteLine(string.Join(", ", languages));

        
        bool unique = Languages.IsUnique(languages);
        Console.WriteLine("\nCada lenguaje es unico?");
        Console.WriteLine(unique);
    }
    public static List<string> NewList()
    {
        return new List<string>();
    }

    public static List<string> GetExistingLanguages()
    {
        return new List<string>{"c#", "Clojure", "Elm"};
    }

    public static List<string> AddLanguage(List<string> languages, string language)
    {
        languages.Add(language);
       return languages;
    }

    public static int CountLanguages(List<string> languages)
    {
        return languages.Count;
    }

    public static bool HasLanguage(List<string> languages, string language)
    {
        return languages.Contains(language);
    }

    public static List<string> ReverseList(List<string> languages)
    {
        languages.Reverse();
        return languages;
    }

    public static bool IsExciting(List<string> languages)
    {
        if (languages.Count == 0)
        {
            return false;
        }
        if (languages[0] == "c#")
        {
            return true;
        }
        if (languages.Count >= 2 && languages.Count <= 3 && languages[1] == "C#") return true;

        return false;
    }

    public static List<string> RemoveLanguage(List<string> languages, string language)
    {
        languages.Remove(language);
        return languages;
    }

    public static bool IsUnique(List<string> languages)
    {
        return new HashSet<string>(languages).Count == languages.Count;
    }
}

