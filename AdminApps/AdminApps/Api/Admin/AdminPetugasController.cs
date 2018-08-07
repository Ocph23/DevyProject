using AdminLib.Domains;
using AdminLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SharedApp;
using SharedApp.Models;
using System.Web;
using Newtonsoft.Json;
using Microsoft.AspNet.Identity.Owin;
using AdminApps.Models;


namespace AdminApps.Api.Admin
{
    [Authorize(Roles = "Admin, Petugas")]
    public class AdminPetugasController : ApiController
    {

        private PetugasDomain petugasDomain = new PetugasDomain();
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _appRoleManager;

        // GET: api/AdminPetugas
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var result = await petugasDomain.Get();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/AdminPetugas/5
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                var res = await petugasDomain.GetById(id);
                return Ok(res);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST: api/AdminPetugas
        public async Task<IHttpActionResult> Post([FromBody]PetugasModel value)
        {
            try
            {
                var registerPetugas = await RegisterPetugas(value.Email);
                value.UserId = registerPetugas.Id;
                var result = await  petugasDomain.SaveChange(value);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/AdminPetugas/5
        public async Task<IHttpActionResult> Put(int id, [FromBody]PetugasModel value)
        {
            try
            {
                var result = await petugasDomain.SaveChange(value);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/AdminPetugas/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                var result = await petugasDomain.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        private async Task<ApplicationUser> RegisterPetugas(string email)
        {
            try
            {
                var user = new Models.ApplicationUser { UserName = email, Email = email,   LockoutEnabled = true, EmailConfirmed = true };
                var created = await UserManager.CreateAsync(user, "Petugas#123");
                if(created.Succeeded)
                {
                    string roleName = "Petugas";
                    if (!await AppRoleManager.RoleExistsAsync(roleName))
                    {
                        var r = new MySql.AspNet.Identity.IdentityRole("123", roleName);
                       var roleCreated= await AppRoleManager.CreateAsync(r);
                        if (!roleCreated.Succeeded)
                            throw new SystemException("Role Tidak Berhasil Disimpan");


                    }

                    var role = await AppRoleManager.FindByNameAsync(roleName);
                    if(role!=null)
                    {
                      var added=  await UserManager.AddToRoleAsync(user.Id, roleName);
                        if (!added.Succeeded)
                            throw new SystemException(string.Format("User Tidak Berhasil Di tambahkan Ke Role {0}", roleName));
                    }
                    else
                    {
                        throw new SystemException(string.Format("Role {0} Tidak Ditemukan", roleName));

                    }
                }
                else
                {
                    throw new SystemException("User TIdak Berhasil Dibuat");
                }

                return user;
            }
            catch (Exception ex)
            {

                throw new SystemException(ex.Message);
            }
        }

        public ApplicationUserManager UserManager

        {

            get

            {

                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

            }

            private set

            {

                _userManager = value;

            }

        }

        public ApplicationRoleManager AppRoleManager

        {

            get

            {

                return _appRoleManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationRoleManager>();

            }

            private set

            {

                _appRoleManager = value;

            }

        }



    }
}
