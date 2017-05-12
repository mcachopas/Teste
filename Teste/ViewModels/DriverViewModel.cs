using System;
using System.Collections.Generic;
using System.Diagnostics;
using Teste.Helpers;
using Teste.Models;
using Teste.Views;
using Xamarin.Forms;

namespace Teste.ViewModels
{
	public class DriverViewModel : BaseDriverViewModel
	{
        public ObservableRangeCollection<Driver> Drivers { get; set; }
        public Command LoadTrucksCommand { get; set; }
        public Command DeleteCommand { get; set; }
        public Driver deleteDriver;

        public DriverViewModel ()
		{
            Drivers = new ObservableRangeCollection<Driver>();
            LoadTrucksCommand = new Command(() => ExecuteLoadTrucksCommand());
            DeleteCommand = new Command(() => ExecutedeleteCommand());

            MessagingCenter.Subscribe<NewDriverPage, Driver>(this, "AddItem", async (obj, driver) =>
            {
                var _driver = driver as Driver;
                Drivers.Add(_driver);
                await DriverStore.AddDriverAsync(_driver);
            });
        }

        async void ExecutedeleteCommand()
        {
            await DriverStore.DeleteDriverAsync(deleteDriver);
        }

        async void ExecuteLoadTrucksCommand()
        {
            try
            {
                Drivers.Clear();
                var drivers = await DriverStore.GetDriversAsync(true);
                Drivers.ReplaceRange(drivers);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "Unable to load Trucks.",
                    Cancel = "OK"
                }, "message");
            }
        }
    }
}
