using System;
using Teste.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Teste.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewTruckRepairPage : ContentPage
	{
        public TruckRepair TruckRepair { get; set; }

        public NewTruckRepairPage ()
		{
			InitializeComponent ();

            TruckRepair = new TruckRepair()
            {
                Date = DateTime.Now,
                KM = 18.2,
                Price = 20.00,
                OilFilter = false,
                DieselFilter = false,
                AirFilter = false,
                MotorFilter = false,
                Breaks = "Calçios",
                Repairs = "Reparos",
                TiresCondition = 100,
                Obs = "Observação",
            };

            BindingContext = this;
		}

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", TruckRepair);
            await Navigation.PopToRootAsync();
        }
    }
}
