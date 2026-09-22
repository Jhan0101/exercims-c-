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
