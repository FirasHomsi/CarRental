using CarRental.DataAdapter.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalAPI.Models
{
  public class VehicleModelViewModel : IVehicleModelModel
  {
    public int IdModel { get; set; }
    public string ModelName { get; set; }
  }
}
