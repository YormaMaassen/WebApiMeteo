namespace WebApiMeteo.Entities
{
    public class Ville
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public ICollection<Meteo> Meteos { get; set; } = new List<Meteo>();
    }
}
