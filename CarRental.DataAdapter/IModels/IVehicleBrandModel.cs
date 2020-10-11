using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DataAdapter.IModels
{
  public interface IVehicleBrandModel
  {
    int IdBrand { get; set; }
    string BrandName { get; set; }
  }
}
