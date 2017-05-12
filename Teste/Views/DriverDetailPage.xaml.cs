using Teste.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Teste.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DriverDetailPage : ContentPage
	{
        DriverDetailViewModel viewModel;
        public DriverDetailPage ()
		{
			InitializeComponent ();
		}

        public DriverDetailPage(DriverDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext  = this.viewModel = viewModel;
        }
    }
}
