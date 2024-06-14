using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DataLayer;

public class DalTest
{
    public static void Main()
    {
        DalImplementation dal = new DalImplementation();
        foreach (var cur in dal.Read())
        {
            Console.WriteLine(cur);
        }
        //dal.Update(1, 1.1, 1.2);
        foreach (var cur in dal.Read())
        {
            Console.WriteLine(cur);
        }
    }
}

