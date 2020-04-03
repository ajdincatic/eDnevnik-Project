using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SeminarskiRS1.Model
{
    public class Login
    {
        public int LoginID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
