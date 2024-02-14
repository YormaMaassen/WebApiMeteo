using AutoMapper;
using WebApiMeteo.Db;
using WebApiMeteo.Model;
using WebApiMeteo.Process.Interfaces;

namespace WebApiMeteo.Process
{
    public class GetMeteoProcess : IGetMeteoProcess
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public GetMeteoProcess(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Meteo GetMeteo(int villeId, DateTime date)
        {
            return _mapper.Map<Model.Meteo>(_context.Meteos.FirstOrDefault(m => m.Date == date && m.VilleId == villeId));
        }
    }
}
