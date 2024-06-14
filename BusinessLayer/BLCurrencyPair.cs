
/// <summary>
/// Business layer currency pair
/// nedded to separate the DAL from the UI
/// </summary>
public class BLCurrencyPair
{
    public int Id { get; set; }

    public String Pair { get; set; }

    public double MaxVal { get; set; }
    public double MinVal { get; set; }

    public override string ToString()
    {
        return "BL" + $" {Id} {Pair} {MaxVal} {MinVal}";

    }
}



