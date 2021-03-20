using RestApiExample.Models;
using RestApiExample.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RestApiExample.ViewModels
{
    public class MainViewModel
    {
        public string Word { get; set; }
        public ICommand InstanceCommand { get; set; }
        InstanceApiService instanceApiService = new InstanceApiService();
        Synonim synonim = new Synonim();
        ObservableCollection<string> Synonims { get; set; } = new ObservableCollection<string>();

        public MainViewModel() 
        {
            InstanceCommand = new Command(OnInstanceCommand);
            
        }

        public async void OnInstanceCommand()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                

                synonim = await instanceApiService.GetInstanceAsync(Word);

                

                await App.Current.MainPage.DisplayAlert("Synonim", synonim.Synonyms[0], "Ok");

            }
            else { await App.Current.MainPage.DisplayAlert("Alert", "No hay conexion a internet", "Ok"); }
        }
    }
}
