using System;
using System.Collections.Generic;

namespace CarRental.Data.Entities
{
    public partial class VehicleColors
    {
        public VehicleColors()
        {
            Vehicles = new HashSet<Vehicles>();
        }

        public int Idcolor { get; set; }
        public string VehicleColor { get; set; }

        public virtual ICollection<Vehicles> Vehicles { get; set; }
    }
}
