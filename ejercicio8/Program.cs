using System;
using System.Runtime.CompilerServices;

public static class Languages
{
    public static void Main()
    {
        // 1. NewList()
        List<string> languages = Languages.NewList();
        Console.WriteLine("NewList():");
        Console.WriteLine(string.Join(", ", languages));

        // 2. GetExistingLanguages()
        languages = Languages.GetExistingLanguages();
        Console.WriteLine("\nGetExistingLanguages():");
        Console.WriteLine(string.Join(", ", languages));

        // 3. AddLanguage()
        Languages.AddLanguage(languages, "c++");
        Console.WriteLine("\nAgregar lenguaje(\"c++\"):");
        Console.WriteLine(string.Join(", ", languages));

        // 4. CountLanguages()
        int count = Languages.CountLanguages(languages);
        Console.WriteLine("\nContar lenguajes():");
        Console.WriteLine(count);

        // 5. HasLanguage()
        bool hasLanguage = Languages.HasLanguage(languages, "c++");
        Console.WriteLine("\nEsta el lenguaje?(\"c++\"):");
        Console.WriteLine(hasLanguage);

        // 6. ReverseList()
        Languages.ReverseList(languages);
        Console.WriteLine("\nReverseList():");
        Console.WriteLine(string.Join(", ", languages));

        // 7. IsExciting()
        bool exciting = Languages.IsExciting(languages);
        Console.WriteLine("\nIsExciting():");
        Console.WriteLine(exciting);

        // 8. RemoveLanguage()
        Languages.RemoveLanguage(languages, "c++");
        Console.WriteLine("\nRemover lenguaje(\"c++\"):");
        Console.WriteLine(string.Join(", ", languages));

        // 9. IsUnique()
        bool unique = Languages.IsUnique(languages);
        Console.WriteLine("\nIsUnique():");
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

