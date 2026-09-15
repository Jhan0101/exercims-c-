using System;
class RemoteControlCar
{
    public static void Main()
    {
        var carro = RemoteControlCar.Buy();

        Console.WriteLine($"Distancia conducida: {carro.DistanceDisplay()}");
        Console.WriteLine($"Porcentaje de la bateria: {carro.BatteryDisplay()}");

        carro.Drive();
        carro.Drive();

        Console.WriteLine($"Distancia conducida: {carro.DistanceDisplay()}");
        Console.WriteLine($"Porcentaje de la bateria: {carro.BatteryDisplay()}");

    }
    private int _distanciaConducida = 0;
    private int _porcentajeDeBateria = 100;

    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }

    public string DistanceDisplay()
    {
        return $"Condujo {_distanciaConducida} metros";
    }

    public string BatteryDisplay()
    {
       if(_porcentajeDeBateria == 0)
        {
            return "Bateria descargada";
        }
        return $"Bateria al {_porcentajeDeBateria}%";
    }

    public void Drive()
    {
       if (_porcentajeDeBateria > 0)
        {
            _distanciaConducida += 20;
            _porcentajeDeBateria -=1;
        }
    }
}

