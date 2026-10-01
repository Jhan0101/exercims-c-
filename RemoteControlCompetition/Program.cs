public interface IRemoteControlCar
{
    void Drive();
    int DistanceTravelled { get; }
}

public class ProductionRemoteControlCar : IRemoteControlCar, IComparable<ProductionRemoteControlCar>
{
    public int DistanceTravelled { get; private set; }
    public int NumberOfVictories { get; set; }

    public void Drive()
    {
        DistanceTravelled += 10;
    }

    public int CompareTo(ProductionRemoteControlCar other)
    {
        return NumberOfVictories.CompareTo(other.NumberOfVictories);
    }
}

public class ExperimentalRemoteControlCar : IRemoteControlCar
{
    public int DistanceTravelled { get; private set; }

    public void Drive()
    {
        DistanceTravelled += 20;
    }
}

public static class TestTrack
{
    public static void Race(IRemoteControlCar car)
    {
        car.Drive();
    }

    public static List<ProductionRemoteControlCar> GetRankedCars(ProductionRemoteControlCar prc1,
        ProductionRemoteControlCar prc2)
    {
        var cars = new List<ProductionRemoteControlCar>  {prc1, prc2};
        cars.Sort();
        return cars;
    }
}

class Program
{
    public static void Main()
    {
        TestTrack.Race( new ProductionRemoteControlCar());
        TestTrack.Race(new ExperimentalRemoteControlCar());
        Console.WriteLine("Tarea 1 ejecutadas sin excepcion");

        var prod = new ProductionRemoteControlCar();
        TestTrack.Race(prod);
        var exp = new ExperimentalRemoteControlCar();
        TestTrack.Race(exp);
        Console.WriteLine($"prod distancia recorrida: {prod.DistanceTravelled}");
        Console.WriteLine($"exp distancia recorrida: {exp.DistanceTravelled}");

        var prc1 = new ProductionRemoteControlCar();
        var prc2 = new ProductionRemoteControlCar();
        prc1.NumberOfVictories = 10;
        prc2.NumberOfVictories = 20;
        List<ProductionRemoteControlCar> ranking = TestTrack.GetRankedCars(prc1, prc2);
        Console.WriteLine($"rankings[1] == prc1 -> {ranking[1] == prc1}");
    }
}