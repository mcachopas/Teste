using System.Collections.Generic;
using System.Threading.Tasks;

namespace Teste.Services
{
	public interface ITruckStore<T>
	{
        Task<bool> AddTruckAsync(T truck);
        Task<bool> UpdateTruckAsync(T truck);
        Task<bool> DeleteTruckAsync(T truck);
        //Task<IEnumerable<T>> GetTruck();
        List<T> GetTruck();
       Task<IEnumerable<T>> GetTrucksAsync(bool forceRefresh = false);

        Task<bool> InitializeAsync();
        Task<bool> PullLatestAsync();
        Task<bool> SyncAsync();

    }
}
