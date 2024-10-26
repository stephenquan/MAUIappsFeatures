using System.Diagnostics;

namespace AppDatePicker
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();

            DisplayFormats(); 

            BindingContext = viewModel;

        }

        public void DisplayFormats()
        {
            Debug.WriteLine($"*** DatePicker Format: {datePicker.Format}");

            Debug.WriteLine($"*** TimePicker Format: {timePicker.Format}");
            // *** DatePicker Format: d
            // *** TimePicker Format: t

        }
    }
}
