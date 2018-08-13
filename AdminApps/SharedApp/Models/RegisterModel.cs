using System;
using System.Collections.Generic;
using System.Text;

namespace SharedApp.Models
{
   public class RegisterModel:PelangganModel
    {
       
      
        public string Password { get; set; }

      
        public string ConfirmPassword { get; set; }
    }
}
