using CarRental.DataAdapter.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Data.Models
{
  public class VehicleDetailedModel : IVehicleDetailedModel
  {
    public string SerialNumber { get; set; }
    public int IdModel { get; set; }
    public int IdBrand { get; set; }
    public string VehicleFuelTypeName { get; set; }
    public int IdColor { get; set; }
    public string Observations { get; set; }
    public string BrandName { get; set; }
    public string ModelName { get; set; }
    public string Color { get; set; }
  }
}
