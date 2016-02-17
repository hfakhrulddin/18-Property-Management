using System;
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
    public class PropertiesController : ApiController
    {
        private PropertyManagerDataContext db = new PropertyManagerDataContext();

        // GET: api/Properties
        public IEnumerable<PropertyModel> GetProperties()
        {
            return Mapper.Map<IEnumerable<PropertyModel>>(db.Properties.Where(p=> p.User.UserName == User.Identity.Name));
            //return db.Properties;
        }

        // GET: api/Properties/5
        [ResponseType(typeof(PropertyModel))]
        public IHttpActionResult GetProperty(int id)
        {
            //Property property = db.Properties.Find(id);//without LOGIN OWIN
            Property property = db.Properties.FirstOrDefault(p => p.User.UserName == User.Identity.Name && p.PropertyId == id);
            if (property == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<PropertyModel>(property));
        }

        //GET: api/Properties/5/Leases
        [Route("api/Properties/{PropertyId}/Leases")]
        public IEnumerable<LeaseModel> GetLeasesforProperty(int propertyId)
        {
            var leases = db.Leases.Where(l => l.PropertyId == propertyId);
            return Mapper.Map<IEnumerable<LeaseModel>>(leases);
        }
        ///
        [Route("api/Properties/{PropertyId}/WorkOrders")]
        public IEnumerable<WorkOrderModel> GetWorkOrdersforProperty(int propertyId)
        {
            var workOrders = db.WorkOrders.Where(wo => wo.PropertyId == propertyId);
            return Mapper.Map<IEnumerable<WorkOrderModel>>(workOrders);
        }

        // PUT: api/Properties/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProperty(int id, PropertyModel property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != property.PropertyId)
            {
                return BadRequest();
            }
            //var dbproperty = db.Properties.Find(id);//without LOGIN OWIN
            Property dbproperty = db.Properties.FirstOrDefault(p => p.User.UserName == User.Identity.Name && p.PropertyId == id);
            if (dbproperty == null)
            {
                return BadRequest();
            }

            dbproperty.Update(property);
            db.Entry(dbproperty).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertyExists(id))
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

        // POST: api/Properties
        [ResponseType(typeof(PropertyModel))]
        public IHttpActionResult PostProperty(PropertyModel property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ///////////////////////////////////////////
            var dbproperty = new Property(property);
            dbproperty.User = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                 
            
            db.Properties.Add(dbproperty);
            /////////////////////////////////////////////
            //db.Properties.Add(property);
            db.SaveChanges();
            property.PropertyId = dbproperty.PropertyId;
            return CreatedAtRoute("DefaultApi", new { id = property.PropertyId }, property);
        }

        // DELETE: api/Properties/5
        [ResponseType(typeof(PropertyModel))]
        public IHttpActionResult DeleteProperty(int id)
        {
            //Property property = db.Properties.Find(id); without OWIN
            Property property = db.Properties.FirstOrDefault(p => p.User.UserName == User.Identity.Name && p.PropertyId == id);
            if (property == null)
            {
                return NotFound();
            }

            db.Properties.Remove(property);
            db.SaveChanges();

            return Ok(Mapper.Map<PropertyModel>(property));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PropertyExists(int id)
        {
            return db.Properties.Count(e => e.PropertyId == id) > 0;
        }
    }
}