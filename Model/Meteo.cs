using WebApiMeteo.Entities;
using WebApiMeteo.Enum;

namespace WebApiMeteo.Model
{
    public class Meteo
    {
        public int MeteoId { get; set; }
        public DateTime Date { get; set; }
        public TempsEnum Temps { get; set; }
        public double Temperature { get; set; }
        public double TemperatureMin { get; set; }
        public double TemperatureMax { get; set; }
        public double VitesseDuVent { get; set; }
        public int VilleId { get; set; }
        public Ville Ville { get; set; }
    }
}
