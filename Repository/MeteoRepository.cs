using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApiMeteo.Db;
using WebApiMeteo.Model;
using WebApiMeteo.Repository.Interfaces;

namespace WebApiMeteo.Repository
{
    public class MeteoRepository : IMeteoRepository
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public MeteoRepository(Context context, IMapper _mapper)
        {
            _context = context;
            _mapper = _mapper;
        }

        public async Task<Meteo> GetAsync(int id)
        {
            return _mapper.Map<Model.Meteo>(await _context.Meteos.Include(m => m.Ville).FirstOrDefaultAsync(m => m.MeteoId == id));
        }

        public async Task<IEnumerable<Meteo>> GetAllAsync()
        {
            return _mapper.Map<IList<Model.Meteo>>(await _context.Meteos.Include(m => m.Ville).ToListAsync());
        }

        public async Task CreateAsync(Meteo meteo)
        {
            _context.Meteos.Add(_mapper.Map<Entities.Meteo>(meteo));
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Meteo meteo)
        {
            _context.Meteos.Update(_mapper.Map<Entities.Meteo>(meteo));
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var meteo = await _context.Meteos.FindAsync(id);
            if (meteo != null)
            {
                _context.Meteos.Remove(meteo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
