using SQLite;
using Xamarin.Forms;

namespace Teste.Models
{
	public class Truck
	{

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Motor { get; set; }
        public string Year { get; set; }
        public string FuelType { get; set; }
        public string OilType { get; set; }
    }
}
