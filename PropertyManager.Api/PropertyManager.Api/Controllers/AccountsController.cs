using PropertyManager.Api.Infrastructure;
using PropertyManager.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PropertyManager.Api.Controllers
{
    public class AccountsController : ApiController
    {
     // Create a Repo instant.
        private AuthorizationRepository _repo = new AuthorizationRepository();
     // 
     [AllowAnonymous]
     [Route("api/accounts/register")]
        public async Task<IHttpActionResult> Register(RegistrationModel registration)
        {

            // 1. Server side validation.
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // 2. Pass the registration onto AuthRepository.
            var result = await _repo.RegisterUser(registration);

            // 3. Check to see that registration was successful
            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Registration form was invalid");
            }
        }
       ///////////////////////////////////////////Dispose
        protected override void Dispose(bool disposing)
        {
                _repo.Dispose();
        }
    }
}
