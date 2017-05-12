using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(Teste.Services.MockDriverStore))]
namespace Teste.Services
{
	public class MockDriverStore : IDriverStore<Driver>
	{
        bool isInitialized;
        List<Driver> drivers;
        DadosBanco DB = new DadosBanco();
        SQLiteConnection db;

        public MockDriverStore ()
		{
            db = new SQLiteConnection(DB.GetConnection());
        }

        public async Task<bool> AddDriverAsync(Driver driver)
        {
            db.Insert(driver);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateDriverAsync(Driver driver)
        {
            db.Update(driver);
            return await Task.FromResult(true);
        }


        public async Task<bool> DeleteDriverAsync(Driver driver)
        {
            db.Delete(driver);
            return await Task.FromResult(false);
        }

        public List<Driver> GetDriver()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Driver>> GetDriversAsync(bool forceRefresh = false)
        {
            drivers = new List<Driver>();
            drivers = db.Table<Driver>().ToList();
            return await Task.FromResult(drivers);
        }

        public async Task<bool> InitializeAsync()
        {
            if (isInitialized)
                return await Task.FromResult(true);

            isInitialized = true;
            return await Task.FromResult(true);
        }

        public Task<bool> PullLatestAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SyncAsync()
        {
            throw new NotImplementedException();
        }

        private void Reload()
        {

        }
    }
}
