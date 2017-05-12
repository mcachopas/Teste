using Teste.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Teste.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TruckRepairDetailPage : ContentPage
	{
        TruckRepairDetailViewModel viewModel;
        public TruckRepairDetailPage ()
		{
			InitializeComponent ();
          
        }

        public TruckRepairDetailPage(TruckRepairDetailViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }
    }
}
