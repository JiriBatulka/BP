using BP.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BP.StoredProcedures
{
    public class OrderSP
    {
        private readonly BPContext BPContext;
        public OrderSP(BPContext BPContext)
        {
            this.BPContext = BPContext;
        }
    }
}
