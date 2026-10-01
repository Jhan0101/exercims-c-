using System;
using System.Diagnostics.Tracing;
static class GameMaster
{
    public static string Describe(Character character)
    {
        return $"You're level {character.Level} {character.Class} with {character.HitPoints} hit points.";
    }

    public static string Describe(Destination destination)
    {
        return $"You've arrive at {destination.Name}, which has {destination.Inhabitants} inhabitants.";
    }

    public static string Describe(TravelMethod travelMethod)
    {
        switch (travelMethod)
        {
            case TravelMethod.Walking: 
                return "You're traveling to your destination by walking.";
            case TravelMethod.Horseback:
                return "You're traveling to your destination on horseback";   
             default: return "";     
        }   
    }

    public static string Describe(Character character, Destination destination, TravelMethod travelMethod)
    {
        return $"{Describe(character)} {Describe(travelMethod)} {Describe(travelMethod)}";
    }

    public static string Describe(Character character, Destination destination)
    {
        return $"{Describe(character)} {Describe(destination)} {TravelMethod.Walking}";
    }
}

class Character
{
    public string Class { get; set; }
    public int Level { get; set; }
    public int HitPoints { get; set; }

    
}

class Destination
{
    public string Name { get; set; }
    public int Inhabitants { get; set; }
}

enum TravelMethod
{
    Walking,
    Horseback
}

class Program
{
public static void Main()
    {
        Character character = new Character();
        character.Class = "Caballero";
        character.Level = 60;
        character.HitPoints = 200;

        Destination destination = new Destination();
        destination.Name = "San Juan";
        destination.Inhabitants = 666;

        Console.WriteLine(GameMaster.Describe(character));

        Console.WriteLine(GameMaster.Describe(destination));

        Console.WriteLine(GameMaster.Describe(TravelMethod.Walking));

        Console.WriteLine(GameMaster.Describe(character, destination, TravelMethod.Horseback));

        Console.WriteLine(GameMaster.Describe(character, destination));
    }
}