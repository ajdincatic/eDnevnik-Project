using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using SeminarskiRS1.Model;

namespace eDnevnik.data.Models
{
    public class AutorizacijskiToken
    {
        public int Id { get; set; }
        public string Vrijednost { get; set; }
        [ForeignKey(nameof(Login))]
        public int LoginId { get; set; }
        public Login User { get; set; }
        public DateTime VrijemeEvidentiranja { get; set; }
    }
}
