namespace BusinessLayer;

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
    private readonly IDAL _dal = new DalImplementation();

    private readonly Random _random = new();

    public event Action? CurrencyPairsUpdated;

    /// <summary>
    /// convert each DAL CurrencyPair to BL CurrencyPair
    /// so the UI will not be dependent on the DAL
    /// </summary>
    /// <returns>list of BL CurrencyPair</returns>
    public List<BLCurrencyPair> Read()
    {
        List<BLCurrencyPair> blPairs = new List<BLCurrencyPair>();

        foreach (var dalPair in _dal.Read())
        {
            blPairs.Add(new BLCurrencyPair
            {
                Id = dalPair.Id,
                Pair = dalPair.Pair,
                MaxVal = dalPair.MaxVal,
                MinVal = dalPair.MinVal
            }
            );
        }
        return blPairs;
    }


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
