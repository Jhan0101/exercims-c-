using System.Security.Cryptography;
using System;

public static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        string dept = department?.ToUpper() ?? "OWNER";

        if (id == null)
        {
            return $"{name} - {dept}";
        }

        return $"[{id}] - {name} - {dept}";
    }
}
public class Program
{
    public static void Main()
    {
        Console.WriteLine(Badge.Print(712, "Jhan Pimentel", "Departameto de tecnologia"));
        Console.WriteLine(Badge.Print(id: null, "Jane Johnson", "Procurement"));
        Console.WriteLine(Badge.Print(254, "Charlotte Hale", department: null));
        Console.WriteLine(Badge.Print(id: null, "Charlotte Hale", department: null));
    }
        
    
}