
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Teste.ViewModels;

namespace Teste.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TruckDetailPage : ContentPage
    {
        TruckDetailViewModel viewModel;
        public TruckDetailPage()
        {
            InitializeComponent();
        }

        public TruckDetailPage(TruckDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
    }
}
