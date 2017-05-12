using SQLite;
using System;

namespace Teste.Models
{
	public class Driver 
	{

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public DateTime BirthYear { get; set; }
        public String Document { get; set; }
        public DateTime Expiration { get; set; }
        public String Adress { get; set; }
        public String Phone { get; set; }

    }
}
