using CarRental.Data.Repositories;
using CarRental.DataAdapter.IModels;
using CarRental.DataAdapter.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRental.Services.VehicleServices
{
  public class VehicleServices : IVehicleServices
  {
    private readonly IVehicleRepository _vehicleRepository;

    public VehicleServices()
    {
      _vehicleRepository = new VehicleRepository();
    }

    public IQueryable<IVehicleModel> GetAllVehicles()
    {
      return _vehicleRepository.GetAllVehicles();
    }

    public IVehicleModel AddVehicle(IVehicleModel vehicle)
    {
      var veh = _vehicleRepository.GetAllVehicles()
        .Where(v => v.SerialNumber == vehicle.SerialNumber)
        .SingleOrDefault();

      if(veh != null)
      {
        return null;
      }

      var isCreated = _vehicleRepository.AddVehicle(vehicle);

      if (!isCreated)
      {
        return null;
      }

      return vehicle;
    }

    public IVehicleModel UpdateVehicle(IVehicleModel model)
    {
      var editedVehicle = _vehicleRepository.UpdateVehicle(model);

      return editedVehicle;
    }

    public bool DeleteVehicle(string serialNumber)
    {
      var deleted = _vehicleRepository.DeleteVehicle(serialNumber);

      return deleted;
    }
  }
}
