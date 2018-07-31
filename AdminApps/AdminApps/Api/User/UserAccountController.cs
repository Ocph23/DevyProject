using AdminApps.Models;
using AdminLib.Domains;
using Microsoft.AspNet.Identity.Owin;
using SharedApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace AdminApps.Api.User
{
    public class UserAccountController : ApiController
    {


        private UserAccountDomain domain = new UserAccountDomain();
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _appRoleManager;

        // GET: api/UserAccount
        [HttpPost]
        [Route("api/User/Register")]
        public async Task<IHttpActionResult>Register(RegisterModel model)
        {
            try
            {
                var register = await RegisterPelanggan(model.Email, model.Password);
                PelangganModel pel = (PelangganModel)model;
                pel.IdUser = register.Item1.Id;

                PelangganDomain dom = new PelangganDomain();
                var result =await dom.SaveChange(pel);
                return Ok(register);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }




        private async Task<Tuple<ApplicationUser,string>> RegisterPelanggan(string email,string password)
        {
            try
            {
                ApplicationUser user = new Models.ApplicationUser { UserName = email, Email = email, LockoutEnabled = false, EmailConfirmed = false };
                var created = await UserManager.CreateAsync(user, password);
                if (created.Succeeded)
                {
                    string roleName = "Pelanggan";
                    if (!await AppRoleManager.RoleExistsAsync(roleName))
                    {
                        var r = new MySql.AspNet.Identity.IdentityRole("125", roleName);
                        var roleCreated = await AppRoleManager.CreateAsync(r);
                        if (!roleCreated.Succeeded)
                            throw new SystemException("Role Tidak Berhasil Disimpan");


                    }

                    var role = await AppRoleManager.FindByNameAsync(roleName);
                    if (role != null)
                    {
                        var added = await UserManager.AddToRoleAsync(user.Id, roleName);
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
                string c = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                string strcode = HttpUtility.UrlEncode(c);
                var callbackUrl = Url.Link("DefaultApi", new { controller = "User/ConfirmPassword", userId = user.Id, code = strcode });
                await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");
                return Tuple.Create(user, strcode);
            }
            catch (Exception ex)
            {

                throw new SystemException(ex.Message);
            }
        }



        [HttpGet]
        [Route("api/User/ConfirmPassword")]
        public async Task<IHttpActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return BadRequest("Error");
            }

            var c = HttpUtility.UrlDecode(code);
            var result = await UserManager.ConfirmEmailAsync(userId, c);
            return Ok(result.Succeeded ? "ConfirmEmail" : "Error");
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
