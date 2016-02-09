using PropertyManager.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyManager.Api.Domain
{

    public enum RentFrequencies {

        Daily = 1,
        Weekly = 2,
        Monthly = 3,
        Quarterly =4,
        BiAnnually = 5,
        Annually = 6
    }


    public class Lease
    {

        public Lease()
        {

        }

        public Lease(LeaseModel lease)
        {
            this.Update(lease);
        }
        public int LeaseId { get; set; }
        public int TenantId { get; set; }
        public int PropertyId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal RentAmount { get; set; }
        public RentFrequencies RentFrequencies { get; set;}



        public virtual Property Property { get; set; }
        public virtual Tenant Tenant { get; set; }

        public void Update(LeaseModel model)
        {
            LeaseId = model.LeaseId;
            TenantId = model.TenantId;
            PropertyId = model.PropertyId;
            StartDate = model.StartDate;
            EndDate = model.EndDate;
            RentAmount = model.RentAmount;
            RentFrequencies = model.RentFrequencies;

    }

    }
}