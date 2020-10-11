using CarRental.Data.Models;
using CarRental.Data.Repositories;
using CarRental.DataAdapter.IModels;
using CarRental.Services.VehicleServices;
using CarRentalAPI.Controllers;
using CarRentalAPI.Models;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRental.Test
{
  [TestFixture]
  public class VehicleTest
  {
    VehicleRepository vehicleRepository;

    [SetUp]
    public void SetUp()
    {
      vehicleRepository = new VehicleRepository();
    }

    [TearDown]
    public void TearDown()
    {
      vehicleRepository.Dispose();
    }


    [Test]
    public void TestUpdateVehicle_ValidInput()
    {
      var vehicle = new VehicleModel
      {
        SerialNumber = "12312312312312312",
        IdModel = 6,
        IdBrand = 2,
        IdColor = 1,
        VehicleFuelTypeName = "Diesel",
        Observations = "tested"
      };

      var result = vehicleRepository.UpdateVehicle(vehicle);

      Assert.AreEqual(vehicle.ToString(), result.ToString());
    }

    [Test]
    public void TestUpdateVehicle_InvalidInput()
    {
      var vehicle = new VehicleModel
      {
        SerialNumber = "notValid",
        IdModel = 6,
        IdBrand = 2,
        IdColor = 1,
        VehicleFuelTypeName = "Diesel",
        Observations = "tested"
      };

      Assert.Catch<NullReferenceException>(() => vehicleRepository.UpdateVehicle(vehicle));
    }

    [TestCase("notValid")]
    public void TestDeleteVehicle_InvalidInput(string serialNumber)
    {
      var result = vehicleRepository.DeleteVehicle(serialNumber);

      Assert.AreEqual(false, result);
    }


    [TestCase("notValid")]
    public void TestAddVehicle_ValidInput()
    {
      var vehicle = new VehicleModel
      {
        SerialNumber = "XXXXXXXXXXXXXXXXX",
        IdModel = 8,
        IdBrand = 4,
        IdColor = 4,
        VehicleFuelTypeName = "Diesel",
        Observations = "-"
      };

      var result = vehicleRepository.AddVehicle(vehicle);

      Assert.AreEqual(true, result);
    }

    [TestCase("12312312312312312")]
    [TestCase("PKY77SD52KP089233")]
    [TestCase("90909090909090909")]
    public void TestGetVehicle_ValidInput(string serialNumber)
    {
      var result = vehicleRepository.GetAllVehicles()
        .Where(v => v.SerialNumber == serialNumber)
        .SingleOrDefault();

      Assert.AreEqual(new VehicleModel().ToString(), result.ToString());
    }

  }
}
