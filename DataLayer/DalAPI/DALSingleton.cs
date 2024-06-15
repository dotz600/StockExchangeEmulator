using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DalAPI;

/// <summary>
/// Singleton design pattern class
/// Ensures that the Data layer is created only once
/// </summary>
public sealed class DALSingleton
{
    private static readonly IDAL instance = new DalImplementation();

    public static IDAL Instance
    {
        get { return instance; }
    }
}
