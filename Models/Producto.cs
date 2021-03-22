using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasVeterinarias.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public int VeterinariaId { get; set; }
        public string Imagen { get; set; }
        public string Marca { get; set; }
        public string Etapa { get; set; }
        public int? Stock { get; set; }
        public double? Precio { get; set; }
        public string Especie { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Detalles { get; set; }
        public string Raza { get; set; }
        public IFormFile ImageProducts { get; set; }
    }
}
