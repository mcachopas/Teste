using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Teste.Helpers;
using Teste.Models;
using Teste.Services;
using Xamarin.Forms;

namespace Teste.ViewModels
{
    /// <summary>
    /// Get the azure service instance
    /// </summary>
    public class BaseTruckViewModel : ObservableObject
	{
        public ITruckStore<Truck> TruckStore => DependencyService.Get<ITruckStore<Truck>>();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }
        /// <summary>
        /// Private backing field to hold the title
        /// </summary>
        string title = string.Empty;
        /// <summary>
        /// Public property to set and get the title of the item
        /// </summary>
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
    }
}
