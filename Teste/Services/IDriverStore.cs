using System.Collections.Generic;
using System.Threading.Tasks;

namespace Teste.Services
{
	public interface IDriverStore<T>
	{
        Task<bool> AddDriverAsync(T driver);
        Task<bool> UpdateDriverAsync(T driver);
        Task<bool> DeleteDriverAsync(T driver);
        //Task<IEnumerable<T>> GetDriver();
        List<T> GetDriver();
        Task<IEnumerable<T>> GetDriversAsync(bool forceRefresh = false);

        Task<bool> InitializeAsync();
        Task<bool> PullLatestAsync();
        Task<bool> SyncAsync();
    }
}
