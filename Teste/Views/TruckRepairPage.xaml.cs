using System;
using Teste.Models;
using Teste.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Teste.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TruckRepairPage : ContentPage
	{
        TruckRepairViewModel viewModel;
        Truck truck;
        public TruckRepairPage ()
		{
			InitializeComponent ();
            BindingContext = viewModel = new TruckRepairViewModel();
        }

        public TruckRepairPage(Truck truck)
        {
            InitializeComponent();
            BindingContext = viewModel = new TruckRepairViewModel();
            this.truck = truck;
            viewModel.truck = truck;
        }

        async void OnTruckRepairSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var truckRepair = args.SelectedItem as TruckRepair;
            if (truckRepair == null)
                return;
            await Navigation.PushAsync(new TruckRepairDetailPage(new TruckRepairDetailViewModel(truckRepair)));
            TruckRepairListView.SelectedItem = null;
        }

        async void NewTruckRepair_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewTruckRepairPage());
        }

        async void OnEdit(object sender, EventArgs e, SelectedItemChangedEventArgs args)
        {

            var truckrepair = ((MenuItem)sender).CommandParameter as TruckRepair;
            if (truckrepair == null)
                return;
            await Navigation.PushAsync(new TruckRepairDetailPage(new TruckRepairDetailViewModel(truckrepair)));
        }

        void OnDelete(object sender, EventArgs e, SelectedItemChangedEventArgs args)
        {
            var truckrepair = ((MenuItem)sender).CommandParameter as TruckRepair;
            if (truckrepair == null)
                return;
            viewModel.truckrepair = truckrepair;
            viewModel.DeleteCommand.Execute(null);
            //viewModel.LoadTrucksCommand.Execute(null);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (viewModel.TruckRepair.Count == 0)
            {
                viewModel.LoadTruckRepairCommand.Execute(null);
            }
        }
    }
}
