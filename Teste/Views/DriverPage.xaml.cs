using System;

using Teste.Models;
using Teste.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Teste.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DriverPage : ContentPage
	{
        DriverViewModel viewModel;
        public DriverPage ()
		{
			InitializeComponent ();
            BindingContext = viewModel = new DriverViewModel();
        }

        async void OnDriverSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var driver = args.SelectedItem as Driver;
            if (driver == null)
                return;
            await Navigation.PushAsync(new DriverDetailPage(new DriverDetailViewModel(driver)));
            DriverListView.SelectedItem = null;
        }

        async void NewDriver_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewDriverPage());
        }

        async void OnEdit(object sender, EventArgs e, SelectedItemChangedEventArgs args)
        {

            var driver = ((MenuItem)sender).CommandParameter as Driver;
            if (driver == null)
                return;
            await Navigation.PushAsync(new DriverDetailPage(new DriverDetailViewModel(driver)));
        }

        void OnDelete(object sender, EventArgs e, SelectedItemChangedEventArgs args)
        {
            var driver = ((MenuItem)sender).CommandParameter as Driver;
            if (driver == null)
                return;
            viewModel.deleteDriver = driver;
            viewModel.DeleteCommand.Execute(null);
            viewModel.LoadTrucksCommand.Execute(null);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (viewModel.Drivers.Count == 0) 
                viewModel.LoadTrucksCommand.Execute(null);
        }
    }
}
