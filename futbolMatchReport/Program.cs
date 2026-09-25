using System.Collections;
using System;
public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum)
    {
        switch (shirtNum)
        {
            case 1: return "goalie";
            case 2: return "left back";
            case 3: 
            case 4: return "center back";
            case 5: return "right back";
            case 6: 
            case 7: 
            case 8: return "midfielder";
            case 9: return "left wing";
            case 10: return "striker";
            case 11: return "right wing";
            default: return "UNKNOW"; 
        }
    }

    public static string AnalyzeOffField(object report)
    {
        switch (report)
        {
            case int supporters:
                return $"There are {supporters} supporters at the match";
            case string anuncio:
                return anuncio;
            case Foul foul:
                return foul.GetDescription();
             case Injury injury:
                return $"oh no, {injury.GetDescription()}. Medics are on the field";
            case Incident incident:
                return incident.GetDescription();
            case Manager manager:
                return manager.Describe();
            default: return "";        
        }
    }
}
public class Manager
{
    public string Name { get; }

    public string? Club { get; }

    public Manager(string name, string? club)
    {
        this.Name = name;
        this.Club = club;
    }
    
    public string Describe()
    {
        return Club is null? Name : $"{Name}, {Club}";
    }
}

public class Incident
{
    public virtual string GetDescription() => "An incident happened.";
}

public class Foul : Incident
{
    public override string GetDescription() => "The referee deemed a foul.";
}

class Injury : Incident
{
    private readonly int player;

    public Injury(int player)
    {
        this.player = player;
    }

    public override string GetDescription() => $"Player {player} is injured.";
}
public class Program
{
    public static void Main()
    {
        Console.WriteLine(PlayAnalyzer.AnalyzeOnField(5));
        Console.WriteLine(PlayAnalyzer.AnalyzeOnField(10));
        Console.WriteLine(PlayAnalyzer.AnalyzeOnField(99));

        Console.WriteLine(PlayAnalyzer.AnalyzeOffField(60000));
        Console.WriteLine(PlayAnalyzer.AnalyzeOffField("El autor del gol ha sido RAPHINHA!!"));
        Console.WriteLine(PlayAnalyzer.AnalyzeOffField(0.12));

        Console.WriteLine(PlayAnalyzer.AnalyzeOffField(new Foul()));
        Console.WriteLine(PlayAnalyzer.AnalyzeOffField(new Incident()));
        Console.WriteLine(PlayAnalyzer.AnalyzeOffField(new Injury(1)));

        Console.WriteLine(PlayAnalyzer.AnalyzeOffField(new Manager("Hansi Flick", "Barcelona")));
        Console.WriteLine(PlayAnalyzer.AnalyzeOffField(new Manager("Mourinho", null)));
    }
}