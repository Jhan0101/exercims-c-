using System;


static class SavingsAccount
{
    public static void Main()
{
   
    Console.WriteLine("Cual es su balance?");
    decimal monto = Convert.ToDecimal(Console.ReadLine());
    Console.WriteLine($"Su tasa de interes es de: {InterestRate(monto)}");
    Console.WriteLine($"Intereses: {Interest(monto)}");
    Console.WriteLine($"Actualizacion de su balance anual: {AnnualBalanceUpdate(monto)}");
    Console.WriteLine("\nCual es el balance que quiere conseguir?");
    decimal objetivo = Convert.ToDecimal(Console.ReadLine());
    Console.WriteLine($"Cantidad de anos que le tomara alcanzarlo: {YearsBeforeDesiredBalance(monto, objetivo)}");
}
    public static float InterestRate(decimal balance)
    {
       if(balance<0){
           return 3.213f;
           
       } else if (balance>0 && balance<1000){
           return 0.5f;
           
       }else if ( balance>1000 && balance<5000){
           return 1.621f;
           
       }else {
           return 2.475f;

       }
        
    }

    public static decimal Interest(decimal balance)
    {
       return (balance * (decimal)InterestRate(balance))/100;
    }

    public static decimal AnnualBalanceUpdate(decimal balance)
    {
        return Interest(balance) + balance;
    }

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
       int years=0;
        while (balance < targetBalance)
        {
            balance = AnnualBalanceUpdate(balance);
            years++;
        }
        return years;
    }
}
