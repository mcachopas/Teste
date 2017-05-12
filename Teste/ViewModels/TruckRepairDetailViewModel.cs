using System;
using System.Collections.Generic;
using System.Text;
using Teste.Models;

namespace Teste.ViewModels
{
    public class TruckRepairDetailViewModel
    {
        public TruckRepair TruckRepair { get; set; }
        public TruckRepairDetailViewModel(TruckRepair truckrepair = null)
        {
            TruckRepair = truckrepair;
        }
    }
}
