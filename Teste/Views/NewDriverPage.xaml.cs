using System;
using System.Collections.Generic;
using System.Linq;
using Teste.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Teste.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewDriverPage : ContentPage
	{
        public Driver Driver { get; set; }

        public NewDriverPage ()
		{

            InitializeComponent ();

            Driver = new Driver
            {
                Name = "Nome",
                Surname = "SobreNome",
                BirthYear = DateTime.Now,
                Document = "CNH",
                Expiration = DateTime.Now,
                Adress = "Endereço",
                Phone = "Telefone"
            };

            BindingContext = this;
		}

        async void Save_Clicked(object sender, EventArgs e)
        {
          MessagingCenter.Send(this, "AddItem", Driver);
            await Navigation.PopToRootAsync();
        }
    }
}
