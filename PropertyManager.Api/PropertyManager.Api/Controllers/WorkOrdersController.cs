﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PropertyManager.Api.Domain;
using PropertyManager.Api.Infrastructure;
using PropertyManager.Api.Models;
using AutoMapper;

namespace PropertyManager.Api.Controllers
{
    [Authorize]
    public class WorkOrdersController : ApiController
    {
        private PropertyManagerDataContext db = new PropertyManagerDataContext();

        // GET: api/WorkOrders
        public IEnumerable<WorkOrderModel> GetWorkOrders()
        {
            return Mapper.Map<IEnumerable<WorkOrderModel>>(db.WorkOrders);
            //return db.WorkOrders;
        }

        // GET: api/WorkOrders/5
        [ResponseType(typeof(WorkOrderModel))]
        public IHttpActionResult GetWorkOrder(int id)
        {
            WorkOrder workOrder = db.WorkOrders.Find(id);
            if (workOrder == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<WorkOrderModel>(workOrder));
        }

        /// get the work orders for spcifice dates.
        [Route("api/workorders/{startDate}/{endDate}")]
        public IEnumerable<WorkOrderModel> Getrange(DateTime startDate, DateTime endDate)
        {
            var dateRange = db.WorkOrders.Where(wo => wo.OpenedDate >= startDate && wo.OpenedDate <= endDate);
            return Mapper.Map<IEnumerable<WorkOrderModel>>(dateRange);
        }

        // PUT: api/WorkOrders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWorkOrder(int id, WorkOrderModel workOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != workOrder.WorkOrderId)
            {
                return BadRequest();
            }
            var dbworkOrder = db.WorkOrders.Find(id);
            dbworkOrder.Update(workOrder);
            db.Entry(dbworkOrder).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkOrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/WorkOrders
        [ResponseType(typeof(WorkOrderModel))]
        public IHttpActionResult PostWorkOrder(WorkOrderModel workOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ///////////////////////////////////////////
            var dbworkOrder = new WorkOrder(workOrder);
            workOrder.WorkOrderId = dbworkOrder.WorkOrderId;
            db.WorkOrders.Add(dbworkOrder);
            //////////////////////////////////////////
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = workOrder.WorkOrderId }, workOrder);
        }

        // DELETE: api/WorkOrders/5
        [ResponseType(typeof(WorkOrderModel))]
        public IHttpActionResult DeleteWorkOrder(int id)
        {
            WorkOrder workOrder = db.WorkOrders.Find(id);
            if (workOrder == null)
            {
                return NotFound();
            }

            db.WorkOrders.Remove(workOrder);
            db.SaveChanges();

            return Ok(Mapper.Map<WorkOrderModel>(workOrder));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WorkOrderExists(int id)
        {
            return db.WorkOrders.Count(e => e.WorkOrderId == id) > 0;
        }
    }
}