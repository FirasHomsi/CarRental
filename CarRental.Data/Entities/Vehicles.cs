using System;
using System.Collections.Generic;

namespace CarRental.Data.Entities
{
  public partial class Vehicles
  {
    public string SerialNumber { get; set; }
    public int Idmodel { get; set; }
    public int Idbrand { get; set; }
    public string VehicleFuelTypeName { get; set; }
    public int Idcolor { get; set; }
    public string Observations { get; set; }

    public virtual VehicleModels Id { get; set; }
    public virtual VehicleColors IdcolorNavigation { get; set; }
    public virtual VehicleFuelTypes VehicleFuelTypeNameNavigation { get; set; }
  }
}
