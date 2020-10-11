using System;
using System.Collections.Generic;

namespace CarRental.Data.Entities
{
    public partial class VehicleModels
    {
        public VehicleModels()
        {
            Vehicles = new HashSet<Vehicles>();
        }

        public int Idmodel { get; set; }
        public int Idbrand { get; set; }
        public string ModelName { get; set; }

        public virtual VehicleBrands IdbrandNavigation { get; set; }
        public virtual ICollection<Vehicles> Vehicles { get; set; }
    }
}
