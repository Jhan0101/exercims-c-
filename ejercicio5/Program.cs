using System;

static class AssemblyLine
{
    public static void Main()
    {
        Console.WriteLine($"Indicador de exito de: {SuccessRate(7)}");
        Console.WriteLine($"Indicador de produccion por hora: {ProductionRatePerHour(8)}");
        Console.WriteLine($"Indicador de produccion por minuto: {WorkingItemsPerMinute(8)}");
    }
    public static double SuccessRate(int speed)
    {
        if (speed == 0)
        {
            return 0.0;
        }
        else if(speed >= 1 && speed <= 4)
        {
            return 1.0;
        }
        else if(speed >= 5 && speed <= 8)
        {
            return 0.9;
        }
        else if(speed == 9)
        {
            return 0.8;
        }
        else{
            return 0.77;
        }
        
    }
    
    public static double ProductionRatePerHour(int speed)
    {
        double autosPorHora;
        autosPorHora = speed*221*SuccessRate(speed);
        return autosPorHora;
    }

    public static int WorkingItemsPerMinute(int speed)
    {
       double autosPorMinuto;
       autosPorMinuto = ProductionRatePerHour(speed)/60;

       return (int)autosPorMinuto;
    }
}
