using Teste.Models;
using Teste.Services;
using Xamarin.Forms;

namespace Teste.ViewModels
{
	public class BaseDriverViewModel
	{
        public IDriverStore<Driver> DriverStore => DependencyService.Get<IDriverStore<Driver>>();

        public BaseDriverViewModel ()
		{

		}
	}
}
