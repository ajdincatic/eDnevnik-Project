using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eDnevnik.data.ViewModels
{
    public class LoginVM
    {
        public string username { get; set; }
        public string password { get; set; }
        public bool ZapamtiPassword { get; set; }
    }
}
