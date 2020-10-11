using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRental.Services.VehicleServices;
using CarRentalAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CarRentalAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class VehicleController : ControllerBase
  {
    private readonly VehicleServices _vehicleServices;
    private readonly ILogger<VehicleController> _logger;

    public VehicleController(ILogger<VehicleController> logger)
    {
      _logger = logger;
      _vehicleServices = new VehicleServices();
    }


    [HttpGet]
    [Route("GetVehicles")]
    public ActionResult<IEnumerable<VehicleViewModel>> Get()
    {
      var vehicles = _vehicleServices.GetAllVehicles()
       .Select(v => new VehicleViewModel
       {
         SerialNumber = v.SerialNumber,
         IdBrand = v.IdBrand,
         IdColor = v.IdColor,
         IdModel = v.IdModel,
         VehicleFuelTypeName = v.VehicleFuelTypeName,
         Observations = v.Observations
       })
       .ToList();

      if (vehicles.Count == 0)
      {
        return NotFound();
      }

      return vehicles;
    }

    [HttpGet]
    [Route("{serialNumber}")]
    public ActionResult<VehicleViewModel> Get(string serialNumber)
    {
      var vehicle = _vehicleServices.GetAllVehicles()
       .Where(v => v.SerialNumber == serialNumber)
       .Select(v => new VehicleViewModel
       {
         SerialNumber = v.SerialNumber,
         IdBrand = v.IdBrand,
         IdColor = v.IdColor,
         IdModel = v.IdModel,
         VehicleFuelTypeName = v.VehicleFuelTypeName,
         Observations = v.Observations
       })
       .SingleOrDefault();

      if(vehicle == null)
      {
        return NotFound();
      }

      return vehicle;
    }

    [HttpPost]
    [Route("AddVehicle")]
    public ActionResult<VehicleViewModel> AddVehicle(VehicleViewModel model)
    {
      var vehicle = _vehicleServices.AddVehicle (model);

      if(vehicle == null)
      {
        var msg = "There's already a vehicle with the same SerialNumber of: " + model.SerialNumber;

        _logger.LogInformation(msg);
        return NotFound(msg);
      }

      return new VehicleViewModel
      {
        SerialNumber = vehicle.SerialNumber,
        IdBrand = vehicle.IdBrand,
        IdColor = vehicle.IdColor,
        IdModel = vehicle.IdModel,
        VehicleFuelTypeName = vehicle.VehicleFuelTypeName,
        Observations = vehicle.Observations
      };
    }

    [HttpPut]
    public ActionResult<VehicleViewModel> UpdateVehicle(VehicleViewModel model)
    {
      var vehicle = _vehicleServices.UpdateVehicle(model);

      if (vehicle == null)
      {
        var msg = "The vehicle with the serial number " + model.SerialNumber + " was not found";

        _logger.LogInformation(msg);
        return NotFound(msg);
      }

      return new VehicleViewModel
      {
        SerialNumber = vehicle.SerialNumber,
        IdBrand = vehicle.IdBrand,
        IdColor = vehicle.IdColor,
        IdModel = vehicle.IdModel,
        VehicleFuelTypeName = vehicle.VehicleFuelTypeName,
        Observations = vehicle.Observations
      };
    }


    [HttpDelete]
    [Route("{serialNumber}")]
    public ActionResult<VehicleViewModel> DeleteVehicle(string serialNumber)
    {
      var vehicle = _vehicleServices.DeleteVehicle(serialNumber);

      if (!vehicle)
      {
        var msg = "The vehicle with the serial number " + serialNumber + " was not found";

        _logger.LogInformation(msg);
        return NotFound(msg);
      }

      return Ok();
    }

  }
}
