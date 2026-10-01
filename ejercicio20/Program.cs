
using System.Runtime.CompilerServices;

public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }
    public override bool Equals(object obj)
    {
        return obj is FacialFeatures other 
        && EyeColor == other.EyeColor 
        && PhiltrumWidth == other.PhiltrumWidth;

    }

    public override int GetHashCode()
    {
        return HashCode.Combine(EyeColor, PhiltrumWidth);
    }
}

public class Identity
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }
    public override bool Equals(object obj)
    {
        return obj is Identity other
        && Email == other.Email
        && FacialFeatures.Equals(other.FacialFeatures);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Email, FacialFeatures);
    }
}

public class Authenticator
{
    private readonly Identity admin = new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m));
    private readonly HashSet<Identity> registered = new HashSet<Identity>();
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB)
    {
        return faceA.Equals(faceB);
    }

    public bool IsAdmin(Identity identity)
    {
        return admin.Equals(identity);
    }

    public bool Register(Identity identity)
    {
       return registered.Add(identity);
    }

    public bool IsRegistered(Identity identity)
    {
        return registered.Contains(identity);
    }

    public static bool AreSameObject(Identity identityA, Identity identityB)
    {
       return object.ReferenceEquals(identityA, identityB);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Tarea 1: AreSameFace
        Console.WriteLine("--- Tarea 1: AreSameFace ---");
        Console.WriteLine(Authenticator.AreSameFace(
            new FacialFeatures("green", 0.9m),
            new FacialFeatures("green", 0.9m)));   // => true
        Console.WriteLine(Authenticator.AreSameFace(
            new FacialFeatures("blue", 0.9m),
            new FacialFeatures("green", 0.9m)));   // => false

        // Tarea 2: IsAdmin
        Console.WriteLine("--- Tarea 2: IsAdmin ---");
        var authenticator = new Authenticator();
        Console.WriteLine(authenticator.IsAdmin(
            new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m))));          // => true
        Console.WriteLine(authenticator.IsAdmin(
            new Identity("admin@thecompetition.com", new FacialFeatures("green", 0.9m)))); // => false

        // Tarea 4: IsRegistered sin identidades registradas
        Console.WriteLine("--- Tarea 4: IsRegistered (vacío) ---");
        var emptyAuthenticator = new Authenticator();
        Console.WriteLine(emptyAuthenticator.IsRegistered(
            new Identity("alice@thecompetition.com", new FacialFeatures("blue", 0.8m)))); // => false

        // Tarea 3: Register e IsRegistered
        Console.WriteLine("--- Tarea 3: Register ---");
        var registerAuthenticator = new Authenticator();
        Console.WriteLine(registerAuthenticator.Register(
            new Identity("tunde@thecompetition.com", new FacialFeatures("blue", 0.9m))));     // => true
        Console.WriteLine(registerAuthenticator.IsRegistered(
            new Identity("tunde@thecompetition.com", new FacialFeatures("blue", 0.9m))));     // => true
        Console.WriteLine(registerAuthenticator.Register(
            new Identity("tunde@thecompetition.com", new FacialFeatures("blue", 0.9m))));     // => false

        // Tarea 5: AreSameObject
        Console.WriteLine("--- Tarea 5: AreSameObject ---");
        var identityA = new Identity("alice@thecompetition.com", new FacialFeatures("blue", 0.9m));
        var identityB = identityA;
        Console.WriteLine(Authenticator.AreSameObject(identityA, identityB));  // => true

        var identityC = new Identity("alice@thecompetition.com", new FacialFeatures("blue", 0.9m));
        var identityD = new Identity("alice@thecompetition.com", new FacialFeatures("blue", 0.9m));
        Console.WriteLine(Authenticator.AreSameObject(identityC, identityD));  // => false
    }
}