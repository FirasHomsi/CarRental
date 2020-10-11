using CarRental.Data.Entities;
using CarRental.Data.Models;
using CarRental.DataAdapter.IModels;
using CarRental.DataAdapter.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Data.Repositories
{
  public class VehicleRepository : IVehicleRepository
  {
    private CarRentalDBContext _ctx;

    public VehicleRepository()
    {
      _ctx = new CarRentalDBContext();
    }

    public IQueryable<IVehicleModel> GetAllVehicles()
    {
      var vehicles = _ctx.Vehicles
        .Select(v => new VehicleModel
        {
          SerialNumber = v.SerialNumber,
          IdBrand = v.Idbrand,
          IdColor = v.Idcolor,
          IdModel = v.Idmodel,
          VehicleFuelTypeName = v.VehicleFuelTypeName,
          Observations = v.Observations
        });

      return vehicles;
    }

    public bool AddVehicle(IVehicleModel vehicle)
    {
      try
      {
        _ctx.Vehicles.Add(new Vehicles
        {
          SerialNumber = vehicle.SerialNumber,
          Idbrand = vehicle.IdBrand,
          Idmodel = vehicle.IdModel,
          Idcolor = vehicle.IdColor,
          VehicleFuelTypeName = vehicle.VehicleFuelTypeName,
          Observations = vehicle.Observations
        });

        _ctx.SaveChanges();

        return true;
      }
      catch (Exception)
      {
        throw;
      }
    }

    public IVehicleModel UpdateVehicle(IVehicleModel model)
    {
      try
      {
        var vehicle = _ctx.Vehicles
          .Where(z => z.SerialNumber == model.SerialNumber)
          .SingleOrDefault();

        if (vehicle == null)
        {
          throw new NullReferenceException($"Vehicle with SN: {model.SerialNumber} couldn't be found!");
        }

        vehicle.Idcolor = model.IdColor;
        vehicle.VehicleFuelTypeName = model.VehicleFuelTypeName;
        vehicle.Observations = model.Observations;

        _ctx.SaveChanges();

        return new VehicleModel
        {
          SerialNumber = model.SerialNumber,
          IdBrand = vehicle.Idbrand,
          IdModel = vehicle.Idmodel,
          IdColor = vehicle.Idcolor,
          VehicleFuelTypeName = vehicle.VehicleFuelTypeName,
          Observations = vehicle.Observations
        };
      }
      catch (Exception)
      {
        throw;
      }
    }

    public bool DeleteVehicle(string serialNumber)
    {
      try
      {
        var vehicle = _ctx.Vehicles
         .Where(z => z.SerialNumber == serialNumber)
         .SingleOrDefault();

        if (vehicle == null)
        {
          throw new NullReferenceException($"Vehicle with SN: {serialNumber} couldn't be found!");
        }

        _ctx.Vehicles.Remove(vehicle);
        _ctx.SaveChanges();

        return true;
      }
      catch (Exception)
      {
        throw;
      }
    }



    public void Dispose()
    {
      _ctx.Dispose();
      //GC.SuppressFinalize(this);
    }


  }
}
