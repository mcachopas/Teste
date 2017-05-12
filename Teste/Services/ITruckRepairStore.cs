using System.Collections.Generic;
using System.Threading.Tasks;
using Teste.Models;
using Xamarin.Forms;

namespace Teste.Services
{
	public interface ITruckRepairStore<T>
	{
        Task<bool> AddTruckRepairAsync(T truckRepair);
        Task<bool> UpdateTruckRepairAsync(T truckRepair);
        Task<bool> DeleteTruckRepairAsync(T truckRepair);
        Task<IEnumerable<T>> GetTruckRepairAsync();
        Task<IEnumerable<T>> GetbyTruckRepairAsync(Truck truck);
    }
}
