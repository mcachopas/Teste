using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.Models;
using Xamarin.Forms;


[assembly: Dependency(typeof(Teste.Services.MockTruckStore))]
namespace Teste.Services
{
	public class MockTruckStore : ITruckStore<Truck>
	{

        bool isInitialized;
        List<Truck> trucks;
        DadosBanco DB = new DadosBanco();
        SQLiteConnection db;

        public MockTruckStore ()
		{
            db = new SQLiteConnection(DB.GetConnection());
        }

        public async Task<bool> AddTruckAsync(Truck truck)
        {
            db.Insert(truck);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteTruckAsync(Truck truck)
        {
            db.Delete(truck);
            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<Truck>> GetTrucksAsync(bool forceRefresh = false)
        {
            trucks = new List<Truck>();
            trucks = db.Table<Truck>().ToList();
            return await Task.FromResult(trucks);
        }

        public Task<bool> PullLatestAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SyncAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateTruckAsync(Truck truck)
        {
            db.Update(truck);
            return await Task.FromResult(true);
        }

        public async Task<bool> InitializeAsync()
        {
            if (isInitialized)
                return await Task.FromResult(true);

            isInitialized = true;
            return await Task.FromResult(true);
        }

        public List<Truck> GetTruck()
        {
            return trucks;
        }

        private Truck Truck_Adapter(Truck truck)
        {
            return truck;
        }
    }
}
