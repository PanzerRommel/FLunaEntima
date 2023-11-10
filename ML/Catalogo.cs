using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Catalogo
    {
        public int IdProducto { get; set; }
        public string? Descripcion { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaCreacion { get; set; }

        public List<object>? Catalogos { get; set; }
    }
}
