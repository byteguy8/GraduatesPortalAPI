public class Graduate
{
    public int id { get; set; }

    public int ParticipanteId {get; set;}
    public String? Identificacion { get; set; }
    public string? PrimerNombre { get; set; }
    public string? SegundoNombre { get; set; }
    public string? PrimerApellido { get; set; }
    public string? SegundoApellido { get; set; }
    public char Genero { get; set; }
    public string? FechaNac { get; set; }
    public string? FotoPerfilUrl { get; set; }
    public string? About { get; set; }
    public Boolean? Destacado { get; set; }
    public string? MatriculaGrado { get; set; }
    public string? MatriculaEgresado { get; set; }
    public Nationality? Nacionalidad { get; set; }
    public User? user { get; set; }
    public List<string>? telephones { get; set; }
    public List<string>? emails { get; set; }
    public List<string>? addresses { get; set; }
}