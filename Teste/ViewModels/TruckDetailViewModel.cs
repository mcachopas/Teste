using Teste.Models;

namespace Teste.ViewModels
{
	public class TruckDetailViewModel : BaseTruckViewModel
    {
		public Truck Truck { get; set; }
        public TruckDetailViewModel(Truck truck = null)
        {
            Title = truck.Brand;
            Truck = truck;
        }

        int quantity = 1;
        public int Quantity
        {
            get { return quantity; }
            set { SetProperty(ref quantity, value); }
        }
    }
}
