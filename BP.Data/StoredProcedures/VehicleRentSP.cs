using BP.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BP.StoredProcedures
{
    public class VehicleRentSP
    {
        private readonly BPContext BPContext;
        public VehicleRentSP(BPContext BPContext)
        {
            this.BPContext = BPContext;
        }
    }
}
