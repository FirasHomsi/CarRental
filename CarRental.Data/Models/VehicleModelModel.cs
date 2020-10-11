﻿using CarRental.DataAdapter.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Data.Models
{
  public class VehicleModelModel : IVehicleModelModel
  {
    public int IdModel { get; set; }
    public int IdBrand { get; set; }
    public string ModelName { get; set; }
  }
}
