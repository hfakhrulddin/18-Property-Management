using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PropertyManager.Api.Domain;
using PropertyManager.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PropertyManager.Api.Infrastructure
{

    public class AuthorizationRepository : IDisposable
    {

        private PropertyManagerDataContext _db;
        private UserManager<PropertyManagerUser>_userManager;

        public AuthorizationRepository()
        {
            _db = new PropertyManagerDataContext();
            _userManager = new UserManager<PropertyManagerUser>(new UserStore<PropertyManagerUser>(_db));// We want a UserManager deal with PropertyManagerUser.//
        }

        //Register a user using the function below
        public async Task<IdentityResult> RegisterUser(RegistrationModel model)

        {
            //Create instant of the PropertyManagerUser from the domain class.
            var propertyManagerUser = new PropertyManagerUser
            {
                UserName = model.Username,
                Email = model.EmailAddress
            };

            var result = await _userManager.CreateAsync(propertyManagerUser, model.Password);

            return result;

        }

        //Authentication a user (look if the user exitst in the database)
        public async Task<PropertyManagerUser> FindUser(string username, string password)
        {
            return await _userManager.FindAsync(username, password);
        }

        //Dispose the Object
        public void Dispose()
        {
            _userManager.Dispose();  
        }
    }
}