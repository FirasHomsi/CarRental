using CarRental.DataAdapter.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Data.Models
{
  public class VehicleColorModel : IVehicleColorModel
  {
    public int IdColor { get; set; }
    public string VehicleColor { get; set; }
  }
}
