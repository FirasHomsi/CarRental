using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DataAdapter.IModels
{
  public interface IVehicleFuelTypeModel
  {
    string VehicleFuelType { get; set; }
    string Observations { get; set; }
  }
}
