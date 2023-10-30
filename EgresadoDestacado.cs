using System;
using System.Collections.Generic;

namespace GraduatesPortalAPI;

public partial class EgresadoDestacado
{
    public int EgresadoDestacadoId { get; set; }

    public int EgresadoId { get; set; }

    public DateTime FechaDesde { get; set; }

    public DateTime FechaHasta { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual Egresado Egresado { get; set; } = null!;
}
