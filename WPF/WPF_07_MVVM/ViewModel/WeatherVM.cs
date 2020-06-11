using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using WPF_07_MVVM.Model;
using WPF_07_MVVM.ViewModel.Command;
using WPF_07_MVVM.ViewModel.Helpers;

namespace WPF_07_MVVM.ViewModel
{
    public class WeatherVM : INotifyPropertyChanged
    {
        private string query;
        private CurrentCondition currentConditions;
        public ObservableCollection<City> Cities { get; set; } = new ObservableCollection<City>();
        private City selectedCity;
        public SearchComand SearchCommand { get; set; }
        public WeatherVM()
        {
            SearchCommand = new SearchComand(this);
            Query = "";
        }

        public City SelectedCity
        {
            get { return selectedCity; }
            set
            {
                selectedCity = value;
                GetConditions();
                OnNotify();
            }
        }
        public CurrentCondition CurrentConditions
        {
            get => currentConditions;
            set
            {
                currentConditions = value;
                OnNotify();
            }
        }
        public string Query
        {
            get => query;
            set
            {
                query = value;
                OnNotify();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnNotify([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public async void MakeRequestCities()
        {
            List<City> temp = await AccuWeatherHelper.GetCities(Query);  // отримуємо всі міста
            Cities.Clear();
            foreach (var item in temp)
            {
                Cities.Add(item);
            }
        }
        private async void GetConditions()
        {
            if (SelectedCity != null)
            {
                CurrentConditions = await AccuWeatherHelper.GetCurrentConditions(SelectedCity.Key);
            }
            else
                CurrentConditions = new CurrentCondition();
        }

    }
}
