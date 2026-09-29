using System;
using System.Globalization;

class WeighingMachine
{
    public int Precision { get; }

    private double weight;
    public double Weight
    {
        get { return weight; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            weight = value;
        }
    }

    public double TareAdjustment { get; set; } = 5.0;

    public string DisplayWeight
    {
        get
        {
            double displayWeight = Weight - TareAdjustment;
            return displayWeight.ToString("F" + Precision, CultureInfo.InvariantCulture) + " kg";
        }
    }

    public WeighingMachine(int precision)
    {
        Precision = precision;
    }
}
class Program
{
    static void Main()
    {
        // Tarea 1: Precision
        var wm = new WeighingMachine(precision: 3);
        Console.WriteLine($"Precision: {wm.Precision}");

        // Tarea 2: Weight (get y set)
        wm.Weight = 60.5;
        Console.WriteLine($"Weight: {wm.Weight}");

        // Tarea 3: Weight negativo lanza ArgumentOutOfRangeException
        try
        {
            wm.Weight = -10;
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Weight negativo: se lanzó ArgumentOutOfRangeException");
        }

        // Tarea 5: valor por defecto de TareAdjustment
        Console.WriteLine($"TareAdjustment por defecto: {wm.TareAdjustment}");

        // Tarea 4: TareAdjustment se puede asignar
        wm.TareAdjustment = -10.6;
        Console.WriteLine($"TareAdjustment asignado: {wm.TareAdjustment}");

        // Tarea 6: DisplayWeight
        var wm2 = new WeighingMachine(precision: 3);
        wm2.Weight = 60.567;
        wm2.TareAdjustment = 10;
        Console.WriteLine($"DisplayWeight: {wm2.DisplayWeight}");
    }
}