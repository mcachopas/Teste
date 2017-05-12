using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Teste.Helpers;
using Teste.Models;
using Teste.Views;
using Xamarin.Forms;

namespace Teste.ViewModels
{
    class TruckRepairViewModel : BaseTruckRepairViewModel
    {
        public ObservableRangeCollection<TruckRepair> TruckRepair { get; set; }
        public Command LoadTruckRepairCommand { get; set; }
        public Command DeleteCommand { get; set; }
        public TruckRepair truckrepair;
        public Truck truck;

        public TruckRepairViewModel()
        {
            TruckRepair = new ObservableRangeCollection<Models.TruckRepair>();
            LoadTruckRepairCommand = new Command(() => ExecuteLoadTruckRepairCommand());
            DeleteCommand = new Command(() => ExecutedeleteCommand());

            MessagingCenter.Subscribe<NewTruckRepairPage, TruckRepair>(this, "AddItem", async (obj, truckrepair) =>
            {
                var _truckrepair = truckrepair as TruckRepair;
                _truckrepair.TruckID = truck.ID;
                TruckRepair.Add(_truckrepair);
                await TruckRepairStore.AddTruckRepairAsync(_truckrepair);
            });
        }

        async void ExecutedeleteCommand()
        {
            await TruckRepairStore.DeleteTruckRepairAsync(truckrepair);
        }

        async void ExecuteLoadTruckRepairCommand()
        {
            try
            {
                TruckRepair.Clear();
                var truckrepairs = await TruckRepairStore.GetbyTruckRepairAsync(truck);
                TruckRepair.ReplaceRange(truckrepairs);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "Unable to load Trucks Repairs.",
                    Cancel = "OK"
                }, "message");
            }
            
        }
    }
}
