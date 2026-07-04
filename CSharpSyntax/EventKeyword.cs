// 1. Custom event data
public class TemperatureChangedEventArgs : EventArgs
{
    public double OldTemperature { get; }
    public double NewTemperature { get; }

    public TemperatureChangedEventArgs(double oldTemp, double newTemp)
    {
        OldTemperature = oldTemp;
        NewTemperature = newTemp;
    }
}

// 2. Publisher
public class Thermometer
{
    private double _temperature;

    // Declare the event
    public event EventHandler<TemperatureChangedEventArgs>? TemperatureChanged;

    public void SetTemperature(double newTemperature)
    {
        if (_temperature == newTemperature)
            return;

        double oldTemperature = _temperature;
        _temperature = newTemperature;

        // Raise the event
        OnTemperatureChanged(oldTemperature, newTemperature);
    }

// unlike abstract methods, virtual methods can have an implementation (makes it overridable so to say)
    protected virtual void OnTemperatureChanged(
        double oldTemperature,
        double newTemperature)
    {
        TemperatureChanged?.Invoke(
            this, // class where the event is raised
            new TemperatureChangedEventArgs(oldTemperature, newTemperature));
    }
}

// 3. Subscriber
public class Display
{
    public void OnTemperatureChanged(
        object? sender, // the object that raised the event
        TemperatureChangedEventArgs e)
    {
        Console.WriteLine(
            $"Temperature changed: {e.OldTemperature}°C -> {e.NewTemperature}°C in {sender}");
    }
}

public class Program
{
    public static void Main()
    {
        var thermometer = new Thermometer();
        var display = new Display();

        // Subscribe
        thermometer.TemperatureChanged += display.OnTemperatureChanged;

        thermometer.SetTemperature(25);
        thermometer.SetTemperature(30);
        thermometer.SetTemperature(35);

        // Unsubscribe
        thermometer.TemperatureChanged -= display.OnTemperatureChanged;

        Console.WriteLine("Display unsubscribed.");

        // Nothing will be printed
        thermometer.SetTemperature(40);
    }
}