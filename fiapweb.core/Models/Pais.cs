using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace fiapweb.core.Models
{
    public class Pais
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Bandeira { get; set; }
        public bool Publicado { get; set; }
    }
}
