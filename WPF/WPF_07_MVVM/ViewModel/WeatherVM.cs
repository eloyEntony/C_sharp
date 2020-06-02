using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WPF_07_MVVM.Model;
using WPF_07_MVVM.ViewModel.Command;
using WPF_07_MVVM.ViewModel.Helpers;

namespace WPF_07_MVVM.ViewModel
{
    public class WeatherVM : INotifyPropertyChanged
    {
        private string query;
        private CurrentCondition currentCondition;
        public City SelectedCity
        {
            get { return selectedCity; }
            set
            {
                selectedCity = value;
                GetCondition();
                OnNitify();
            }
        }
        public string Query
        {
            get => query;
            set
            {
                query = value;
                OnNitify();
            }
        }
        public CurrentCondition CurrentCondition 
        { 
            get => currentCondition; 
            set 
            {
                if (SelectedCity != null)
                {
                    currentCondition = value; OnNitify();
                }                
            } 
        }
        public ObservableCollection<City> Cities { get; set; } = new ObservableCollection<City>();

        public SearchComand SearchComand { get; set; }
        public WeatherVM() {
            SearchComand = new SearchComand(this);
            Query = "";
        }

        private City selectedCity;
      

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnNitify([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public async void MakeRequestCities()
        {
            List<City> temp = await AccuWeatherHelper.GetCities(Query); //get all cities in range
            Cities.Clear();
            foreach (var item in temp)
            {
                Cities.Add(item);
            }
        }

        private async void GetCondition()
        {
            if (SelectedCity != null)
                CurrentCondition = await AccuWeatherHelper.GetCurrentConditions(selectedCity.Key);
            else
                CurrentCondition = new CurrentCondition();
            
        }
    }
}
