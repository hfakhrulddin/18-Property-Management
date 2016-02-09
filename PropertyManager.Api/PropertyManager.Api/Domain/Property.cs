﻿using PropertyManager.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyManager.Api.Domain
{
    public class Property
    {

        public Property()
        {

        }

        public Property(PropertyModel property)
        {
            this.Update(property);
        }


        public int PropertyId { get; set; }
        public int? AddressId { get; set; }
        public string PropertyName { get; set; }
        public int? SquareFeet { get; set; }
        public int? NumberOfBedrooms { get; set; }
        public float NumberOfBathrooms { get; set; }
        public int NumberOfVehicales { get; set; }



        public virtual Address Address { get; set; }
        

        public virtual ICollection<Lease> Leases { get; set; }
        public virtual ICollection<WorkOrder> WorkOrders { get; set; }

        public void Update(PropertyModel model) {

            PropertyId = model.PropertyId;
            AddressId = model.AddressId;
            PropertyName = model.PropertyName;
            SquareFeet = model.SquareFeet;
            NumberOfBedrooms = model.NumberOfBedrooms;
            NumberOfBathrooms = model.NumberOfBathrooms;
            NumberOfVehicales = model.NumberOfVehicales;
    }
    }
}