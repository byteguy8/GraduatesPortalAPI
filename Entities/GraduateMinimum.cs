public class GraduateMinimum
{
    public int id { get; set; }
    public int ParticipanteId { get; set; }
    public String? Identificacion { get; set; }
    public string? PrimerNombre { get; set; }
    public string? SegundoNombre { get; set; }
    public string? PrimerApellido { get; set; }
    public string? SegundoApellido { get; set; }
    public char Genero { get; set; }
    public string? FechaNac { get; set; }
    public string? MatriculaGrado { get; set; }
    public string? MatriculaEgresado { get; set; }
    public Nationality? Nacionalidad { get; set; }
}