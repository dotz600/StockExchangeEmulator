using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DLEntity;
namespace DataLayer.DalAPI;

/// <summary>
/// interface for the DAL layer
/// defines the Read and Update methods
/// </summary>
public interface IDAL
{
    List<CurrencyPair> Read();
    void Update(int id, double minVal, double maxVal);
}
