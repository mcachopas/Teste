using Teste.Models;
using Xamarin.Forms;

namespace Teste.ViewModels
{
	public class DriverDetailViewModel
	{
        public Driver Driver { get; set; }
		public DriverDetailViewModel (Driver driver = null)
		{
            Driver = driver;
		}
	}
}
