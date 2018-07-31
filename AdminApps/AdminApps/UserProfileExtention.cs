using AdminLib.Domains;
using Microsoft.AspNet.Identity;
using SharedApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;

namespace AdminApps
{
    public static class UserProfileExtention
    {
        public static async Task<PetugasModel> GetPetugas(this IPrincipal user)
        {
            var userid = user.Identity.GetUserId();
            if (!string.IsNullOrEmpty(userid))
            {
                PetugasDomain domain = new PetugasDomain();
                var result = await domain.GetPetugasByUserId(userid);
                return result;
            }

            return null;
        }

        public static async Task<PelangganModel> PelangganProfile(this IPrincipal user)
        {
            var userid = user.Identity.GetUserId();
            if (!string.IsNullOrEmpty(userid))
            {
                PelangganDomain domain = new PelangganDomain();
                var result = await domain.GetPelangganByUserId(userid);
                return result;
            }

            return null;
        }


    }
}