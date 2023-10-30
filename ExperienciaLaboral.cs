using System;
using System.Collections.Generic;

namespace GraduatesPortalAPI;

public partial class ExperienciaLaboral
{
    public int ExperienciaLaboralId { get; set; }

    public int EgresadoId { get; set; }

    public string Posicion { get; set; } = null!;

    public int? Salario { get; set; }

    public DateTime FechaEntrada { get; set; }

    public DateTime? FechaSalida { get; set; }

    public bool? Mostrar { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual Egresado Egresado { get; set; } = null!;
}
