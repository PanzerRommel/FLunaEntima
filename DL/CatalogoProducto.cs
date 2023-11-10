using System;
using System.Collections.Generic;

namespace DL;

public partial class CatalogoProducto
{
    public int IdProducto { get; set; }

    public string? Descripcion { get; set; }

    public int? IdUsuario { get; set; }

    public DateTime? FechaCreacion { get; set; }
}
