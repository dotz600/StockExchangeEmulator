using System.Windows;


namespace UI;
/// <summary>
/// Main window present the currency pairs
/// and the changes in their values
/// changes are updated every 1.5-2.5 seconds randomly
/// </summary>


public partial class MainWindow : Window
{
    private readonly BusinessLayer.Blimplemntation _bl = new();
    public MainWindow()
    {
        try
        {
            InitializeComponent();
            view.ItemsSource = _bl.Read();
            _bl.CurrencyPairsUpdated += UpdateScreen;//adding event handler for updating the UI
            _bl.Update();
        }
        catch (Exception e)
            { MessageBox.Show(e.Message); }
    }

    /// <summary>
    /// Update the UI with the new data
    /// start after the event is raised in BL
    /// after the data is updated in the data base
    /// </summary>
    private void UpdateScreen()
    {
        Dispatcher.Invoke(() =>
        {
            view.ItemsSource = null;  // Clear the previous data to ensure proper refresh
            view.ItemsSource = _bl.Read();
        });
    }
}

    
