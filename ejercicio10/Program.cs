using System;
//need for speed ejercicio
class RemoteControlCar
{
    private int velocidad, consumo;
    private int distacia=0, bateria=100;

    public RemoteControlCar(int velocidad, int consumo)
    {
        this.velocidad = velocidad;
        this.consumo = consumo;

    }

    public bool BatteryDrained()
    {
        return bateria<consumo;
    }

    public int DistanceDriven()
    {
       return distacia;
    }

    public void Drive()
    {
        if (!BatteryDrained())
        {
            distacia += velocidad;
            bateria -= consumo;
        }
    }

    public static RemoteControlCar Nitro()
    {
        return new RemoteControlCar(50, 4);
    }
}

class RaceTrack
{
    private int distPista;

    public RaceTrack(int distPista)
    {
        this.distPista = distPista;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        while (!car.BatteryDrained())
        {
            car.Drive();
            if (car.DistanceDriven() >= distPista)
            {
                return true;
            }
        }
        return car.DistanceDriven()>=distPista;
    }
}
class Program
{
    static void Main()
    {
        // --- Prueba 1: carro normal ---
        int speed = 5;
        int batteryDrain = 2;
        var car = new RemoteControlCar(speed, batteryDrain);
        car.Drive();
        Console.WriteLine($"Distancia recorrida (1 vuelta): {car.DistanceDriven()} metros");
        Console.WriteLine($"¿Batería agotada?: {car.BatteryDrained()}");

        // --- Prueba 2: carro Nitro ---
        var nitro = RemoteControlCar.Nitro();
        nitro.Drive();
        Console.WriteLine($"Distancia recorrida por el Nitro: {nitro.DistanceDriven()} metros");

        // --- Prueba 3: carrera en una pista ---
        int distance = 100;
        var raceTrack = new RaceTrack(distance);
        var carParaCarrera = new RemoteControlCar(5, 2);
        bool termino = raceTrack.TryFinishTrack(carParaCarrera);
        Console.WriteLine($"¿El carro terminó la pista de {distance}m?: {termino}");

        // --- Prueba 4: pista más larga, carro se queda sin batería ---
        var pistaLarga = new RaceTrack(10000);
        var carDebil = new RemoteControlCar(5, 2);
        bool terminoLarga = pistaLarga.TryFinishTrack(carDebil);
        Console.WriteLine($"¿El carro terminó la pista larga de 10000m?: {terminoLarga}");
    }
}