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
    public class TenantsController : ApiController
    {
        private PropertyManagerDataContext db = new PropertyManagerDataContext();

        // GET: api/Tenants
        public IEnumerable<TenantModel> GetTenants()
        {
            return Mapper.Map<IEnumerable<TenantModel>>(db.Tenants.Where(t => t.User.UserName == User.Identity.Name));
            //return db.Tenants;
        }

        // GET: api/Tenants/5
        [ResponseType(typeof(TenantModel))]
        public IHttpActionResult GetTenant(int id)
        {
            //Tenant tenant = db.Tenants.Find(id);
            Tenant tenant = db.Tenants.FirstOrDefault(t => t.User.UserName == User.Identity.Name && t.TenantId == id);
            if (tenant == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<TenantModel>(tenant));
        }

        //GET: api/Tenant/5/Leases
        [Route("api/Tenants/{TenantId}/Leases")]
        public IEnumerable<LeaseModel> GetLeasesforTenant(int tenantId)
        {
            var leases = db.Leases.Where(l => l.TenantId == tenantId);
            return Mapper.Map<IEnumerable<LeaseModel>>(leases);
        }
        // PUT: api/Tenants/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTenant(int id, TenantModel tenant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tenant.TenantId)
            {
                return BadRequest();
            }
            //var dbtenant = db.Tenants.Find(id); // the code without OWIN
            Tenant dbtenant = db.Tenants.FirstOrDefault(t => t.User.UserName == User.Identity.Name && t.TenantId == id);
            if (dbtenant == null )
            {
                return BadRequest();
            }
            dbtenant.Update(tenant);
            db.Entry(dbtenant).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TenantExists(id))
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

        // POST: api/Tenants
        [ResponseType(typeof(TenantModel))]
        public IHttpActionResult PostTenant(TenantModel tenant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            /////////////////////////////////////////////////
            var dbtenant = new Tenant(tenant);
            dbtenant.User = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            db.Tenants.Add(dbtenant);
            //////////////////////////////////////////////////////
            db.SaveChanges();
            //tenant.TenantId = dbtenant.TenantId;
            return CreatedAtRoute("DefaultApi", new { id = tenant.TenantId }, tenant);
        }

        // DELETE: api/Tenants/5
        [ResponseType(typeof(TenantModel))]
        public IHttpActionResult DeleteTenant(int id)
        {
            //Tenant tenant = db.Tenants.Find(id);  without  Login
            Tenant tenant = db.Tenants.FirstOrDefault(t => t.User.UserName == User.Identity.Name && t.TenantId == id);
            if (tenant == null)
            {
                return NotFound();
            }

            db.Tenants.Remove(tenant);
            db.SaveChanges();

            return Ok(Mapper.Map<TenantModel>(tenant));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TenantExists(int id)
        {
            return db.Tenants.Count(e => e.TenantId == id) > 0;
        }
    }
}