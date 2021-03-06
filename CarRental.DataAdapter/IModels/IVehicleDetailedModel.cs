﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DataAdapter.IModels
{
  public interface IVehicleDetailedModel
  {
    string SerialNumber { get; set; }

    int IdModel { get; set; }

    int IdBrand { get; set; }

    string VehicleFuelTypeName { get; set; }

    int IdColor { get; set; }

    string Observations { get; set; }

    string BrandName { get; set; }
    string ModelName { get; set; }
    string Color { get; set; }
  }
}
