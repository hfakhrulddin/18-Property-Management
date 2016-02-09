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
    public class LeasesController : ApiController
    {
        private PropertyManagerDataContext db = new PropertyManagerDataContext();

        // GET: api/Leases
        public IEnumerable<LeaseModel> GetLeases()
        {
            return Mapper.Map< IEnumerable<LeaseModel>>(db.Leases);
            //return db.Leases;
        }

        // GET: api/Leases/5
        [ResponseType(typeof(LeaseModel))]
        public IHttpActionResult GetLease(int id)
        {
            Lease lease = db.Leases.Find(id);
            if (lease == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<LeaseModel>(lease));
        }

        // PUT: api/Leases/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLease(int id, LeaseModel lease)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lease.LeaseId)
            {
                return BadRequest();
            }
            var dblease = db.Leases.Find(id);
            dblease.Update(lease);
            db.Entry(dblease).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeaseExists(id))
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

        // POST: api/Leases
        [ResponseType(typeof(LeaseModel))]
        public IHttpActionResult PostLease(LeaseModel lease)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //////////////////////////////
            var dblease = new Lease(lease);
            lease.LeaseId = dblease.LeaseId;
            db.Leases.Add(dblease);
            //////////////////////////////////////////
            //db.Leases.Add(lease);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lease.LeaseId }, lease);
        }

        // DELETE: api/Leases/5
        [ResponseType(typeof(LeaseModel))]
        public IHttpActionResult DeleteLease(int id)
        {
            Lease lease = db.Leases.Find(id);
            if (lease == null)
            {
                return NotFound();
            }

            db.Leases.Remove(lease);
            db.SaveChanges();

            return Ok(Mapper.Map<LeaseModel>(lease));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LeaseExists(int id)
        {
            return db.Leases.Count(e => e.LeaseId == id) > 0;
        }
    }
}