using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fiapweb.core.Models
{
    public class Pais
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Bandeira { get; set; }
        public bool Publicado { get; set; }
    }
}
