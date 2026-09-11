using System;

// 1. Punto de entrada donde se ejecuta el programa
var lasagna = new Lasagna();

Console.WriteLine($"Minutos esperados en el horno: {lasagna.ExpectedMinutesInOven()}");
Console.WriteLine($"Minutos restantes (si lleva 30): {lasagna.RemainingMinutesInOven(30)}");
Console.WriteLine($"Tiempo de preparación (2 capas): {lasagna.PreparationTimeInMinutes(2)}");
Console.WriteLine($"Tiempo total transcurrido (3 capas, 20 min): {lasagna.ElapsedTimeInMinutes(3, 20)}");

class Lasagna
{
    // 1. Devuelve 40
    public int ExpectedMinutesInOven()
    {
        return 40;
    }

    // 2. Devuelve los minutos restantes en el horno
    public int RemainingMinutesInOven(int actualMinutes)
    {
        return ExpectedMinutesInOven() - actualMinutes;
    }

    // 3. Devuelve los minutos de preparación según las capas
    public int PreparationTimeInMinutes(int layers)
    {
        return layers*2;
    }

    // 4. Devuelve el tiempo total transcurrido
    public int ElapsedTimeInMinutes(int layers, int actualMinutes)
    {
        return PreparationTimeInMinutes(layers) + actualMinutes;
    }
}