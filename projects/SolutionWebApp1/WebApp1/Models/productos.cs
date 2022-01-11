using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp1.Models
{
    public class productos
    {
        public string NombreProducto { get; set; }
        public float Precio { get; set; }
        public string imagen { get; set; }

        public float descuento { get; set; }

        public int valoracion { get; set; }

    }
}
