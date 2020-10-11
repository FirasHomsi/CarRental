using CarRental.DataAdapter.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalAPI.Models
{
  public class VehicleBrandViewModel : IVehicleBrandModel
  {
    public int IdBrand { get; set; }
    public string BrandName { get; set; }
  }
}
