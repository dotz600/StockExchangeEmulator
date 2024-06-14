using DataLayer.DalAPI;
using DataLayer.DLEntity;

namespace DataLayer;

/// <summary>
/// implementation of the DAL layer
/// implemnts Read and Update methods
/// </summary>
public class DalImplementation : IDAL
{
    private static readonly DbTablesContext _db = new DbTablesContext();


    /// <summary>
    /// constructor that creates the data base if it does not exist
    /// </summary>
    public DalImplementation() =>_db.Database.EnsureCreated();
    


    /// <summary>
    /// return the list of currency pairs
    /// </summary>
    /// <returns></returns>
    public List<CurrencyPair> Read() => _db.CurrencyPairDB.ToList();


    /// <summary>
    /// update the currency pair values
    /// </summary>
    /// <param name="id"></param>
    /// <param name="minVal"></param>
    /// <param name="maxVal"></param>
    /// <exception cref="Exception"></exception>
    public void Update(int id, double minVal, double maxVal)
    {
        var currencyPair = _db.CurrencyPairDB.Find(id) ??
            throw new Exception("Currency pair not found");

        currencyPair.MinVal = minVal;
        currencyPair.MaxVal = maxVal;
        _db.SaveChanges();
    }



}
