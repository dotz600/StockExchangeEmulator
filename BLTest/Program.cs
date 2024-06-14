using BusinessLayer;

namespace BLTest;

public class Program
{
    public static TradeEmulator _tradeEmulator = new();
    
    public static void Main()
    {
        foreach ( var p in _tradeEmulator.Read())
            Console.WriteLine(p);
        _tradeEmulator.Update();
        while (true)
        {
            foreach ( var p in _tradeEmulator.Read())
                Console.WriteLine(p);
            Thread.Sleep(2500);
        }

    }
   
}
