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
        [ObservableProperty]
        public CultureInfo culture; 
        string[] cultureFormats = { "en-US", "de-DE", "fr-FR", "da-DK", "" };
        private int idxCulture = 0;

        [ObservableProperty]
        public string? dateFormat;
        private string[] dateFormats = { "d", "MM/dd/yyyy", "dd/MM/yyyy", "ddd dd/MM/yyyy" };
        private int idxDateFormat = 0;

        [ObservableProperty]
        public string? timeFormat; 
        private string[] timeFormats = { "hh:mm tt", "HH:mm" };
        private int idxTimeFormat = 0;

        [ObservableProperty]
        private double number;
        [ObservableProperty]
        private string? txtNumber = string.Empty; 

        public MainViewModel()
        {
            SelectedDate = DateTime.Today;
            SelectedTime = DateTime.Now.TimeOfDay;

            // culture = CultureInfo.CurrentCulture; // detects from OS. 
            // culture = CultureInfo.InvariantCulture; 
            Culture = new CultureInfo(cultureFormats[0] ?? "");
            CultureInfo.CurrentCulture = Culture;
            CultureInfo.CurrentUICulture = Culture;
            CountryName = Culture.Name;
            DateFormat = dateFormats[0] ?? "d";
            TimeFormat = timeFormats[0] ?? "hh:mm tt";
            Number = 3.1425;
            // TxtNumber = String.Format("{0:N3}", Number); // 
        }

        partial void OnNumberChanged(double value)
        {
            TxtNumber = String.Format("{0:N3}", value);
        }

        [RelayCommand]
        public void LoopCultureFormat()
        {
            idxCulture = ++idxCulture % cultureFormats.Length;
            Culture = new CultureInfo(cultureFormats[idxCulture]);
            CultureInfo.CurrentCulture = Culture;
            CultureInfo.CurrentUICulture = Culture;
            CountryName = Culture.Name;
            Number = Number * 1.0001;

            DateFormat = Culture.DateTimeFormat.LongDatePattern;
            TimeFormat = Culture.DateTimeFormat.LongTimePattern;
        }

        [RelayCommand]
        public void LoopDateFormat()
        {
            idxDateFormat = ++idxDateFormat % dateFormats.Length;
            var dateBefore = SelectedDate.Date;
            DateFormat = dateFormats[idxDateFormat];
            var dateAfter = SelectedDate.Date;
            Debug.WriteLine($"*** Date before change of date format {dateBefore} and after: {dateAfter}"); 
        }

        [RelayCommand]
        public void LoopTimeFormat()
        {
            idxTimeFormat = ++idxTimeFormat % timeFormats.Length;
            var timeBefore = SelectedTime.Minutes;
            TimeFormat = timeFormats[idxTimeFormat];
            var timeAfter = SelectedTime.Seconds;
            Debug.WriteLine($"*** Date before change of time format {timeBefore} and after: {timeAfter}");
        }
    }
}
