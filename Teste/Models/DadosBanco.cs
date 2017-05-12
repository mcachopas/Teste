using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Models;
using Xamarin.Forms;

namespace Teste.Models
{
    class DadosBanco : IDadosespecificos
    {
        String connection = "";
        
        public DadosBanco()
        {
            CriaDB();
        }

        public string CaminhoDB(string NomeDB)
        {
            throw new NotImplementedException();
        }

        public void CriaDB()
        {
            var db = new SQLiteConnection(DependencyService.Get<IDadosespecificos>().CaminhoDB("Driver.DB"));
            
            db.CreateTable<Driver>();
            db.CreateTable<Truck>();
            db.CreateTable<TruckRepair>();

            this.connection = DependencyService.Get<IDadosespecificos>().CaminhoDB("Driver.DB");
        }

        public void DeleteDB()
        {

        }

        public void VerificaDB()
        {

        }

        public String GetConnection()
        {
            return this.connection;
        }
    }
}
