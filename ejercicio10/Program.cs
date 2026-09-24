using System; 

abstract class Character
{
    private readonly string characterType;
    protected Character(string characterType)
    {
        this.characterType = characterType;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable()
    {
       return false;
    }

    public override string ToString()
    {
       return $"character is a {characterType}";
    }
}

class Warrior : Character
{
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target)
    {
        return target.Vulnerable() ? 10:6;
    }
}

class Wizard : Character
{
    private bool spellPrepared;
    public Wizard() : base("Wizard")
    {
    }

    public override int DamagePoints(Character target)
    {
        return spellPrepared ? 12:3;
    }

    public void PrepareSpell()
    {
        spellPrepared = true;
    }

    public override bool Vulnerable()
    {
        return !spellPrepared;
    }
}
class Program
{
    static void Main()
    {
        var warrior = new Warrior();
        var wizard = new Wizard();

        Console.WriteLine(warrior);                          // Character is a Warrior
        Console.WriteLine(wizard);                           // Character is a Wizard
        Console.WriteLine(warrior.Vulnerable());             // False
        Console.WriteLine(wizard.Vulnerable());              // True (sin hechizo)
        Console.WriteLine(warrior.DamagePoints(wizard));     // 10
        Console.WriteLine(wizard.DamagePoints(warrior));     // 3

        wizard.PrepareSpell();

        Console.WriteLine(wizard.Vulnerable());              // False
        Console.WriteLine(warrior.DamagePoints(wizard));     // 6
        Console.WriteLine(wizard.DamagePoints(warrior));     // 12
    }
}