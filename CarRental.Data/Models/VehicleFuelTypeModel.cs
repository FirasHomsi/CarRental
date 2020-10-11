using CarRental.DataAdapter.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Data.Models
{
  public class VehicleFuelTypeModel : IVehicleFuelTypeModel
  {
    public string VehicleFuelType { get; set; }
    public string Observations { get; set; }
  }
}
