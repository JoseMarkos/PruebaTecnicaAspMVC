using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaJoseCulajay.Models
{
    public class Candidato
    {
        [Key]
        public int CUI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int EscolaridadId { get; set; }
        public Escolaridad Escolaridad { get; set; }
        public int PlazaId { get; set; }

        public Plaza Plaza { get; set; }

    }
}
