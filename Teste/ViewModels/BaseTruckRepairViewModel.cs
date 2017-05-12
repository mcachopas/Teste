using Teste.Models;
using Teste.Services;
using Xamarin.Forms;

namespace Teste.ViewModels
{
    class BaseTruckRepairViewModel
    {
        public ITruckRepairStore<TruckRepair> TruckRepairStore => DependencyService.Get<ITruckRepairStore<TruckRepair>>();

        public BaseTruckRepairViewModel ()
        {

        }
    }
}
