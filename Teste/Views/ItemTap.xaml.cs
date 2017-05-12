using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Teste.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemTap : ContentPage, IGestureRecognizer
	{
		public ItemTap ()
		{
			InitializeComponent ();

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {
                // handle the tap
            };
            image.GestureRecognizers.Add(tapGestureRecognizer);
        }

        async void OnTapGestureRecognizerTapped()
        {
            

            await contador();
        }
        async Task<bool> contador()
        {
            return await Task.FromResult(true);
        }

    }
}
