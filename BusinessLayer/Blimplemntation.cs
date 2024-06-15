namespace BusinessLayer;
using GlobalEntity;
using DataLayer;
using DataLayer.DalAPI;

/// <summary>
/// implementation of the business layer
/// implemnts Read and Update methods
/// using the DAL layer.
/// using event to update the UI when the data is updated
/// </summary>
public class Blimplemntation
{
    private readonly IDAL _dal = DALSingleton.Instance;

    private readonly Random _random = new();

    public event Action? CurrencyPairsUpdated;

    /// <summary>
    /// get the list of currency pairs from the DAL
    /// </summary>
    /// <returns>list of CurrencyPair</returns>
    public List<CurrencyPair> Read() => _dal.Read();

    


    /// <summary>
    /// stimulate the trade by updating the values of the currency pairs
    /// each iteration the value Max/Min will be updated randomly
    /// an event will be raised to update the UI
    /// the thread will sleep for 1.5-2.5 seconds randomly
    /// </summary>
    public void Update()
    {
        try
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    TradeEmulate();
                    CurrencyPairsUpdated?.Invoke();//rais event to update UI
                    await Task.Delay(_random.Next(1500, 2500));
                }
            });
        }
        catch (Exception e)
        { throw new Exception(e.Message + "BLimplemntation - thread problem"); }

    }


    /// <summary>
    /// update the valuse and store them in the DAL
    /// </summary>
    private void TradeEmulate()
    {
        var currencyPairs = _dal.Read();

        foreach (var currencyPair in currencyPairs)
        {
            var minVal = currencyPair.MinVal + _random.NextDouble() * 0.1 - 0.05;
            var maxVal = currencyPair.MaxVal + _random.NextDouble() * 0.1 - 0.05;
            if (minVal > maxVal)
            {
                var temp = minVal;
                minVal = maxVal;
                maxVal = temp;
            }
            try
            {
                _dal.Update(currencyPair.Id, minVal, maxVal);
            }
            catch (Exception e) 
                { throw new Exception(e.Message + "BLimplemntation"); }
        }
    }

}
