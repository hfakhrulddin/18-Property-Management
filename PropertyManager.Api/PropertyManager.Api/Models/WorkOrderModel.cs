using PropertyManager.Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyManager.Api.Models
{
    public class WorkOrderModel
    {
            public int WorkOrderId { get; set; }
            public int PropertyId { get; set; }
            public int? TenantId { get; set; }
            public string Description { get; set; }
            public DateTime OpenedDate { get; set; }
            public DateTime ClosedDate { get; set; }
            public Priorities Priorities { get; set; }


        public AddressModel Address { get; set; }

    }
       
}
