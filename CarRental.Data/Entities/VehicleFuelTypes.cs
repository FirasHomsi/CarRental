using System;
using System.Collections.Generic;

namespace CarRental.Data.Entities
{
    public partial class VehicleFuelTypes
    {
        public VehicleFuelTypes()
        {
            Vehicles = new HashSet<Vehicles>();
        }

        public string VehicleFuelTypeName { get; set; }
        public string Observations { get; set; }

        public virtual ICollection<Vehicles> Vehicles { get; set; }
    }
}
