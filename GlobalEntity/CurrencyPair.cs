using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalEntity;

/// <summary>
/// currency pair entity
/// hold pair of currencies and the max/min values they trading
/// in global project to be accses from all layers
/// </summary>
public class CurrencyPair
{
    public int Id { get; set; }

    public String Pair { get; set; }

    public double MaxVal { get; set; }
    public double MinVal { get; set; }

    public override string ToString()
    {
        return $"{Id} {Pair} {MaxVal} {MinVal}";

    }
}
