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

        public CultureInfo Culture
        {
            get => CultureInfo.CurrentCulture;
            set
            {
                CultureInfo.CurrentCulture = value;
                CultureInfo.CurrentUICulture = value;
                OnPropertyChanged();
            }
        }
        string[] cultureFormats = { "en-US", "de-DE", "fr-FR", "da-DK", "" };
        private int idxCulture = 0;

        [ObservableProperty]
        private double number;

        public MainViewModel()
        {
            SelectedDate = DateTime.Today;
            SelectedTime = DateTime.Now.TimeOfDay;
            Culture = new CultureInfo(cultureFormats[0] ?? "");
            Number = 3.1425;
        }

        [RelayCommand]
        public void LoopCultureFormat()
        {
            idxCulture = ++idxCulture % cultureFormats.Length;
            Culture = new CultureInfo(cultureFormats[idxCulture]);
            Number = Number * 1.0001;
        }
    }
}
