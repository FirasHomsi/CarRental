using System;
using System.Collections.Generic;

namespace CarRental.Data.Entities
{
    public partial class VehicleBrands
    {
        public VehicleBrands()
        {
            VehicleModels = new HashSet<VehicleModels>();
        }

        public int Idbrand { get; set; }
        public string BrandName { get; set; }

        public virtual ICollection<VehicleModels> VehicleModels { get; set; }
    }
}
