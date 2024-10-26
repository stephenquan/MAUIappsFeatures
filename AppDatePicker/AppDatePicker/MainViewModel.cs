using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using System.Globalization;

namespace AppDatePicker
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private DateTime selectedDate;
        [ObservableProperty]
        private TimeSpan selectedTime; 

        [ObservableProperty]
        public string? countryName;
        public CultureInfo culture;
        string[] cultureFormats = { "en-US", "de-DE", "fr-FR", "da-DK", "" };
        private int idxCulture = 0;

        [ObservableProperty]
        public string? dateFormat;
        private string[] dateFormats = { "d", "MM/dd/yyyy", "dd/MM/yyyy" };
        private int idxDateFormat = 0;

        [ObservableProperty]
        public string? timeFormat; 
        private string[] timeFormats = { "hh:mm tt", "HH:mm" };
        private int idxTimeFormat = 0;

        public MainViewModel()
        {
            SelectedDate = DateTime.Today;
            SelectedTime = DateTime.Now.TimeOfDay;

            // culture = CultureInfo.CurrentCulture; // detects from OS. 
            // culture = CultureInfo.InvariantCulture; 
            culture = new CultureInfo(cultureFormats[0] ?? "");
            CountryName = culture.Name;
            DateFormat = dateFormats[0] ?? "d";
            TimeFormat = timeFormats[0] ?? "hh:mm tt"; 
        }

        [RelayCommand]
        public void ToogleCultureFormat()
        {
            idxCulture = ++idxCulture % cultureFormats.Length;
            culture = new CultureInfo(cultureFormats[idxCulture]);
            CountryName = culture.Name; 
        }

        [RelayCommand]
        public void ToogleDateFormat()
        {
            idxDateFormat = ++idxDateFormat % dateFormats.Length;
            var dateBefore = SelectedDate.Date;
            DateFormat = dateFormats[idxDateFormat];
            var dateAfter = SelectedDate.Date;
            Debug.WriteLine($"*** Date before change of date format {dateBefore} and after: {dateAfter}"); 
        }

        [RelayCommand]
        public void ToogleTimeFormat()
        {
            idxTimeFormat = ++idxTimeFormat % timeFormats.Length;
            var timeBefore = SelectedTime.Minutes;
            TimeFormat = timeFormats[idxTimeFormat];
            var timeAfter = SelectedTime.Seconds;
            Debug.WriteLine($"*** Date before change of time format {timeBefore} and after: {timeAfter}");
        }
    }
}
