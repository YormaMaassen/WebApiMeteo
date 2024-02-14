using WebApiMeteo.Model;

namespace WebApiMeteo.Process.Interfaces
{
    public interface IGetMeteoProcess
    {
        Meteo GetMeteo(int villeId, DateTime date);
    }
}
