using System;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Teste.Models;
using Teste.ViewModels;


namespace Teste.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TruckPage : ContentPage
    {
        TrucksViewModel viewModel;

        public TruckPage ()
		{
			InitializeComponent ();

            BindingContext = viewModel = new TrucksViewModel();
		}

        async void OnTruckSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var truck = args.SelectedItem as Truck;
            if (truck == null)
                return;
            //await Navigation.PushAsync(new TruckDetailPage(new TruckDetailViewModel(truck)));
            await Navigation.PushAsync(new TruckRepairPage(truck));
            TruckListView.SelectedItem = null;
        }

        async void NewTruck_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewTruckPage());
        }

        async void OnEdit(object sender, EventArgs e, SelectedItemChangedEventArgs args)
        {
            
            var truck = ((MenuItem)sender).CommandParameter as Truck;
            if (truck == null)
                return;
            //await Navigation.PushAsync(new NewTruckPage());
            await Navigation.PushAsync(new TruckDetailPage(new TruckDetailViewModel(truck)));
        }

        void OnDelete(object sender, EventArgs e, SelectedItemChangedEventArgs args)
        {
            var truck = ((MenuItem)sender).CommandParameter as Truck;
            if (truck == null)
                return;
            viewModel.deleteTruck = truck;
            viewModel.DeleteCommand.Execute(null);
            viewModel.LoadTrucksCommand.Execute(null);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
           if (viewModel.Trucks.Count == 0)
                viewModel.LoadTrucksCommand.Execute(null);
        }
    }
}
