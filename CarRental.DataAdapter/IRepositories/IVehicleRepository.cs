using CarRental.DataAdapter.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DataAdapter.IRepositories
{
  public interface IVehicleRepository : IDisposable
  {
    IQueryable<IVehicleModel> GetAllVehicles();
    bool AddVehicle(IVehicleModel vehicle);
    IVehicleModel UpdateVehicle(IVehicleModel model);
    bool DeleteVehicle(string serialNumber);
  }
}
