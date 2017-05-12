using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Teste.Models;
using Xamarin.Forms;
using System.Linq;

[assembly: Dependency(typeof(Teste.Services.MockTruckRepairStore))]
namespace Teste.Services
{
    
    class MockTruckRepairStore : ITruckRepairStore<TruckRepair>
    {
        List<TruckRepair> truckrepairs;
        DadosBanco DB = new DadosBanco();
        SQLiteConnection db;

        public MockTruckRepairStore()
        {
            db = new SQLiteConnection(DB.GetConnection());
        }

        public async Task<bool> AddTruckRepairAsync(TruckRepair truckRepair)
        {
            db.Insert(truckRepair);
            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<TruckRepair>> GetbyTruckRepairAsync(Truck truck)
        {
            truckrepairs = new List<TruckRepair>();
            truckrepairs = db.Table<TruckRepair>().Where(i => i.TruckID == truck.ID).ToList();
            return await Task.FromResult(truckrepairs);
        }

        public async Task<IEnumerable<TruckRepair>> GetTruckRepairAsync()
        {
            truckrepairs = new List<TruckRepair>();
            truckrepairs = db.Table<TruckRepair>().ToList();
            return await Task.FromResult(truckrepairs);
        }

        public async Task<bool> DeleteTruckRepairAsync(TruckRepair truckRepair)
        {
            db.Delete(truckRepair);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateTruckRepairAsync(TruckRepair truckRepair)
        {
            db.Update(truckRepair);
            return await Task.FromResult(true);
        }
    }
}
