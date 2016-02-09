using PropertyManager.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyManager.Api.Domain
{
    

    public enum Priorities
    {

        Critical = 1,
        Major = 2,
        High = 3,
        Medium = 4,
        Low = 5,
      
    }

    public class WorkOrder
    {
        public WorkOrder(WorkOrderModel workorder)
        {
            this.Update(workorder);
        }
        public WorkOrder()
        {

        }
        public int WorkOrderId { get; set; }
        public int PropertyId { get; set; }
        public int? TenantId { get; set; }
        public string Description { get; set; }
        public DateTime OpenedDate { get; set; }
        public DateTime ClosedDate { get; set; }
        public Priorities Priorities { get; set; }

        public virtual Property Property { get; set; }
        public virtual Tenant Tenant { get; set; }


        public void Update(WorkOrderModel model) {

            WorkOrderId = model.WorkOrderId;
            PropertyId = model.PropertyId;
            TenantId = model.TenantId;
            Description = model.Description;
            OpenedDate = model.OpenedDate;
            ClosedDate = model.ClosedDate;
        Priorities = model.Priorities;
    }
    }
}