﻿using CarRental.DataAdapter.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalAPI.Models
{
  public class VehicleDetailedViewModel : IVehicleDetailedModel
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
    public string VehicleName => "Vehicle " + ModelName + " - " + BrandName + " - " + VehicleFuelTypeName + " - " + Color + " with SN: " + SerialNumber;
  }
}
