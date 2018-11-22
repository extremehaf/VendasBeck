using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VendasBeck.Models
{
    [Table("eventos")]
    public class EventosClass
    {
        [Key]
        public int idEvento { get; set; }
        public string nome { get; set; }
        public System.DateTime? data { get; set; }
    }
}