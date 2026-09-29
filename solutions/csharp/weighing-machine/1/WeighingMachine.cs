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