public class Graduate
{
    public ulong id { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string birthday { get; set; }
    public char gender { get; set; }
    public string identification { get; set; }
    public Nationality nationality { get; set; }
    public User user { get; set; }
    public List<string> telephones { get; set; }
    public List<string> emails { get; set; }
    public List<string> addresses { get; set; }
}