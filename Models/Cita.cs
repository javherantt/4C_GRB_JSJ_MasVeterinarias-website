using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasVeterinarias.Models
{
    public class Cita
    {
        public int Id { get; set; }
        public int VeterinariaId { get; set; }
        public int ClienteId { get; set; }
        public string NombreMascota { get; set; }
        public string Hora { get; set; }
        public DateTime? Fecha { get; set; }
        public int ServicioId { get; set; }
        public string Estatus { get; set; }
    }
}
