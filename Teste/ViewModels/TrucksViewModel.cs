using System;
using System.Diagnostics;
using Teste.Helpers;
using Teste.Models;
using Teste.Views;
using Xamarin.Forms;

namespace Teste.ViewModels
{

    public class TrucksViewModel : BaseTruckViewModel
    {
        public ObservableRangeCollection<Truck> Trucks { get; set; }
        public Command LoadTrucksCommand { get; set; }
        public Command DeleteCommand { get; set; }
        public Truck deleteTruck;

        public TrucksViewModel ()
		{
            Title = "Browse";
            Trucks = new ObservableRangeCollection<Truck>();
            LoadTrucksCommand = new Command(() => ExecuteLoadTrucksCommand());
            DeleteCommand = new Command(() => ExecutedeleteCommand());

            MessagingCenter.Subscribe<NewTruckPage, Truck>(this, "AddItem", async (obj, truck) =>
            {
                var _truck = truck as Truck;
                Trucks.Add(_truck);
                await TruckStore.AddTruckAsync(_truck);
            });

        }

        async void ExecutedeleteCommand()
        {
            await TruckStore.DeleteTruckAsync(deleteTruck);
        }

        async void  ExecuteLoadTrucksCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                Trucks.Clear();
                var trucks = await TruckStore.GetTrucksAsync(true);
                Trucks.ReplaceRange(trucks);
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
            IsBusy = false;
        }
    }
}
