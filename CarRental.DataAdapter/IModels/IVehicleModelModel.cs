using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DataAdapter.IModels
{
  public interface IVehicleModelModel
  {
    int IdModel { get; set; }
    string ModelName { get; set; }
  }
}
