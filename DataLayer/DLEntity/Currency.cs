using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DLEntity;

/// <summary>
/// dal currency entity
/// </summary>
public class Currency
{
    public int Id { get; set; }

    public String Country { get; set; }

    public String Name { get; set; }

    public String Abbreviation { get; set; }


    public override string ToString()
    {
        return $"{Id} {Country} {Name} {Abbreviation}";
    }
}

