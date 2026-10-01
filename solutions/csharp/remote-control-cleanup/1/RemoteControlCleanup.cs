public class RemoteControlCar
{
    public string CurrentSponsor { get; private set; }

    private Speed currentSpeed;

    public RemoteControlCar()
    {
        Telemetry = new RemoteControlCarTelemetry(this);
    }
    public RemoteControlCarTelemetry Telemetry { get; }
       public void Calibrate_Telemetry()
    {

    }

    public bool SelfTest_Telemetry()
    {
        return true;
    }

    public void ShowSponsor_Telemetry(string sponsorName)
    {
        SetSponsor(sponsorName);
    }

    public void SetSpeed_Telemetry(decimal amount, string unitsString)
    {
        SpeedUnits speedUnits = SpeedUnits.MetersPerSecond;
        if (unitsString == "cps")
        {
            speedUnits = SpeedUnits.CentimetersPerSecond;
        }

        SetSpeed(new Speed(amount, speedUnits));
    }

    public string GetSpeed()
    {
        return currentSpeed.ToString();
    }

    private void SetSponsor(string sponsorName)
    {
        CurrentSponsor = sponsorName;

    }

    private void SetSpeed(Speed speed)
    {
        currentSpeed = speed;
    }
    public class RemoteControlCarTelemetry
{
    private readonly RemoteControlCar car;
    internal RemoteControlCarTelemetry(RemoteControlCar car)
    {
        this.car = car;
    }

    public void Calibrate()
    {
        
    }

    public bool SelfTest()
    {
        return true;
    }

    public void ShowSponsor(string sponsorName)
    {
        car.SetSponsor(sponsorName);
    }

    public void SetSpeed(decimal amount, string unitString)
    {
        SpeedUnits speedUnits = SpeedUnits.MetersPerSecond;
        if(unitString == "csp")
        {
            speedUnits = SpeedUnits.CentimetersPerSecond;
        }

        car.SetSpeed(new Speed(amount, speedUnits));
    }
}
}

public enum SpeedUnits
{
    MetersPerSecond,
    CentimetersPerSecond
}

public struct Speed
{
    public decimal Amount { get; }
    public SpeedUnits SpeedUnits { get; }

    public Speed(decimal amount, SpeedUnits speedUnits)
    {
        Amount = amount;
        SpeedUnits = speedUnits;
    }

    public override string ToString()
    {
        string unitsString = "meters per second";
        if (SpeedUnits == SpeedUnits.CentimetersPerSecond)
        {
            unitsString = "centimeters per second";
        }

        return Amount + " " + unitsString;
    }
}
