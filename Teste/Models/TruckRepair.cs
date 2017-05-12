using SQLite;
using System;

using Xamarin.Forms;

namespace Teste.Models
{
	public class TruckRepair
	{
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int TruckID { get; set; }
        public DateTime Date { get; set; }
        public Double KM { get; set; }
        public Double Price { get; set; }
        public bool OilFilter { get; set; }
        public bool DieselFilter { get; set; }
        public bool AirFilter { get; set; }
        public bool MotorFilter { get; set; }
        public String Breaks { get; set; }
        public String Repairs { get; set; }
        public Double TiresCondition { get; set; }
        public String Obs { get; set; }
    }
}
