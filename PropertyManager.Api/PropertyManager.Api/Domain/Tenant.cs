using PropertyManager.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyManager.Api.Domain
{
    public class Tenant
    {
        public Tenant()
        {

        }
        public Tenant(TenantModel tenant)
        {
            this.Update(tenant);

        }
        public int TenantId { get; set; }

        public string UserId { get; set; }// this related to Login User OAuth one to many relationship (one).
        public virtual PropertyManagerUser User { get; set; }

        public int? AddressId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string EmailAddress { get; set; }

        public virtual Address Address { get; set; }

        public virtual ICollection<Lease> Leases { get; set; }
        public virtual ICollection<WorkOrder> WorkOrders { get; set; }


        public void Update(TenantModel model) {

            TenantId = model.TenantId;
            AddressId = model.AddressId;
            FirstName = model.FirstName;
            LastName = model.LastName;
            Telephone = model.Telephone;
            EmailAddress = model.EmailAddress;
    }
    }
}