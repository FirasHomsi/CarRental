using CarRental.DataAdapter.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRental.Services.VehicleServices
{
  public interface IVehicleServices
  {
    public IQueryable<IVehicleModel> GetAllVehicles();
  }
}
