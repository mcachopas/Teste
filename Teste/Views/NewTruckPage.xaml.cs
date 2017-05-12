using System;
using Teste.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Teste.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewTruckPage : ContentPage
	{
        public Truck Truck { get; set; }

		public NewTruckPage ()
		{
			InitializeComponent ();

            Truck = new Truck
            {
                Model = "Modelo",
                Brand = "Marca",
                Motor = "Motor",
                Year = "Ano",
                FuelType = "Tipo de Oleo",
                OilType = "Tipo de Oleo"
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Truck);
            await Navigation.PopToRootAsync();
        }
    }

    
}
